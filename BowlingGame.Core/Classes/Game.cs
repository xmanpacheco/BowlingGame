using System.Collections.Generic;
using BowlingGame.Core.Exceptions;
using BowlingGame.Core.Interfaces;

namespace BowlingGame.Core.Classes
{
    public class Game : IGame
    {
        private IScoreCardService _scoreCardService;
        private IScoreCalcService _scoreCalcService;
        private IValidatorService _validatorService; 

        public Game(IScoreCardService scoreCardService, 
            IScoreCalcService scoreCalcService,
            IValidatorService validatorService)
        {
            _scoreCardService = scoreCardService;
            _scoreCalcService = scoreCalcService;
            _validatorService = validatorService; 
        }

        private List<int> _rolls;

        public void Roll(int pins)
        {
            if (!_validatorService.ValidatePins(pins))
                throw new PinsOutOfRangeException(); 

            _rolls.Add(pins);
        }

        public ScoreCard ScoreByFrame()
        {
            return _scoreCardService.BuildFrameList(_rolls); 
        }

        public void Start()
        {
            _rolls = new List<int>(); 
        }

        public int TotalScore()
        {
            return _scoreCalcService.CalculateScore(_rolls); 
        }
        private static void ValidatePins(int? pins)
        {
            if (pins < 0 || pins > 10)
                throw new PinsOutOfRangeException();
        }
    }
}
