using System;

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
