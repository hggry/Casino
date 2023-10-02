using CasinoLib.GameRules.PlayerChoice;
using CasinoLib.GameRules.PlayerChoice.Poker;
using CasinoLib.InputMethod;
using System;
using System.Collections.Generic;

namespace CasinoLib.GameRules
{
    public class PokerGameRules : IGameRules
    {
        private List<IPlayerChoice> _availablerChoices;

        public PokerGameRules()
        {
            _availablerChoices = new List<IPlayerChoice>
            {
                new FoldOrCheckPlayerChoice(new ConsoleInputMethod(1,"Fold or Check")),
                new RaisePlayerChoice(new ConsoleInputMethod(2,"Raise"))
            };
        }


        public bool CanPlayerContinue(Player p)
        {
            bool result = true;

            return result;
        }

        public bool CanPlayerContinue(IPlayer player)
        {
            throw new NotImplementedException();
        }

        public List<IPlayerChoice> GetAvailablePlayerChoices(Player player)
        {
            return _availablerChoices;
        }

        public List<IPlayerChoice> GetAvailablePlayerChoices(IPlayer player)
        {
            throw new NotImplementedException();
        }

        public int GetInitialCardsPerPlayer()
        {
            return 2;
        }

        public int GetPoints(Hand hand)
        {
            throw new NotImplementedException();
        }

        public int GetPoints(IHand hand)
        {
            throw new NotImplementedException();
        }

        public bool IsGameOver()
        {
            throw new NotImplementedException();
        }

        public bool IsPlayerChoiceValid(IPlayerChoice playerChoice)
        {
            foreach (var validChoice in _availablerChoices)
                if (playerChoice.GetType() == validChoice.GetType())
                    return true;
            return false;
        }

        public bool IsRoundOver(List<Player> players)
        {
            throw new NotImplementedException();
        }

        public bool IsRoundOver(List<IPlayer> players)
        {
            throw new NotImplementedException();
        }

        public bool IsRoundOver(IList<IPlayer> players)
        {
            throw new NotImplementedException();
        }

        public bool IsWinner(Player player, int competingNumber)
        {
            throw new NotImplementedException();
        }

        public int IsWinner(IPlayer player, int competingNumber)
        {
            throw new NotImplementedException();
        }

        IList<IPlayerChoice> IGameRules.GetAvailablePlayerChoices(IPlayer player)
        {
            throw new NotImplementedException();
        }
    }
}
