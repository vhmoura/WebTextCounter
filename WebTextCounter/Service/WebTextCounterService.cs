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
            var result = _GetTextDataFromWebResult(WebHelper.GetWebData(address));
            return result;
        }

        private List<TextData> _GetTextDataFromWebResult(string webData)
        {
            var reg = new Regex("[^a-zA-Z']");
            //var reg = new Regex(@"[^\w\s]");

            return webData.Split(new char[] { '\r', '\n', ' ' }, StringSplitOptions.RemoveEmptyEntries) // remove new line
                          .Select(s => reg.Replace(s, string.Empty).Trim().ToLower()) // take only chars
                          .GroupBy(a => a) // group, count and check for prime
                          .Select(m => new TextData { Name = m.Key, Count = m.Count(), IsPrime = MathHelper.IsPrime(m.Count()) })
                          .OrderBy(g=>g.Name)
                          .ToList();
        }
    }
}
