using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using BowlingGame.Core.Exceptions;
using BowlingGame.Core.Interfaces;

namespace BowlingGame.Core.Classes
{
    public class Game : IGame
    {
        private List<int> _rolls;
        private int _currentRoll; // keep track of rolls

        public void Roll(int pins)
        {
            ValidatePins(pins);
            _rolls.Add(pins);
            _currentRoll++; 
        }

        public ScoreCard ScoreByFrame()
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
                if (_rolls[i] == 10 )
                    i--;
            }
            return scoreCard;
        }

        public void Start()
        {
            _rolls = new List<int>(); 
            _currentRoll = 1; // first roll
        }

        public int TotalScore()
        {
            int score = 0;
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
        private static void ValidatePins(int? pins)
        {
            if (pins < 0 || pins > 10)
                throw new PinsOutOfRangeException();
        }
    }
}
