using ProjectManager.Read.Sql.Parameters;
using Services.Common.Paging;
using System.Threading.Tasks;

namespace ProjectManager.Read.Sql.Interfaces
{
    public interface IDOBaseRepository<T> where T : class
    {
        Task<PagingItems<T>> GetWithPaggingAsync(RequestBaseFilterParam requetsBaseFilterParam);
        Task<PagingItems<T>> GetWithPaggingFKAsync(RequestBaseFilterParam requetsBaseFilterParam);
    }

}
