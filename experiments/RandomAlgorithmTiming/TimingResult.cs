using System;
using System.Collections.Generic;

namespace RandomAlgorithmTiming
{
    public class TimingResult
    {
        public string Name { get; set; }
        public List<TimeSpan> Times { get; set; } = new List<TimeSpan>();
        public double AverageTicks { get; set; } = 0;
        public double AverageMilliseconds { get; set; } = 0;
    }
}
