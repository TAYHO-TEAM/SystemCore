using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectManager.CMD.Domain.DomainObjects;
using ProjectManager.Common;


namespace ProjectManager.CMD.Infrastructure.EFConfig
{
    public class NS_NganSachDetailConfiguration : IEntityTypeConfiguration<NS_NganSachDetail>
    {
        public void Configure(EntityTypeBuilder<NS_NganSachDetail> builder)
        {
            builder.ToTable(QuanLyDuAnConstants.NS_NganSachDetail_TABLENAME);
            builder.Property(x => x.NganSachId).HasField("_nganSachId").UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.CongViec).HasField("_congViec").HasMaxLength(500).UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.GiaTri).HasField("_giaTri").UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.NgayCapNhat).HasField("_ngayCapNhat").UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.DienGiai).HasField("_dienGiai").UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.isLock).HasField("_isLock").UsePropertyAccessMode(PropertyAccessMode.Field);
        }
    }
}
