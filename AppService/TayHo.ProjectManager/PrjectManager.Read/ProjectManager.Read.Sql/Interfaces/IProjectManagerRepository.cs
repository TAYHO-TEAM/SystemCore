using DevExtreme.AspNet.Data.ResponseModel;
using ProjectManager.Read.Sql.DTOs.BaseClasses;
using System.Threading.Tasks;

namespace ProjectManager.Read.Sql.Interfaces
{
    public interface IProjectManagerRepository
    {
        Task<LoadResult> GetAccount(string nameEF,DevLoadOptionsBase dataSourceLoadOptions);
    }

}
