using System;

namespace MeasureupTests
{
    public class EventHandling
    {
        public delegate void UnhandledExceptionEventHandler(object sender, UnhandledExceptionEventArgs e);

        public event EventHandler<UnhandledExceptionEventHandler> MyEventHandler;

        public EventHandling()
        {
            MyEventHandler = HandleApplicationError;
        }

        private void HandleApplicationError(object sender, UnhandledExceptionEventHandler unhandledException)
        {
            unhandledException(sender, new UnhandledExceptionEventArgs(new Exception(), true));
        }

        protected virtual void OnMyEventHandler(UnhandledExceptionEventHandler e)
        {
            var handler = MyEventHandler;
            if (handler != null) handler(this, e);  
        }
    }
}