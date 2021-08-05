using System;
using System.Collections.Generic;

namespace LostHarbor.Core.Extensions
{
    public static class ListExtensions
    {
        #region Public Methods

        /// <summary>
        /// Fills a list with each index equal to that index.
        /// </summary>
        /// <param name="source"> List to fill. </param>
        /// <param name="count"> Number of indices to fill. </param>
        public static void FillWithIndex(this IList<int> source, int count)
        {
            for (int index = 0; index < count; index++)
            {
                source[index] = index;
            }
        }

        /// <summary>
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static int IndexOfMaxDouble(this IList<double> source)
        {
            if (source == null)
                throw new ArgumentNullException("source");
            if (source.Count == 0)
                throw new InvalidOperationException("List contains no elements");

            var maxValue = source[0];
            int maxIndex = 0;

            for (int index = 1; index < source.Count; index++)
            {
                if (source[index] > maxValue)
                {
                    maxValue = source[index];
                    maxIndex = index;
                }
            }
            return maxIndex;
        }

        /// <summary>
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static int IndexOfMinDouble(this IList<double> source)
        {
            if (source == null)
                throw new ArgumentNullException("source");
            if (source.Count == 0)
                throw new InvalidOperationException("List contains no elements");

            var minValue = source[0];
            int minIndex = 0;

            for (int index = 1; index < source.Count; index++)
            {
                if (source[index] < minValue)
                {
                    minValue = source[index];
                    minIndex = index;
                }
            }
            return minIndex;
        }

        #endregion Public Methods
    }
}
