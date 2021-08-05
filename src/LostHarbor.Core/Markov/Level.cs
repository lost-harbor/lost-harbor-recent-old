using System;
using System.Collections.Generic;

namespace LostHarbor.Core.Markov
{
    /// <summary>
    ///
    /// </summary>
    internal class Level
    {
        #region Private Fields

        private int order = 0;
        private Dictionary<string, Process> processes;
        private int total = 0;

        #endregion Private Fields

        #region Internal Constructors

        /// <summary>
        ///
        /// </summary>
        /// <param name="order"></param>
        internal Level(int order)
        {
            this.order = order;
            processes = new Dictionary<string, Process>();
        }

        #endregion Internal Constructors

        #region Internal Properties

        /// <summary>
        ///
        /// </summary>
        internal Dictionary<string, Process> Processes
        {
            get
            {
                return processes;
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
        /// <param name="process"></param>
        /// <returns></returns>
        internal Process this[string process]
        {
            get
            {
                if (processes.ContainsKey(process))
                    return processes[process];
                else
                    return new Process();
            }
        }

        #endregion Internal Indexers

        #region Internal Methods

        /// <summary>
        ///
        /// </summary>
        /// <param name="process"></param>
        /// <param name="outcome"></param>
        internal void Add(string process, char outcome)
        {
            var sanitizedProcess = SanitizeProcess(process);

            if (processes.ContainsKey(sanitizedProcess))
                processes[sanitizedProcess].Add(outcome);
            else
                processes.Add(sanitizedProcess, new Process(outcome));

            total++;
        }

        #endregion Internal Methods

        #region Private Methods

        /// <summary>
        ///
        /// </summary>
        /// <param name="process"></param>
        /// <returns></returns>
        private string SanitizeProcess(string process)
        {
            var processLength = process.Length;

            if (processLength < order) throw new ArgumentException("Process length cannot be smaller than order.");

            if (processLength > order)
                return process.Substring(processLength - order);
            else
                return process;
        }

        #endregion Private Methods
    }
}
