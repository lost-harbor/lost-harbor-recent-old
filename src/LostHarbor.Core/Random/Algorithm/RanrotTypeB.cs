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

// Implementation of RanrotB RNGs by Agner Fog
// http://www.agner.org/random/theory/chaosran.pdf

using System;

namespace LostHarbor.Core.Random.Algorithm
{
    /// <summary>
    /// RanrotB pseudo-random number generator.
    /// </summary>
    public class RanrotB : IRandomNumberGenerator
    {
        protected const int KK = 17, JJ = 10, R1 = 13, R2 = 9;
        protected uint[] randbuffer;
        protected int p1, p2;

        public RanrotB() : this(Environment.TickCount) { }
        public RanrotB(int seed)
        {
            uint s = (uint)seed;
            randbuffer = new uint[KK];
            for (int i = 0; i < KK; i++)
            {
                randbuffer[i] = s = s * 2891336453 + 1;
            }
            p1 = 0; p2 = JJ;
            // Warm-up generator
            for (int i = 0; i < 9; i++) InternalNext();
        }
        public RanrotB(string seed) : this(seed.GetHashCode()) { }

        public IRandomNumberGenerator NextRandom() => new RanrotB(Next());
        public int Next() => (int)(NextDouble() * int.MaxValue);
        public double NextDouble() => InternalNext() * (1.0 / uint.MaxValue);

        private uint InternalNext()
        {
            uint x;
            x = randbuffer[p1] = ((randbuffer[p2] << R1)
                | (randbuffer[p2] >> (32 - R1))) + ((randbuffer[p1] << R2)
                | (randbuffer[p1] >> (32 - R2)));
            if (--p1 < 0) p1 = KK - 1;
            if (--p2 < 0) p2 = KK - 1;
            return x;
        }
    }
}

