using Dapper;
using Dapper.Common;
using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Data.ResponseModel;
using DevExtreme.AspNet.Mvc;
using ProjectManager.CMD.Infrastructure;
using ProjectManager.Read.Sql.Interfaces;
using ProjectManager.Read.Sql.Parameters;
using Services.Common.DomainObjects;
using Services.Common.Paging;
using System;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectManager.Read.Sql.Repositories
{
    public class ProjectManagerRepository: IProjectManagerRepository
    {
        //protected readonly ProjectManagerBaseContext _dbContext;
        //protected readonly ISqlConnectionFactory _connectionFactory;
        public ProjectManagerRepository( )//ProjectManagerBaseContext dbContext)
        {
            //_dbContext = dbContext;
            //_connectionFactory = connectionFactory ?? throw new ArgumentNullException(nameof(connectionFactory));
        }
        //public async Task<LoadResult> GetAccount (DataSourceLoadOptions dataSourceLoadOptions )
        //{
        //    //var orders = _dbContext.AccountInfo.Select(i => new
        //    //{
        //    //    i.AccountId,
        //    //    i.AccountName,
        //    //    i.CreateBy
        //    //});
        //    return new LoadResult();// await DataSourceLoader.LoadAsync(orders, dataSourceLoadOptions);
        //}

    }
}
