namespace Tlw.ZPG.Domain.Models.Admin
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.ComponentModel.DataAnnotations.Schema;
    using Tlw.ZPG.Infrastructure;
    using Tlw.ZPG.Infrastructure.Utils;

    public partial class User : EntityBase
    {
        public User()
        {
            this.Roles = new HashSet<Role>();
        }

        #region ����
        public int CountyId { get; set; }
        public string UserName { get; set; }
        public string Unit { get; set; }
        public string LoginAccount { get; set; }
        public string LoginPassword { get; set; }
        public string LinkPhone { get; set; }
        public string Email { get; set; }
        public int Status { get; set; }
        public virtual ICollection<Role> Roles { get; set; }
        public virtual County County { get; set; }
        #endregion

        public bool ValidatePassword(string password)
        {
            return this.LoginPassword == SecurityUtil.MD5Encrypt(password);
        }

        public void EncryptPassword()
        {
            this.LoginPassword = SecurityUtil.MD5Encrypt(this.LoginPassword);
        }

        public void ChangePassword(string password, string newPassword)
        {
            if (ValidatePassword(password))
            {
                this.LoginPassword = SecurityUtil.MD5Encrypt(newPassword);
            }
            else
            {
                throw new ChangePasswordException("ԭ���벻��ȷ");
            }
        }

        public IList<Menu> GetUserMenus()
        {
            List<Menu> list = new List<Menu>();
            foreach (var item in this.Roles)
            {
                list.AddRange(item.Menus);
            }
            return list;
        }

        public IList<Function> GetUserFunctions()
        {
            List<Function> list = new List<Function>();
            foreach (var item in this.Roles)
            {
                list.AddRange(item.Functions);
            }
            return list;
        }

        public override IEnumerable<BusinessRule> Validate()
        {
            if (string.IsNullOrEmpty(this.LoginAccount))
            {
                yield return new BusinessRule("LoginAccount", "��¼�˺Ų���Ϊ��");
            }
            if (string.IsNullOrEmpty(this.LoginPassword))
            {
                yield return new BusinessRule("LoginPassword", "��¼���벻��Ϊ��");
            }
        }
    }
}
