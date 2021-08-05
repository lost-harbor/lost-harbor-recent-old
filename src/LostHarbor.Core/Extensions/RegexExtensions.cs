using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace LostHarbor.Core.Extensions
{
    public static class RegexExtensions
    {
        public static bool IsMatch(this string value, string pattern)
        {
            var regex = new Regex(pattern);
            return regex.IsMatch(value);
        }
    }
}
