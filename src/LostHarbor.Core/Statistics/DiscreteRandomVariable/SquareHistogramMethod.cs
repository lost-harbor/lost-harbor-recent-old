using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using LostHarbor.Core.Extensions;

namespace LostHarbor.Core.Statistics.DiscreteRandomVariable
{
    public class SquareHistogramMethod<T> : DiscreteRandomVariableMethod<T>, IDiscreteRandomVariable
    {
        private AliasHistogramTable histogram;

        public SquareHistogramMethod(string fileURI)
        {
            Load(fileURI);
        }

        public SquareHistogramMethod(List<double> probabilities)
        {
            InitializeHistogram(probabilities);
            CalculateAliases();
        }

        private void InitializeHistogram(List<double> probabilities)
        {
            histogram = new AliasHistogramTable();

            // Aliases default to a self-reference.
            histogram.Alias = new List<int>();
            histogram.Alias.FillWithIndex(probabilities.Count);

            // Scale probabilities to an average of 1.0
            histogram.Probability = new List<double>(probabilities);
            histogram.Probability.ForEach(probability => probability *= histogram.Probability.Count);
        }

        private void CalculateAliases()
        {
            for (int index = 0; index < histogram.Probability.Count - 1; index++)
            {
                // Robin Hood heuristic
                var maxIndex = histogram.Probability.IndexOfMaxDouble(); // Rich
                var minIndex = histogram.Probability.IndexOfMinDouble(); // Poor

                histogram.Alias[minIndex] = maxIndex;
                histogram.Probability[maxIndex] -= 1 - histogram.Probability[minIndex];
            }
        }

        public void Save(string fileURI)
        {
            try
            {
                using (var file = File.Open(fileURI, FileMode.Create))
                {
                    var binaryFormatter = new BinaryFormatter();
                    binaryFormatter.Serialize(file, histogram);
                }
            }
            catch (IOException exception)
            {
                throw new IOException("Error accessing histogram file.", exception);
            }
        }

        public void Load(string fileURI)
        {
            try
            {
                using (var file = File.Open(fileURI, FileMode.Open))
                {
                    var binaryFormatter = new BinaryFormatter();
                    histogram = (AliasHistogramTable)binaryFormatter.Deserialize(file);
                }
            }
            catch (IOException exception)
            {
                throw new IOException("Error accessing histogram file.", exception);
            }

            if (!histogram.IsValid())
            {
                throw new Exception("Histogram is invalid.");
            }
        }

        public void Create(List<double> probabilities)
        {
            throw new NotImplementedException();
        }

        public int Next(System.Random random)
        {
            throw new NotImplementedException();
        }
    }
}
