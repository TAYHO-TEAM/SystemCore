﻿using ProjectManager.CMD.Domain.DomainObjects;
using ProjectManager.CMD.Domain.IRepositories;
using Services.Common.APIs.Cmd.EF;


namespace ProjectManager.CMD.Infrastructure.Repositories
{
    public class AssignmentsRepository : BaseRepository<Assignments>, IAssignmentsRepository
    {
        public AssignmentsRepository(QuanLyDuAnContext dbContext) : base(dbContext)
        {
        }
    }
}
