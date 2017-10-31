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
        private string webAddress;

        public WebTextCounterService(string address)
        {
            this.webAddress = address;
        }

        public List<TextData> GetData()
        {
            if (string.IsNullOrWhiteSpace(webAddress))
                throw new Exception("Invalid web address");

            try
            {
                var webData = WebHelper.GetWebData(webAddress);                
                return _GetTextDataFromWebResult(webData);
            }
            catch
            {
                throw new Exception("Invalid web address");
            }                           
        }

        private List<TextData> _GetTextDataFromWebResult(string webData)
        {            
            var reg = new Regex("[^a-zA-Z']");
            return webData.Split(new char[] { '\r', '\n', ' ' }, StringSplitOptions.RemoveEmptyEntries) // remove new line
                                       .Select(s => reg.Replace(s, string.Empty).ToLower()) // take only chars
                                       .GroupBy(a => a) // group, count and check for prime
                                       .Select(m => new TextData { Name = m.Key, Count = m.Count(), IsPrime = MathHelper.IsPrime(m.Count()) })
                                       .ToList();
        }
    }
}
