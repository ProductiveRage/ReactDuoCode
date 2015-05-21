using DuoCode.Dom;
using DuoCode.Runtime;

namespace ReactDuoCodeDemo.ReactBindings
{
    [Js(Extern = true, Name = "React")]
    public static class React
    {
        [Js(Extern = true, Name = "render")]
        public static void Render(Element element, HTMLElement container) { }
    }
}