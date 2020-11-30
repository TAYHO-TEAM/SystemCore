using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Services.Common.DomainObjects.Extensions
{
    public static class MediatorExtension
    {
        public static async Task DispatchDomainEventsAsync(this IMediator mediator, IEnumerable<Entity> domainEntities)
        {
            var domainEvents = domainEntities
                .SelectMany(x => x.DomainEvents)
                .ToList();
            var tasks = domainEvents.Select(async domainEvent =>
            {
                try
                {
                    await mediator.Publish(domainEvent).ConfigureAwait(false);
                }
                catch (Exception ex)
                {
                    throw;
                }
            });
            await Task.WhenAll(tasks).ConfigureAwait(false);
        }
    }
}