using DuoCode.Runtime;
using ReactDuoCodeDemo.ReactBindings.Attributes;

namespace ReactDuoCodeDemo.ReactBindings
{
    [Js(Extern = true, Name = "React.DOM")]
    public static class DOM
    {
        public static Element div(HTMLAttributes properties, params Element[] children) { return null; }
        public static Element h1(HTMLAttributes properties, params Element[] children) { return null; }
        public static Element input(InputAttributes properties, params Element[] children) { return null; }
        public static Element span(HTMLAttributes properties, params Element[] children) { return null; }
    }
}