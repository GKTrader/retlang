using System;
using Retlang.Core;
using Retlang.Fibers;

namespace Retlang.Channels
{
    public class NamedChannelSubscription<T> : ChannelSubscription<T>
    {
        private readonly string _name;

        public NamedChannelSubscription(IFiber fiber, Action<T> receiver, string name) : base(fiber, receiver)
        {
            _name = name;
        }

        protected override void OnMessageOnProducerThread(T msg)
        {
            _fiber.Enqueue(new NamedAction(() => _receiver(msg), _name));
        }
    }
}