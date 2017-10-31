using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebTextCounter.Service
{
    public class WebTextCounterService
    {
        private string webAddress;

        public WebTextCounterService(string address)
        {
            this.webAddress = address;
        }

        public object Count()
        {
            _CheckValidWebAddress();

            throw new NotImplementedException();
        }

        private void _CheckValidWebAddress()
        {
            if (string.IsNullOrWhiteSpace(webAddress))
                throw new Exception("Invalid web address");

            if (!WebHelper.WebAddressIsAlive(webAddress))
                throw new Exception("Invalid web address");
        }

    }
}
