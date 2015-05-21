using DuoCode.Runtime;

namespace ReactDuoCodeDemo.ReactBindings.Events
{
    [Js(Extern = true)]
    public class InputEventTarget : EventTarget
    {
        public string value;
    }
}