using System.Collections.Generic;
using System.Linq;

namespace LostHarbor.Core.Markov
{
    /// <summary>
    ///
    /// </summary>
    public class Chain
    {
        #region Private Fields

        private List<char> alphabet;
        private int order;
        private Dictionary<int, Order> orders;

        #endregion Private Fields

        #region Public Constructors

        public Chain(Model model)
        {
            orders = new Dictionary<int, Order>();
            order = model.Levels.Count;

            AnalyzeAlphabet(model);
            AnalyzeModel(model);
        }

        #endregion Public Constructors

        #region Internal Indexers

        internal Order this[int order]
        {
            get
            {
                return orders[order];
            }
        }

        #endregion Internal Indexers

        #region Public Methods

        public char NextLetter(string context, System.Random random)
        {
            for (int i = context.Length; i > 0; i--)
            {
                var letter = orders[i].Next(context, random);

                if (letter != PrivateUseArea.NoCharacter) return letter;
            }

            return PrivateUseArea.NoCharacter;
        }

        public char RandomLetter(System.Random random)
        {
            var randomIndex = random.Next(0, alphabet.Count);

            return alphabet[randomIndex];
        }

        #endregion Public Methods

        #region Private Methods

        private void AnalyzeAlphabet(Model model)
        {
            alphabet = model.Alphabet.Outcomes.Keys.ToList();

            if (alphabet.Contains(PrivateUseArea.StartWord))
                alphabet.Remove(PrivateUseArea.StartWord);

            if (alphabet.Contains(PrivateUseArea.EndWord))
                alphabet.Remove(PrivateUseArea.EndWord);

            alphabet.Sort();
        }

        private void AnalyzeModel(Model model)
        {
            for (int i = 1; i <= order; i++)
            {
                orders.Add(i, new Order());

                var level = model[i];

                foreach (string processKey in level.Processes.Keys)
                {
                    var process = level[processKey];

                    foreach (char outcomeKey in process.Outcomes.Keys)
                    {
                        var outcome = process[outcomeKey];

                        double probability = outcome / process.Total;
                        orders[i].Add(processKey, outcomeKey, probability);
                    }
                }
            }
        }

        #endregion Private Methods
    }
}
