using CasinoLib.InputMethod;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CasinoConsole
{
    public class PokerMain : IPlayable
    {
        private IInputMethod _inputMethod;

        public PokerMain(IInputMethod inputMethod)
        {
            _inputMethod = inputMethod;
        }

        public IInputMethod GetInputMethod()
        {
            return _inputMethod;
        }


        public void Play()
        {
            throw new NotImplementedException();
        }
    }
}
