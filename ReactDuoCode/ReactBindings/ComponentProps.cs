using System;
using DuoCode.Runtime;

namespace ReactDuoCodeDemo.ReactBindings
{
    /// <summary>
    /// React will pick apart a "props" reference in its createElement call - stripping any properties that do not report true for "hasOwnProperty", such as any functions declared
    /// on a prototype, for JavaScript classes. The workaound is that the components push the real props object into a "Props" property. This means that components have to access
    /// it as this.props.Props, but the C# ComponentWrapper is aware of this so that any mistakes made in C# components (such as trying to directly access this.props) will be
    /// picked up by the compiler. This class is what is used to describe the indirection.
    /// </summary>
    [Js(Extern = true)]
    public sealed class ComponentProps<T>
    {
        private ComponentProps() { }

        [Js(Extern = true, Name = "Props")]
        public T Props { get; }
    }
}
