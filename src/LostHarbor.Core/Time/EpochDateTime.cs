using System;

namespace LostCode.Core.Time
{
    public static class EpochDateTime
    {
        public static DateTime Ntp
        {
            get
            {
                return new DateTime(1900, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            }
        }

        public static DateTime Unix
        {
            get
            {
                return new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            }
        }
    }
}
