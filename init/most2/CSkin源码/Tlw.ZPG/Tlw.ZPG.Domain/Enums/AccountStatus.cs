namespace Tlw.ZPG.Domain.Enums
{
    using System;
    using System.ComponentModel;

    /// <summary>
    /// �˻�״̬
    /// </summary>
    public enum AccountStatus
    {
        /// <summary>
        /// ����
        /// </summary>
        [Description("����")]
        Normal,
        /// <summary>
        /// ��ʧ
        /// </summary>
        [Description("��ʧ")]
        Loss,
        /// <summary>
        /// ����
        /// </summary>
        [Description("����")]
        Froze
    }
}
