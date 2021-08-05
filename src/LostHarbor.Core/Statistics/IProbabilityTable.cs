using System;
using System.Collections.Generic;

namespace LostHarbor.Core.Statistics
{
    internal interface IProbabilityTable<T>
    {
        void Create(Dictionary<T, double> probabilities);

        void Save(string fileURI);

        void Load(string fileURI);

        T Next(System.Random random);

        bool IsValid();
    }
}
