using System.Collections.Generic;

namespace LostHarbor.Core.Markov
{
    internal class Process
    {
        #region Private Fields

        private Dictionary<char, int> outcomes;
        private int total = 0;

        #endregion Private Fields

        #region Internal Constructors

        /// <summary>
        ///
        /// </summary>
        internal Process()
        {
            outcomes = new Dictionary<char, int>();
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="outcome"></param>
        internal Process(char outcome)
        {
            outcomes = new Dictionary<char, int>();
            Add(outcome);
        }

        #endregion Internal Constructors

        #region Internal Properties

        /// <summary>
        ///
        /// </summary>
        internal Dictionary<char, int> Outcomes
        {
            get
            {
                return outcomes;
            }
        }

        /// <summary>
        ///
        /// </summary>
        internal int Total
        {
            get
            {
                return total;
            }
        }

        #endregion Internal Properties

        #region Internal Indexers

        /// <summary>
        ///
        /// </summary>
        /// <param name="outcome"></param>
        /// <returns></returns>
        internal int this[char outcome]
        {
            get
            {
                if (outcomes.ContainsKey(outcome))
                    return outcomes[outcome];
                else
                    return 0;
            }
        }

        #endregion Internal Indexers

        #region Internal Methods

        /// <summary>
        ///
        /// </summary>
        /// <param name="outcome"></param>
        internal void Add(char outcome)
        {
            if (outcomes.ContainsKey(outcome))
                outcomes[outcome]++;
            else
                outcomes.Add(outcome, 1);

            total++;
        }

        #endregion Internal Methods
    }
}
