using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Services.Common.APIs.Cmd.EF
{
    public class NoMediator : IMediator
    {
        public Task<TResponse> Send<TResponse>(IRequest<TResponse> request, CancellationToken cancellationToken = new CancellationToken())
        {
            return Task.FromResult<TResponse>(default!);
        }

        public Task<object?> Send(object request, CancellationToken cancellationToken = new CancellationToken())
        {
            return Task.FromResult<object?>(default);
        }

        public Task Publish(object notification, CancellationToken cancellationToken = new CancellationToken())
        {
            return Task.CompletedTask;
        }

        public Task Publish<TNotification>(TNotification notification, CancellationToken cancellationToken = new CancellationToken()) where TNotification : INotification
        {
            return Task.CompletedTask;
        }
    }
}