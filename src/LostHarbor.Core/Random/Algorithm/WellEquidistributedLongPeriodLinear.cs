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

// Implementation of WELL RNG by Francois Panneton, Pierre L'ecuyer and Makoto Matsumoto
// http://www.iro.umontreal.ca/~lecuyer/myftp/papers/wellrng.pdf

using System;

namespace LostHarbor.Core.Random.Algorithm
{
    /// <summary>
    /// WellEquidistributedLongPeriodLinear pseudo-random number generator.
    /// </summary>
    public class WellEquidistributedLongPeriodLinear : IRandomNumberGenerator
    {
        protected const int W = 32;
        protected const int R = 624;
        protected const int P = 31;
        protected const uint MASKU = 0xffffffffU >> (W - P);
        protected const uint MASKL = ~MASKU;
        protected const int M1 = 70;
        protected const int M2 = 179;
        protected const int M3 = 449;
        protected const uint TEMPERB = 0x12345678U;
        protected const uint TEMPERC = 0x87654321U;

        protected uint[] stateVector;
        protected int stateVectorIndex;

        public WellEquidistributedLongPeriodLinear() : this(Environment.TickCount) { }
        public WellEquidistributedLongPeriodLinear(int seed)
        {
            stateVector = new uint[R];
            stateVectorIndex = 0;
            stateVector[0] = (uint)seed;
            for (int i = 1; i < R; i++)
                stateVector[i] = (uint)(1812433253 * (stateVector[i - 1] ^ (stateVector[i - 1] >> 30)) + i);
        }
        public WellEquidistributedLongPeriodLinear(string seed) : this(seed.GetHashCode()) { }

        public IRandomNumberGenerator NextRandom() => new WellEquidistributedLongPeriodLinear(Next());
        public int Next() => (int)(NextDouble() * int.MaxValue);
        public double NextDouble() => InternalNext() * (1.0 / uint.MaxValue);

        private uint InternalNext()
        {
            uint z1, z2;
            int i1, i2, i3, i4, i5;
            if (stateVectorIndex < 2)
            {
                if (stateVectorIndex < 1) i2 = stateVectorIndex - 1 + R; else i2 = stateVectorIndex - 1;
                i1 = stateVectorIndex - 2 + R;
            }
            else
            {
                i1 = stateVectorIndex - 2;
                i2 = stateVectorIndex - 1;
            }
            if (stateVectorIndex + M3 >= R)
            {
                if (stateVectorIndex + M2 >= R)
                {
                    if (stateVectorIndex + M1 >= R) i3 = stateVectorIndex + M1 - R; else i3 = stateVectorIndex + M1;
                    i4 = stateVectorIndex + M2 - R;
                }
                else
                {
                    i3 = stateVectorIndex + M1;
                    i4 = stateVectorIndex + M2;
                }
                i5 = stateVectorIndex + M3 - R;
            }
            else
            {
                i3 = stateVectorIndex + M1;
                i4 = stateVectorIndex + M2;
                i5 = stateVectorIndex + M3;
            }
            z1 = stateVector[stateVectorIndex] ^ (stateVector[stateVectorIndex] << 25) ^ stateVector[i3] ^ (stateVector[i3] >> 27);
            z2 = (stateVector[i4] >> 9) ^ stateVector[i5] ^ (stateVector[i5] >> 1);
            stateVector[stateVectorIndex] = z1 ^ z2;
            z1 = (stateVector[i2] & MASKL) ^ (stateVector[i1] & MASKU) ^ (z1 << 9) ^ (z2 << 21) ^ (stateVector[stateVectorIndex] >> 21);
            stateVectorIndex = i2;
            stateVector[i2] = z1;
            z1 ^= (z1 << 7) & TEMPERB;
            z1 ^= (z1 << 15) & TEMPERC;
            return z1;
        }
    }
}

