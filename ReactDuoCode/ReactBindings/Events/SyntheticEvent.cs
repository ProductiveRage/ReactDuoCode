using System;
using DuoCode.Runtime;

namespace ReactDuoCodeDemo.ReactBindings.Events
{
    [Js(Extern = true)]
    public class SyntheticEvent
    {
        public bool bubbles;
        public bool cancelable;
        public bool defaultPrevented;
        public Action preventDefault;
        public Action stopPropagation;
        public string type;
    }
}