using Microsoft.Extensions.Options;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Threading;
using System.Threading.Tasks;

namespace Dapper.Common.Core
{
    public class SqlConnectionFactory : ISqlConnectionFactory
    {
        private readonly IOptions<DapperDbOptions> _dapperOptions;
        private IDbConnection _connection;

        public SqlConnectionFactory(IOptions<DapperDbOptions> dapperOptions)
        {
            _dapperOptions = dapperOptions;
        }

        public async Task<IDbConnection> CreateConnectionAsync()
        {
            if (_connection == null || _connection.State != ConnectionState.Open)
            {
                var sqlConnection = new SqlConnection(_dapperOptions.Value?.ConnectionStrings);
                await sqlConnection.OpenAsync(CancellationToken.None);
                return sqlConnection;
            }
            return _connection;
        }

        public void Dispose()
        {
            if (_connection != null && _connection.State == ConnectionState.Open)
            {
                _connection.Dispose();
            }
        }
    }
}