using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Registalaser.Domain.Exceptions
{
    public class UnAuth: Exception
    {
        public UnAuth(string message):base(message)
        {

        }
        public UnAuth(String message, Exception innerException) : base(message, innerException)
        {

        }

        public override string ToString()
        {
            return Message;
        }
    }
}
