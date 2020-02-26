using BowlingGame.Core.Classes;
using System.Collections.Generic;

namespace BowlingGame.Core.Interfaces
{
    public interface IGame
    {
        public void Start();
        public void Roll(int pins);
        public ScoreCard ScoreByFrame();
        public int TotalScore();
    }
}
