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

// Implementation of Xorshift RNGs by George Marsaglia
// https://www.jstatsoft.org/article/view/v008i14

using System;

namespace LostHarbor.Core.Random.Algorithm
{
    /// <summary>
    /// Xorshift pseudo-random number generator.
    /// </summary>
    public class XorShift : IRandomNumberGenerator
    {
        private uint x, y = 362436069, z = 521288629, w = 88675123;

        /// <summary>
        /// Initializes the XorShift pseudo-random number generator with the current time as the seed.
        /// </summary>
        public XorShift() : this(Environment.TickCount) { }

        /// <summary>
        /// Initialize the XorShift pseudo-random number generator with an int as the seed.
        /// </summary>
        public XorShift(int seed) => x = (uint)seed;

        /// <summary>
        /// Initialize the XorShift pseudo-random number generator with a string as the seed.
        /// </summary>
        public XorShift(string seed) : this(seed.GetHashCode()) { }

        /// <summary>
        /// Returns a child random number generator.
        /// </summary>
        /// <returns>A random number generator based on the parent random number generator.</returns>
        public IRandomNumberGenerator NextRandom() => new XorShift(Next());

        /// <summary>
        /// Returns a non-negative random integer.
        /// </summary>
        /// <returns>An int [0..Int32.MaxValue)</returns>
        public int Next() => (int)(NextDouble() * int.MaxValue);

        /// <summary>
        /// Returns a random floating-point number that is greater than or equal to 0.0, and less
        /// than 1.0.
        /// </summary>
        /// <returns>A double [0..1)</returns>
        public double NextDouble() => InternalNext() * (1.0 / uint.MaxValue);

        private uint InternalNext()
        {
            var t = x ^ (x << 11);
            x = y;
            y = z;
            z = w;
            w = w ^ (w >> 19) ^ t ^ (t >> 8);
            return w;
        }
    }
}

