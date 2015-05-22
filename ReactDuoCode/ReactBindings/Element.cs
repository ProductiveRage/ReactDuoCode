using DuoCode.Runtime;

namespace ReactDuoCodeDemo.ReactBindings
{
    [Js(Extern = true)]
    public sealed class Element
    {
        private Element() { }
        public extern static implicit operator Element(string text);
    }
}