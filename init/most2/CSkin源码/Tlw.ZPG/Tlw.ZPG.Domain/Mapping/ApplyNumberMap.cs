namespace Tlw.ZPG.Domain.Mapping
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Common;
    using System.Data.Entity;
    using System.Data.Entity.ModelConfiguration;
    using System.Data.Entity.Infrastructure;

    using Tlw.ZPG.Domain.Models;

    internal partial class ApplyNumberMap : EntityTypeConfiguration<ApplyNumber>
    {
        public ApplyNumberMap()
        {
            this.HasKey(t => t.ID);
            this.ToTable("A_ApplyNumber");
            this.Property(t => t.ID).HasColumnName("ApplyId");
            this.Property(t => t.Number).HasColumnName("Number").IsRequired().HasMaxLength(50);
            this.Property(t => t.IsUsed).HasColumnName("IsUsed");
            this.Property(t => t.UsedTime).HasColumnName("UsedTime");
            this.Property(t => t.GrantUserId).HasColumnName("GrantUserId");
            this.HasOptional(t => t.GrantUser).WithMany();
            this.HasOptional(t => t.Trade).WithMany();
        }
    }
}
