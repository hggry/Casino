using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CasinoLib.GameRules.PlayerChoice.Poker
{
    public interface IRaisePlayerChoice : IPlayerChoice
    {
        int GetRaiseAmound();
    }
}
