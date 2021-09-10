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

    internal partial class CountyMap : EntityTypeConfiguration<County>
    {
        public CountyMap()
        {
            this.HasKey(t => t.ID);
            this.ToTable("T_County");
            this.Property(t => t.ID).HasColumnName("CountyId");
            this.Property(t => t.CountyName).HasColumnName("CountyName").IsRequired().HasMaxLength(50);
            this.Property(t => t.ParentId).HasColumnName("ParentId");
            this.Property(t => t.CountyCode).HasColumnName("CountyCode").HasMaxLength(50);
            this.Property(t => t.OrderNo).HasColumnName("OrderNo");
            this.Property(t => t.FullName).HasColumnName("FullName").HasMaxLength(100);
            this.HasOptional(t => t.Parent).WithMany(t => t.Nodes).HasForeignKey(d => d.ParentId).WillCascadeOnDelete(false);
        }
    }
}
