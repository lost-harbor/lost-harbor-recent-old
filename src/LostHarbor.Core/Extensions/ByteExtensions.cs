using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

namespace LostHarbor.Core.Extensions
{
    public static class ByteExtensions
    {
        /// <summary>
        /// Determine if a Byte is an even number.
        /// </summary>
        /// <returns>True if the Byte is even; false otherwise.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsEven(this Byte number)
        {
            return number % 2 == 0;
        }

        /// <summary>
        /// Determine if a Byte is an odd number.
        /// </summary>
        /// <returns>True if the Byte is an odd number; false otherwise.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsOdd(this Byte number)
        {
            return number % 2 != 0;
        }




        public static Boolean IsPrime(this Byte source)
        {
            if ((source % 2) == 0)
            {
                return source == 2;
            }
            Byte sqrt = (Byte)Math.Sqrt(source);
            for (Byte t = 3; t <= sqrt; t += 2)
            {
                if (source % t == 0)
                {
                    return false;
                }
            }
            return source != 1;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Boolean IsBetween(this Byte source, Byte minimum, Byte maximum)
        {
            return source >= minimum && source <= maximum;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Byte Clamp(this Byte source, Byte minimum, Byte maximum)
        {
            return Math.Max(Math.Min(source, maximum), minimum);
        }
    }
}
