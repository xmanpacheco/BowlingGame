using System.Collections.Generic;

namespace BowlingGame.Core.Classes
{
    public class ScoreCard
    {
        private List<Frame> _frames; 

        public List<Frame> Frames
        {
            get { return _frames; }
        }
        public int Score 
        { 
            get 
            { 
                if (_frames.Count > 1)
                {
                    // Last Frame may not have a score due to unrolled strike/spare
                    return _frames[_frames.Count - 1].Score == null ?
                        (int)_frames[_frames.Count - 2].Score :
                        (int)_frames[_frames.Count - 1].Score; 
                }
                return 0;  
            }
        }

        public ScoreCard()
        {
            _frames = new List<Frame>(); 
        }

        public void AddFrame(int? score, bool isStrike, bool isSpare)
        {
            _frames.Add(new Frame()
            {
                Score = score,
                IsSpare = isSpare,
                IsStrike = isStrike
            });
        }
    }
}
