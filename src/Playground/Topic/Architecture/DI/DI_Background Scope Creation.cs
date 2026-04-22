using Playground.Domain;
using Microsoft.Extensions.DependencyInjection;

namespace Playground.Topic.Architecture.DI;

public class DI_Basic_Constructor_Injection : ExampleBase
{
    public DI_Basic_Constructor_Injection()
        : base("DI Basic Constructor Injection", TopicType.DI)
    {
    }

    public override void Run()
    {
        var services = new ServiceCollection();

        services.AddScoped<IEmailService, EmailService>();
        services.AddScoped<OrderService>();

        var provider = services.BuildServiceProvider();

        var service = provider.GetRequiredService<OrderService>();
        service.PlaceOrder();
    }
}

public interface IEmailService
{
    void Send(string message);
}

public class EmailService : IEmailService
{
    public void Send(string message)
    {
        Console.WriteLine($"Email sent: {message}");
    }
}

public class OrderService
{
    private readonly IEmailService _email;

    public OrderService(IEmailService email)
    {
        _email = email;
    }

    public void PlaceOrder()
    {
        _email.Send("Order Placed.");
    }
}
