using CasinoLib.InputMethod;

namespace CasinoLib.GameRules.PlayerChoice.Blackjack
{
    public class HoldPlayerChoice : IHoldPlayerChoice
    {
        IInputMethod _inputMethod;

        public HoldPlayerChoice(IInputMethod inputMethod)
        {
            _inputMethod = inputMethod;
        }

        public IInputMethod GetInputMethod()
        {
            return _inputMethod;
        }
    }
}
