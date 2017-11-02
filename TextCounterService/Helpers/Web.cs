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
        public static string GetString(string address)
        {
            if (string.IsNullOrWhiteSpace(address))
                throw new InvalidWebAddressException();

            string result = string.Empty;
            using (var client = new WebClient())
            {
                try
                {
                    using (var stream = client.OpenRead(address))
                    using (var textReader = new StreamReader(stream, Encoding.UTF8, true))
                    {
                        result = textReader.ReadToEnd();
                    }
                }
                catch
                {
                    throw new UnableToConnectWebAddressException();
                }
            }

            if (string.IsNullOrEmpty(result))
                throw new EmptyStringException();

            return result;
        }
    }
}
