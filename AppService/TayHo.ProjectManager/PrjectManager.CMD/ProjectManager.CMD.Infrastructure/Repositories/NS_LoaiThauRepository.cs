using ProjectManager.CMD.Domain.DomainObjects;
using ProjectManager.CMD.Domain.IRepositories;
using Services.Common.APIs.Cmd.EF;


namespace ProjectManager.CMD.Infrastructure.Repositories
{
    public class NS_LoaiThauRepository : BaseRepository<NS_LoaiThau>, INS_LoaiThauRepository
    {
        public NS_LoaiThauRepository(QuanLyDuAnContext dbContext) : base(dbContext)
        {
        }
    }
}
