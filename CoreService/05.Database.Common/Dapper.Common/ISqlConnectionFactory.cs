using System;
using System.Data;
using System.Threading.Tasks;

namespace Dapper.Common
{
    public interface ISqlConnectionFactory : IDisposable
    {
        Task<IDbConnection> CreateConnectionAsync();
    }
}