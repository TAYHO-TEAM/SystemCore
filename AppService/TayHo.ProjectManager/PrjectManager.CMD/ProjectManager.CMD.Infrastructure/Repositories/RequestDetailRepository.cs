﻿using ProjectManager.CMD.Domain.DomainObjects;
using ProjectManager.CMD.Domain.IRepositories;
using Services.Common.APIs.Cmd.EF;


namespace ProjectManager.CMD.Infrastructure.Repositories
{
    public class RequestDetailRepository : BaseRepository<RequestDetail>, IRequestDetailRepository
    {
        public RequestDetailRepository(QuanLyDuAnContext dbContext) : base(dbContext)
        {
        }
    }
}
