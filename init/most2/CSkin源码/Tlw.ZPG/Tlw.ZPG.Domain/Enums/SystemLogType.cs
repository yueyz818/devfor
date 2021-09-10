namespace Tlw.ZPG.Domain.Enums
{
    using System;
    using System.ComponentModel;

    /// <summary>
    /// ��־���
    /// </summary>
    public enum SystemLogType
    {
        /// <summary>
        /// ������־
        /// </summary>
        [Description("������־")]
        Affiche,
        /// <summary>
        /// ������־
        /// </summary>
        [Description("������־")]
        Trade,
        /// <summary>
        /// �������־
        /// </summary>
        [Description("�������־")]
        ApplyNumber,
        /// <summary>
        /// ��¼��־
        /// </summary>
        [Description("��¼��־")]
        Login,
        /// <summary>
        /// �쳣��־
        /// </summary>
        [Description("�쳣��־")]
        Exception,
        /// <summary>
        /// ������־
        /// </summary>
        [Description("������־")]
        Other,
    }
}
