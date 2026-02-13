using Playground.Domain;
using Playground.LINQ;
using Playground.Collections;

namespace Playground.Infrastructure;

public static class ExampleRegistry
{
    public static List<IExample> GetAll()
    {
        return new List<IExample>
        {
            new SelectExample(),
            new ListExample()
        };
    }
}
