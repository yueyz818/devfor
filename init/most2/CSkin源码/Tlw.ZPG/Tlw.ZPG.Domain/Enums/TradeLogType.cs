namespace Tlw.ZPG.Domain.Enums
{
    using System;
    using System.ComponentModel;

    /// <summary>
    /// ������־���
    /// </summary>
    public enum TradeLogType
    {
        /// �����˵�½
        /// </summary>
        [Description("�����˵�½")]
        BidderLogin,
        /// �����˵ǳ�
        /// </summary>
        [Description("�����˵ǳ�")]
        BidderLoginOut,
        /// �������޸�����
        /// </summary>
        [Description("�������޸�����")]
        BidderUpdatePassword,
        /// ������ȷ�ϳɽ�
        /// </summary>
        [Description("������ȷ�ϳɽ�")]
        BidderConfigResult,
        /// �����˶��ύ��
        /// </summary>
        [Description("�����˶��ύ��")]
        HangFroze,
        /// �����˽ⶳ����
        /// </summary>
        [Description("�����˽ⶳ����")]
        HangRecover,
        /// ��������ֹ����
        /// </summary>
        [Description("��������ֹ����")]
        HangTerminate,
        /// ������¼�뱣����
        /// </summary>
        [Description("������¼�뱣����")]
        HangReservePrice,
    }
}
