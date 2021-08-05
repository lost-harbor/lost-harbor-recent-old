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

// Implementation of Mersenne Twister was introduced by Takuji Nishimura and Makoto Matsumoto
// https://www.jstatsoft.org/article/view/v008i14

using System;

namespace LostHarbor.Core.Random.Algorithm
{
    /// <summary>
    /// Mersenna Twister pseudo-random number generator.
    /// </summary>
    public class MersenneTwister : IRandomNumberGenerator
    {
        private const int N = 624;
        private const int M = 397;
        private readonly uint[] mag = new uint[] { 0U, 2567483615U };
        private readonly uint[] stateVector;
        private int stateVectorIndex;

        public MersenneTwister() : this(Environment.TickCount) { }

        public MersenneTwister(int seed)
        {
            stateVector = new uint[N];
            stateVectorIndex = N + 1;
            stateVector[0] = (uint)seed;
            for (int i = 1; i < N; i++)
            {
                stateVector[i] = (uint)(1812433253 * (stateVector[i - 1] ^ (stateVector[i - 1] >> 30)) + i);
            }
        }

        public MersenneTwister(string seed) : this(seed.GetHashCode()) { }

        public IRandomNumberGenerator NextRandom() => new MersenneTwister(Next());

        public int Next() => (int)(NextDouble() * int.MaxValue);

        public double NextDouble() => InternalNext() * (1.0 / uint.MaxValue);

        private uint InternalNext()
        {
            uint y;
            if (stateVectorIndex >= N)
            {
                updateStateVector();
                stateVectorIndex = 0;
            }
            y = stateVector[stateVectorIndex++];
            y ^= y >> 11;
            y ^= (y << 7) & 2636928640U;
            y ^= (y << 15) & 4022730752U;
            y ^= y >> 18;
            return y;

            void updateStateVector()
            {
                int kk = 1;
                uint y, p;
                y = stateVector[0] & 2147483648U;

                do
                {
                    p = stateVector[kk];
                    stateVector[kk - 1] = stateVector[kk + (M - 1)] ^ ((y | (p & 2147483647U)) >> 1) ^ mag[p & 1];
                    y = p & 2147483648U;
                } while (++kk < N - M + 1);

                do
                {
                    p = stateVector[kk];
                    stateVector[kk - 1] = stateVector[kk + (M - N - 1)] ^ ((y | (p & 2147483647U)) >> 1) ^ mag[p & 1];
                    y = p & 2147483648U;
                } while (++kk < N);

                p = stateVector[0];
                stateVector[N - 1] = stateVector[M - 1] ^ ((y | (p & 2147483647U)) >> 1) ^ mag[p & 1];
            }
        }
    }
}

