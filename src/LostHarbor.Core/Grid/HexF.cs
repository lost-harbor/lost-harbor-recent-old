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

namespace LostHarbor.Core.Grid
{
    public struct HexF
    {
        public readonly double X;
        public readonly double Y;
        public double Z => -X - Y;

        public HexF(double x, double y)
        {
            X = x;
            Y = y;

            // Assert valid HexF coordinates
            if (Math.Round(X + Y + Z) != 0) throw new ArgumentException("Coordinates do not represent a valid HexF.");
        }

        public Hex ToHex()
        {
            int xInt = (int)Math.Round(X);
            int yInt = (int)Math.Round(Y);
            int zInt = (int)Math.Round(Z);
            double xDiff = Math.Abs(xInt - X);
            double yDiff = Math.Abs(yInt - Y);
            double zDiff = Math.Abs(zInt - Z);
            if (xDiff > yDiff && xDiff > zDiff)
            {
                xInt = -yInt - zInt;
            }
            else if (yDiff > zDiff)
            {
                yInt = -xInt - zInt;
            }
            return new Hex(xInt, yInt);
        }
        public static implicit operator Hex(HexF hexF) => hexF.ToHex();
        public static implicit operator HexF(Hex hex) => new(hex.X + 1e-6, hex.Y + 1e-6);

        public HexF Lerp(HexF b, double t) => new(X * (1.0 - t) + b.X * t, Y * (1.0 - t) + b.Y * t);
    }
}
