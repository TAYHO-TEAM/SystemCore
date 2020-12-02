using ProjectManager.CMD.Domain.DomainObjects;
using ProjectManager.CMD.Domain.IRepositories;
using Services.Common.APIs.Cmd.EF;


namespace ProjectManager.CMD.Infrastructure.Repositories
{
    public class NS_HopDongRepository : BaseRepository<NS_HopDong>, INS_HopDongRepository
    {
        public NS_HopDongRepository(QuanLyDuAnContext dbContext) : base(dbContext)
        {
        }
    }
}
