using System;

namespace LostHarbor.Core.Extensions
{
    public static class DoubleExtensions
    {
        /// <summary>
        /// Compares two Double values to see if one is larger or considered equal to the other.
        /// </summary>
        /// <param name="comparedWith">The Double to compare with.</param>
        /// <param name="comparedTo">The Double to compare to.</param>
        /// <param name="epsilon">The smallest difference that is considered equal.</param>
        /// <returns>True if greater than or nearly equal to; false otherwise.</returns>
        public static bool GreaterOrNearlyEqualTo(this Double comparedWith, Double comparedTo,
            Double epsilon = EPSILON)
        {
            return comparedWith.NearlyEqualTo(comparedTo, epsilon) || comparedWith > comparedTo;
        }

        /// <summary>
        /// Compares two Double values to see if one is larger than the other.
        /// </summary>
        /// <param name="comparedWith">The Double to compare with.</param>
        /// <param name="comparedTo">The Double to compare to.</param>
        /// <param name="epsilon">The smallest difference that is considered equal.</param>
        /// <returns>True if greater than; false otherwise.</returns>
        public static bool GreaterThan(this Double comparedWith, Double comparedTo,
            Double epsilon = EPSILON)
        {
            return comparedWith > comparedTo + epsilon;
        }

        /// <summary>
        /// Compares two Double values to see if one is smaller or considered equal to the other.
        /// </summary>
        /// <param name="comparedWith">The Double to compare with.</param>
        /// <param name="comparedTo">The Double to compare to.</param>
        /// <param name="epsilon">The smallest difference that is considered equal.</param>
        /// <returns>True if lesser than or nearly equal to; false otherwise.</returns>
        public static bool LesserOrNearlyEqualTo(this Double comparedWith, Double comparedTo,
            Double epsilon = EPSILON)
        {
            return comparedWith.NearlyEqualTo(comparedTo, epsilon) || comparedWith < comparedTo;
        }

        /// <summary>
        /// Compares two Double values to see if one is smaller than the other.
        /// </summary>
        /// <param name="comparedWith">The Double to compare with.</param>
        /// <param name="comparedTo">The Double to compare to.</param>
        /// <param name="epsilon">The smallest difference that is considered equal.</param>
        /// <returns>True if lesser than; false otherwise.</returns>
        public static bool LesserThan(this Double comparedWith, Double comparedTo,
            Double epsilon = EPSILON)
        {
            return comparedWith < comparedTo - epsilon;
        }

        /// <summary>
        /// Compares two Double values to see if they are close enough to be considered equal.
        /// </summary>
        /// <param name="comparedWith">The Double to compare with.</param>
        /// <param name="comparedTo">The Double to compare to.</param>
        /// <param name="epsilon">The smallest difference that is considered equal.</param>
        /// <returns>True is nearly equal to; false otherwise.</returns>
        public static bool NearlyEqualTo(this Double comparedWith, Double comparedTo,
            Double epsilon = EPSILON)
        {
            var absoluteDifference = Math.Abs(comparedWith - comparedTo);

            return absoluteDifference < epsilon;
        }

        private const Double EPSILON = 0.0005;

        public static Double RotationNormalizedDeg(this Double rotation)
        {
            rotation = rotation % 360.0;

            if (rotation < 0)
            {
                rotation += 360.0;
            }

            return rotation;
        }

        public static Double RotationNormalizedRad(this Double rotation)
        {
            rotation = rotation % Math.PI;
            if (rotation < 0)
            {
                rotation += Math.PI;
            }
            return rotation;
        }




        /// <summary>
        /// Ensures this double falls within the range specified by the lower and upper bounds.
        /// </summary>
        /// <param name="doubleToClamp"> The double that has its value clamped. </param>
        /// <param name="lowerBound"> Smallest allowed value of this double; inclusive. </param>
        /// <param name="upperBound"> Largest allowed value of this double; inclusive. </param>
        /// <returns> The original double, or the lower or upper bound. </returns>
        public static double Clamp(this double doubleToClamp, double lowerBound, double upperBound)
        {
            return Math.Min(Math.Max(doubleToClamp, lowerBound), upperBound);
        }

        /// <summary>
        /// Determines if a double is equivalent to another double within a certain precision.
        /// </summary>
        /// <param name="source"> The double being compared. </param>
        /// <param name="compareTo"> The double the source is being compared with. </param>
        /// <param name="epsilon"> The maximum difference to be considered equivalent. </param>
        /// <returns> Whether the doubles can be considered equivalent. </returns>
        public static bool Equivalent(this double source, double compareTo, double epsilon = Double.Epsilon)
        {
            var absoluteDifference = Math.Abs(source - compareTo);

            return absoluteDifference < epsilon;
        }

        /// <summary>
        /// Determines if a double is equivalent to another double within a certain precision.
        /// </summary>
        /// <param name="source"> The double being compared. </param>
        /// <param name="compareTo"> The double the source is being compared with. </param>
        /// <param name="precision"> The number of digits of precision. </param>
        /// <returns> Whether the doubles can be considered equivalent. </returns>
        public static bool Equivalent(this double source, double compareTo, int precision = 0)
        {
            var epsilon = 1.0 / Math.Pow(10, precision);

            return source.Equivalent(compareTo, epsilon);
        }
    }
}
