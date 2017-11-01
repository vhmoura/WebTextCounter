using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using WebTextCounter.Common;

namespace WebTextCounter.Helpers
{
    public class WebHelper
    {
        public static string GetWebData(string address)
        {
            if (string.IsNullOrWhiteSpace(address))
                throw new InvalidWebAddressException();

            try
            {
                using (var client = new WebClient())
                using (var stream = client.OpenRead(address))
                using (var textReader = new StreamReader(stream, Encoding.UTF8, true))
                {
                    return textReader.ReadToEnd();
                }
            } catch 
            {
                throw new UnableToConnectWebAddressException();
            }
        }
    }
}
