using Microsoft.Graph.Models;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using ServiceStack;
using System;
using System.Text;
using System.Text.Json;

public class GenericConsumer
{
    private readonly IService _service;
    private IConnection _connection;
    private IModel _channel;

    public class EventMessage
    {
        public string EventType { get; set; }
        public int PatientId { get; set; }  // Supondo que as mensagens incluam um ID de paciente.
    }

    public interface IService
    {
        void HandleEvent(EventMessage message);
    }

    public GenericConsumer(IService service, string hostname)
    {
        _service = service;
        var factory = new ConnectionFactory() { HostName = hostname };
        _connection = factory.CreateConnection();
        _channel = _connection.CreateModel();

        _channel.ExchangeDeclare(exchange: "domain_events", type: "fanout");
        var queueName = _channel.QueueDeclare().QueueName;
        _channel.QueueBind(queue: queueName, exchange: "domain_events", routingKey: "");

        var consumer = new EventingBasicConsumer(_channel);
        consumer.Received += OnEventReceived;
        _channel.BasicConsume(queue: queueName, autoAck: true, consumer: consumer);
    }

    private void OnEventReceived(object sender, BasicDeliverEventArgs e)
    {
        var body = e.Body.ToArray();
        var message = Encoding.UTF8.GetString(body);

        try
        {
            var eventMessage = JsonSerializer.Deserialize<EventMessage>(message);
            if (eventMessage != null && eventMessage.EventType == "PatientCreated")
            {
                ProcessEvent(eventMessage);
            }
        }
        catch (JsonException ex)
        {
            Console.WriteLine($"JSON Error: {ex.Message}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error processing message: {ex.Message}");
        }
    }


    private void ProcessEvent(EventMessage message)
    {
        _service.HandleEvent(message);
    }
}
