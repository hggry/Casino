using CasinoLib.InputMethod;

namespace CasinoLib.GameRules.PlayerChoice.Blackjack
{
    public class CardRequestPlayerChoice : ICardRequestPlayerChoice
    {
        IInputMethod _inputMethod;

        public CardRequestPlayerChoice(IInputMethod inputMethod)
        {
            _inputMethod = inputMethod;
        }

        public int GetDesiredCardAmount()
        {
            return 1;
        }

        public IInputMethod GetInputMethod()
        {
            return _inputMethod;
        }

    }
}
