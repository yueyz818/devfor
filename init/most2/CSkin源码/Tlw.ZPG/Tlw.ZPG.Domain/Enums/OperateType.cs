namespace Tlw.ZPG.Domain.Models
{
    using System;
    using System.ComponentModel;

    /// <summary>
    /// �������
    /// </summary>
    public enum OperateType
    {
        #region �û�
        /// �û���¼
        /// </summary>
        [Description("�û���¼")]
        UserLogin,
        /// �޸ĸ�����Ϣ
        /// </summary>
        [Description("�޸ĸ�����Ϣ")]
        UserInfoUpdated,
        /// �޸�����
        /// </summary>
        [Description("�޸�����")]
        UserPasswordUpdated,
        /// �½��û�
        /// </summary>
        [Description("�½��û�")]
        UserCreated, 
        #endregion

        #region ����
        /// �½�����
        /// </summary>
        [Description("�½�����")]
        AfficheCreated,
        /// �޸Ĺ���
        /// </summary>
        [Description("�޸Ĺ���")]
        AfficheUpdated,
        /// ���乫��
        /// </summary>
        [Description("���乫��")]
        AfficheSupplied,
        /// ��������
        /// </summary>
        [Description("��������")]
        AfficheReleased,
        /// ɾ������
        /// </summary>
        [Description("ɾ������")]
        AfficheDeleted,
        #endregion

        #region �ڵ�
        /// �½��ڵ�
        /// </summary>
        [Description("�½��ڵ�")]
        LandCreated,
        /// �޸��ڵ�
        /// </summary>
        [Description("�޸��ڵ�")]
        LandUpdated,
        /// ɾ���ڵ�
        /// </summary>
        [Description("ɾ���ڵ�")]
        LandDeleted,
        /// ¼�뱨������
        /// </summary>
        [Description("¼�뱨������")]
        BasePriceInputed,
        #endregion

        #region ��ʾ
        /// �½���ʾ
        /// </summary>
        [Description("�½���ʾ")]
        NoticeCreated,
        /// �޸Ĺ�ʾ
        /// </summary>
        [Description("�޸Ĺ�ʾ")]
        NoticeUpdated,
        /// ɾ����ʾ
        /// </summary>
        [Description("ɾ����ʾ")]
        NoticeDeleted,
        /// ������ʾ
        /// </summary>
        [Description("������ʾ")]
        NoticeReleased,
        #endregion

        #region ����
        /// ���׶���
        /// </summary>
        [Description("���׶���")]
        TradeFrozed,
        /// ������ֹ
        /// </summary>
        [Description("������ֹ")]
        TradeTerminated,
        /// ��������˳ɽ����
        /// </summary>
        [Description("��������˳ɽ����")]
        TradeResultVerified,
        /// �����˷�����Ϣ
        /// </summary>
        [Description("�����˷�����Ϣ")]
        TradeSendMessage,
        #endregion

        #region �����
        /// ���������
        /// </summary>
        [Description("���������")]
        ApplyHangVerify,
        /// ����Ź�ʧ
        /// </summary>
        [Description("����Ź�ʧ")]
        ApplyNumberLossed,
        /// ����Ŷ���
        /// </summary>
        [Description("����Ŷ���")]
        ApplyNumberFrozed,
        /// ����Žⶳ
        /// </summary>
        [Description("����Žⶳ")]
        ApplyNumberUnFrozed,
        /// ���·�������
        /// </summary>
        [Description("���·�������")]
        ApplyPasswordReset,
        /// �޸��ֻ�����
        /// </summary>
        [Description("�޸��ֻ�����")]
        ApplyPhoneUpdated,
        /// �ϴ�����
        /// </summary>
        [Description("�ϴ�����")]
        ApplyFilesUploaded,
        #endregion

        #region ����
        /// <summary>
        /// ����Ⱥ��
        /// </summary>
        [Description("����Ⱥ��")]
        SendGroupSMS,

        #endregion

        /// �����쳣
        /// </summary>
        [Description("�����쳣")]
        Exception,
        /// ����
        /// </summary>
        [Description("����")]
        Other,
    }
}
