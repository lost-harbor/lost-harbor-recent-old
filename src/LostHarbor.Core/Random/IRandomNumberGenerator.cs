/*
SPDX-License-Identifier: AGPL-3.0-or-later

Lost Harbor - A procedurally generated space exploration game.
Copyright (C) 2021 Marc King and Achal Chhetri

This program is free software: you can redistribute it and/or modify it under the terms of the
GNU Affero General Public License as published by the Free Software Foundation, either version 3
of the License, or (at your option) any later version.

This program is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without
even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the
GNU Affero General Public License for more details.

You should have received a copy of the GNU Affero General Public License along with this program.
If not, see <https://www.gnu.org/licenses/>.
*/

using System;

namespace LostHarbor.Core.Random
{
    /// <summary>
    /// The common interface for all generic random number generators. Based on the public interface
    /// of <see cref="System.Random"/>; new RNGs that implement this interface will be
    /// interchangeable with algorithms that usually use <see cref="System.Random"/>.
    /// </summary>
    /// <remarks>
    /// When implementing this interface, it is recommended that the comments for the required
    /// methods be copied verbatim from this file.
    /// </remarks>
    public interface IRandomNumberGenerator
    {
        /// <summary>
        /// Returns a child random number generator.
        /// </summary>
        /// <returns>A random number generator based on the parent random number generator.</returns>
        IRandomNumberGenerator NextRandom();

        /// <summary>
        /// Returns a non-negative random integer.
        /// </summary>
        /// <returns>An int [0..Int32.MaxValue)</returns>
        public int Next();

        /// <summary>
        /// Returns a random floating-point number that is greater than or equal to 0.0, and less
        /// than 1.0.
        /// </summary>
        /// <returns>A double [0..1)</returns>
        public double NextDouble();

        /// <summary>
        /// Returns a random integer that is within a specified range.
        /// </summary>
        /// <param name="minValue">The least legal value for the Random number.</param>
        /// <param name="maxValue">One greater than the greatest legal return value.</param>
        /// <returns>An int [minvalue..maxvalue)</returns>
        public int Next(int minValue, int maxValue)
        {
            if (minValue > maxValue)
            {
                throw new ArgumentOutOfRangeException(nameof(minValue), $"{nameof(minValue)} cannot be greater than {nameof(maxValue)}.");
            }
            return (int)(NextDouble() * (maxValue - minValue)) + minValue;
        }

        /// <summary>
        /// Returns a non-negative random integer that is less than the specified maximum.
        /// </summary>
        /// <param name="maxValue">One more than the greatest legal return value.</param>
        /// <returns>An int [0..maxValue)</returns>
        public int Next(int maxValue)
        {
            if (maxValue < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(maxValue), $"{nameof(maxValue)} must be greater than or equal to zero.");
            }
            return (int)(NextDouble() * maxValue);
        }

        /// <summary>
        /// Fills the elements of a specified array of bytes with random numbers [0..0x7f]. The
        /// entire array is filled.
        /// </summary>
        /// <param name="buffer">The array to be filled.</param>
        public void NextBytes(byte[] buffer)
        {
            if (buffer == null)
            {
                throw new ArgumentNullException(nameof(buffer), $"{nameof(buffer)} cannot be null.");
            }

            int i = 0;
            uint r;
            while (i + 4 <= buffer.Length)
            {
                r = (uint)Next();
                buffer[i++] = (byte)r;
                buffer[i++] = (byte)(r >> 8);
                buffer[i++] = (byte)(r >> 16);
                buffer[i++] = (byte)(r >> 24);
            }
            if (i >= buffer.Length) return;
            r = (uint)Next();
            buffer[i++] = (byte)r;
            if (i >= buffer.Length) return;
            buffer[i++] = (byte)(r >> 8);
            if (i >= buffer.Length) return;
            buffer[i++] = (byte)(r >> 16);
        }
    }
}
