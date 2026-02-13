namespace Playground.Domain;

public abstract class ExampleBase : IExample
{
    public string Name { get; }
    public TopicType Topic { get; }

    protected ExampleBase(string name, TopicType topic)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Example name required");

        Name = name;
        Topic = topic;
    }

    public abstract void Run();
}
