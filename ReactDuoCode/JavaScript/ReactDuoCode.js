window.ReactDuoCodeDemo = window.ReactDuoCodeDemo || {};
window.ReactDuoCodeDemo.ReactComponentWrapper = (function (_super) {
    function Component(props) {
        _super.call(this, props, null);
    }
    Component.ctor = Component; // Required by DuoCode since it seems to require classes have a "ctor" function to construct them
    Component.GetElement = function (componentType, props) {
        // When the props reference is passed through React's createElement method, it will strip off any properties that do not report true for "hasOwnProperty". This means that
        // any functions that are defined on the prototype are lost, so if props is a class with prototype methods then it will be broken by this process. The workaround is to
        // wrap the provided props reference in another object, with a single property "Props". React won't mess with this data. The only cost for this indirection is that
        // components needs to access this.props.Props to get at this data, but the C# classes will offer static typing to ensure that mistakes aren't made around this
        // (and that this.props is not accessed directly).
        return React.createElement(componentType.self.ctor, { Props: props });
    };
    return Component;
})(React.Component);
