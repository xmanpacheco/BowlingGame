using BowlingGame.Core;
using BowlingGame.Core.Classes;
using BowlingGame.Core.Exceptions;
using BowlingGame.Core.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BowlingGame.Test
{
    [TestClass]
    public class BowlingGameTest
    {
        private IGame _game; 

        [TestInitialize]
        public void Initialize()
        {
            _game = new Game();
            _game.Start(); 
        }

        [TestCleanup]
        public void Cleanup()
        {
            _game = null; 
        }

        [TestMethod]
        public void TestStart()
        {
            _game.Start();
        }

        [TestMethod]
        public void TestRoll()
        {
            _game.Roll(5); 
        }

        [TestMethod]
        [ExpectedException(typeof(PinsOutOfRangeException))]
        public void TestOutOfRangeRoll()
        {
            _game.Roll(11);
        }

        [TestMethod]
        public void TestScoreByFrame()
        {
            var tests = GetTestStrings();
            tests.ForEach(t =>
            {
                var rollList = t.Split(',').Select(x => int.Parse(x)).ToList();
                _game.Start(); 
                rollList.ForEach(r =>
                {
                    _game.Roll(r);
                });
                var scoreCard = _game.ScoreByFrame();
                System.Diagnostics.Debug.WriteLine("Num Frames: {0} Score: {1}", 
                    scoreCard.Frames.Count, scoreCard.Score);

            }); 


        }

        [TestMethod]
        public void TestTotalScore()
        {

            var tests = GetTestStrings(); 
            tests.ForEach(t =>
            {
                var rollList = t.Split(',').Select(x => int.Parse(x)).ToList();
                _game.Start(); 

                rollList.ForEach(r =>
                {
                    _game.Roll(r);
                });
                int score = _game.TotalScore();
                System.Diagnostics.Debug.WriteLine(score); 
            }); 
        }

        private List<string> GetTestStrings()
        {
            List<string> tests = new List<string>();
            tests.Add("2,5,6,4,7,1"); // expected 32
            tests.Add("2,5,6,4,7,1,6,4"); //expected 32 (final can't be determined)
            tests.Add("2,5,10"); // expected 7 (final can't be determined)
            tests.Add("2,3,5,4,7,3,10,8,2,5,2"); // expected 76
            tests.Add("2,3,5,4,7,3,10,8,2,5,2,10,10,10,6,3"); // expected 160
            tests.Add("10,10,10,10,10,10,10,10,10,10,10,10"); // expected 300

            return tests; 
        }

    }
}
