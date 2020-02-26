using System;
using System.Collections.Generic;
using System.Text;

namespace BowlingGame.Core.Exceptions
{
    public class FramesOutOfRangeException : Exception
    {
        public FramesOutOfRangeException()
            : base("Frames parameter is out of range.")
        {

        }
    }
}
