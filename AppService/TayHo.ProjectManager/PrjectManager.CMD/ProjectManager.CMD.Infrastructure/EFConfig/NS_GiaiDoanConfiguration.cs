using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectManager.CMD.Domain.DomainObjects;
using ProjectManager.Common;


namespace ProjectManager.CMD.Infrastructure.EFConfig
{
    public class NS_GiaiDoanConfiguration : IEntityTypeConfiguration<NS_GiaiDoan>
    {
        public void Configure(EntityTypeBuilder<NS_GiaiDoan> builder)
        {
            builder.ToTable(QuanLyDuAnConstants.NS_GiaiDoan_TABLENAME);
            builder.Property(x => x.TenGiaiDoan).HasField("_tenGiaiDoan").HasMaxLength(500).UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.DienGiai).HasField("_dienGiai").HasMaxLength(500).UsePropertyAccessMode(PropertyAccessMode.Field);
        }
    }
}
