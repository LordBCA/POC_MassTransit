
namespace POC_MassTransit.Infrastructure.Messaging;

public class MessageBrokerOptions
{
    public string Service { get; set; }
    public string ConnectionString { get; set; }
    public string Host { get; set; }
    public string UserName { get; set; }
    public string Password { get; set; }
}
