using RabbitMQ.Client;
using System;
using System.Text.Json;

public class RabbitMQPublisher : IDisposable
{
    private readonly IConnection _connection;
    private readonly IModel _channel;

    public RabbitMQPublisher(string hostname)
    {
        var factory = new ConnectionFactory() { HostName = hostname };
        try
        {
            _connection = factory.CreateConnection();
            _channel = _connection.CreateModel();
            _channel.ExchangeDeclare("domain_events", ExchangeType.Fanout, durable: true, autoDelete: false);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Failed to connect or create a channel: {ex.Message}");
            throw;
        }
    }

    public void Publish<T>(T message)
    {
        var body = JsonSerializer.SerializeToUtf8Bytes(message);
        _channel.BasicPublish(exchange: "domain_events", routingKey: "", basicProperties: null, body: body);
    }

    public void Dispose()
    {
        if (_channel.IsOpen)
        {
            _channel.Close();
        }
        if (_connection.IsOpen)
        {
            _connection.Close();
        }
    }
}
