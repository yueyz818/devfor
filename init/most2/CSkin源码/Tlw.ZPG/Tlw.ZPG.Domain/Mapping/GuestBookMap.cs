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

    internal partial class GuestBookMap : EntityTypeConfiguration<GuestBook>
    {
        public GuestBookMap()
        {
            this.HasKey(t => t.ID);
            this.ToTable("C_GuestBook");
            this.Property(t => t.ID).HasColumnName("GuestBookId");
            this.Property(t => t.Title).HasColumnName("Title").IsRequired().HasMaxLength(100);
            this.Property(t => t.Content).HasColumnName("Content").IsRequired().HasMaxLength(500);
            this.Property(t => t.GuestName).HasColumnName("GuestName").HasMaxLength(50);
            this.Property(t => t.CreateTime).HasColumnName("CreateTime");
            this.Property(t => t.Phone).HasColumnName("Phone").HasMaxLength(50);
            this.Property(t => t.Address).HasColumnName("Address").HasMaxLength(50);
        }
    }
}
