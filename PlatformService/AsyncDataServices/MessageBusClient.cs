using System.Text;
using System.Text.Json;
using PlatformService.Dtos;
using RabbitMQ.Client;

namespace PlatformService.AsyncDataServices
{
    public class MessageBusClient : IMessageBusClient
    {
        private readonly IConfiguration? _configuration;
        private readonly IConnection? _connection;
        private readonly IModel? _channel;

        public MessageBusClient(IConfiguration configuration)
        {
            this._configuration = configuration;
            var factory = new ConnectionFactory()
            {
                HostName = _configuration["RabbitMQHost"],
                Port = int.Parse(_configuration["RabbitMQPort"])
            };
            try
            {
                _connection = factory.CreateConnection();
                _channel = _connection.CreateModel();

                _channel.ExchangeDeclare(exchange: "trigger", type: ExchangeType.Fanout);

                _connection.ConnectionShutdown += RabbitMQ_ConnectionShutdown;

                System.Console.WriteLine("--> Connected to MessageBus");
            }
            catch (System.Exception ex)
            {

                System.Console.WriteLine($"--> Could not connect to the Message Bus: {ex.Message}");
            }
        }

        private void RabbitMQ_ConnectionShutdown(object? sender, ShutdownEventArgs e)
        {
            System.Console.WriteLine($"--> RabbitMQ Connection Shutdown");
        }

        public void PublishNewPlatform(PlatformPublishedDto platformPublishedDto)
        {
            var message = JsonSerializer.Serialize(platformPublishedDto);

            if (_connection?.IsOpen ?? false)
            {
                System.Console.WriteLine("--> RebbitMQ connection open sending message...");
                SendMessage(message);
            }
            else
            {
                System.Console.WriteLine("--> RabbitMQ connection closed, not sending");
            }
        }

        public void Dispose()
        {
            System.Console.WriteLine("--> Message disposed");
            if (_channel?.IsOpen ?? false)
            {
                _channel.Close();
                _connection?.Close();
            }
        }

        void SendMessage(string message)
        {
            var body = Encoding.UTF8.GetBytes(message);

            _channel.BasicPublish(exchange: "trigger", routingKey: "", basicProperties: null, body: body);

            System.Console.WriteLine($"--> We have sent {message}");
        }
    }
}