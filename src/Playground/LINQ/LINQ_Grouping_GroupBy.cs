using Playground.Domain;
using System.Collections;

namespace Playground.LINQ;

public class LINQ_Grouping_GroupBy : ExampleBase
{
    public LINQ_Grouping_GroupBy()
        : base("LINQ_Grouping_GroupBy Example", TopicType.LINQ)
    {
    }

    public override void Run()
    {
        //Write a LINQ query to group words by their first letter.
        var words = new List<string>
                        {
                            "apple",
                            "banana",
                            "apricot",
                            "blueberry"
                        };

        var grouped = words.GroupBy(w => w[0]);

        foreach (var group in grouped)
        {
            Console.WriteLine(group.Key);
        }

    }
}
