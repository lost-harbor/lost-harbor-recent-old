using System;

namespace LostHarbor.Core.Extensions
{
    public static class SingleExtensions
    {
        /// <summary>
        /// Compares two Single values to see if one is larger or considered equal to the other.
        /// </summary>
        /// <param name="comparedWith">The Single to compare with.</param>
        /// <param name="comparedTo">The Single to compare to.</param>
        /// <param name="epsilon">The smallest difference that is considered equal.</param>
        /// <returns>True if greater than or nearly equal to; false otherwise.</returns>
        public static bool GreaterOrNearlyEqualTo(this Single comparedWith, Single comparedTo,
            Single epsilon = EPSILON)
        {
            return comparedWith.NearlyEqualTo(comparedTo, epsilon) || comparedWith > comparedTo;
        }

        /// <summary>
        /// Compares two Single values to see if one is larger than the other.
        /// </summary>
        /// <param name="comparedWith">The Single to compare with.</param>
        /// <param name="comparedTo">The Single to compare to.</param>
        /// <param name="epsilon">The smallest difference that is considered equal.</param>
        /// <returns>True if greater than; false otherwise.</returns>
        public static bool GreaterThan(this Single comparedWith, Single comparedTo,
            Single epsilon = EPSILON)
        {
            return comparedWith > comparedTo + epsilon;
        }

        /// <summary>
        /// Compares two Single values to see if one is smaller or considered equal to the other.
        /// </summary>
        /// <param name="comparedWith">The Single to compare with.</param>
        /// <param name="comparedTo">The Single to compare to.</param>
        /// <param name="epsilon">The smallest difference that is considered equal.</param>
        /// <returns>True if lesser than or nearly equal to; false otherwise.</returns>
        public static bool LesserOrNearlyEqualTo(this Single comparedWith, Single comparedTo,
            Single epsilon = EPSILON)
        {
            return comparedWith.NearlyEqualTo(comparedTo, epsilon) || comparedWith < comparedTo;
        }

        /// <summary>
        /// Compares two Single values to see if one is smaller than the other.
        /// </summary>
        /// <param name="comparedWith">The Single to compare with.</param>
        /// <param name="comparedTo">The Single to compare to.</param>
        /// <param name="epsilon">The smallest difference that is considered equal.</param>
        /// <returns>True if lesser than; false otherwise.</returns>
        public static bool LesserThan(this Single comparedWith, Single comparedTo,
            Single epsilon = EPSILON)
        {
            return comparedWith < comparedTo - epsilon;
        }

        /// <summary>
        /// Compares two Single values to see if they are close enough to be considered equal.
        /// </summary>
        /// <param name="comparedWith">The Single to compare with.</param>
        /// <param name="comparedTo">The Single to compare to.</param>
        /// <param name="epsilon">The smallest difference that is considered equal.</param>
        /// <returns>True is nearly equal to; false otherwise.</returns>
        public static bool NearlyEqualTo(this Single comparedWith, Single comparedTo,
            Single epsilon = EPSILON)
        {
            var absoluteDifference = MathF.Abs(comparedWith - comparedTo);

            return absoluteDifference < epsilon;
        }

        private const Single EPSILON = 0.0005F;

        public static Single RotationNormalizedDeg(this Single rotation)
        {
            rotation = rotation % 360.0f;

            if (rotation < 0)
            {
                rotation += 360.0f;
            }

            return rotation;
        }

        public static Single RotationNormalizedRad(this Single rotation)
        {
            rotation = rotation % MathF.PI;
            if (rotation < 0)
            {
                rotation += MathF.PI;
            }
            return rotation;
        }
    }
}
