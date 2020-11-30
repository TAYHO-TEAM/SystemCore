using System;
using System.Threading;
using System.Threading.Tasks;

namespace Services.Common.DomainObjects.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken));
        Task DispatchEventsAsync(CancellationToken cancellationToken = default(CancellationToken));
        Task SaveChangesAndDispatchEventsAsync(CancellationToken cancellationToken = default(CancellationToken));
    }
}