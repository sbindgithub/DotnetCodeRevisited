using Playground.Domain;
using System.Collections;
using System.ComponentModel.DataAnnotations;

namespace Playground.Topic.Paradigms.FunctionalProgramming.LINQ;

public class Dictionary_Class_Driven : ExampleBase
{
    public Dictionary_Class_Driven()
        : base("Dictionary_Class_Driven Example", TopicType.Paradigms_FunctionalProgramming_Func)
    {
    }

    public override void Run()
    {
        // Step 1: Dictionary with concrete classes
        Dictionary<string, object> handlers = new()
        {
            { "EMAIL", new EmailSender() },
            { "SMS", new SmsSender() },
            { "PUSH", new PushNotificationSender() }
        };

        // Step 2: Input
        string type = "SMS";
        string message = "Order shipped";

        // Step 3: Resolve and execute
        if (handlers.TryGetValue(type, out var handler))
        {
            // Manual casting required
            if (handler is EmailSender email)
                email.Send(message);

            else if (handler is SmsSender sms)
                sms.Send(message);

            else if (handler is PushNotificationSender push)
                push.Send(message);
        }
        else
        {
            Console.WriteLine("Invalid notification type");
        }
    }

    public class EmailSender
    {
        public void Send(string message)
        {
            Console.WriteLine($"Email sent: {message}");
        }
    }

    public class SmsSender
    {
        public void Send(string message)
        {
            Console.WriteLine($"SMS sent: {message}");
        }
    }

    public class PushNotificationSender
    {
        public void Send(string message)
        {
            Console.WriteLine($"Push notification sent: {message}");
        }
    }
}


