using System;
using System.Windows.Threading;
using Retlang.Core;

namespace Retlang.Fibers
{
    internal class DispatcherAdapter : IExecutionContext
    {
        private readonly Dispatcher _dispatcher;
        private readonly DispatcherPriority _priority;

        public DispatcherAdapter(Dispatcher dispatcher, DispatcherPriority priority)
        {
            _dispatcher = dispatcher;
            _priority = priority;
        }

        public void Enqueue(INamedAction action)
        {
            _dispatcher.BeginInvoke(new Action(action.Execute), _priority);
        }
    }
}