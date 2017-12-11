using System;
using Retlang.Core;

namespace Retlang.Fibers
{
    public static class ExecutionContextExtensions
    {
        public static void Enqueue(this IExecutionContext context, Action action)
        {
            context.Enqueue(NamedAction.From(action));
        }
    }
}