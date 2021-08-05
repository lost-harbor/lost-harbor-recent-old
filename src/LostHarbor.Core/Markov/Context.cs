using System;
using System.Collections.Generic;
using System.Linq;

namespace LostHarbor.Core.Markov
{
    /// <summary>
    ///
    /// </summary>
    internal class Context
    {
        #region Private Fields

        private bool hasCalculatedProbabilities = false;
        private List<char> outcomes;
        private List<double> probabilities;

        #endregion Private Fields

        #region Internal Constructors

        /// <summary>
        ///
        /// </summary>
        internal Context()
        {
            outcomes = new List<char>();
            probabilities = new List<double>();
        }

        #endregion Internal Constructors

        #region Internal Methods

        /// <summary>
        ///
        /// </summary>
        /// <param name="outcome"></param>
        /// <param name="probability"></param>
        internal void Add(char outcome, double probability)
        {
            outcomes.Add(outcome);
            probabilities.Add(probability);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="random"></param>
        /// <returns></returns>
        internal char Next(System.Random random)
        {
            if (!hasCalculatedProbabilities)
                CalculateProbabilities();

            var chance = random.NextDouble();

            for (int i = 0; i < probabilities.Count; i++)
            {
                if (probabilities[i] > chance)
                    return outcomes[i];
            }

            return outcomes.Last();
        }

        #endregion Internal Methods

        #region Private Methods

        /// <summary>
        ///
        /// </summary>
        private void CalculateProbabilities()
        {
            hasCalculatedProbabilities = true;
            if (probabilities.Count < 2) return;

            for (int i = 1; i < probabilities.Count; i++)
            {
                probabilities[i] += probabilities[i - 1];
            }

            probabilities[probabilities.Count - 1] = 1;
        }

        #endregion Private Methods
    }
}
