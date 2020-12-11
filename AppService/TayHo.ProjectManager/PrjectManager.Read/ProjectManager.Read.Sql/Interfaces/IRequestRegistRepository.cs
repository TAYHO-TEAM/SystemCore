using ProjectManager.Read.Sql.Parameters;
using Services.Common.Paging;
using System.Threading.Tasks;

namespace ProjectManager.Read.Sql.Interfaces
{
    public interface IRequestRegistRepository<T> where T : class
    {
        //Task<PagingItems<T>> GetWithPaggingAsync(RequestBaseFilterParam requetsBaseFilterParam);
        Task<PagingItems<T>> GetWithPaggingStepPermistionAsync(RequestHasAccountIdFilterParam requetsBaseFilterParam);
    }

}
