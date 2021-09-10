namespace Tlw.ZPG.Domain.Models.Trading
{
    using System;
    using System.Collections.Generic;
    using FluentValidation.Results;
    using Tlw.ZPG.Domain.Enums;
    using Tlw.ZPG.Domain.Models.Admin;
    using Tlw.ZPG.Domain.Validators;
    using Tlw.ZPG.Infrastructure;
    using Tlw.ZPG.Infrastructure.Utils;

    public partial class Affiche : EntityBase
    {
        public Affiche()
        {
            this.Trades = new HashSet<Trade>();
            this.Nodes = new HashSet<Affiche>();
        }

        #region ����
        /// <summary>
        /// ԭ����ID
        /// </summary>
        public int? ParentId { get; set; }
        /// <summary>
        /// ����
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// ����
        /// </summary>
        public string Content { get; set; }
        /// <summary>
        /// ��������
        /// </summary>
        public string OtherContent { get; set; }
        /// <summary>
        /// ����Ҫ��
        /// </summary>
        public string QualificationRequire { get; set; }
        /// <summary>
        /// ������֪
        /// </summary>
        public string Notice { get; set; }
        /// <summary>
        /// ���Ʒ�ʽ�����۰취
        /// </summary>
        public string HandModeAndBidMethod { get; set; }
        /// <summary>
        /// �����û�ID
        /// </summary>
        public int CreatorId { get; set; }
        /// <summary>
        /// ����ʱ��
        /// </summary>
        public System.DateTime CreateTime { get; set; }
        /// <summary>
        /// �޸�ʱ��
        /// </summary>
        public System.DateTime? UpdateTime { get; set; }
        /// <summary>
        /// ������ʼʱ��
        /// </summary>
        public System.DateTime SignBeginTime { get; set; }
        /// <summary>
        /// ������ֹʱ��
        /// </summary>
        public System.DateTime SignEndTime { get; set; }
        /// <summary>
        /// ������ʼʱ��
        /// </summary>
        public System.DateTime TradeBeginTime { get; set; }
        /// <summary>
        /// ���׽�ֹʱ��
        /// </summary>
        public System.DateTime TradeEndTime { get; set; }
        /// <summary>
        /// ���ʱ��
        /// </summary>
        public System.DateTime? VerifyTime { get; set; }
        /// <summary>
        /// �Ƿ񷢲�
        /// </summary>
        public bool IsRelease { get; set; }
        /// <summary>
        /// ����ʱ��
        /// </summary>
        public System.DateTime ReleaseTime { get; set; }
        /// <summary>
        /// ������id
        /// </summary>
        public int CountyId { get; set; }
        /// <summary>
        /// ��������
        /// </summary>
        public string AfficheType { get; set; }
        /// <summary>
        /// ���÷�ʽ
        /// </summary>
        public string SellModel { get; set; }
        /// <summary>
        /// ������
        /// </summary>
        public string AfficheNumber { get; set; }
        /// <summary>
        /// ��׼�ĺ�
        /// </summary>
        public string RatificationNumber { get; set; }
        /// <summary>
        /// ��׼����
        /// </summary>
        public string RatificationOrg { get; set; }
        /// <summary>
        /// ���״̬
        /// </summary>
        public AfficheVerifyStatus VerifyStatus { get; set; }
        /// <summary>
        /// ����û�id
        /// </summary>
        public int? VerifyUserId { get; set; }
        /// <summary>
        /// ��ǩ�����,�ָ�
        /// </summary>
        public string Tags { get; set; }
        /// <summary>
        /// ��Դ
        /// </summary>
        public string ComeForm { get; set; }

        public virtual County County { get; set; }
        public virtual User Creator { get; set; }
        public virtual User VerifyUser { get; set; }
        public virtual Affiche Parent { get; internal set; }
        public virtual ICollection<Affiche> Nodes { get; internal set; }
        public virtual ICollection<Trade> Trades { get; internal set; }
        #endregion

        public override IEnumerable<BusinessRule> Validate()
        {
            AfficheValidator validator = new AfficheValidator();
            ValidationResult results = validator.Validate(this);
            foreach (var item in results.Errors)
            {
                yield return new BusinessRule(item.PropertyName, item.ErrorMessage);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="formater"></param>
        public void FormatContent(string formater)
        {
            if (formater == null) throw new DomainException("templete����Ϊnull");
            formater = formater.Replace("{Affiche_Org}", this.ComeForm);
            formater = formater.Replace("{Affiche_Number}", this.AfficheNumber);
            formater = formater.Replace("{RatificationOrg}", this.RatificationOrg);
            formater = formater.Replace("{Affiche_Number}", this.AfficheNumber);
            formater = formater.Replace("{Affiche_QualificationRequire}", this.QualificationRequire);
            formater = formater.Replace("{Affiche_HandModeAndBidMethod}", this.HandModeAndBidMethod);
            formater = formater.Replace("{Affiche_Sign_Time}", this.SignBeginTime.ToString("yyyy��MM��dd��HH����") + this.SignEndTime.ToString("yyyy��MM��dd��HH��"));
            formater = formater.Replace("{Affiche_Trade_Time}", this.TradeBeginTime.ToString("yyyy��MM��dd��HH����") + this.TradeEndTime.ToString("yyyy��MM��dd��HH��"));
            formater = formater.Replace("{Other_Content}", this.OtherContent);
            formater = formater.Replace("{Land_Count}", this.Trades.Count.ToString());
            formater = formater.Replace("{Afiche_Release_Time}", StringUtil.DateToUpper(this.ReleaseTime));
            this.Content = formater;
        }

        /// <summary>
        /// ���乫��
        /// </summary>
        /// <param name="affiche">�¹���</param>
        public void Supply(int userId, Affiche affiche)
        {
            if (affiche == null)
            {
                throw new ReplenishException("���乫�治��Ϊ��");
            }
            if (userId != this.CreatorId)
            {
                throw new ReplenishException("�㲻�ǹ��洴���ߣ����ܲ��乫��");
            }
            if (!this.IsRelease)
            {
                throw new ReplenishException("ԭ����û�з���֮ǰ���ܲ��乫��");
            }
            //���ܶ��Ѿ�����Ĺ����ٴν��в��䣬ϵͳ�Զ���ԭ������в���
            if (this.ParentId.HasValue)
            {
                affiche.Parent = this.Parent;
            }
            else
            {
                affiche.Parent = this;
            }
        }

        /// <summary>
        /// ��������
        /// </summary>
        /// <param name="userId"></param>
        public void Release(int userId)
        {
            ReleaseCheck(userId);
            //���淢����ͬ������ʱ��ͽ���ʱ��
            foreach (var item in this.Trades)
            {
                SetTrade(item);
            }
            this.IsRelease = true;
        }

        private void SetTrade(Trade trade)
        {
            trade.SignBeginTime = this.SignBeginTime;
            trade.SignEndTime = this.SignEndTime;
            trade.TradeBeginTime = this.TradeBeginTime;
            trade.TradeEndTime = this.TradeEndTime;
            trade.Land.SetLandPurpose();
        }

        /// <summary>
        /// ����ڵ�
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="trade"></param>
        public void AddTrade(int userId, Trade trade)
        {
            if (userId != this.CreatorId) throw new DomainException("�㲻�ǹ��洴���ߣ��޷�����ڵ�");
            trade.Affiche = this;
            trade.CreatorId = this.CreatorId;
            SetTrade(trade);
            SetTags(trade.Land);
            this.Trades.Add(trade);
        }

        /// <summary>
        /// ����tags���Ա���ǰ̨��ѯ����ҳ��ǩ��ѯ��
        /// </summary>
        /// <param name="land"></param>
        private void SetTags(Land land)
        {
            foreach (var item in land.LandPurposes)
            {
                var purpose = item.Purpose;
                DoSetTags(purpose.PurposeName);
                while (purpose.ParentId.HasValue)
                {
                    purpose = purpose.Parent;
                    DoSetTags(purpose.PurposeName);
                }
            }
            this.Tags = this.Tags.Trim(',');
        }

        private void DoSetTags(string purposeName)
        {
            if (purposeName.Contains("��ҵ�õ�"))
            {
                this.Tags += "��ҵ�õ�,";
            }
            else if (purposeName.Contains("סլ�õ�") || purposeName.Contains("�̷��õ�"))
            {
                this.Tags += "��ס�õ�,";
            }
            else
            {
                this.Tags += "�����õ�,";
            }
        }

        private void ReleaseCheck(int userId)
        {
            if (this.IsRelease)
            {
                throw new AfficheReleaseException("�����Ѿ������������ٴη���");
            }
            if (userId != this.CreatorId)
            {
                throw new AfficheReleaseException("�㲻�Ǵ˹��洴���ߣ����ܷ�������");
            }
            if (this.ParentId.HasValue)
            {
                //���乫��
                if (this.Trades.Count != this.Parent.Trades.Count)
                {
                    throw new AfficheReleaseException("���乫�治��ɾ�����������ڵ���Ϣ");
                }
                if (this.Parent.TradeBeginTime < DateTime.Now)
                {
                    throw new AfficheReleaseException("ԭ���潻��ʱ���ѵ������ܷ������乫��");
                }
                if (this.ReleaseTime <= this.Parent.ReleaseTime)
                {
                    throw new AfficheReleaseException("���乫�淢��ʱ�䲻������ԭ���淢��ʱ��");
                }
            }
            else
            {
                if (string.IsNullOrEmpty(this.Notice))
                {
                    throw new AfficheReleaseException("������֪����Ϊ��");
                }
                if (this.Trades.Count == 0)
                {
                    throw new AfficheReleaseException("�ڵ���Ϣδ����");
                }
            }
        }
    }
}
