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
    
    internal partial class SystemLogMap : EntityTypeConfiguration<SystemLog>
    {
        public SystemLogMap()
        {                        
              this.HasKey(t => t.ID);        
              this.ToTable("T_SystemLog");
              this.Property(t => t.ID).HasColumnName("LogId");
              this.Property(t => t.CreateTime).HasColumnName("CreateTime");
              this.Property(t => t.LogType).HasColumnName("LogType");
              this.Property(t => t.LogCode).HasColumnName("LogCode").HasMaxLength(50);
              this.Property(t => t.UserId).HasColumnName("UserId");
              this.Property(t => t.UserName).HasColumnName("UserName").HasMaxLength(50);
              this.Property(t => t.Ip).HasColumnName("Ip").HasMaxLength(50);
              this.Property(t => t.Url).HasColumnName("Url").HasMaxLength(200);
              this.Property(t => t.Content).HasColumnName("Content");
              this.Property(t => t.Title).HasColumnName("Title").HasMaxLength(50);
         }
    }
}
