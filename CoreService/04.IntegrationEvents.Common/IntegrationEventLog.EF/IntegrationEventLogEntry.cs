using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using EventBus.Events;
using Newtonsoft.Json;

namespace IntegrationEventLog.EF
{
    public class IntegrationEventLogEntry
    {
        public IntegrationEventLogEntry()
        {
        }

        public IntegrationEventLogEntry(IntegrationEvent @event, Guid transactionId)
        {
            EventId = @event.Id;
            CreationDate = @event.CreationDate;
            EventTypeName = @event.GetType().FullName;
            Content = JsonConvert.SerializeObject(@event);
            State = EventStateEnum.NotPublished;
            TimesSent = 0;
            TransactionId = transactionId.ToString();
        }

        public Guid EventId { get; }
        public EventStateEnum State { get; set; }
        public int TimesSent { get; set; }
        public DateTime CreationDate { get; }
        public string Content { get; set; }
        public string TransactionId { get; }
        public string EventTypeName { get; }
        [NotMapped] public string EventTypeShortName => EventTypeName.Split('.').Last();
        [NotMapped] public IntegrationEvent IntegrationEvent { get; set; }

        public IntegrationEventLogEntry DeserializeJsonContent(Type type)
        {
            IntegrationEvent = JsonConvert.DeserializeObject(Content, type) as IntegrationEvent;
            return this;
        }
    }
}