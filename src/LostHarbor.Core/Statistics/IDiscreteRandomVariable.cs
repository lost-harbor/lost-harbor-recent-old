using System;
using System.Collections.Generic;

namespace LostHarbor.Core.Statistics
{
    public interface IDiscreteRandomVariable
    {
        void Save(string fileURI);

        void Load(string fileURI);

        void Create(List<double> probabilities);

        int Next(System.Random random);
    }
}
