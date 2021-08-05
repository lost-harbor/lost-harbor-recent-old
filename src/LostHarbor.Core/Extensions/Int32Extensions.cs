using System;

namespace LostHarbor.Core.Extensions
{
    public static class Int32Extensions
    {
        /// <summary>
        /// Determine if a Int32 is an even number.
        /// </summary>
        /// <returns>True if the Int32 is even; false otherwise.</returns>
        public static bool IsEven(this Int32 number)
        {
            return number % 2 == 0;
        }

        /// <summary>
        /// Determine if a Int32 is an odd number.
        /// </summary>
        /// <returns>True if the Int32 is an odd number; false otherwise.</returns>
        public static bool IsOdd(this Int32 number)
        {
            return number % 2 != 0;
        }

        /// <summary>
        /// Ensures this integer falls within the range specified by the lower and upper bounds.
        /// </summary>
        /// <param name="lowerBound"> Smallest allowed value of this integer; inclusive. </param>
        /// <param name="upperBound"> Largest allowed value of this integer; inclusive. </param>
        /// <returns> The original integer, or the lower or upper bound. </returns>
        public static int Clamp(this int intToClamp, int lowerBound, int upperBound)
        {
            return Math.Min(Math.Max(intToClamp, lowerBound), upperBound);
        }

        public static string ToFileSize(this Int32 size)
        {
            if (size < 1024) { return (size).ToString("F0") + " bytes"; }
            if (size < Math.Pow(1024, 2)) { return (size / 1024).ToString("F0") + "KB"; }
            if (size < Math.Pow(1024, 3)) { return (size / Math.Pow(1024, 2)).ToString("F0") + "MB"; }
            if (size < Math.Pow(1024, 4)) { return (size / Math.Pow(1024, 3)).ToString("F0") + "GB"; }
            if (size < Math.Pow(1024, 5)) { return (size / Math.Pow(1024, 4)).ToString("F0") + "TB"; }
            if (size < Math.Pow(1024, 6)) { return (size / Math.Pow(1024, 5)).ToString("F0") + "PB"; }
            return (size / Math.Pow(1024, 6)).ToString("F0") + "EB";
        }
    }
}
