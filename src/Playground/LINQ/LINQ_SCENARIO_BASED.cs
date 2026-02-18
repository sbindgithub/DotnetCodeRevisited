using Playground.Domain;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Globalization;
using System.Numerics;
using System.Runtime.ConstrainedExecution;
using System.Xml.Linq;

namespace Playground.LINQ;

public class LINQ_SCENARIO_BASED : ExampleBase
{
    public LINQ_SCENARIO_BASED()
        : base("LINQ_SCENARIO_BASED Example", TopicType.LINQ)
    {
    }

    class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public bool IsActive { get; set; }
    }

    public override void Run()
    {
        //Scenario 1 — Projection Optimization (Very Common)
        //Requirement:
        //Return only Name and Email of users whose name starts with "A".
        //Write the most efficient LINQ query using EF.

        var aUsers = new List<User>
        {
             new User { Id = 1, Name = "Alice", Email = "a@b.c", Address = "123 Main St", Phone = "555-1234",IsActive=false },
             new User { Id = 2, Name = "Bob", Email = "b@b.c", Address = "456 Elm St", Phone = "555-5678",IsActive=true },
             new User { Id = 3, Name = "Anna", Email = "a2@b.c", Address = "789 Oak St", Phone = "555-9012",IsActive=true }
        };

        var result = aUsers
            .Where(u => u.Name.StartsWith("A"))
            .Select(u => new { u.Name, u.Email })
            .ToList();

        foreach (var user in result)
        {
            Console.WriteLine($"Name: {user.Name}, Email: {user.Email}");
        }

        //Scenario 2 — Prevent Double Database Hit
        var users1 = aUsers.Where(u => u.IsActive);

        if (users1.Any())
        {
            foreach (var user in users1)
            {
                Console.WriteLine(user.Name);
            }
        }

        //The real problem:
        //Any() executes one SQL query.
        //The foreach executes another SQL query.
        //You are hitting the database twice.
        //Your rewrite still causes unnecessary Any() check after materialization.

        var users2 = aUsers
                        .Where(u => u.IsActive)
                        .ToList();

        foreach (var user in users2)
        {
            Console.WriteLine(user.Name);
        }



        Console.WriteLine("Scenario 3 — Pagination(Architect Level)");
        Console.WriteLine("Requirement:");
        Console.WriteLine("Get page 3 of users with page size 10.");
        Console.WriteLine("Sorted by Name ascending.");
        Console.WriteLine("Write the correct LINQ query.");
        Console.WriteLine("Pagination formula:");
        Console.WriteLine("Skip = (PageNumber - 1) * PageSize");
        Console.WriteLine("Page 3, size 10:");
        Console.WriteLine("Skip = (3 - 1) * 10 = 20");
        Console.WriteLine("Correct query:");

        var page3 = aUsers
                       .OrderBy(u => u.Name)
                       .Skip(20)
                       .Take(10)
                       .ToList();

        //Scenario 4 — Avoid Loading Entire Table (Trap)
        var users = aUsers.ToList();
        var filtered = users.Where(u => u.IsActive == true);
        //Why is this bad?   Rewrite properly.

        Console.WriteLine("Option A Analysis:");
        Console.WriteLine("Using Include(u => u.Orders) loads full Orders collection for each user.");
        Console.WriteLine("This may result in large JOIN operations and duplicate row expansion.");
        Console.WriteLine("Even though we only need OrderCount, full order data may be fetched.");
        Console.WriteLine("Higher memory usage and unnecessary data transfer.");

        Console.WriteLine("");

        Console.WriteLine("Option B Analysis:");
        Console.WriteLine("No Include is used.");
        Console.WriteLine("Only a correlated subquery COUNT(*) is generated in SQL.");
        Console.WriteLine("No full Orders collection is loaded.");
        Console.WriteLine("Lower memory usage and better performance.");

        Console.WriteLine("");

        Console.WriteLine("Conclusion:");
        Console.WriteLine("Option B is more efficient because it avoids loading related entities.");
        Console.WriteLine("Always avoid Include when you only need aggregates like Count().");
        Console.WriteLine("Correct rewrite:");
        var users3 = aUsers
                                .Where(u => u.IsActive ==true)
                                .ToList();

        Console.WriteLine("Scenario 5 — Complex Business Rule");
        Console.WriteLine("You must filter users using:");

        bool IsPremium(User u)
        {
            return u.Name.Length > 1000 &&
                   u.Phone != "";
        }

        //var users = context.Users
        //                    .Where(u => u.SubscriptionAmount > 1000 &&
        //                                u.CreatedDate.Year >= 2023)
        //                    .ToList();
        Console.WriteLine("It fails because:");

        Console.WriteLine("context.Users is IQueryable<User>.");

        Console.WriteLine("Where builds an expression tree.");

        Console.WriteLine("EF must translate the entire expression to SQL.");

        Console.WriteLine("IsPremium(u) is a custom C# method.");

        Console.WriteLine("EF cannot translate arbitrary method bodies.");

        Console.WriteLine("Result: runtime translation exception.");

        Console.WriteLine("This is not about \"inline methods are not ideal.\"");

        Console.WriteLine("It is about expression tree translation boundaries.");

    }
}

