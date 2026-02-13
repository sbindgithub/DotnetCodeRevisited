using Playground.Domain;

namespace Playground.LINQ;

public class LINQ_Projection_SelectMany : ExampleBase
{
    public LINQ_Projection_SelectMany()
        : base("LINQ_Projection_SelectMany Example", TopicType.LINQ)
    {
    }

    public override void Run()
    {
        var list = new List<List<int>>
                    {
                        new List<int> { 1, 2 },
                        new List<int> { 3, 4 },
                        new List<int> { 5 }
                    };

        var flatList = list.SelectMany(x => x).ToList();

        foreach (var n in flatList)
            Console.WriteLine(n);
    }
}
