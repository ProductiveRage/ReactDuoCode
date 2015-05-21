using DuoCode.Runtime;

namespace ReactDuoCodeDemo.ReactBindings
{
    [Js(Extern = true)]
    public sealed class Element
    {
        private Element() { }
        public static implicit operator Element(string text)
        {
            // This is just a placeholder function, to instruct the compiler that strings are allowed wherever an Element is
            // required. We return null only so that the compiler does not complain about the function not returning anything,
            // this code will never be called since this Element class is marked as external.
            return null;
        }
    }
}