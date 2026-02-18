using Playground.Domain;
using Microsoft.Extensions.DependencyInjection;

namespace Playground.Topic.DependencyInjection;

public class DI_Singleton_With_Transient : ExampleBase
{
    public DI_Singleton_With_Transient()
        : base("Singleton Depending on Transient", TopicType.DI)
    {
    }

    public override void Run()
    {
        var services = new ServiceCollection();

        services.AddTransient<IGuidGenerator, GuidGenerator>();
        services.AddSingleton<ReportService>();

        var provider = services.BuildServiceProvider();

        var report1 = provider.GetRequiredService<ReportService>();
        var report2 = provider.GetRequiredService<ReportService>();

        report1.Print();
        report2.Print();
    }
}

public interface IGuidGenerator
{
    Guid Generate();
}

public class GuidGenerator : IGuidGenerator
{
    public Guid Generate() => Guid.NewGuid();
}

public class ReportService
{
    private readonly IGuidGenerator _generator;

    public ReportService(IGuidGenerator generator)
    {
        _generator = generator;
    }

    public void Print()
    {
        Console.WriteLine($"Report ID: {_generator.Generate()}");
    }
}
