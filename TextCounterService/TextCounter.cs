using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using TextCounterService.Common;
using TextCounterService.Helpers;

namespace TextCounterService
{
    public class TextCounter: TextCounterBase
    {
        public List<TextDataDto> CountWords<T>(string location) where T: ITextCounter
        {
            var source = (ITextCounter)Activator.CreateInstance(typeof(T));

            return GetTextDataDtoFromString(source.GetString(location));
        }        
    }
}
