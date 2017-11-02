using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using TextCounterService.Common;
using TextCounterService.Helpers;

namespace TextCounterService
{
    public class TextCounterBase
    {
        protected List<TextDataDto> GetTextDataDtoFromString(string webData)
        {
            //remove anything that's not alpha
            var reg = new Regex(@"[^\w]");
            return webData.Split(new char[] { '\r', '\n', ' ' }, StringSplitOptions.RemoveEmptyEntries) // break it in parts
                          .Select(s => reg.Replace(s, string.Empty).Trim().ToLower()) // take only chars
                          .Where(st => st.Length > 0) // exclude empty strings
                          .GroupBy(a => a) // group
                          .Select(m => new TextDataDto { Name = m.Key, Count = m.Count(), IsPrime = Prime.IsPrime(m.Count()) }) // count and check for prime
                          .OrderBy(g => g.Name) // not necessary, but it is easier to follow in the screen
                          .ToList();
        }

    }
}