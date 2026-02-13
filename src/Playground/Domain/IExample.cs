namespace Playground.Domain;

public interface IExample
{
    string Name { get; }
    TopicType Topic { get; }
    void Run();
}
