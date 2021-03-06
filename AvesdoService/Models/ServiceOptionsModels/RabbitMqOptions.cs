namespace Models.Options;

public class RabbitMqOptions
{
    public string Hostname { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }
    public string ProductionQueueMessage { get; set; }
    public string SalesQueueMessage { get; set; }
}