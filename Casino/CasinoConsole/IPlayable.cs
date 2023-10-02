using CasinoLib.InputMethod;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CasinoConsole
{
    public interface IPlayable
    {
        IInputMethod GetInputMethod();
        void Play();
    }
}
