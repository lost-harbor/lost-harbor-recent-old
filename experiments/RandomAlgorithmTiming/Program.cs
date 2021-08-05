using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using LostHarbor.Core.Random.Algorithm;

namespace RandomAlgorithmTiming
{
    class Program
    {
        private const int iterationsPerAlgorithm = 10000;
        private const int iterationsPerTest = 10000;
        static void Main(string[] args)
        {
            Console.WriteLine("Random Algorithm Timing");
            Console.WriteLine("=======================");

            Console.Write("Calculating pre-instantiated times...");
            var preinstantiatedResults = new List<TimingResult>();
            var systemRandom = new System.Random();
            preinstantiatedResults.Add(RunTest("System.Random", () => systemRandom.Next()));
            var systemRandomWrapper = new SystemRandomWrapper();
            preinstantiatedResults.Add(RunTest("SystemRandomWrapper", () => systemRandomWrapper.Next()));
            var xorShift = new XorShift();
            preinstantiatedResults.Add(RunTest("XorShift", () => xorShift.Next()));
            var linearCongruential = new LinearCongruential();
            preinstantiatedResults.Add(RunTest("LinearCongruential", () => linearCongruential.Next()));
            var mersenneTwister = new MersenneTwister();
            preinstantiatedResults.Add(RunTest("MersenneTwister", () => mersenneTwister.Next()));
            var motherOfAll = new MotherOfAll();
            preinstantiatedResults.Add(RunTest("MotherOfAll", () => motherOfAll.Next()));
            var ranrotB = new RanrotB();
            preinstantiatedResults.Add(RunTest("RanrotB", () => ranrotB.Next()));
            var wellEquidistributedLongPeriodLinear = new WellEquidistributedLongPeriodLinear();
            preinstantiatedResults.Add(RunTest("W.E.L.L.", () => wellEquidistributedLongPeriodLinear.Next()));
            Console.SetCursorPosition(0, Console.CursorTop);
            DisplayResults("Results of pre-instantiated random objects:", preinstantiatedResults);

            Console.Write("Calculating non-instantiated times...");
            var noninstantiatedResults = new List<TimingResult>();
            noninstantiatedResults.Add(RunTest("System.Random", () =>
            {
                var random = new System.Random();
                random.Next();
            }));
            noninstantiatedResults.Add(RunTest("SystemRandomWrapper", () =>
            {
                var random = new SystemRandomWrapper();
                random.Next();
            }));
            noninstantiatedResults.Add(RunTest("XorShift", () =>
            {
                var random = new XorShift();
                random.Next();
            }));
            noninstantiatedResults.Add(RunTest("LinearCongruential", () =>
            {
                var random = new LinearCongruential();
                random.Next();
            }));
            noninstantiatedResults.Add(RunTest("MersenneTwister", () =>
            {
                var random = new MersenneTwister();
                random.Next();
            }));
            noninstantiatedResults.Add(RunTest("MotherOfAll", () =>
            {
                var random = new MotherOfAll();
                random.Next();
            }));
            noninstantiatedResults.Add(RunTest("RanrotB", () =>
            {
                var random = new RanrotB();
                random.Next();
            }));
            noninstantiatedResults.Add(RunTest("W.E.L.L.", () =>
            {
                var random = new WellEquidistributedLongPeriodLinear();
                random.Next();
            }));
            Console.SetCursorPosition(0, Console.CursorTop);
            DisplayResults("Results of non-instantiated random objects:", noninstantiatedResults);
        }

        public static TimingResult RunTest(string name, Action action)
        {
            var result = new TimingResult() { Name = name };
            var stopwatch = new Stopwatch();
            for (int i = 0; i < iterationsPerAlgorithm + 1; i++)
            {
                stopwatch.Restart();
                for (int j = 0; j < iterationsPerTest; j++)
                {
                    action();
                }
                stopwatch.Stop();
                // Ignore first result
                if (i != 0)
                {
                    result.Times.Add(stopwatch.Elapsed);
                }
            }
            return result;
        }

        public static void DisplayResults(string title, List<TimingResult> results)
        {
            Console.WriteLine(title);

            // calculate averages
            foreach (var result in results)
            {
                result.AverageTicks = Math.Round(result.Times.Average(t => t.Ticks), 2);
                result.AverageMilliseconds = Math.Round(result.Times.Average(t => t.TotalMilliseconds), 5);
            }
            // find the longest name
            var longestName = results.Max(r => r.Name.Length);
            // find highest average
            var highestAverage = results.Max(r => r.AverageMilliseconds);
            // find lowest average
            var lowestAverage = results.Min(r => r.AverageMilliseconds);

            var foregroundColor = Console.ForegroundColor;
            foreach (var result in results)
            {
                if (result.AverageMilliseconds == highestAverage)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                }
                else if (result.AverageMilliseconds == lowestAverage)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                }
                Console.Write("{0,-" + longestName + "} {1,10:N4}ms  ", result.Name, result.AverageMilliseconds);
                PrintBar(result.AverageMilliseconds, highestAverage);
                if (Console.ForegroundColor != foregroundColor)
                {
                    Console.ForegroundColor = foregroundColor;
                }
            }
            Console.WriteLine();
        }

        public static void PrintBar(double average, double maxAverage)
        {
            var percent = Math.Round(((average / maxAverage) * 100) / 2);
            for (int i = 0; i < percent; i++)
            {
                Console.Write("▇");
            }
            Console.WriteLine();
        }
    }
}
