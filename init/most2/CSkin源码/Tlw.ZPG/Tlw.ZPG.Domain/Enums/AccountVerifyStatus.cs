namespace Tlw.ZPG.Domain.Enums
{
    using System;
    using System.ComponentModel;

    /// <summary>
    /// �˻����״̬
    /// </summary>
    public enum AccountVerifyStatus
    {
        /// <summary>
        /// δ�ύ
        /// </summary>
        [Description("δ�ύ")]
        UnSubmit,
        /// <summary>
        /// ���ύ
        /// </summary>
        [Description("���ύ")]
        Submited,
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
        NotifySupply,
        /// <summary>
        /// �Ѳ��������ύ
        /// </summary>
        [Description("�Ѳ��������ύ")]
        SuppliedAndSubmited,
    }
}
