using Acc.Cmd.Domain.DomainObjects;
using Acc.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Acc.Cmd.Infrastructure.EFConfig
{
    public class GroupFunctionConfiguration : IEntityTypeConfiguration<GroupFunction>
    {
        public void Configure(EntityTypeBuilder<GroupFunction> builder)
        {
            builder.ToTable(QuanLyDuAnConstants.GroupFunction_TABLENAME);
            builder.Property(x => x.FunctionId).HasField("_functionId").UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.GroupId).HasField("_groupId").UsePropertyAccessMode(PropertyAccessMode.Field);
        }
    }
}
