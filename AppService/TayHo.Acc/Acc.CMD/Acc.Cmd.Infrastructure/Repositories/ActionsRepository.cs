﻿
using Acc.Cmd.Domain.DomainObjects;
using Acc.Cmd.Domain.Repositories;
using Services.Common.APIs.Cmd.EF;


namespace Acc.Cmd.Infrastructure.Repositories
{
    public class ActionsRepository : BaseRepository<Actions>, IActionsRepository
    {
        public ActionsRepository(QuanLyDuAnContext dbContext) : base(dbContext)
        {
        }
    }
}
