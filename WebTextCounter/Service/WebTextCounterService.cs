using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using WebTextCounter.Common;
using WebTextCounter.Helpers;

namespace WebTextCounter.Service
{    
    public class WebTextCounterService
    {
        public List<TextData> GetData(string address)
        {
            return _GetTextDataFromWebResult(WebHelper.GetWebData(address));
        }

        private List<TextData> _GetTextDataFromWebResult(string webData)
        {
            //remove anything that's not a word
            var reg = new Regex(@"[^\w]");
            return webData.Split(new char[] { '\r', '\n', ' ' }, StringSplitOptions.RemoveEmptyEntries) // break it in parts
                          .Select(s => reg.Replace(s, string.Empty).Trim().ToLower()) // take only chars
                          .Where(st=> st.Length > 0) // exclude empty strings
                          .GroupBy(a => a) // group, count and check for prime
                          .Select(m => new TextData { Name = m.Key, Count = m.Count(), IsPrime = MathHelper.IsPrime(m.Count()) })
                          .OrderBy(g=>g.Name) // not necessary, but it is easier to follow in the screen
                          .ToList();
        }
    }
}
