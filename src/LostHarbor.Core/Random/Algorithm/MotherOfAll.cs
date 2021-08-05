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

// Implementation of Mother-of-All RNGs by George Marsaglia
// http://home.sandiego.edu/~pruski/MotherExplanation.txt

using System;

namespace LostHarbor.Core.Random.Algorithm
{
    /// <summary>
    /// Mother-of-All pseudo-random number generator.
    /// </summary>
    public class MotherOfAll : IRandomNumberGenerator
    {
        private uint x, y, z, w, v;

        public MotherOfAll() : this(Environment.TickCount) { }
        public MotherOfAll(int seed)
        {
            uint s = (uint)seed;
            x = s = 29943829 * s - 1;
            y = s = 29943829 * s - 1;
            z = s = 29943829 * s - 1;
            w = s = 29943829 * s - 1;
            v = 29943829 * s - 1;
            // Warm-up generator
            for (int i = 0; i < 19; i++) InternalNext();
        }
        public MotherOfAll(string seed) : this(seed.GetHashCode()) { }

        public IRandomNumberGenerator NextRandom() => new MotherOfAll(Next());
        public int Next() => (int)(NextDouble() * int.MaxValue);
        public double NextDouble() => InternalNext() * (1.0 / uint.MaxValue);

        private uint InternalNext()
        {
            ulong s = 2111111111UL * w + 1492UL * z + 1776UL * y + 5115UL * x + v;
            w = z;
            z = y;
            y = x;
            x = (uint)s;
            v = (uint)(s >> 32);
            return x;
        }
    }
}

