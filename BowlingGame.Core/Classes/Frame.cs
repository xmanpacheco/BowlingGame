using System;
using System.Collections.Generic;
using System.Text;

namespace BowlingGame.Core.Classes
{
    public class Frame
    {
        public bool IsStrike { get; set; }
        public bool IsSpare { get; set; }
        public int? Score { get; set; }
    }
}
