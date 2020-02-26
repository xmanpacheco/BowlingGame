using BowlingGame.Core.Interfaces;

namespace BowlingGame.Core.Classes
{
    public class ValidatorService : IValidatorService
    {
        public bool ValidatePins(int? pins)
        {
            return (pins >= 0 && pins <= 10);
        }
    }
}