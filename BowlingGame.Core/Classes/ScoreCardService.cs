using System.Collections.Generic;
using BowlingGame.Core.Interfaces;

namespace BowlingGame.Core.Classes
{
    public class ScoreCardService : IScoreCardService
    {
        public ScoreCard BuildFrameList(List<int> _rolls)
        {
            ScoreCard scoreCard = new ScoreCard();

            int score = 0;
            for (int i = 0; i < _rolls.Count; i += 2)
            {
                // simplest case/ non-strike/spare
                int roll1 = _rolls[i];
                int? roll2 = i + 1 == _rolls.Count ? null : (int?)_rolls[i + 1];
                int? roll3 = i + 2 >= _rolls.Count ? null : (int?)_rolls[i + 2];

                if (_rolls[i] + roll2.GetValueOrDefault(0) < 10)
                {
                    score += roll1 + roll2.GetValueOrDefault(0);
                    scoreCard.AddFrame(score, false, false, roll1, roll2);
                    continue;
                }

                // End of rolls, not necessarly end of game
                if (i + 2 >= _rolls.Count)
                {
                    if (scoreCard.Frames.Count == 9) // end of game, include score
                    {
                        score = roll1 + roll2.GetValueOrDefault(0) + roll3.GetValueOrDefault(0);
                        scoreCard.AddFrame(score, roll1 == 10, roll1 != 10, roll1, roll2, roll3);
                    } else
                        scoreCard.AddFrame(null, roll1 == 10, roll1 != 10, roll1, roll2, roll3);

                    break;
                }
                else  // Strike or Spare
                {
                    score += roll1 + roll2.GetValueOrDefault(0) + roll3.GetValueOrDefault(0);
                    if (scoreCard.Frames.Count == 9)
                        scoreCard.AddFrame(score, roll1 == 10, roll1 != 10, roll1, roll2, roll3);
                    else {
                        if (roll1 == 10)
                            scoreCard.AddFrame(score, roll1 == 10, roll1 != 10, roll1);
                        else
                            scoreCard.AddFrame(score, roll1 == 10, roll1 != 10, roll1, roll2);
                    }
                }

                // prevent an 11th frame with an 11th roll
                if (scoreCard.Frames.Count == 10)
                    break;

                // if strike, increment by one
                if (roll1 == 10)
                    i--;
            }
            return scoreCard;
        }
    }
}
