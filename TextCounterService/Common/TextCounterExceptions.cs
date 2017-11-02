using System;
using System.Collections.Generic;
using System.Text;

namespace TextCounterService.Common
{
    public class UnableToConnectWebAddressException : Exception { }
    public class InvalidWebAddressException : Exception { }
    public class InvalidFileException : Exception { }
    public class EmptyStringException : Exception { }
}
