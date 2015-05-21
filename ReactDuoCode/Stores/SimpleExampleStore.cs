using System;
using DuoCode.Dom;
using ReactDuoCodeDemo.Actions;
using ReactDuoCodeDemo.Dispatcher;
using ReactDuoCodeDemo.ReactBindings;
using ReactDuoCodeDemo.ReactBindings.Attributes;

namespace ReactDuoCodeDemo.Stores
{
    public class SimpleExampleStore
    {
        private readonly HTMLElement _renderContainer;
        private readonly AppDispatcher _dispatcher;
        private ViewModel _viewModel;
        public SimpleExampleStore(HTMLElement renderContainer, AppDispatcher dispatcher)
        {
            if (renderContainer == null)
                throw new ArgumentNullException("renderContainer");
            if (dispatcher == null)
                throw new ArgumentNullException("dispatcher");

            _renderContainer = renderContainer;
            _dispatcher = dispatcher;
            _viewModel = new ViewModel(lastUpdated: DateTime.Now, message: "Hi!", validationError: "");
            RenderIfActive();

            _dispatcher.Register(message =>
            {
                var recordChange = message.Action as RecordChangeAction<ViewModel>;
                if (recordChange != null)
                {
                    UserEdit(recordChange.Value);
                    return;
                }

                if (message.Action is TimePassedAction)
                {
                    _viewModel = new ViewModel(lastUpdated: DateTime.Now, message: _viewModel.Message, validationError: _viewModel.ValidationError);
                    RenderIfActive();
                    return;
                }
            });
        }

        private void UserEdit(ViewModel viewModel)
        {
            if (viewModel == null)
                throw new ArgumentNullException("viewModel");

            _viewModel = viewModel;
            RenderIfActive();
        }

        private void RenderIfActive()
        {
            React.Render(
                DOM.div(
                    null,
                    DOM.h1(null, "React in DuoCode"),
                    DOM.span(new HTMLAttributes { className = "time" }, _viewModel.LastUpdated),
                    DOM.input(new InputAttributes { className = "message", value = _viewModel.Message, onChange = ev => UpdateMessage(ev.target.value) }),
                    DOM.span(new HTMLAttributes { className = "error" }, _viewModel.ValidationError)
                ),
                _renderContainer
            );
        }

        private void UpdateMessage(string message)
        {
            if (message == null)
                throw new ArgumentNullException("message");

            _dispatcher.HandleViewAction(new RecordChangeAction<ViewModel>(
                new ViewModel(lastUpdated: DateTime.Now, message: message, validationError: (message.Trim() == "") ? "Why no message??" : "")
            ));
        }

        private class ViewModel
        {
            public ViewModel(DateTime lastUpdated, string message, string validationError)
            {
                if (message == null)
                    throw new ArgumentNullException("message");
                if (validationError == null)
                    throw new ArgumentNullException("validationError");

                LastUpdated = GetTimeString(lastUpdated);
                Message = message;
                ValidationError = validationError;
            }

            /// <summary>
            /// This will never be null
            /// </summary>
            public string LastUpdated { get; private set; }

            /// <summary>
            /// This will never be null
            /// </summary>
            public string Message { get; private set; }

            /// <summary>
            /// This will never be null
            /// </summary>
            public string ValidationError { get; private set; }

            private static string GetTimeString(DateTime value)
            {
                // Can't use value.Format("yyyy-MM-dd") since it's not defined in DuoCode's base library
                return string.Format(
                    "{0}:{1}:{2}",
                    value.Hour,
                    (value.Minute < 10 ? "0" : "") + value.Minute,
                    (value.Second < 10 ? "0" : "") + value.Second
                );
            }
        }
    }
}