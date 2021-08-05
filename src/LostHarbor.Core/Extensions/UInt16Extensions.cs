using System;

namespace LostHarbor.Core.Extensions
{
    public static class UInt16Extensions
    {
        /// <summary>
        /// Determine if a UInt16 is an even number.
        /// </summary>
        /// <returns>True if the UInt16 is even; false otherwise.</returns>
        public static bool IsEven(this UInt16 number)
        {
            return number % 2 == 0;
        }

        /// <summary>
        /// Determine if a UInt16 is an odd number.
        /// </summary>
        /// <returns>True if the UInt16 is an odd number; false otherwise.</returns>
        public static bool IsOdd(this UInt16 number)
        {
            return number % 2 != 0;
        }
    }
}
