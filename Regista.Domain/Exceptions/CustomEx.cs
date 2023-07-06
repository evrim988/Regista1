using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Registalaser.Domain.Exceptions
{
    public class CustomEx:Exception
    {
        public CustomEx(string message):base(message)
        {

        }
        public CustomEx(String message, Exception innerException):base(message, innerException)
        {

        }

        public override string ToString()
        {
            return Message;
        }
    }
}
