using System;
using System.Threading;

namespace Retlang.Core
{
    internal class TimerAction : INamedAction, IDisposable
    {
        private readonly INamedAction _action;
        private readonly long _firstIntervalInMs;
        private readonly long _intervalInMs;

        private Timer _timer;
        private bool _cancelled;

        public TimerAction(INamedAction action, long firstIntervalInMs, long intervalInMs)
        {
            _action = action;
            _firstIntervalInMs = firstIntervalInMs;
            _intervalInMs = intervalInMs;
        }

        public void Schedule(ISchedulerRegistry registry)
        {
            _timer = new Timer(x => ExecuteOnTimerThread(registry), null, _firstIntervalInMs, _intervalInMs);
        }

        public void ExecuteOnTimerThread(ISchedulerRegistry registry)
        {
            if (_intervalInMs == Timeout.Infinite || _cancelled)
            {
                registry.Remove(this);
                if (_timer != null)
                {
                    _timer.Dispose();
                    _timer = null;
                }
            }

            if (!_cancelled)
            {
                registry.Enqueue(this);
            }
        }

        public virtual void Dispose()
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