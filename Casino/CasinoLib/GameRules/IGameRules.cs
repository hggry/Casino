using CasinoLib.GameRules.PlayerChoice;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CasinoLib.GameRules
{
    public interface IGameRules
    {
        int GetInitialCardsPerPlayer();
        int GetPoints(IHand hand);
        bool CanPlayerContinue(IPlayer player);
        int IsWinner(IPlayer player, int competingNumber);
        bool IsRoundOver(IList<IPlayer> players);
        IList<IPlayerChoice> GetAvailablePlayerChoices(IPlayer player);
        bool IsPlayerChoiceValid(IPlayerChoice playerChoice);
    }
}
 