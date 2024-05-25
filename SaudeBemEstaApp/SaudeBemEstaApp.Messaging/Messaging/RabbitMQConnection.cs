using RabbitMQ.Client;
using System;

public class RabbitMQConnection : IDisposable
{
    private readonly IConnection _connection;
    private readonly IModel _channel;

    public RabbitMQConnection(string hostname)
    {
        var factory = new ConnectionFactory() { HostName = hostname };
        try
        {
            _connection = factory.CreateConnection();
            _channel = _connection.CreateModel();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"RabbitMQ Connection Error: {ex.Message}");
            throw;
        }
    }

    // Propriedade pública para acessar o canal
    public IModel Channel => _channel;

    // Publicar mensagens em uma exchange específica
    public void PublishMessage(string exchange, string routingKey, byte[] messageBody)
    {
        _channel.BasicPublish(exchange: exchange, routingKey: routingKey, basicProperties: null, body: messageBody);
    }

    // Método para configurar uma exchange de fanout
    public void SetupFanoutExchange(string exchangeName)
    {
        _channel.ExchangeDeclare(exchange: exchangeName, type: "fanout", durable: true, autoDelete: false);
    }

    // Limpar recursos
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
