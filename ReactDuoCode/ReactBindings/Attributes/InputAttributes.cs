using System;
using DuoCode.Runtime;
using ReactDuoCodeDemo.ReactBindings.Events;

namespace ReactDuoCodeDemo.ReactBindings.Attributes
{
    public class InputAttributes : HTMLAttributes
    {
        public Action<FormEvent<InputEventTarget>> onChange;
        public string value;
    }
}