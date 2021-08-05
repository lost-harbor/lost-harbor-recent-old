using System;

namespace LostCode.Core.Time
{
    public static class LocalTime
    {
        public static double Now()
        {
            return DateTime.UtcNow.Subtract(EpochDateTime.Ntp).TotalSeconds;
        }
    }
}
