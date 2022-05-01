﻿using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Models.Options;
using RabbitMQ.Client;
using Services.MessageQueueHandlerService;

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

    public void SendReservationSuccessMessage()
    {
        throw new NotImplementedException();
    }
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        throw new NotImplementedException();
    }

    public void SendProductionQueueMessage()
    {
        throw new NotImplementedException();
    }

    public void SendSalesQueueMessage()
    {
        throw new NotImplementedException();
    }
}