using System;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using EventBus.Events;
using EventBus.Interfaces;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Polly;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using RabbitMQ.Client.Exceptions;

namespace EventBus.RabbitMQ
{
    public class EventBusRabbitMQ : IEventBus
    {
        private const string BROKER_NAME = "ASCVN.VNU.BE_TEST";
        private const string AUTOFAC_SCOPE_NAME = "ASCVN.VNU.BE_TEST";
        private const string INTEGRATION_EVENT_SUFFIX = "IntegrationEvent";

        private readonly IEventBusSubscriptionsManager _subManager;
        private readonly IRabbitMQPersistentConnection _persistentConnection;
        private readonly ILogger<EventBusRabbitMQ> _logger;
        private readonly ILifetimeScope _autofac;
        private readonly int _retryCount;
        private IModel _consumerChannel;
        private string _queueName;

        public EventBusRabbitMQ(IRabbitMQPersistentConnection persistentConnection, ILogger<EventBusRabbitMQ> logger, ILifetimeScope autofac, IEventBusSubscriptionsManager subManager, int retryCount, string queueName = null)
        {
            _persistentConnection = persistentConnection;
            _logger = logger;
            _autofac = autofac;
            _subManager = subManager;
            _retryCount = retryCount;
            _queueName = queueName;
            _consumerChannel = CreateConsumerChannel();
        }

        public void Publish(IntegrationEvent @event)
        {
            if (!_persistentConnection.IsConnected) _persistentConnection.TryConnect();
            var policy = Policy.Handle<SocketException>()
                .Or<BrokerUnreachableException>()
                .WaitAndRetry(_retryCount, retryAttempt => TimeSpan.FromSeconds(Math.Pow(2, retryAttempt)), (ex, time) =>
                {
                    _logger.LogWarning(ex, "RabbitMQ Client could not connect after {TimeOut}s ({ExceptionMessage})", $"{time.TotalSeconds:n1}", ex.Message);
                });
            var eventName = @event.GetType().Name;
            using var channel = _persistentConnection.CreateModel();
            channel.ExchangeDeclare(BROKER_NAME, "direct");
            var message = JsonConvert.SerializeObject(@event);
            var body = Encoding.UTF8.GetBytes(message);
            policy.Execute(() =>
            {
                var properties = channel.CreateBasicProperties();
                properties.DeliveryMode = 2;
                channel.BasicPublish(BROKER_NAME, eventName, true, properties, body);
            });
        }

        public void Subscribe<T, TH>() where T : IntegrationEvent where TH : IIntegrationEventHandler<T>
        {
            var eventName = _subManager.GetEventKey<T>();
            var containsKey = _subManager.HasSubscriptionsForEvent(eventName);
            if (!containsKey)
            {
                if (!_persistentConnection.IsConnected) _persistentConnection.TryConnect();
                using var channel = _persistentConnection.CreateModel();
                channel.QueueBind(_queueName, BROKER_NAME, eventName);
            }
            _subManager.AddSubscription<T, TH>();
            StartBasicConsume();
        }

        public void Unsubscribe<T, TH>() where T : IntegrationEvent where TH : IIntegrationEventHandler<T>
        {
            throw new NotImplementedException();
        }

        #region Private function

        private void StartBasicConsume()
        {
            if (_consumerChannel != null)
            {
                var consumer = new AsyncEventingBasicConsumer(_consumerChannel);
                consumer.Received += Consumer_Received;
                _consumerChannel.BasicConsume(_queueName, false, consumer);
            }
        }

        private async Task Consumer_Received(object sender, BasicDeliverEventArgs eventArgs)
        {
            var eventName = eventArgs.RoutingKey;
            var message = Encoding.UTF8.GetString(eventArgs.Body.ToArray());
            try
            {
                if (message.ToLowerInvariant().Contains("throw-fake-exception"))
                {
                    throw new InvalidOperationException($"Fake exception requested: \"{message}\"");
                }

                await ProcessEvent(eventName, message);
            }
            catch (Exception ex)
            {
                _logger.LogWarning(ex, "----- ERROR Processing message \"{Message}\"", message);
            }
            // Even on exception we take the message off the queue.
            // in a REAL WORLD app this should be handled with a Dead Letter Exchange (DLX).
            // For more information see: https://www.rabbitmq.com/dlx.html
            _consumerChannel.BasicAck(eventArgs.DeliveryTag, multiple: false);
        }

        private async Task ProcessEvent(string eventName, string message)
        {
            if (_subManager.HasSubscriptionsForEvent(eventName))
            {
                using (var scope = _autofac.BeginLifetimeScope(AUTOFAC_SCOPE_NAME))
                {
                    var subscriptions = _subManager.GetHandlersForEvent(eventName);
                    foreach (var subscription in subscriptions)
                    {
                        var handler = scope.ResolveOptional(subscription.HandlerType);
                        if (handler == null) continue;
                        var eventType = _subManager.GetEventTypeByName(eventName);
                        var integrationEvent = JsonConvert.DeserializeObject(message, eventType);
                        var concreteType = typeof(IIntegrationEventHandler<>).MakeGenericType(eventType);
                        await Task.Yield();
                        await (Task)concreteType.GetMethod("Handle").Invoke(handler, new[] { integrationEvent });
                    }
                }
            }
        }

        private IModel CreateConsumerChannel()
        {
            if (!_persistentConnection.IsConnected)
            {
                _persistentConnection.TryConnect();
            }

            _logger.LogTrace("Creating RabbitMQ consumer channel");

            var channel = _persistentConnection.CreateModel();

            channel.ExchangeDeclare(exchange: BROKER_NAME,
                type: "direct");

            channel.QueueDeclare(queue: _queueName,
                durable: true,
                exclusive: false,
                autoDelete: false,
                arguments: null);

            channel.CallbackException += (sender, ea) =>
            {
                _logger.LogWarning(ea.Exception, "Recreating RabbitMQ consumer channel");

                _consumerChannel.Dispose();
                _consumerChannel = CreateConsumerChannel();
                StartBasicConsume();
            };

            return channel;
        }

        #endregion Private function
    }
}