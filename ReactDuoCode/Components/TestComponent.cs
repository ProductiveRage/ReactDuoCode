using System;
using ReactDuoCodeDemo.ReactBindings;

namespace ReactDuoCodeDemo.Components
{
    public class TestComponent : ComponentWrapper<TestComponent.Props>
    {
        // All components require a constructor to pass props through to the base class. It should be private so that the ComponentProps wrapper never need be explicitly
        // instantiated by calling code. The "New" factory method is optional but recommended as it makes the calling code saner (otherwise, the Ele.Props(props).As<T>()
        // factory may be used, but it reverses the order of the props and component type which is a bit intuitive - but necessary for type inference, as C# can only infer
        // a single generic type parameter at a time and we need two; TProps and TComponent<TProps>).
        public static Element New(Props props) { return Ele.Props(props).As<TestComponent>(); }
        private TestComponent(ComponentProps<Props> props) : base(props) { }

        public override Element render()
        {
            return DOM.div(null, props.Props.Name);
        }

        public class Props
        {
            public Props(string name)
            {
                // Note: Can't use string.IsNullOrWhiteSpace since it's not defined in DuoCode's base library
                if ((name ?? "").Trim() == "")
                    throw new ArgumentException("Null/blank name specified");

                Name = name;
            }

            /// <summary>
            /// This will never be null or blank
            /// </summary>
            public string Name { get; private set; }
        }
    }
}