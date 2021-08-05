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

// Implementation of Linear Congruential Generator (LCG)
// http://en.wikipedia.org/wiki/Linear_congruential_generator

using System;

namespace LostHarbor.Core.Random.Algorithm
{
    /// <summary>
    /// Linear congruential pseudo-random number generator.
    /// </summary>
    public class LinearCongruential : IRandomNumberGenerator
    {
        private uint x;
        private readonly uint a = 1664525;
        private readonly uint c = 1013904223;

        /// <summary>
        /// Initializes the LinearCongruential pseudo-random number generator with the current time as the seed.
        /// </summary>
        public LinearCongruential() : this(Environment.TickCount) { }

        /// <summary>
        /// Initialize the LinearCongruential pseudo-random number generator with an int as the seed.
        /// </summary>
        public LinearCongruential(int seed) => x = (uint)seed;

        /// <summary>
        /// Initialize the LinearCongruential pseudo-random number generator with a string as the seed.
        /// </summary>
        public LinearCongruential(string seed) : this(seed.GetHashCode()) { }

        /// <summary>
        /// Returns a child random number generator.
        /// </summary>
        /// <returns>A random number generator based on the parent random number generator.</returns>
        public IRandomNumberGenerator NextRandom() => new LinearCongruential(Next());

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
            x = (uint)((ulong)x * a + c);
            return x;
        }
    }
}

