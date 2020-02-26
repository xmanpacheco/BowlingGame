using BowlingGame.Core.Classes;

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
