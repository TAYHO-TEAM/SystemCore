using System;
using System.Collections.Generic;
using EventBus.Events;
using EventBus.Interfaces;

namespace EventBus
{
    public interface IEventBusSubscriptionsManager
    {
        void AddSubscription<T, TH>() where T : IntegrationEvent where TH : IIntegrationEventHandler<T>;
        bool HasSubscriptionsForEvent(string eventName);
        Type GetEventTypeByName(string eventName);
        IEnumerable<SubscriptionInfo> GetHandlersForEvent(string eventName);
        string GetEventKey<T>();
    }
}