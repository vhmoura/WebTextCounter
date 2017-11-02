using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using TextCounterService.Common;

namespace TextCounterService.Helpers
{
    public static class Web
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
            }
            catch
            {
                throw new UnableToConnectWebAddressException();
            }
        }
    }
}
