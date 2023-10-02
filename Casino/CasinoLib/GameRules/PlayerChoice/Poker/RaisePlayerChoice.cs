using CasinoLib.InputMethod;
using System;

namespace CasinoLib.GameRules.PlayerChoice.Poker
{
    public class RaisePlayerChoice : IRaisePlayerChoice
    {
        private IInputMethod _inputMethod;

        public RaisePlayerChoice(IInputMethod inputMethod)
        {
            _inputMethod = inputMethod;
        }

        public IInputMethod GetInputMethod()
        {
            throw new NotImplementedException();
        }

        public int GetRaiseAmound()
        {
            return 0;
        }
    }
}
