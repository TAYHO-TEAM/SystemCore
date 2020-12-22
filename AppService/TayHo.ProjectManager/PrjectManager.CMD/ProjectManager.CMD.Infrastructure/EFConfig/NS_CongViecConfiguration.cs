using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectManager.CMD.Domain.DomainObjects;
using ProjectManager.Common;


namespace ProjectManager.CMD.Infrastructure.EFConfig
{
    public class NS_CongViecConfiguration : IEntityTypeConfiguration<NS_CongViec>
    {
        public void Configure(EntityTypeBuilder<NS_CongViec> builder)
        {
            builder.ToTable(QuanLyDuAnConstants.NS_CongViec_TABLENAME);
            builder.Property(x => x.NhomCongViecId).HasField("_nhomCongViecId").UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.ReasonId).HasField("_reasonId").UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.TenCongViec).HasField("_tenCongViec").HasMaxLength(500).UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.DienGiai).HasField("_dienGiai").UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.DonViTinh).HasField("_donViTinh").HasMaxLength(500).UsePropertyAccessMode(PropertyAccessMode.Field);
        }
    }
}
