﻿using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using ProjectManager.CMD.Domain.DomainObjects;
using ProjectManager.CMD.Domain.IRepositories;
using Services.Common.APIs.Cmd.EF;
using System.Data;
using System.Threading.Tasks;

namespace ProjectManager.CMD.Infrastructure.Repositories
{
    public class DocumentReleasedRepository : BaseRepository<DocumentReleased>, IDocumentReleasedRepository
    {
        public DocumentReleasedRepository(QuanLyDuAnContext dbContext) : base(dbContext)
        {
        }
        public async Task<bool> IsCreatedDocumentReleasedAsync(int DocumentTypeId, int AccountId, int Id)
        {
            await using var cmd = _dbContext.Database.GetDbConnection().CreateCommand();
            await cmd.Connection.OpenAsync();
            cmd.CommandText = "sp_DocumentReleased_CreateByAccountID";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@DocumentTypeId", DocumentTypeId));
            cmd.Parameters.Add(new SqlParameter("@AccountId", AccountId));
            cmd.Parameters.Add(new SqlParameter("@DocumentReleasedId", Id));
            var result = await cmd.ExecuteNonQueryAsync().ConfigureAwait(false);
            await cmd.Connection.CloseAsync();
            return (bool)(result == 0 ? false : true);
        }
    }
}
