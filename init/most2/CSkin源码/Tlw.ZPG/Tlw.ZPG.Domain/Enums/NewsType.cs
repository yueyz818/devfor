namespace Tlw.ZPG.Domain.Enums
{
    using System;
    using System.ComponentModel;

    /// <summary>
    /// �������
    /// </summary>
    public enum NewsType
    {
        /// <summary>
        /// ���߷�����Ѷ
        /// </summary>
        [Description("���߷�����Ѷ")]
        Info,
        /// <summary>
        /// ֪ʶ�ʴ�
        /// </summary>
        [Description("֪ʶ�ʴ�")]
        QA,
        /// <summary>
        /// ����������
        /// </summary>
        [Description("����������")]
        FAQ
    }
}
