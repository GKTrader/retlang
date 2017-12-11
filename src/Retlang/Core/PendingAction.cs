using System;

namespace Retlang.Core
{
    public interface INamedAction
    {
        void Execute();
        string Name { get; }
    }

    internal class PendingAction : INamedAction, IDisposable
    {
        private readonly INamedAction _action;
        private bool _cancelled;

        public PendingAction(INamedAction action)
        {
            _action = action;
        }

        public void Dispose()
        {
            _cancelled = true;
        }

        public string Name { get { return _action.Name; } }

        public void Execute()
        {
            if (!_cancelled)
            {
                _action.Execute();
            }
        }
    }
}
