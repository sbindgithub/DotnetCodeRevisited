using Playground.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Playground.Topic.Paradigms.OOP.Abstraction.Interface
{
    internal class OOP_Abstraction_Interface_Delegate : ExampleBase
    {
        //void Handler(object sender, TEventArgs e) // Shape of an event handler
        public OOP_Abstraction_Interface_Delegate()
            : base("Interface Delegate Example", TopicType.OOP_Abstraction)
        {
        }

        public class NotificationEventArgs : EventArgs
        {
            public string Message { get; set; }
        }

        public interface INotifier
        {
            // Delegate declaration
            public delegate void NotifyHandler(string message);

            // Event using that delegate
            event NotifyHandler NotificationRaised;
        }

        public class NotificationService : INotifier
        {
            public event INotifier.NotifyHandler NotificationRaised;

            public void Raise(string message)
            {
                NotificationRaised?.Invoke(message);
            }
        }

        public class EmailService
        {
            public void Subscribe(INotifier notifier)
            {
                notifier.NotificationRaised += HandleNotification;
            }

            private void HandleNotification(string message)
            {
                Console.WriteLine($"Email sent: {message}");
            }
        }

        public class SmsService
        {
            public void Subscribe(INotifier notifier)
            {
                notifier.NotificationRaised += HandleNotification;
            }

            private void HandleNotification(string message)
            {
                Console.WriteLine($"SMS sent: {message}");
            }
        }

        public class LoggingService
        {
            public void Subscribe(INotifier notifier)
            {
                notifier.NotificationRaised += HandleNotification;
            }

            private void HandleNotification(string message)
            {
                Console.WriteLine($"Logged: {message}");
            }
        }

        public override void Run()
        {
            INotifier notifier = new NotificationService();

            var email = new EmailService();
            var sms = new SmsService();
            var log = new LoggingService();

            email.Subscribe(notifier);
            sms.Subscribe(notifier);
            log.Subscribe(notifier);

            ((NotificationService)notifier).Raise("Order placed");
        }
    }
}
