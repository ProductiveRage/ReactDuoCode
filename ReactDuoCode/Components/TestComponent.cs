using System;
using ReactDuoCodeDemo.ReactBindings;

namespace ReactDuoCodeDemo.Components
{
    public class TestComponent : ComponentWrapper<TestComponentProps>
    {
        // All components require a constructor to pass props through to the base class. It should be private so that the ComponentProps wrapper never need be explicitly
        // instantiated by calling code. The "New" factory method is optional but recommended as it makes the calling code saner (otherwise, the Ele.Props(props).As<T>()
        // factory may be used, but it reverses the order of the props and component type which is a bit intuitive - but necessary for type inference, as C# can only infer
        // a single generic type parameter at a time and we need two; TProps and TComponent<TProps>).
        public static Element New(TestComponentProps props) { return Ele.Props(props).As<TestComponent>(); }
        private TestComponent(ComponentProps<TestComponentProps> props) : base(props) { }

        public override Element render()
        {
            return DOM.div(null, props.Props.Name);
        }
    }
}