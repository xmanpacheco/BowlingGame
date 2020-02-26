using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using BowlingGame.Core.Exceptions;
using BowlingGame.Core.Interfaces;

namespace BowlingGame.Core.Classes
{
    public class Game : IGame
    {
        private FrameListBuilder _frameListBuilder; 
        public Game(FrameListBuilder frameListBuilder)
        {
            _frameListBuilder = frameListBuilder; 
        }
        private List<int> _rolls;

        public void Roll(int pins)
        {
            ValidatePins(pins);
            _rolls.Add(pins);
        }

        public ScoreCard ScoreByFrame()
        {
            return _frameListBuilder.BuildFrameList(_rolls); 
        }

        public void Start()
        {
            _rolls = new List<int>(); 
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
