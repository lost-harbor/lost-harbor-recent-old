using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

namespace LostHarbor.Core.Markov
{
    public static class Language
    {
        /// <summary>
        ///
        /// </summary>
        /// <param name="fileUri"></param>
        /// <param name="delimiter"></param>
        /// <returns></returns>
        public static List<String> LoadSampleFile(String fileUri, String delimiter)
        {
            try
            {
                var fileContents = File.ReadAllText(fileUri, Encoding.UTF32);
                return ParseSampleString(fileContents, delimiter);
            }
            catch (Exception e)
            {
                throw new Exception("Error loading sample file.", e);
            }
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="sample"></param>
        /// <param name="delimiter"></param>
        /// <returns></returns>
        public static List<String> ParseSampleString(String sample, String delimiter)
        {
            var lines = sample.Split(new String[] { "\n" }, StringSplitOptions.RemoveEmptyEntries);

            List<String> words = new List<String>();

            foreach (var line in lines)
            {
                words.AddRange(line.Split(new String[] { delimiter }, StringSplitOptions.RemoveEmptyEntries));
            }

            return words;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="samples"></param>
        /// <param name="order"></param>
        /// <returns></returns>
        public static Model CreateModel(List<String> samples, Int32 order)
        {
            return new Model(samples, order);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static Chain CreateChain(Model model)
        {
            return new Chain(model);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="samples"></param>
        /// <param name="order"></param>
        /// <returns></returns>
        public static Chain CreateChain(List<String> samples, Int32 order)
        {
            return new Chain(new Model(samples, order));
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="fileUri"></param>
        /// <returns></returns>
        public static Chain LoadChain(String fileUri)
        {
            return null;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="chain"></param>
        /// <param name="fileUri"></param>
        public static void SaveChain(Chain chain, String fileUri)
        {
            using (var stream = File.Open(fileUri, FileMode.Create))
            {
                var binaryFormatter = new BinaryFormatter();
                binaryFormatter.Serialize(stream, chain);
            }
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="chain"></param>
        /// <param name="count"></param>
        /// <param name="random"></param>
        /// <returns></returns>
        public static List<String> GenerateWords(Chain chain, Int32 count, System.Random random = null)
        {
            if (random == null) random = new System.Random();

            var words = new List<String>();

            for (int i = 0; i < count; i++)
            {
                words.Add(GenerateWord(chain, random));
            }

            return words;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="chain"></param>
        /// <param name="random"></param>
        /// <returns></returns>
        public static String GenerateWord(Chain chain, System.Random random = null)
        {
            if (random == null) random = new System.Random();

            var word = PrivateUseArea.StartWord.ToString();

            while (word[word.Length - 1] != PrivateUseArea.EndWord)
            {
                word += chain.NextLetter(word, random);
            }

            return word;
        }
    }
}
