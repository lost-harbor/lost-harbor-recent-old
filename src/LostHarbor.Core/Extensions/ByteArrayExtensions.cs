using System;

namespace LostHarbor.Core.Extensions
{
    public static class ByteArrayExtensions
    {
        public static UInt64 ParseUInt32(this byte[] source, int index)
        {
            if (source.Length < index + sizeof(UInt32))
            {
                throw new ArgumentOutOfRangeException("index", "Array too small to contain UInt32 at index.");
            }

            UInt32 value = (UInt32)source[index] << 24 |
                           (UInt32)source[index + 1] << 16 |
                           (UInt32)source[index + 2] << 8 |
                           (UInt32)source[index + 3];

            return value;
        }
    }
}
