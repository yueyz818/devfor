namespace Tlw.ZPG.Domain.Mapping.Admin
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Common;
    using System.Data.Entity;
    using System.Data.Entity.ModelConfiguration;
    using System.Data.Entity.Infrastructure;

    using Tlw.ZPG.Domain.Models;
    using Tlw.ZPG.Domain.Models.Admin;

    internal partial class MenuMap : EntityTypeConfiguration<Menu>
    {
        public MenuMap()
        {
            this.HasKey(t => t.ID);
            this.ToTable("U_Menu");
            this.Property(t => t.ID).HasColumnName("MenuId");
            this.Property(t => t.MenuName).HasColumnName("MenuName").IsRequired().HasMaxLength(50);
            this.Property(t => t.MenuUrl).HasColumnName("MenuUrl").HasMaxLength(200);
            this.Property(t => t.ParentId).HasColumnName("ParentId");
            this.Property(t => t.MenuIcon).HasColumnName("MenuIcon").HasMaxLength(200);
            this.Property(t => t.OrderNo).HasColumnName("OrderNo");
            this.Property(t => t.MenuCode).HasColumnName("MenuCode").HasMaxLength(50);
            this.HasOptional(t => t.Parent).WithMany(t => t.Nodes).HasForeignKey(d => d.ParentId).WillCascadeOnDelete(false);
            this.HasMany(t => t.Roles).WithMany(t => t.Menus)
                    .Map(m =>
                    {
                        m.ToTable("U_RoleMenu");
                        m.MapLeftKey("MenuId");
                        m.MapRightKey("RoleId");
                    });
        }
    }
}
