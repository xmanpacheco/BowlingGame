using System;
using System.Collections.Generic;
using System.Text;

namespace BowlingGame.Core.Exceptions
{
    public class PinsOutOfRangeException : Exception
    {
        public PinsOutOfRangeException()
            : base("Pins parameter is out of range.")
        {

        }
    }
}
