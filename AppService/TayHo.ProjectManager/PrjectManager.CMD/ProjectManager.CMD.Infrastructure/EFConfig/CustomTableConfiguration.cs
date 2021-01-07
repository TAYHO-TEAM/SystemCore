﻿using ProjectManager.CMD.Domain.DomainObjects;
using ProjectManager.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ProjectManager.CMD.Infrastructure.EFConfig
{
    public class CustomTableConfiguration : IEntityTypeConfiguration<CustomTable>
    {
        public void Configure(EntityTypeBuilder<CustomTable> builder)
        {
            builder.ToTable(QuanLyDuAnConstants.CustomTable_TABLENAME);
            builder.Property(x => x.Code).HasField("_code").HasMaxLength(256).UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.Title).HasField("_title").HasMaxLength(512).UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.NoColum).HasField("_noColum").UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.NoRown).HasField("_noRown").UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.Style).HasField("_style").HasMaxLength(1024).UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.Priority).HasField("_priority").UsePropertyAccessMode(PropertyAccessMode.Field);
        }
    }
}
