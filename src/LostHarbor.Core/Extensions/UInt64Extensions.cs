using System;

namespace LostHarbor.Core.Extensions
{
    public static class UInt64Extensions
    {
        /// <summary>
        /// Determine if a UInt64 is an even number.
        /// </summary>
        /// <returns>True if the UInt64 is even; false otherwise.</returns>
        public static bool IsEven(this UInt64 number)
        {
            return number % 2 == 0;
        }

        /// <summary>
        /// Determine if a UInt64 is an odd number.
        /// </summary>
        /// <returns>True if the UInt64 is an odd number; false otherwise.</returns>
        public static bool IsOdd(this UInt64 number)
        {
            return number % 2 != 0;
        }
    }
}
