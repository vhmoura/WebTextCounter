using System;
using System.Collections.Generic;
using System.Text;

namespace TextCounterService.Helpers
{
    public interface ITextCounter
    {
        string GetString(string location);
    }
}
