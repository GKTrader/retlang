using System;

namespace Retlang.Core
{
    public class NamedAction : INamedAction
    {
        private readonly Action _action;
        private readonly string _name;

        public NamedAction(Action action, string name)
        {
            _action = action;
            _name = name;
        }

        public Action Action
        {
            get { return _action; }
        }

        public string Name
        {
            get { return _name; }
        }

        public void Execute()
        {
            _action();
        }

        public static INamedAction From(Action action)
        {
            return new UnnamedAction(action);
        }
    }

    public class UnnamedAction : INamedAction
    {
        private readonly Action _action;

        public UnnamedAction(Action action)
        {
            _action = action;
        }

        public void Execute()
        {
            _action();
        }

        public string Name
        {
            get { return string.Format("{0} for target {1}", _action.Method.Name, _action.Target); }
        }
    }
}