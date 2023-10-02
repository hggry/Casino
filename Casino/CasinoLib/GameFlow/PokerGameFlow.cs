using CasinoLib.GameRules.PlayerChoice;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CasinoLib.GameFlow
{
    public class PokerGameFlow : IGameFlow
    {
        public bool CanPlayerContinue()
        {
            throw new NotImplementedException();
        }

        public void DealInitialCards()
        {
            throw new NotImplementedException();
        }

        public IHand DoDealersTurn()
        {
            throw new NotImplementedException();
        }

        public IList<IPlayerChoice> GetAvailablePlayerChoices(IPlayer player)
        {
            throw new NotImplementedException();
        }

        public IPlayer GetCurrentPlayer()
        {
            throw new NotImplementedException();
        }

        public IPlayer GetNextPlayer()
        {
            throw new NotImplementedException();
        }

        public IList<IPlayer> GetPlayers()
        {
            throw new NotImplementedException();
        }

        public int GetPoints(IHand hand)
        {
            throw new NotImplementedException();
        }

        public bool IsRoundOver()
        {
            throw new NotImplementedException();
        }

        public void PerformPlayerChoice(IPlayerChoice playerChoice)
        {
            throw new NotImplementedException();
        }

        public void PourOutWinnings()
        {
            throw new NotImplementedException();
        }

        public void ResetValues()
        {
            throw new NotImplementedException();
        }

        public bool SetPlayerBet(int betAmount, IPlayer p)
        {
            throw new NotImplementedException();
        }

        public bool ValidateBetAmount(int betAmount, IPlayer p)
        {
            throw new NotImplementedException();
        }
    }
}
