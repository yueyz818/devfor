namespace Tlw.ZPG.Domain.Enums
{
    using System;
    using System.ComponentModel;

    /// <summary>
    /// 新闻类别
    /// </summary>
    public enum NewsType
    {
        /// <summary>
        /// 政策法规资讯
        /// </summary>
        [Description("政策法规资讯")]
        Info,
        /// <summary>
        /// 知识问答
        /// </summary>
        [Description("知识问答")]
        QA,
        /// <summary>
        /// 常见问题解答
        /// </summary>
        [Description("常见问题解答")]
        FAQ
    }
}
