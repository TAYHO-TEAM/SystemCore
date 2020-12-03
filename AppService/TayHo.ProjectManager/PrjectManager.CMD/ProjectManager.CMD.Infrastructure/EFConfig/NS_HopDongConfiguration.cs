﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectManager.CMD.Domain.DomainObjects;
using ProjectManager.Common;


namespace ProjectManager.CMD.Infrastructure.EFConfig
{
    public class NS_HopDongConfiguration : IEntityTypeConfiguration<NS_HopDong>
    {
        public void Configure(EntityTypeBuilder<NS_HopDong> builder)
        {
            builder.ToTable(QuanLyDuAnConstants.NS_HopDong_TABLENAME);
            builder.Property(x => x.ParentID).HasField("_parentID").UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.SoHopDong).HasField("_soHopDong").HasMaxLength(50).UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.ContractorInfoId).HasField("_contractorInfoId").UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.GoiThauID).HasField("_goiThauID").UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.GiaTri).HasField("_giaTri").UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.NgayKy).HasField("_ngayKy").UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.DienGiai).HasField("_dienGiai").UsePropertyAccessMode(PropertyAccessMode.Field);
        }
    }
}