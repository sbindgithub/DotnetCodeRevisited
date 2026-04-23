using Playground.Domain;
using System.Collections;
using System.Collections.Concurrent;
using System.Diagnostics;

namespace Playground.Topic.Paradigms.FunctionalProgramming.LINQ;

public class DataParallelism_OrderProcessing : ExampleBase
{
    public DataParallelism_OrderProcessing()
        : base("DataParallelism_OrderProcessing Example", TopicType.DataParallelism_OrderProcessing)
    {
    }

    public override void Run()
    {
        #region // 1. Sequential version (baseline)

        //var orders = Enumerable.Range(1, 10000)
        //                   .Select(i => new Order { Id = i, Amount = 100 + i })
        //                   .ToList();

        //var results = new List<decimal>();

        //var sw = Stopwatch.StartNew();

        //foreach (var order in orders)
        //{
        //    var final = ProcessOrder(order);
        //    results.Add(final);
        //}

        //sw.Stop();
        //Console.WriteLine($"Sequential Time: {sw.ElapsedMilliseconds} ms");

        #endregion

        #region // 2. Parallel version

        var orders = Enumerable.Range(1, 10000)
                          .Select(i => new Order { Id = i, Amount = 100 + i })
                          .ToList();

        var results = new ConcurrentBag<decimal>();

        var sw = Stopwatch.StartNew();

        Parallel.ForEach(orders, order =>
        {
            var final = ProcessOrder(order);
            results.Add(final);
        });

        sw.Stop();
        Console.WriteLine($"Parallel Time: {sw.ElapsedMilliseconds} ms");

        #endregion
    }


    public class Order
    {
        public int Id { get; set; }
        public decimal Amount { get; set; }
    }

    private decimal ProcessOrder(Order order)
    {
        // Simulate heavy computation
        decimal tax = order.Amount * 0.18m;

        var sqrt = (decimal)Math.Sqrt((double)order.Amount);

        for (int i = 0; i < 1000; i++)
        {
            tax += sqrt;
        }

        decimal discount = order.Amount > 500 ? order.Amount * 0.1m : 0;

        return order.Amount + tax - discount;
    }
}
