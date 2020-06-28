# React with DuoCode

This is an experimental project to see how easy (or not!) it would be to get DuoCode to work with React and the Flux architecture. Turns out that it's not too difficult at all!

There are no bindings for the React library for DuoCode at this time, so I've had to create some bare-bones bindings to illustrate how it would work. I've also had to create a small "shim" class that C# / DuoCode classes can inherit from in order to be used as React components (see [JavaScript/ReactDuoCode.js](https://github.com/ProductiveRage/ReactDuoCode/src/b82ec608b74244af964794ef4513972db39abc12/ReactDuoCode/JavaScript/ReactDuoCode.js?at=default) and [ReactBindings/ComponentWrapper.cs](https://github.com/ProductiveRage/ReactDuoCode/src/b82ec608b74244af964794ef4513972db39abc12/ReactDuoCode/ReactBindings/ComponentWrapper.cs?at=default)). From the base React library, it currently only supports React.DOM.div / span / h1 / input (and only a small subset of attributes on those element types), but hopefully it makes it clear how to add support for more elements and attributes. And, really, writing custom component classes is where the interesting logic is at.

The following is a very simple (but complete) React component, written in C#:

    using System;
    using ReactDuoCodeDemo.ReactBindings;

    namespace ReactDuoCodeDemo.Components
    {
        public class TestComponent : ComponentWrapper<TestComponent.Props>
        {
            public static Element New(Props props) { return Ele.Props(props).As<TestComponent>(); }
            private TestComponent(ComponentProps<Props> props) : base(props) { }
    
            public override Element Render()
            {
                return DOM.div(null, props.Props.Name);
            }
    
            public class Props
            {
                public Props(string name)
                {
                    if (name == null)
                        throw new ArgumentNullException("name");
                    Name = name;
                }
                public string Name { get; private set; }
            }
        }
    }

There's a little boilerplate code, with a private constructor and a static "New" factory function. And there's a slight oddity with having to access component props through "props.Props"*.. but otherwise it's fairly self explanatory.

\* *Inside React, there is some dirty manipulation of the "props" object, stripping out any non-hasOwnProperty values or functions. This is a problem if that object relies upon any functions in a prototype - which is the case with JavaScript objects that are translated from C# classes with properties - which is why the props data is automagically pushed into a child "Props" reference, since React won't try to mess with that).*

The program.cs in the DuoCode project looks like this:

    using System;
    using DuoCode.Dom;
    using ReactDuoCodeDemo.Actions;
    using ReactDuoCodeDemo.Dispatcher;
    using ReactDuoCodeDemo.Stores;

    namespace ReactDuoCodeDemo
    {
        static class Program
        {
            static void Run()
            {
                var dispatcher = new AppDispatcher();
                new SimpleExampleStore(
                    Global.window.document.getElementById("main"),
                    dispatcher
                );
                Global.window.setInterval(
                    (Action)(() => dispatcher.HandleServerAction(new TimePassedAction())),
                    500
                );
            }
        }
    }

All that's required is to instantiate an AppDispatcher and an initial Store, then to hook them up together and provide the Store with an element to render in. The "setInterval" call is just to emulate some server-side events and make the final app looks like it's doing something until you edit the input box's value.

When you *do* start the app, any changes you make to the text box are passed through the dispatcher into the store and so result in re-renders; just like the one-way-message-passing Flux architecture recommends. If you clear the input box then you get a warning message displayed, illustrating validation performed by the Store. This is all textbook React / Flux material, and it's really really easy and really really clean in DuoCode!

The AppDispatcher is as simple as:

    using System;
    using DuoCode.Dom;

    namespace ReactDuoCodeDemo.Dispatcher
    {
        public class AppDispatcher
        {
            private event EventHandler<DispatcherMessage> _dispatcher;

            public void Register(Action<DispatcherMessage> callback)
            {
                // .net has great multi-threading support for events.. but this will be translated into JavaScript
                // in the browser where everything's single-threaded (so we needn't worry about it!)
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

If you want to see how anything else works, have a look in the repo. If you know React and Flux then it should be plain-sailing, if you know React and Flux *and* C# then it should be a revelation! :D

*Note: I created this repo May 21st 2015 with the 0.6 beta version of DuoCode that says it will expire on the 30th of June this year - it's possible that some of this code will have to change when DuoCode approaches 1.0.. though, frankly, I don't expect that to be the case since all of the C#-to-JavaScript compilation process seems really solid at this point. Right now I'm most concerned about what kind of pricing structure will come into play once the beta period ends.*
