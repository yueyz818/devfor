namespace Tlw.ZPG.Domain.Enums
{
    using System;
    using System.ComponentModel;

    /// <summary>
    /// ������
    /// </summary>
    public enum VerifyType
    {
        /// <summary>
        /// ����ˣ�ͨ��
        /// </summary>
        [Description("����ˣ�ͨ��")]
        Verified,
        /// <summary>
        /// ����ˣ���������
        /// </summary>
        [Description("����ˣ���������")]
        NotAccept,
        /// <summary>
        /// ����ˣ�֪ͨ����
        /// </summary>
        [Description("����ˣ�֪ͨ����")]
        NotifyAdditional,
    }
}
