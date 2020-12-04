using ProjectManager.CMD.Domain.DomainObjects;
using Services.Common.DomainObjects.Interfaces;
using System.Threading.Tasks;

namespace ProjectManager.CMD.Domain.IRepositories
{
    public interface IRequestRegistRepository : ICmdRepository<RequestRegist>
    {
        Task<bool> IsCreatedRequestRegistAsync(int DocumentTypeId, int AccountId, int Id);
    }
}
