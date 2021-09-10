namespace Tlw.ZPG.Domain.Models.Bid
{
    using System;
    using System.Collections.Generic;
    using Tlw.ZPG.Domain.Enums;
    using Tlw.ZPG.Domain.Models.Bid.Events;
    using Tlw.ZPG.Domain.Models.Admin;
    using Tlw.ZPG.Domain.Models.Trading;
    using Tlw.ZPG.Infrastructure;
    using Tlw.ZPG.Infrastructure.Utils;
    using Tlw.ZPG.Infrastructure.Domain.Events;
    using FluentValidation.Results;
    using Tlw.ZPG.Domain.Validators;

    public partial class Account : EntityBase
    {
        public Account()
        {
            this.AccountVerifies = new HashSet<AccountVerify>();
            this.UnionBidPersons = new HashSet<Person>();
        }

        #region ����
        public string ApplyNumber { get; internal set; }
        public string Password { get; internal set; }
        public bool PasswordUpdated { get; internal set; }
        public System.DateTime CreateTime { get; internal set; }
        public AccountStatus Status { get; internal set; }
        public string RandomNumber { get; internal set; }
        public int TradeId { get; set; }
        public ApplyType ApplyType { get; set; }
        public int ContactId { get; set; }
        public int? AgentId { get; set; }
        public int? CorporationId { get; set; }
        public int AccountPersonId { get; set; }
        public bool IsOnline { get; set; }
        public Nullable<System.DateTime> OnlineTime { get; set; }
        public AccountVerifyStatus VerifyStatus { get; set; }
        public virtual Trade Trade { get; internal set; }
        public virtual Person Agent { get; set; }
        public virtual Person AccountPerson { get; set; }
        public virtual Person Contact { get; set; }
        public virtual Person Corporation { get; set; }
        public virtual ICollection<AccountVerify> AccountVerifies { get; set; }
        public virtual ICollection<Person> UnionBidPersons { get; set; }
        public virtual ICollection<TradeDetail> TradeDetails { get; set; }
        public virtual ICollection<AccountAttach> Attachments { get; set; }
        #endregion

        #region ����

        /// <summary>
        /// ����12λ�����
        /// </summary>
        /// <returns></returns>
        private string GenerateRandomNumber()
        {
            return new Random().NextDouble().ToString().Substring(3, 6) + new Random().NextDouble().ToString().Substring(3, 6);
        }

        /// <summary>
        /// ���룬ע��
        /// </summary>
        public void Apply(Trade trade)
        {
            this.Trade = trade;
            this.RandomNumber = GenerateRandomNumber();
            this.CreateTime = DateTime.Now;
            this.Status = AccountStatus.Normal;
            this.VerifyStatus = AccountVerifyStatus.UnSubmit;
        }

        /// <summary>
        /// ��ȡ����������
        /// </summary>
        /// <returns></returns>
        public string GetAccountName()
        {
            string name = string.Empty;
            if (this.ApplyType == ApplyType.Union)
            {
                foreach (var item in this.UnionBidPersons)
                {
                    name += item.PersonName + item.Unit;
                }
            }
            else
            {
                name = this.AccountPerson.PersonName + this.AccountPerson.Unit;
            }
            return name;
        }

        /// <summary>
        /// �Ƿ����ύ���
        /// </summary>
        public bool CanSubmitVerify()
        {
            return this.VerifyStatus == AccountVerifyStatus.UnSubmit || this.VerifyStatus == AccountVerifyStatus.NotifySupply;
        }

        /// <summary>
        /// �ύ���
        /// </summary>
        public void SubmitVerify()
        {
            DoSubmitVerify(null);
        }

        /// <summary>
        /// �ύ�������
        /// </summary>
        public void SubmitVerifyContent(string content)
        {
            if (string.IsNullOrEmpty(content)) throw new SubmitApplyException("���ݲ���Ϊ��");
            DoSubmitVerify(content);
        }

        private void DoSubmitVerify(string content)
        {
            if (CanSubmitVerify())
            {
                if (content == null)
                {
                    this.VerifyStatus = AccountVerifyStatus.Submited;
                }
                var verify = new AccountVerify()
                {
                    AccountId = this.ID,
                    CreateTime = DateTime.Now,
                    Content = content,
                    Status = this.VerifyStatus,
                };
                this.AccountVerifies.Add(verify);
                DomainEvents.Publish(new SubmitVerifyEvent() { Account = this, AccountVerify = verify });
            }
            else
            {
                throw new SubmitApplyException("��ǰ�������ύ���");
            }
        }

        /// <summary>
        /// ��̨����Ա�Ƿ�������
        /// </summary>
        public bool CanVerifyByUser()
        {
            return this.VerifyStatus == AccountVerifyStatus.Submited || this.VerifyStatus == AccountVerifyStatus.SuppliedAndSubmited;
        }

        /// <summary>
        /// ��̨����Ա���
        /// </summary>
        /// <param name="content"></param>
        /// <param name="user"></param>
        public void VerifyByUser(int userId, string content, VerifyType verifyType)
        {
            if (CanVerifyByUser())
            {
                this.VerifyStatus = (AccountVerifyStatus)Enum.Parse(typeof(AccountVerifyStatus), verifyType.ToString());
                this.AccountVerifies.Add(new AccountVerify()
                {
                    AccountId = this.ID,
                    Content = content,
                    CreateTime = DateTime.Now,
                    Status = this.VerifyStatus,
                    UserId = userId,
                });
                DomainEvents.Publish(new VerifyByUserEvent() { Account = this });
            }
            else
            {
                throw new VerifyApplyException("��ǰ���������");
            }
        }

        private string GeneratePassword()
        {
            return new Random().NextDouble().ToString().Substring(3, 8);
        }

        /// <summary>
        /// ���ž����
        /// </summary>
        public void GrantApplyNumber(int userId, string applyNumber)
        {
            if (userId != this.Trade.Affiche.CreatorId) throw new GrantApplyNumberException("������ֻ�ܷ����Լ��ڵصľ����");
            if (this.VerifyStatus != AccountVerifyStatus.Verified) throw new GrantApplyNumberException("δ���ͨ���������ž����");
            if (this.Status == AccountStatus.Froze) throw new GrantApplyNumberException("������Ѷ��᲻�����ž����");
            CheckGrantTime();
            this.ApplyNumber = applyNumber;
            this.Password = GeneratePassword();
            this.Status = AccountStatus.Normal;
            DomainEvents.Publish(new GrantApplyNumberEvent() { Account = this });
        }

        private void CheckGrantTime()
        {
            var days = AppSettings.GetValue("MinReleaseNum2TEDay", 2);
            if (DateTime.Now > this.Trade.TradeEndTime.AddDays(-days))
            {
                throw new GrantApplyNumberException(string.Format("�����ֻ���ڽ��׽�ֹʱ��ǰ{0}�췢��", days));
            }
        }

        /// <summary>
        /// ���Ὰ���
        /// </summary>
        public void Froze(int userId)
        {
            if (this.Status == AccountStatus.Loss) throw new AccountFrozeException("������ѹ�ʧ����������");
            if (this.Status == AccountStatus.Normal)
            {
                if (this.Trade.CreatorId != userId) throw new AccountFrozeException("������ֻ�ܶ����Լ��ڵصľ����");
                this.Status = AccountStatus.Froze;
                DomainEvents.Publish(new FrozeAccountEvent() { Account = this });
            }
        }

        /// <summary>
        /// �ⶳ���ָ���
        /// </summary>
        public void Recover(int userId)
        {
            if (this.Status == AccountStatus.Loss) throw new AccountFrozeException("������ѹ�ʧ��������ⶳ");
            if (this.Status == AccountStatus.Froze)
            {
                if (this.Trade.CreatorId != userId) throw new AccountFrozeException("������ֻ�ܽⶳ�Լ��ڵصľ����");
                this.Status = AccountStatus.Normal;
                DomainEvents.Publish(new RecoverAccountEvent() { Account = this });
            }
        }

        public bool CheckPassword(string password)
        {
            return this.Password == SecurityUtil.MD5Encrypt(password);
        }

        public void ResetPassword(int userId)
        {
            if (this.Status == AccountStatus.Froze || this.Status == AccountStatus.Loss) 
                throw new AccountFrozeException("������Ѷ�����ʧ����������������");
            if (this.Trade.CreatorId != userId) throw new AccountFrozeException("������ֻ�������Լ��ڵصľ���ŵ�����");
            this.Password = GeneratePassword();
            this.PasswordUpdated = false;
            DomainEvents.Publish(new ResetPasswordEvent() { Account = this });
        }

        /// <summary>
        /// ��ʧ
        /// </summary>
        /// <param name="userId"></param>
        public void Loss(int userId)
        {
            if (this.Status == AccountStatus.Loss)
            {
                throw new DomainException("�þ�����Ѿ���ʧ��һ�Σ������ٴι�ʧ");
            }
            else
            {
                if (this.Trade.CreatorId != userId) throw new AccountFrozeException("������ֻ�ܹ�ʧ�Լ��ڵصľ����");
                var days = AppSettings.GetValue("MinLoseNum2TEDay", 2);
                if (DateTime.Now > this.Trade.TradeEndTime.AddDays(-days))
                    throw new GrantApplyNumberException(string.Format("��������ƽ��׽�ֹ���޲���{0}�գ����ܹ�ʧ", days));
                this.Status = AccountStatus.Loss;
                DomainEvents.Publish(new LossAccountEvent() { Account = this });
            }
        }

        #endregion

        #region Validate
        public override IEnumerable<BusinessRule> Validate()
        {
            AccountValidator validator = new AccountValidator();
            ValidationResult results = validator.Validate(this);
            foreach (var item in results.Errors)
            {
                yield return new BusinessRule(item.PropertyName, item.ErrorMessage);
            }
        }

        #endregion
    }
}
