using Acc.Cmd.Domain.DomainObjects;
using Acc.Cmd.Domain.Repositories;
using Services.Common.APIs.Cmd.EF;


namespace Acc.Cmd.Infrastructure.Repositories
{
    public class GroupFunctionRepository : BaseRepository<GroupFunction>, IGroupFunctionRepository
    {
        public GroupFunctionRepository(QuanLyDuAnContext dbContext) : base(dbContext)
        {
        }
    }
}
