using CasinoLib.InputMethod;

namespace CasinoLib.GameRules.PlayerChoice.Blackjack
{
    public class SplitRequestPlayerChoice : ISplitRequestPlayerChoice
    {
        IInputMethod _inputMethod;

        public SplitRequestPlayerChoice(IInputMethod inputMethod)
        {
            _inputMethod = inputMethod;
        }

        public IInputMethod GetInputMethod()
        {
            return _inputMethod;
        }
    }
}
