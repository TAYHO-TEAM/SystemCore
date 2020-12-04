using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using ProjectManager.CMD.Domain.DomainObjects;
using ProjectManager.CMD.Domain.IRepositories;
using Services.Common.APIs.Cmd.EF;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace ProjectManager.CMD.Infrastructure.Repositories
{
    public class RequestRegistRepository : BaseRepository<RequestRegist>, IRequestRegistRepository
    {
        public RequestRegistRepository(QuanLyDuAnContext dbContext) : base(dbContext)
        {
        }
        public async Task<bool> IsCreatedRequestRegistAsync(int DocumentTypeId,int AccountId, int Id)
        {
            await using var cmd = _dbContext.Database.GetDbConnection().CreateCommand();
            await cmd.Connection.OpenAsync();
            cmd.CommandText = "sp_RequestRegist_CreateByAccountID";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@DocumentTypeId", DocumentTypeId));
            cmd.Parameters.Add(new SqlParameter("@AccountId", AccountId));
            cmd.Parameters.Add(new SqlParameter("@RequestRegistId", Id));

            var result = await cmd.ExecuteScalarAsync().ConfigureAwait(false);
            return (bool)result;
        }
    }
}
