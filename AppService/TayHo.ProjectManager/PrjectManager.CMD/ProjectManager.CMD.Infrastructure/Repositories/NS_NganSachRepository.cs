using ProjectManager.CMD.Domain.DomainObjects;
using ProjectManager.CMD.Domain.IRepositories;
using Services.Common.APIs.Cmd.EF;


namespace ProjectManager.CMD.Infrastructure.Repositories
{
    public class NS_NganSachRepository : BaseRepository<NS_NganSach>, INS_NganSachRepository
    {
        public NS_NganSachRepository(QuanLyDuAnContext dbContext) : base(dbContext)
        {
        }
    }
}
