using System;

namespace ReactDuoCodeDemo.ReactBindings
{
    /// <summary>
    /// To turn a C# class into a React component, it must inherit from the generic ComponentWrapper class (which hooks into some JavaScript magic via the ReactDuoCodeDemo.js file). This
    /// can make the instantiation code a bit syntactically-noisy. This static factory uses C#'s type inference to make the calling code a little cleaner, but at the cost that the
    /// props value must be specified byefore the component type, since C#'s compiler can only infer a single generic type parameter at a time. It is recommended that all component
    /// classes have a private constructor and a static factory method to instantiate them - the factory method can use this logic for brevity.
    /// </summary>
    public static class Ele
    {
        public static ElementFactory<TProps> Props<TProps>(TProps props)
        {
            if (props == null)
                throw new ArgumentNullException("props");
            return new ElementFactory<TProps>(props);
        }

        public class ElementFactory<TProps>
        {
            private readonly TProps _props;
            public ElementFactory(TProps props)
            {
                if (props == null)
                    throw new ArgumentNullException("props");
                _props = props;
            }
            public Element As<TComponent>() where TComponent : ComponentWrapper<TProps>
            {
                return ComponentWrapper.GetElement(typeof(TComponent), _props);
            }
        }
    }
}