using System;
using System.Collections.Generic;

namespace LostHarbor.Core.Statistics
{
    public class CumulativeDistribution<T> : IProbabilityTable<T>
    {
        private List<T> _Values;
        private List<double> _Probabilities;

        public void Create(Dictionary<T, double> probabilities)
        {
            // check input
            double totalProbability = 0.0;
            foreach (var probability in probabilities.Values)
            {
                totalProbability += probability;
            }
        }

        public bool IsValid()
        {
            throw new NotImplementedException();
        }

        public void Load(string fileURI)
        {
            throw new NotImplementedException();
        }

        public T Next(System.Random random)
        {
            throw new NotImplementedException();
        }

        public void Save(string fileURI)
        {
            throw new NotImplementedException();
        }
    }
}
