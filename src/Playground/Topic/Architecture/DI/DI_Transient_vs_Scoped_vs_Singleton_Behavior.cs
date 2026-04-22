using Playground.Domain;
using Microsoft.Extensions.DependencyInjection;

namespace Playground.Topic.Architecture.DI;

public class DI_Transient_vs_Scoped_vs_Singleton_Behavior : ExampleBase
{
    public DI_Transient_vs_Scoped_vs_Singleton_Behavior()
        : base("DI Lifetime Comparison", TopicType.DI)
    {
    }

    public override void Run()
    {
        var services = new ServiceCollection();

        services.AddTransient<TransientService>();
        services.AddScoped<ScopedService>();
        services.AddSingleton<SingletonService>();

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

public class TransientService
{
    public Guid Id { get; } = Guid.NewGuid();
}

public class ScopedService
{
    public Guid Id { get; } = Guid.NewGuid();
}

public class SingletonService
{
    public Guid Id { get; } = Guid.NewGuid();
}
