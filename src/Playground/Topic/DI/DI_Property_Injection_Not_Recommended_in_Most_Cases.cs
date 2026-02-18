using Playground.Domain;
using Microsoft.Extensions.DependencyInjection;

namespace Playground.Topic.DependencyInjection;

public class DI_Property_Injection : ExampleBase
{
    public DI_Property_Injection()
        : base("DI Property Injection Example", TopicType.DI)
    {
    }

    public override void Run()
    {
        var services = new ServiceCollection();

        services.AddScoped<IMessageService, MessageService>();
        services.AddScoped<NotificationService>();

        var provider = services.BuildServiceProvider();

        var notification = provider.GetRequiredService<NotificationService>();

        // Property injection happens manually here
        notification.MessageService = provider.GetRequiredService<IMessageService>();

        notification.Notify();
    }
}

public interface IMessageService
{
    void Send(string message);
}

public class MessageService : IMessageService
{
    public void Send(string message)
    {
        Console.WriteLine($"Message Sent: {message}");
    }
}

public class NotificationService
{
    // Property Injection
    public IMessageService? MessageService { get; set; }

    public void Notify()
    {
        if (MessageService == null)
        {
            Console.WriteLine("Dependency not set!");
            return;
        }

        MessageService.Send("Property Injection in action.");
    }
}
