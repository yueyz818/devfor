namespace Tlw.ZPG.Domain.Enums
{
    using System;
    using System.ComponentModel;

    /// <summary>
    /// �ɽ�����
    /// </summary>
    public enum TradeDealType
    {
        /// <summary>
        /// δ֪
        /// </summary>
        [Description("δ֪")]
        None,
        /// <summary>
        /// ���Ϲ���
        /// </summary>
        [Description("���Ϲ���")]
        Hang,
        /// <summary>
        /// ת����������
        /// </summary>
        [Description("ת����������")]
        Auction,
    }
}
