using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectManager.CMD.Domain.DomainObjects;
using ProjectManager.Common;


namespace ProjectManager.CMD.Infrastructure.EFConfig
{
    public class NS_GoiThauConfiguration : IEntityTypeConfiguration<NS_GoiThau>
    {
        public void Configure(EntityTypeBuilder<NS_GoiThau> builder)
        {
            builder.ToTable(QuanLyDuAnConstants.NS_GoiThau_TABLENAME);
            builder.Property(x => x.HangMucId).HasField("_hangMucId").UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.LoaiThauId).HasField("_loaiThauId").UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.GiaiDoanId).HasField("_giaiDoanId").UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.HopDongId).HasField("_hopDongId").UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.DienGiai).HasField("_dienGiai").UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.GiaTri).HasField("_giaTri").UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.isLock).HasField("_isLock").UsePropertyAccessMode(PropertyAccessMode.Field);
        }
    }
}
