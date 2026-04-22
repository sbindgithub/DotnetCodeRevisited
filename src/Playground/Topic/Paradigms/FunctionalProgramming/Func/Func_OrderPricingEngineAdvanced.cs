using Playground.Domain;
using System.Collections;

namespace Playground.Topic.Paradigms.FunctionalProgramming.LINQ;

public class Func_OrderPricingEngineAdvanced : ExampleBase
{
    public Func_OrderPricingEngineAdvanced()
        : base("Func_OrderPricingEngineAdvanced Example", TopicType.Paradigms_FunctionalProgramming_Func)
    {
    }

    class OrderContext
    {
        public decimal Amount { get; set; }
    }

    public override void Run()
    {
    Func<OrderContext, decimal> vipDiscount =  ctx => ctx.Amount > 2000 ? ctx.Amount * 0.8m : ctx.Amount;

        Func<OrderContext, decimal> bulkDiscount =
            ctx => ctx.Amount >= 500 && ctx.Amount <= 2000
                ? ctx.Amount * 0.9m
                : ctx.Amount;

        decimal Process(OrderContext ctx, List<Func<OrderContext, decimal>> rules)
        {
            foreach (var rule in rules)
            {
                ctx.Amount = rule(ctx);
            }
            return ctx.Amount;
        }

        var context = new OrderContext { Amount = 1500 };

        var rules = new List<Func<OrderContext, decimal>>
        {
            vipDiscount,
            bulkDiscount
        };

        var finalPrice = Process(context, rules);

        Console.WriteLine(finalPrice);
    }


}
