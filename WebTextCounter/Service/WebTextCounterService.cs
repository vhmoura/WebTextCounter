using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using WebTextCounter.Helpers;

namespace WebTextCounter.Service
{
    public class AA
    {
        public string Name { get; set; }
        public int Count { get; set; }
        public bool IsPrime { get; set; }
    }

    public class WebTextCounterService
    {
        private string webAddress;

        public WebTextCounterService(string address)
        {
            this.webAddress = address;
        }

        public List<AA> GetData()
        {
            if (string.IsNullOrWhiteSpace(webAddress))
                throw new Exception("Invalid web address");

            try
            {
                var task = Task.FromResult<string>(WebHelper.GetWebData(webAddress))
                .ContinueWith(i =>
                {
                    var reg = new Regex("[^a-zA-Z']");
                    return i.Result.Split(new char[] { '\r', '\n', ' ' }, StringSplitOptions.RemoveEmptyEntries) // remove new line
                                       .Select(s => reg.Replace(s, string.Empty).ToLower()) // take only chars
                                       .GroupBy(a => a) // group and count
                                       .Select(m => new AA { Name = m.Key, Count = m.Count(), IsPrime = MathHelper.IsPrime(m.Count()) })
                                       .ToList();
                });

                return task.Result;
            }
            catch
            {
                throw new Exception("Invalid web address");
            }                           
        }
    }
}
