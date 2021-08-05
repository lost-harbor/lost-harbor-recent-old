using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LostHarbor.Core.Extensions
{
    public static class CharExtensions
    {
        /// <summary>
        /// </summary>
        /// <param name="charToRepeat"></param>
        /// <param name="timesToRepeat"></param>
        /// <returns></returns>
        public static string Repeat(this char charToRepeat, int timesToRepeat)
        {
            return new string(charToRepeat, timesToRepeat);
        }
    }
}
