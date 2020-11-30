using System.Data;
using System.Threading.Tasks;

namespace Dapper.Common
{
    public interface IDynamicSqlConnectionFactory
    {
        Task<IDbConnection> GetOpenConnection(string dbConnString);
    }
}