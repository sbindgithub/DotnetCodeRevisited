using Playground.Domain;
using Microsoft.Extensions.DependencyInjection;

namespace Playground.Topic.Architecture.DI;



public class DI_Lifetime_Comparison : ExampleBase
{
    public DI_Lifetime_Comparison()
        : base("DI Lifetime Comparison", TopicType.DI)
    {
    }

    public override void Run()
    {
        var services = new ServiceCollection();

        services.AddTransient<DemoTransientService>();
        services.AddScoped<DemoScopedService>();
        services.AddSingleton<DemoSingletonService>();

        var provider = services.BuildServiceProvider();

        using var scope1 = provider.CreateScope();
        using var scope2 = provider.CreateScope();

        Console.WriteLine("Scope 1:");
        Print(scope1.ServiceProvider);

        Console.WriteLine("Scope 2:");
        Print(scope2.ServiceProvider);
    }

    private void Print(IServiceProvider provider)
    {
        Console.WriteLine($"Transient: {provider.GetRequiredService<TransientService>().Id}");
        Console.WriteLine($"Scoped: {provider.GetRequiredService<ScopedService>().Id}");
        Console.WriteLine($"Singleton: {provider.GetRequiredService<SingletonService>().Id}");
        Console.WriteLine();
    }
}

public class DemoTransientService
{
    public Guid Id { get; } = Guid.NewGuid();
}

public class DemoScopedService
{
    public Guid Id { get; } = Guid.NewGuid();
}

public class DemoSingletonService
{
    public Guid Id { get; } = Guid.NewGuid();
}
