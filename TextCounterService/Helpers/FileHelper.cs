using System;
using System.Collections.Generic;
using System.Text;
using TextCounterService.Common;
using System.IO;

namespace TextCounterService.Helpers
{
    public class FileHelper: ITextCounter
    {
        public string GetString(string fileName)
        {
            if (!File.Exists(fileName))
                throw new InvalidFileException();

            var text = File.ReadAllText(fileName);

            if (string.IsNullOrEmpty(text))
                throw new EmptyStringException();

            return text;
        }
    }
}
