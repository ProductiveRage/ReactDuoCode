using System;
using DuoCode.Dom;

namespace ReactDuoCodeDemo.Dispatcher
{
    public class AppDispatcher
    {
        private event EventHandler<DispatcherMessage> _dispatcher;

        public void Register(Action<DispatcherMessage> callback)
        {
            // .net has great multi-threading support for events.. but this will be translated into JavaScript in the browser where everything's single-threaded!
            _dispatcher += (sender, e) => callback(e);
        }

        public void HandleViewAction(IDispatcherAction action)
        {
            if (action == null)
                throw new ArgumentNullException("action");

            _dispatcher(null, new DispatcherMessage(MessageSourceOptions.View, action));
        }

        public void HandleServerAction(IDispatcherAction action)
        {
            if (action == null)
                throw new ArgumentNullException("action");

            _dispatcher(null, new DispatcherMessage(MessageSourceOptions.Server, action));
        }
    }
}
