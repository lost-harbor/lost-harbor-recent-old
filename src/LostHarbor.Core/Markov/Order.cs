using System.Collections.Generic;

namespace LostHarbor.Core.Markov
{
    /// <summary>
    ///
    /// </summary>
    internal class Order
    {
        #region Private Fields

        private Dictionary<string, Context> contexts;

        #endregion Private Fields

        #region Internal Constructors

        /// <summary>
        ///
        /// </summary>
        internal Order()
        {
            contexts = new Dictionary<string, Context>();
        }

        #endregion Internal Constructors

        #region Internal Methods

        /// <summary>
        ///
        /// </summary>
        /// <param name="context"></param>
        /// <param name="outcome"></param>
        /// <param name="probability"></param>
        internal void Add(string context, char outcome, double probability)
        {
            if (!contexts.ContainsKey(context))
                contexts.Add(context, new Context());

            contexts[context].Add(outcome, probability);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="context"></param>
        /// <param name="random"></param>
        /// <returns></returns>
        internal char Next(string context, System.Random random)
        {
            if (contexts.ContainsKey(context))
                return contexts[context].Next(random);

            return PrivateUseArea.NoCharacter;
        }

        #endregion Internal Methods
    }
}
