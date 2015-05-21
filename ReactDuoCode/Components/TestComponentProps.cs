using System;

namespace ReactDuoCodeDemo.Components
{
    public class TestComponentProps
    {
        public TestComponentProps(string name)
        {
            // Note: Can't use string.IsNullOrWhiteSpace since it's not defined in DuoCode's base library
            if ((name ?? "").Trim() == "")
                throw new ArgumentException("Null/blank name specified");

            Name = name;
        }

        /// <summary>
        /// This will never be null or blank
        /// </summary>
        public string Name { get; private set; }
    }
}
