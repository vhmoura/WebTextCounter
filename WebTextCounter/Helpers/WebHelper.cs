using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace WebTextCounter.Helpers
{
    public class WebHelper
    {
        public static bool WebAddressIsAlive(string address)
        {
            try
            {
                var request = (HttpWebRequest)HttpWebRequest.Create(address);
                request.Timeout = 3000;
                request.AllowAutoRedirect = false;
                request.Method = "HEAD";
                using (var response = request.GetResponse())
                {
                    return true;
                }
            }
            catch
            {
                return false;
            }            
        }

        public static string GetWebData(string address)
        {
            using (var client = new WebClient())
            using (var stream = client.OpenRead(address))
            using (var textReader = new StreamReader(stream, Encoding.UTF8, true))
            {
                return textReader.ReadToEnd();
            }
        }
    }
}
