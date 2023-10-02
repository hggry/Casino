using CasinoLib.InputMethod;

namespace CasinoLib.GameRules.PlayerChoice.Poker
{
    public class FoldOrCheckPlayerChoice : IFoldOrCheckPlayerChoice
    {
        private IInputMethod _inputMethod;
        public FoldOrCheckPlayerChoice(IInputMethod inputMethod)
        {
            _inputMethod = inputMethod;
        }

        public IInputMethod GetInputMethod()
        {
            return _inputMethod;
        }

        public bool HasFoolded()
        {
            return false;
        }
    }
}
