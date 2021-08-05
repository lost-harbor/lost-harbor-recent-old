using System;

namespace LostHarbor.Core.Extensions
{
    public static class SByteExtensions
    {
        /// <summary>
        /// Determine if a SByte is an even number.
        /// </summary>
        /// <returns>True if the SByte is even; false otherwise.</returns>
        public static bool IsEven(this SByte number)
        {
            return number % 2 == 0;
        }

        /// <summary>
        /// Determine if a SByte is an odd number.
        /// </summary>
        /// <returns>True if the SByte is an odd number; false otherwise.</returns>
        public static bool IsOdd(this SByte number)
        {
            return number % 2 != 0;
        }
    }
}
