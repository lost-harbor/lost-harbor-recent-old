using System;
using System.Collections.Generic;

namespace LostHarbor.Core.Statistics
{
    public abstract class ProbabilityTable<T> : IProbabilityTable<T>
    {
        private List<T> Values;

        public virtual void Create(Dictionary<T, double> probabilities)
        {
            throw new NotImplementedException();
        }

        public abstract bool IsValid();

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
