using Playground.Domain;
using Microsoft.Extensions.DependencyInjection;

namespace Playground.Topic.DependencyInjection;

public class DI_Method_Injection : ExampleBase
{
    public DI_Method_Injection()
        : base("DI Method Injection Example", TopicType.DI)
    {
    }

    public override void Run()
    {
        var services = new ServiceCollection();

        services.AddScoped<ILoggerService, LoggerService>();
        services.AddScoped<ReportProcessor>();

        var provider = services.BuildServiceProvider();

        var processor = provider.GetRequiredService<ReportProcessor>();
        var logger = provider.GetRequiredService<ILoggerService>();

        processor.ProcessReport(logger);
    }
}

public interface ILoggerService
{
    void Log(string message);
}

public class LoggerService : ILoggerService
{
    public void Log(string message)
    {
        Console.WriteLine($"LOG: {message}");
    }
}

public class ReportProcessor
{
    // Method Injection
    public void ProcessReport(ILoggerService logger)
    {
        logger.Log("Processing report...");
        Console.WriteLine("Report processed.");
    }
}
