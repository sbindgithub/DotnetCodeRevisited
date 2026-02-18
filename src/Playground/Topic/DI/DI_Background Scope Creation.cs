using Playground.Domain;
using Microsoft.Extensions.DependencyInjection;

namespace Playground.Topic.DependencyInjection;

public class DI_Background_Scope : ExampleBase
{
    public DI_Background_Scope()
        : base("DI Background Scope Creation", TopicType.DI)
    {
    }

    public override void Run()
    {
        var services = new ServiceCollection();

        services.AddScoped<FakeDbContext>();
        services.AddSingleton<BackgroundJob>();

        var provider = services.BuildServiceProvider();

        var job = provider.GetRequiredService<BackgroundJob>();
        job.Execute(provider);
    }
}

public class FakeDbContext
{
    public Guid Id { get; } = Guid.NewGuid();
}

public class BackgroundJob
{
    public void Execute(IServiceProvider provider)
    {
        using var scope = provider.CreateScope();
        var db = scope.ServiceProvider.GetRequiredService<FakeDbContext>();

        Console.WriteLine($"DbContext Instance: {db.Id}");
    }
}
