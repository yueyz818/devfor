namespace Tlw.ZPG.Domain.Models.Trading
{
    using System;
    using System.Collections.Generic;
    using Tlw.ZPG.Domain.Models.Admin;
    using Tlw.ZPG.Infrastructure;

    public partial class Land : EntityBase
    {
        public Land()
        {
            this.LandAttaches = new HashSet<LandAttach>();
            this.LandPurposes = new HashSet<LandPurpose>();
        }

        #region ����
        /// <summary>
        /// ��Ŀ����
        /// </summary>
        public string ProjectName { get; set; }
        /// <summary>
        /// �ڵر��
        /// </summary>
        public string LandNumber { get; set; }
        /// <summary>
        /// λ��
        /// </summary>
        public string Location { get; set; }
        /// <summary>
        /// ���
        /// </summary>
        public decimal Area { get; set; }
        /// <summary>
        /// ������;��������
        /// </summary>
        public string LandPurpose { get; private set; }
        /// <summary>
        /// ������״
        /// </summary>
        public int LandState { get; set; }
        /// <summary>
        /// �����˵绰
        /// </summary>
        public string Phones { get; set; }
        /// <summary>
        /// ������֪
        /// </summary>
        public string Notice { get; set; }
        /// <summary>
        /// ��ע
        /// </summary>
        public string Remark { get; set; }
        /// <summary>
        /// ��������
        /// </summary>
        public string OtherCondition { get; set; }
        /// <summary>
        /// �ݻ���
        /// </summary>
        public decimal Capability { get; set; }
        /// <summary>
        /// �ܶ�
        /// </summary>
        public decimal Density { get; set; }
        /// <summary>
        /// �̵���
        /// </summary>
        public decimal GreenLandRate { get; set; }
        /// <summary>
        /// ��Լ��֤��
        /// </summary>
        public decimal FulfilGuarantee { get; set; }
        /// <summary>
        /// ��������֤��
        /// </summary>
        public decimal CompletionGuarantee { get; set; }
        /// <summary>
        /// �ڵط�Χ
        /// </summary>
        public string LandScope { get; set; }

        public virtual ICollection<LandAttach> LandAttaches { get; internal set; }
        public virtual ICollection<LandPurpose> LandPurposes { get; internal set; }
        #endregion

        /// <summary>
        /// ��LandPurposes����ת��Ϊ�ַ�������
        /// </summary>
        public void SetLandPurpose()
        {
            LandPurpose=string.Empty;
            foreach (var item in LandPurposes)
            {
                LandPurpose += string.Format("{0}�������{1}ƽ���ס��������ޣ�{2}��;",item.Purpose.PurposeName,item.Area,item.Years);
            }
        }
    }
}
