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
    public class SystemRandomWrapper : IRandomNumberGenerator
    {
        private readonly System.Random _random;
        public SystemRandomWrapper() : this(Environment.TickCount) { }
        public SystemRandomWrapper(int seed) => _random = new System.Random(seed);
        public IRandomNumberGenerator NextRandom() => new SystemRandomWrapper(Next());
        public int Next() => _random.Next();
        public double NextDouble() => _random.NextDouble();
        public int Next(int minValue, int maxValue) => _random.Next(minValue, maxValue);
        public int Next(int maxValue) => _random.Next(maxValue);
        public void NextBytes(byte[] buffer) => _random.NextBytes(buffer);
    }
}

