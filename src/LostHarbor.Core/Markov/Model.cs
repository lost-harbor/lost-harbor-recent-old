using System;
using System.Collections.Generic;
using LostHarbor.Core.Extensions;

namespace LostHarbor.Core.Markov
{
    public class Model
    {
        #region Private Fields

        private Process alphabet;

        private Dictionary<int, Level> levels;

        #endregion Private Fields

        #region Public Constructors

        /// <summary>
        ///
        /// </summary>
        /// <param name="samples"></param>
        /// <param name="order"></param>
        public Model(List<string> samples, int order)
        {
            CreateEmptyLevels(order);
            AnalyzeSamples(samples, order);
        }

        #endregion Public Constructors

        #region Internal Properties

        /// <summary>
        ///
        /// </summary>
        internal Process Alphabet
        {
            get
            {
                return alphabet;
            }
        }

        /// <summary>
        ///
        /// </summary>
        internal Dictionary<int, Level> Levels
        {
            get
            {
                return levels;
            }
        }

        #endregion Internal Properties

        #region Internal Indexers

        /// <summary>
        ///
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
        internal Level this[int order]
        {
            get
            {
                if (!levels.ContainsKey(order)) throw new ArgumentOutOfRangeException("Order does not exist in model.");

                return levels[order];
            }
        }

        #endregion Internal Indexers

        #region Internal Methods

        /// <summary>
        ///
        /// </summary>
        /// <param name="process"></param>
        /// <param name="outcome"></param>
        internal void AddProcessToLevels(string process, char outcome)
        {
            alphabet.Add(outcome);

            foreach (var level in levels.Values)
            {
                level.Add(process, outcome);
            }
        }

        #endregion Internal Methods

        #region Private Methods

        /// <summary>
        ///
        /// </summary>
        /// <param name="samples"></param>
        /// <param name="order"></param>
        private void AnalyzeSamples(List<string> samples, int order)
        {
            foreach (var sample in samples)
            {
                var word = PrivateUseArea.StartWord.Repeat(order) + sample + PrivateUseArea.EndWord;

                for (int index = 0; index < word.Length - order; index++)
                {
                    var process = word.Substring(index, index + order);
                    var outcome = word[index + order];

                    AddProcessToLevels(process, outcome);
                }
            }
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="highestOrder"></param>
        private void CreateEmptyLevels(int highestOrder)
        {
            levels = new Dictionary<int, Level>();

            for (int order = 1; order <= highestOrder; order++)
            {
                levels.Add(order, new Level(order));
            }
        }

        #endregion Private Methods
    }
}
