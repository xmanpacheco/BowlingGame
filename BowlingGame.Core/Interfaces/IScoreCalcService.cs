using System.Collections.Generic;

namespace BowlingGame.Core.Interfaces
{
    public interface IScoreCalcService
    {
        public int CalculateScore(List<int> _rolls);
    }
}
