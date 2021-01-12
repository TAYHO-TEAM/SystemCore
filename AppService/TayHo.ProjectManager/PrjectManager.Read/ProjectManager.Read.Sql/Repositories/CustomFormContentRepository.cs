using Dapper;
using Dapper.Common;
using ProjectManager.Read.Sql.DTOs.DTO;
using ProjectManager.Read.Sql.Interfaces;
using ProjectManager.Read.Sql.Parameters;
using Services.Common.Paging;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectManager.Read.Sql.Repositories
{
    public class CustomFormContentRepository<T> : ICustomFormContentRepository<T> where T : class
    {
        protected readonly ISqlConnectionFactory _connectionFactory;

        public CustomFormContentRepository(ISqlConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory ?? throw new ArgumentNullException(nameof(connectionFactory));
        }
      
    }
}
