namespace Tlw.ZPG.Domain.Enums
{
    using System;
    using System.ComponentModel;

    public enum TradeStatus
    {
        /// <summary>
        /// ����
        /// </summary>
        [Description("����")]
        Normal,
        /// <summary>
        /// ����
        /// </summary>
        [Description("����")]
        Froze,
        /// <summary>
        /// ��ֹ
        /// </summary>
        [Description("��ֹ")]
        Terminate,
    }
}
