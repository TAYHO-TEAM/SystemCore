using ProjectManager.CMD.Domain.DomainObjects;
using Services.Common.DomainObjects.Interfaces;
using System.Threading.Tasks;

namespace ProjectManager.CMD.Domain.IRepositories
{
    public interface IDocumentReleasedRepository : ICmdRepository<DocumentReleased>
    {
        Task<bool> IsCreatedDocumentReleasedAsync(int DocumentTypeId, int AccountId, int Id);
        Task<string> IsGetTitleDocumentReleasedAsync(int ProjectId, int WorkItemId, int DocumentTypeId);
        Task DocumentReleasedProcessAsync();
    }
}
