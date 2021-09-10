namespace Tlw.ZPG.Domain.Models
{
    using System;
    using System.Collections.Generic;
    using Tlw.ZPG.Infrastructure;

    public partial class Attachment : EntityBase
    {
        public string FilePath { get; set; }
        public string FileTitle { get; set; }
        public System.DateTime CreateTime { get; set; }
    }
}
