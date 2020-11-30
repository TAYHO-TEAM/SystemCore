using EventBus.Events;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace IntegrationEventLog.EF.Services
{
    public class IntegrationEventLogService : IIntegrationEventLogService
    {
        private readonly IntegrationEventLogContext _integrationEventLogContext;
        private readonly DbConnection _dbConnection;
        private readonly List<Type> _eventTypes;

        public IntegrationEventLogService(DbConnection dbConnection)
        {
            _dbConnection = dbConnection ?? throw new ArgumentNullException(nameof(dbConnection));
            _integrationEventLogContext = new IntegrationEventLogContext(new DbContextOptionsBuilder<IntegrationEventLogContext>().UseSqlServer(_dbConnection).Options);
            _eventTypes = Assembly.Load(Assembly.GetEntryAssembly().FullName).GetTypes().Where(t => t.Name.EndsWith(nameof(IntegrationEvent))).ToList();
        }

        public async Task<IEnumerable<IntegrationEventLogEntry>> RetrieveEventLogsPendingToPublishAsync(Guid transactionId)
        {
            var tid = transactionId.ToString();
            var integrationEventLogs = await _integrationEventLogContext.IntegrationEventLogs
                .Where(e => e.TransactionId == tid && e.State == EventStateEnum.NotPublished)
                .ToListAsync()
                .ConfigureAwait(false);
            if (integrationEventLogs != null && integrationEventLogs.Any())
            {
                return integrationEventLogs
                    .OrderBy(x => x.CreationDate)
                    .Select(e => e.DeserializeJsonContent(_eventTypes.Find(t => t.Name == e.EventTypeShortName)));
            }
            return new List<IntegrationEventLogEntry>();
        }

        public Task SaveEventAsync(IntegrationEvent @event, IDbContextTransaction transaction)
        {
            if (transaction == null) throw new ArgumentNullException(nameof(transaction));
            var eventLogEntry = new IntegrationEventLogEntry(@event, transaction.TransactionId);
            _integrationEventLogContext.Database.UseTransaction(transaction.GetDbTransaction());
            _integrationEventLogContext.IntegrationEventLogs.Add(eventLogEntry);
            return _integrationEventLogContext.SaveChangesAsync();
        }

        public Task MarkEventAsPublishedAsync(Guid eventId)
        {
            return UpdateEventStatus(eventId, EventStateEnum.Published);
        }

        public Task MarkEventAsInProgressAsync(Guid eventId)
        {
            return UpdateEventStatus(eventId, EventStateEnum.InProgress);
        }

        public Task MarkEventAsFailedAsync(Guid eventId)
        {
            return UpdateEventStatus(eventId, EventStateEnum.PublishedFailed);
        }

        private Task UpdateEventStatus(Guid guid, EventStateEnum state)
        {
            var integrationEventLog = _integrationEventLogContext.IntegrationEventLogs.Single(x => x.EventId == guid);
            integrationEventLog.State = state;
            if (state == EventStateEnum.InProgress) integrationEventLog.TimesSent++;
            _integrationEventLogContext.IntegrationEventLogs.Update(integrationEventLog);
            return _integrationEventLogContext.SaveChangesAsync();
        }
    }
}