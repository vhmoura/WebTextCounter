using System;
using System.Collections.Generic;
using System.Text;
using TextCounterService.Common;

namespace TextCounterService.Helpers
{
    public class Text: ITextCounter
    {
        public string GetString(string text)
        {
            if (string.IsNullOrWhiteSpace(text))
                throw new EmptyStringException();

            return text;
        }
    }
}
