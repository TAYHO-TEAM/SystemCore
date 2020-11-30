using Microsoft.Extensions.Logging;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using RabbitMQ.Client.Exceptions;
using System;
using System.IO;
using System.Net.Sockets;
using Polly;

namespace EventBus.RabbitMQ
{
    public class DefaultRabbitMQPersistentConnection : IRabbitMQPersistentConnection
    {
        private readonly IConnectionFactory _connectionFactory;
        private readonly ILogger<DefaultRabbitMQPersistentConnection> _logger;
        private readonly int _retryCount;
        private IConnection _connection;
        private bool _disposed;
        private object sync_root = new object();

        public DefaultRabbitMQPersistentConnection(IConnectionFactory connectionFactory, ILogger<DefaultRabbitMQPersistentConnection> logger, int retryCount = 5)
        {
            _connectionFactory = connectionFactory ?? throw new ArgumentNullException(nameof(connectionFactory));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _retryCount = retryCount;
        }

        public void Dispose()
        {
            if (_disposed) return;
            _disposed = true;
            try
            {
                _connection.Dispose();
            }
            catch (IOException ex)
            {
                _logger.LogCritical(ex.ToString());
            }
        }

        public bool IsConnected => _connection != null && _connection.IsOpen && !_disposed;

        public bool TryConnect()
        {
            lock (sync_root)
            {
                var policy = Policy.Handle<SocketException>()
                    .Or<BrokerUnreachableException>()
                    .WaitAndRetry(_retryCount, retryAttempt => TimeSpan.FromSeconds(Math.Pow(2, retryAttempt)),
                        (ex, time) =>
                        {
                            _logger.LogWarning(ex, "RabbitMQ Client could not connect after {TimeOut}s ({ExceptionMessage})", $"{time.TotalSeconds:n1}", ex.Message);
                        });
                policy.Execute(() => { _connection = _connectionFactory.CreateConnection(); });
                if (IsConnected)
                {
                    _connection.ConnectionBlocked += OnConnectedBlocked;
                    _connection.CallbackException += OnCallbackException;
                    _connection.ConnectionShutdown += OnConnectionShutdown;
                    return true;
                }
                _logger.LogCritical("ERROR: RabbitMQ connections could not be created and opened");
                return false;
            }
        }

        public IModel CreateModel()
        {
            if (!IsConnected)
            {
                throw new InvalidOperationException("");
            }
            return _connection.CreateModel();
        }

        private void OnConnectedBlocked(object sender, ConnectionBlockedEventArgs args)
        {
            if (!_disposed) return;
            _logger.LogWarning("A RabbitMQ connection is shutdown. Trying to re-connect...");
            TryConnect();
        }

        private void OnCallbackException(object sender, CallbackExceptionEventArgs args)
        {
            if (!_disposed) return;
            _logger.LogWarning("A RabbitMQ connection throw exception. Trying to re-connect...");
            TryConnect();
        }

        private void OnConnectionShutdown(object sender, ShutdownEventArgs args)
        {
            if (!_disposed) return;
            _logger.LogWarning("A RabbitMQ connection is on shutdown. Trying to re-connect...");
            TryConnect();
        }
    }
}