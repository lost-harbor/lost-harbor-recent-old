using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LostHarbor.Core.Extensions
{
    public static class DecimalExtensions
    {
        /// <summary>
        /// Compares two Decimal values to see if one is larger or considered equal to the other.
        /// </summary>
        /// <param name="comparedWith">The Decimal to compare with.</param>
        /// <param name="comparedTo">The Decimal to compare to.</param>
        /// <param name="epsilon">The smallest difference that is considered equal.</param>
        /// <returns>True if greater than or nearly equal to; false otherwise.</returns>
        public static bool GreaterOrNearlyEqualTo(this Decimal comparedWith, Decimal comparedTo,
            Decimal epsilon = EPSILON)
        {
            return comparedWith.NearlyEqualTo(comparedTo, epsilon) || comparedWith > comparedTo;
        }

        /// <summary>
        /// Compares two Decimal values to see if one is larger than the other.
        /// </summary>
        /// <param name="comparedWith">The Decimal to compare with.</param>
        /// <param name="comparedTo">The Decimal to compare to.</param>
        /// <param name="epsilon">The smallest difference that is considered equal.</param>
        /// <returns>True if greater than; false otherwise.</returns>
        public static bool GreaterThan(this Decimal comparedWith, Decimal comparedTo,
            Decimal epsilon = EPSILON)
        {
            return comparedWith > comparedTo + epsilon;
        }

        /// <summary>
        /// Compares two Decimal values to see if one is smaller or considered equal to the other.
        /// </summary>
        /// <param name="comparedWith">The Decimal to compare with.</param>
        /// <param name="comparedTo">The Decimal to compare to.</param>
        /// <param name="epsilon">The smallest difference that is considered equal.</param>
        /// <returns>True if lesser than or nearly equal to; false otherwise.</returns>
        public static bool LesserOrNearlyEqualTo(this Decimal comparedWith, Decimal comparedTo,
            Decimal epsilon = EPSILON)
        {
            return comparedWith.NearlyEqualTo(comparedTo, epsilon) || comparedWith < comparedTo;
        }

        /// <summary>
        /// Compares two Decimal values to see if one is smaller than the other.
        /// </summary>
        /// <param name="comparedWith">The Decimal to compare with.</param>
        /// <param name="comparedTo">The Decimal to compare to.</param>
        /// <param name="epsilon">The smallest difference that is considered equal.</param>
        /// <returns>True if lesser than; false otherwise.</returns>
        public static bool LesserThan(this Decimal comparedWith, Decimal comparedTo,
            Decimal epsilon = EPSILON)
        {
            return comparedWith < comparedTo - epsilon;
        }

        /// <summary>
        /// Compares two Decimal values to see if they are close enough to be considered equal.
        /// </summary>
        /// <param name="comparedWith">The Decimal to compare with.</param>
        /// <param name="comparedTo">The Decimal to compare to.</param>
        /// <param name="epsilon">The smallest difference that is considered equal.</param>
        /// <returns>True is nearly equal to; false otherwise.</returns>
        public static bool NearlyEqualTo(this Decimal comparedWith, Decimal comparedTo,
            Decimal epsilon = EPSILON)
        {
            var absoluteDifference = Math.Abs(comparedWith - comparedTo);

            return absoluteDifference < epsilon;
        }

        private const Decimal EPSILON = 0.0005M;

        public static Decimal RotationNormalizedDeg(this Decimal rotation)
        {
            rotation = rotation % 360.0M;

            if (rotation < 0)
            {
                rotation += 360.0M;
            }

            return rotation;
        }

        public static Decimal RotationNormalizedRad(this Decimal rotation)
        {
            rotation = rotation % (Decimal)Math.PI;
            if (rotation < 0)
            {
                rotation += (Decimal)Math.PI;
            }
            return rotation;
        }
    }
}
