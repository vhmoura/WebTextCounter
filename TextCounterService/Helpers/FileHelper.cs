using System;
using System.Collections.Generic;
using System.Text;
using TextCounterService.Common;

namespace TextCounterService.Helpers
{
    public static class FileHelper
    {
        public static string GetString(string fileName)
        {
            if (!System.IO.File.Exists(fileName))
                throw new InvalidFileException();

            var text = System.IO.File.ReadAllText(fileName);

            if (string.IsNullOrEmpty(text))
                throw new EmptyStringException();

            return text;
        }
    }
}
