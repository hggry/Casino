using CasinoLib.GameRules.PlayerChoice;
using System.Collections.Generic;

namespace CasinoLib.GameFlow
{
    public interface IGameFlow
    {
        void DealInitialCards();
        void PerformPlayerChoice(IPlayerChoice playerChoice);
        void PourOutWinnings();
        bool IsRoundOver();
        IPlayer GetNextPlayer();
        bool SetPlayerBet(int betAmount, IPlayer p);
        bool ValidateBetAmount(int betAmount, IPlayer p);
        IList<IPlayer> GetPlayers();
        IPlayer GetCurrentPlayer();
        bool CanPlayerContinue();
        IHand DoDealersTurn();
        int GetPoints(IHand hand);
        IList<IPlayerChoice> GetAvailablePlayerChoices(IPlayer player);
        void ResetValues();
    }
}
