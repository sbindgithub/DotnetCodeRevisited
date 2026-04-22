using Playground.Domain;
using Microsoft.Extensions.DependencyInjection;

namespace Playground.Topic.Architecture.DI;


public class DI_Strategy_Pattern : ExampleBase
{
    public DI_Strategy_Pattern()
        : base("DI Strategy Pattern", TopicType.DI)
    {
    }

    public override void Run()
    {
        var services = new ServiceCollection();

        services.AddScoped<IPaymentService, CreditCardPayment>();
        services.AddScoped<IPaymentService, UpiPayment>();
        services.AddScoped<CheckoutService>();

        var provider = services.BuildServiceProvider();

        var checkout = provider.GetRequiredService<CheckoutService>();
        checkout.Process("UPI", 1000);
    }
}

public interface IPaymentService
{
    string Method { get; }
    void Pay(decimal amount);
}

public class CreditCardPayment : IPaymentService
{
    public string Method => "Card";

    public void Pay(decimal amount)
    {
        Console.WriteLine($"Paid {amount} via Card");
    }
}

public class UpiPayment : IPaymentService
{
    public string Method => "UPI";

    public void Pay(decimal amount)
    {
        Console.WriteLine($"Paid {amount} via UPI");
    }
}

public class CheckoutService
{
    private readonly IEnumerable<IPaymentService> _services;

    public CheckoutService(IEnumerable<IPaymentService> services)
    {
        _services = services;
    }

    public void Process(string method, decimal amount)
    {
        var service = _services.First(x => x.Method == method);
        service.Pay(amount);
    }
}
