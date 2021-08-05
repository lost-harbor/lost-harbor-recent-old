using System.Collections.Generic;

namespace LostHarbor.Core.Statistics.DiscreteRandomVariable
{
    /// <summary>
    /// A data structure for storing a squared histogram lookup table that uses aliasing.
    /// </summary>
    /// <remarks>
    /// Stores the probability that a uniform distribution of i = 0..n  will be i and not an alias stored for i.
    ///
    /// Based on the statistics work of George Marsaglia, Wai Wan Tsang, Jingbo Wang in their paper <i> "Fast
    /// Generation of Discrete Random Variables" </i>, as detailed in Section 4. http://dx.doi.org/10.18637/jss.v011.i03
    /// </remarks>
    internal struct AliasHistogramTable
    {
        #region Public Fields

        public List<int> Alias;
        public List<double> Probability;

        #endregion Public Fields

        #region Public Methods

        /// <summary>
        /// Determines if the lookup table is in a state that can be properly used.
        /// </summary>
        /// <returns>If the lookup table is in a usable state.</returns>
        public bool IsValid()
        {
            if (Alias == null || Probability == null) return false;

            if (Alias.Count != Probability.Count) return false;

            return true;
        }

        #endregion Public Methods
    }
}
