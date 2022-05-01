using System.Text;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Models.MessageQueueModels;
using Models.Options;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using Services.MessageQueueHandlerService;
using StaticData;

namespace Services.RabbitMqService;

public class RabbitMqService : BackgroundService, IRabbitMqService
{
    private readonly RabbitMqOptions _rabbitMqOptions;
    private readonly IMessageQueueHandler _messageQueueHandler;
    private IConnection _connection;
    private IModel _channel;
    public RabbitMqService(IOptions<RabbitMqOptions> options, IMessageQueueHandler messageQueueHandler)
    {
        _messageQueueHandler = messageQueueHandler;
        _rabbitMqOptions = options.Value;
    }

    protected override Task ExecuteAsync(CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();
        var factory = new ConnectionFactory()
        {
            HostName = _rabbitMqOptions.Hostname,
            UserName = _rabbitMqOptions.Username,
            Password = _rabbitMqOptions.Password
        };

        _connection = factory.CreateConnection();

        _channel = _connection.CreateModel();
        _channel.QueueDeclare(RabbitMqConstants.ProductionQueueMessage, false, false, false);

        var consumer = new EventingBasicConsumer(_channel);
        consumer.Received += (channel, message) =>
        {
            var messageContent = Encoding.UTF8.GetString(message.Body.ToArray());
            var ProductionQueueMessage = JsonConvert.DeserializeObject<ProductionQueueMessage>(messageContent);

            _messageQueueHandler.ProductUpdatesQueueMessageHandler(ProductionQueueMessage, cancellationToken).GetAwaiter().GetResult();

            _channel.BasicAck(message.DeliveryTag, false);
        };
        _channel.BasicConsume(RabbitMqConstants.ProductionQueueMessage, false, consumer);
        return Task.CompletedTask;
    }

    public void CreateConnection()
    {
        var factory = new ConnectionFactory()
        {
            HostName = _rabbitMqOptions.Hostname,
            UserName = _rabbitMqOptions.Username,
            Password = _rabbitMqOptions.Password
        };
        _connection = factory.CreateConnection();
    }
    public bool ConnectionExists()
    {
        while (true)
        {
            if (_connection is not null)
            {
                return true;
            }

            CreateConnection();
        }
    }
    public void SendSalesQueueMessage(SalesQueueMessage message)
    {
        if (!ConnectionExists()) return;

        using var channel = _connection.CreateModel();
        channel.QueueDeclare(RabbitMqConstants.SalesQueueMessage, false, false, false);

        var jsonContent = JsonConvert.SerializeObject(message);
        var body = Encoding.UTF8.GetBytes(jsonContent);

        channel.BasicPublish("", RabbitMqConstants.SalesQueueMessage, null, body);
    }
}