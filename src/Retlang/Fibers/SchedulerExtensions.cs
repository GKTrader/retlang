using System;
using Retlang.Core;

namespace Retlang.Fibers
{
    public static class SchedulerExtensions
    {
        public static IDisposable Schedule(this IScheduler scheduler, Action action, long firstInMs)
        {
            return scheduler.Schedule(NamedAction.From(action), firstInMs);
        }

        public static IDisposable ScheduleOnInterval(this IScheduler scheduler, Action action, long firstInMs,
            long regularInMs)
        {
            return scheduler.ScheduleOnInterval(NamedAction.From(action), firstInMs, regularInMs);
        }
    }
}