using DuoCode.Runtime;
using ReactDuoCodeDemo.ReactBindings.Attributes;

namespace ReactDuoCodeDemo.ReactBindings
{
    [Js(Extern = true, Name = "React.DOM")]
    public static class DOM
    {
        public extern static Element div(HTMLAttributes properties, params Element[] children);
        public extern static Element h1(HTMLAttributes properties, params Element[] children);
        public extern static Element input(InputAttributes properties, params Element[] children);
        public extern static Element span(HTMLAttributes properties, params Element[] children);
    }
}