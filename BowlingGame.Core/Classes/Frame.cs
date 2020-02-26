
namespace BowlingGame.Core.Classes
{
    public class Frame
    {
        public bool IsStrike { get; set; }
        public bool IsSpare { get; set; }
        public int? Score { get; set; }
        public int Roll1 { get; set; }
        public int? Roll2 { get; set; }
        public int? Roll3 { get; set; }
    }
}
