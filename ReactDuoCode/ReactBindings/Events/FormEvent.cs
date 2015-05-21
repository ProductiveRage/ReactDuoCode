using DuoCode.Runtime;

namespace ReactDuoCodeDemo.ReactBindings.Events
{
    [Js(Extern = true)]
    public class FormEvent : SyntheticEvent
    {
        [Js(Name = "target")]
        public EventTarget target;
    }

    [Js(Extern = true)]
    public class FormEvent<T> : FormEvent where T : EventTarget
    {
        [Js(Name = "target")]
        public new T target;
    }
}