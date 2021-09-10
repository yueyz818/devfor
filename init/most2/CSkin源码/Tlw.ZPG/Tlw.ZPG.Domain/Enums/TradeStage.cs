namespace Tlw.ZPG.Domain.Enums
{
    using System;
    using System.ComponentModel;

    /// <summary>
    /// ���׽׶�
    /// </summary>
    public enum TradeStage
    {
        /// <summary>
        /// δ��ʼ����
        /// </summary>
        [Description("δ��ʼ����")]
        UnStartSign,
        /// <summary>
        /// ������
        /// </summary>
        [Description("������")]
        Signing,
        /// <summary>
        /// ����
        /// </summary>
        [Description("����")]
        Hang,
        /// <summary>
        /// �ȴ�
        /// </summary>
        [Description("�ȴ�")]
        Ready,
        /// <summary>
        /// ����
        /// </summary>
        [Description("����")]
        Auction,
        /// <summary>
        /// ����
        /// </summary>
        [Description("����")]
        Complete,
    }
}
