using CasinoLib.InputMethod;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CasinoLib.GameRules.PlayerChoice.Blackjack
{
    public class DoubleBetPlayerChoice : IDoubleBetPlayerChoice
    {
        private IInputMethod _inputMethod;
        public DoubleBetPlayerChoice(IInputMethod inputMethod)
        {
            _inputMethod = inputMethod;
        }
        public IInputMethod GetInputMethod()
        {
            return _inputMethod;
        }
    }
}
