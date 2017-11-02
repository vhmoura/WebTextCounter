using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using TextCounterService.Common;
using TextCounterService.Helpers;

namespace TextCounterService
{
    public class TextCounter
    {
        public List<TextDataDto> CountWordsFromWeb(string address)
        {
            return _GetTextDataFromWebResult(Web.GetString(address));
        }

        public List<TextDataDto> CountWordsFromString(string text)
        {
            return _GetTextDataFromWebResult(Text.GetString(text));
        }

        public List<TextDataDto> CountWordsFromFile(string fileName)
        {
            return _GetTextDataFromWebResult(FileHelper.GetString(fileName));
        }

        private List<TextDataDto> _GetTextDataFromWebResult(string webData)
        {
            //remove anything that's not alpha
            var reg = new Regex(@"[^\w]");
            return webData.Split(new char[] { '\r', '\n', ' ' }, StringSplitOptions.RemoveEmptyEntries) // break it in parts
                          .Select(s => reg.Replace(s, string.Empty).Trim().ToLower()) // take only chars
                          .Where(st => st.Length > 0) // exclude empty strings
                          .GroupBy(a => a) // group, count and check for prime
                          .Select(m => new TextDataDto { Name = m.Key, Count = m.Count(), IsPrime = Prime.IsPrime(m.Count()) })
                          .OrderBy(g => g.Name) // not necessary, but it is easier to follow in the screen
                          .ToList();
        }
    }
}
