using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuralNetworks.Exceptions
{
    public class InvalidInputException : Exception
    {
        public new string Message
        {
            get
            {
                return "Invalid input exception: " + base.Message;
            }
        }
        public InvalidInputException(string message) : base(message) { }
    }
}
