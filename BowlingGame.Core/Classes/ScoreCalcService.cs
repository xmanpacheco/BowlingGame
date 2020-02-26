using BowlingGame.Core.Interfaces;
using System.Collections.Generic;

namespace BowlingGame.Core.Classes
{
    public class ScoreCalcService : IScoreCalcService
    {
        public int CalculateScore(List<int> _rolls)
        {
            int score = 0;
            // frame consists of two rolls except if strike
            for (int i = 0; i < _rolls.Count - 1; i += 2)
            {
                // simplest case/ non-strike/spare
                if (_rolls[i] + _rolls[i + 1] < 10)
                {
                    score += _rolls[i] + _rolls[i + 1];
                    continue;
                }

                if (i + 2 >= _rolls.Count)
                    break;
                else
                {
                    score += _rolls[i] + _rolls[i + 1] + _rolls[i + 2];
                    // if strike, increment by one
                    if (_rolls[i] == 10)
                        i--;
                }
            }
            return score; 
        }
    }
}
