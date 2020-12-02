using ProjectManager.CMD.Domain.DomainObjects;
using ProjectManager.CMD.Domain.IRepositories;
using Services.Common.APIs.Cmd.EF;


namespace ProjectManager.CMD.Infrastructure.Repositories
{
    public class NS_NganSachDetailRepository : BaseRepository<NS_NganSachDetail>, INS_NganSachDetailRepository
    {
        public NS_NganSachDetailRepository(QuanLyDuAnContext dbContext) : base(dbContext)
        {
        }
    }
}
