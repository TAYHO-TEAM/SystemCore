using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectManager.CMD.Domain.DomainObjects;
using ProjectManager.Common;


namespace ProjectManager.CMD.Infrastructure.EFConfig
{
    public class DocumentReleasedConfiguration : IEntityTypeConfiguration<DocumentReleased>
    {
        public void Configure(EntityTypeBuilder<DocumentReleased> builder)
        {
            builder.ToTable(QuanLyDuAnConstants.DocumentReleased_TABLENAME);
            builder.Property(x => x.Title).HasField("_title").HasMaxLength(512).UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.Description).HasField("_description").UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.DocumentTypeId).HasField("_documentTypeId").UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.ProjectId).HasField("_projectId").UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.WorkItemId).HasField("_workItemId").UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.TagWorkItem).HasField("_tagWorkItem").UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.Property(x => x.NoAttachment).HasField("_noAttachment").UsePropertyAccessMode(PropertyAccessMode.Field);
        }
    }
}
