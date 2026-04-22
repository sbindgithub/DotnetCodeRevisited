using Playground.Domain;
using System.Collections;

namespace Playground.Topic.Paradigms.FunctionalProgramming.LINQ;

public class Func_OrderPricingEngine : ExampleBase
{
    public Func_OrderPricingEngine()
        : base("Func_OrderPricingEngine Example", TopicType.Paradigms_FunctionalProgramming_Func)
    {
    }

    public override void Run()
    {
        // Traditional approach
        //decimal CalculatePrice(decimal amount, string customerType)
        //{
        //    if (customerType == "VIP")
        //        return amount * 0.8m;
        //    else if (customerType == "Festival")
        //        return amount * 0.9m;
        //    else
        //        return amount;
        //}

        decimal ProcessOrder(decimal amount, Func<decimal, decimal> pricingStrategy)
        {
            return pricingStrategy(amount);
        }

        Func<decimal, decimal> noDiscount = amt => amt;

        Func<decimal, decimal> vipDiscount = amt => amt * 0.8m;

        Func<decimal, decimal> festivalDiscount = amt => amt * 0.9m;

        var price1 = ProcessOrder(1000, vipDiscount);        // 800
        var price2 = ProcessOrder(1000, festivalDiscount);  // 900
        var price3 = ProcessOrder(1000, noDiscount);        // 1000

        Console.WriteLine($"VIP Price: {price1}");
        Console.WriteLine($"Festival Price: {price2}");
        Console.WriteLine($"Regular Price: {price3}");
    }
}
