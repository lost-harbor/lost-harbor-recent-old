using System;

namespace LostHarbor.Core.Extensions
{
    public static class UInt32Extensions
    {
        /// <summary>
        /// Determine if a UInt32 is an even number.
        /// </summary>
        /// <returns>True if the UInt32 is even; false otherwise.</returns>
        public static bool IsEven(this UInt32 number)
        {
            return number % 2 == 0;
        }

        /// <summary>
        /// Determine if a UInt32 is an odd number.
        /// </summary>
        /// <returns>True if the UInt32 is an odd number; false otherwise.</returns>
        public static bool IsOdd(this UInt32 number)
        {
            return number % 2 != 0;
        }
    }
}
