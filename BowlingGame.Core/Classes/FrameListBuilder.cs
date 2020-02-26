using System;
using System.Collections.Generic;
using System.Text;

namespace BowlingGame.Core.Classes
{
    public class FrameListBuilder
    {
        public ScoreCard BuildFrameList(List<int> _rolls)
        {
            ScoreCard scoreCard = new ScoreCard();

            int score = 0;
            for (int i = 0; i < _rolls.Count; i += 2)
            {
                // simplest case/ non-strike/spare
                int? roll2 = i + 1 == _rolls.Count ? null : (int?)_rolls[i + 1];

                if (_rolls[i] + roll2.GetValueOrDefault(0) < 10)
                {
                    score += _rolls[i] + roll2.GetValueOrDefault(0);
                    scoreCard.AddFrame(score, false, false);
                    continue;
                }

                // End of rolls, not necessarly end of game
                if (i + 2 >= _rolls.Count)
                {
                    scoreCard.AddFrame(null, _rolls[i] == 10, _rolls[i] != 10);
                    break;
                }
                else  // Strike or Spare
                {
                    score += _rolls[i] + _rolls[i + 1] + _rolls[i + 2];
                    scoreCard.AddFrame(score, _rolls[i] == 10, _rolls[i] != 10);
                }

                // prevent an 11th frame with an 11th roll
                if (scoreCard.Frames.Count == 10)
                    break;

                // if strike, increment by one
                if (_rolls[i] == 10)
                    i--;
            }
            return scoreCard;

        }
    }
}
