using System;
using Newtonsoft.Json;

namespace EventBus.Events
{
    public class IntegrationEvent
    {
        public IntegrationEvent()
        {
            Id = Guid.NewGuid();
            CreationDate = DateTime.UtcNow;
        }

        [JsonConstructor]
        public IntegrationEvent(DateTime creationTime, Guid id)
        {
            CreationDate = creationTime;
            Id = id;
        }
        public Guid Id { get; }
        public DateTime CreationDate { get; }
    }
}