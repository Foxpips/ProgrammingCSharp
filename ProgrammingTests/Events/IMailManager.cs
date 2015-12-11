using System;
using System.Threading;
using NUnit.Framework;
using Rhino.Mocks;

namespace ProgrammingTests.Events
{
    public static class EventExtensions
    {
        public static void Raise<TEventArgs>(this EventHandler<TEventArgs> eventHandler, object sender, TEventArgs args)
        {
            var handler = Volatile.Read(ref eventHandler);
            if (handler != null)
            {
                handler(sender, args);
            }
        }
    }

    public abstract class MailManagerBase
    {
        protected abstract void InvokeMailEvent(EmailEventArgs args);
    }

    public class EmailEventArgs : EventArgs
    {
        public string EmailTitle { get; set; }
        public string EmailContent { get; set; }
    }

    public class MailServer : MailManagerBase
    {
        public event EventHandler<EmailEventArgs> MailEvent;

        protected override void InvokeMailEvent(EmailEventArgs args)
        {
            MailEvent.Raise(this, args);
        }

        public void GetMail(EmailEventArgs args)
        {
            Console.WriteLine("Sending/Receiving...");
            InvokeMailEvent(args);
        }
    }

    public class HomeMail
    {
        private readonly Action<string, string> _print = (s, s1) => Console.WriteLine("{0},{1}", s, s1);

        public void ListenForMail(MailServer server)
        {
            server.MailEvent += (sender, args) => _print("You've got Mail " + args.EmailTitle, args.EmailContent);
        }
    }

    public class TestMailManagerEvent
    {
        [Test]
        public void Mail_HomeMail_InvokeMailEvent()
        {
            var mailServer = new MailServer();
            var homeMail = new HomeMail();
            homeMail.ListenForMail(mailServer);

            mailServer.GetMail(new EmailEventArgs {EmailContent = "Email Content", EmailTitle = "Email Title"});
        }
    }
}