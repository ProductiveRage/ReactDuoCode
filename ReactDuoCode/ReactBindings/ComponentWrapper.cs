using System;
using DuoCode.Runtime;

namespace ReactDuoCodeDemo.ReactBindings
{
    [Js(Extern = true, Name = "ReactDuoCodeDemo.ReactComponentWrapper")]
    public abstract class ComponentWrapper<TProps>
    {
        protected readonly ComponentProps<TProps> props;
        protected ComponentWrapper(ComponentProps<TProps> props) { }
        public abstract Element render();
    }

    [Js(Extern = true, Name = "ReactDuoCodeDemo.ReactComponentWrapper")]
    public static class ComponentWrapper
    {
        [Js(OmitGenericArgs = true)]
        public static Element GetElement<TProps>(Type componentType, TProps props) { return null; }
    }
}
