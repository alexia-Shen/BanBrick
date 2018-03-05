using System;
using System.Collections.Generic;
using System.Linq;

namespace BanBrick.Infrastructure.Extensions
{
    public static class StringExtensions
    {
        public static Dictionary<string, string> ToDictionary(this string str) {
            var result = new Dictionary<string, string>();

            if (string.IsNullOrEmpty(str))
                return result;

            var values = str.Split(';').Select(x => x.Split('='));

            foreach (var value in values)
            {
                if (value.Length == 1) {
                    result.Add(value[0].Trim(), "true");
                } else {
                    result.Add(value[0].Trim(), value[1].Trim());
                }
            }
            
            return result;
        }
    }
}
