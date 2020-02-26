using System.Collections.Generic;

namespace BowlingGame.Core.Classes
{
    public class ScoreCard
    {
        public List<Frame> Frames { get; }

        public int Score 
        { 
            get 
            { 
                if (Frames.Count > 1)
                {
                    // Last Frame may not have a score due to unrolled strike/spare
                    return Frames[Frames.Count - 1].Score == null ?
                        (int)Frames[Frames.Count - 2].Score :
                        (int)Frames[Frames.Count - 1].Score; 
                }
                return 0;  
            }
        }

        public ScoreCard()
        {
            Frames = new List<Frame>(); 
        }

        public void AddFrame(int? score, bool isStrike, bool isSpare,
            int roll1, int? roll2 = null, int? roll3 = null)
        {
            Frames.Add(new Frame()
            {
                Score = score,
                IsSpare = isSpare,
                IsStrike = isStrike,
                Roll1 = roll1, 
                Roll2 = roll2,
                Roll3 = roll3
            });
        }
    }
}
