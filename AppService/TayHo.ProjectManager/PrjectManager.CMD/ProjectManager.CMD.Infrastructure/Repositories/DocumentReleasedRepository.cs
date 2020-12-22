using ProjectManager.CMD.Domain.DomainObjects;
using ProjectManager.CMD.Domain.IRepositories;
using Services.Common.APIs.Cmd.EF;


namespace ProjectManager.CMD.Infrastructure.Repositories
{
    public class DocumentReleasedRepository : BaseRepository<DocumentReleased>, IDocumentReleasedRepository
    {
        public DocumentReleasedRepository(QuanLyDuAnContext dbContext) : base(dbContext)
        {
        }
    }
}
