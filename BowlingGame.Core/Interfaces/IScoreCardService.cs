using BowlingGame.Core.Classes;
using System.Collections.Generic;

namespace BowlingGame.Core.Interfaces
{
    public interface IScoreCardService
    {
        public ScoreCard BuildFrameList(List<int> _rolls);
    }
}
