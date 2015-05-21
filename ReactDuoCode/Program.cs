using System;
using DuoCode.Dom;
using ReactDuoCodeDemo.Actions;
using ReactDuoCodeDemo.Dispatcher;
using ReactDuoCodeDemo.Stores;

namespace ReactDuoCodeDemo
{
    static class Program
    {
        static void Run()
        {
            var dispatcher = new AppDispatcher();
            new SimpleExampleStore(
                Global.window.document.getElementById("main"),
                dispatcher
            );
            Global.window.setInterval(
                (Action)(() => dispatcher.HandleServerAction(new TimePassedAction())),
                500
            );
        }
    }
}
