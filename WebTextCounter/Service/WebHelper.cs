using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace WebTextCounter.Service
{
    public static class WebHelper
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
    }
}
