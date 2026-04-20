using Playground.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Playground.Topic.OOP.Abstraction.Interface
{
    internal class OOP_Abstraction_Interface_Event : ExampleBase
    {
        //void Handler(object sender, TEventArgs e) // Shape of an event handler
        public OOP_Abstraction_Interface_Event()
            : base("Interface Event Example", TopicType.OOP_Abstraction)
        {
        }

        public class NotificationEventArgs : EventArgs
        {
            public string Message { get; set; }
        }

        public interface INotifier
        {
            event EventHandler<NotificationEventArgs> NotificationRaised;
        }

        public class NotificationService : INotifier
        {
            public event EventHandler<NotificationEventArgs> NotificationRaised;

            public void RaiseNotification(NotificationEventArgs e) => NotificationRaised?.Invoke(this, e);
        }

        public class EmailService
        {
            public void Subscribe(INotifier notifier)
            {
                notifier.NotificationRaised += HandleNotification;
            }

            private void HandleNotification(object sender, NotificationEventArgs e)
            {
                Console.WriteLine($"Email sent: {e.Message}");
            }
        }

        public class SmsService
        {
            public void Subscribe(INotifier notifier)
            {
                notifier.NotificationRaised += HandleNotification;
            }

            private void HandleNotification(object sender, NotificationEventArgs e)
            {
                Console.WriteLine($"SMS sent: {e.Message}");
            }
        }

        public class LoggingService
        {
            public void Subscribe(INotifier notifier)
            {
                notifier.NotificationRaised += HandleNotification;
            }

            private void HandleNotification(object sender, NotificationEventArgs e)
            {
                Console.WriteLine($"Logged: {e.Message}");
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

            NotificationEventArgs eventArgs = new NotificationEventArgs { Message = "Order placed" };
            ((NotificationService)notifier).RaiseNotification(eventArgs);
        }
    }
}
