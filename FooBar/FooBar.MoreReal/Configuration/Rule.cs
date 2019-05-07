using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FooBar.MoreReal.Configuration
{
    // Using the structure since inheritance is not needed here, 
    // and the structures are compared by value, which will be convenient when implementing checks for uniqueness of rules.
    public struct Rule
    {
        public Rule(int serialIndex, string message)
        {
            if (serialIndex < 1)
                throw new ArgumentException($"{serialIndex} must be positive, non zero", nameof(serialIndex));

            if (message == null)
                throw new ArgumentNullException(nameof(message), $"{message} can be empty, but not null");

            SerialIndex = serialIndex;
            Message = message;
        }

        public int SerialIndex { get; internal set; }
        public string Message { get; internal set; }
    }
}
