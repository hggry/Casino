using CasinoLib.GameRules.PlayerChoice;
using CasinoLib.GameRules.PlayerChoice.Blackjack;
using CasinoLib.InputMethod;
using System.Collections.Generic;

namespace CasinoLib.GameRules
{
    public class BlackJackGameRules : IGameRules
    {
        private List<IPlayerChoice> _availableChoices;
        public BlackJackGameRules()
        {
            _availableChoices = new List<IPlayerChoice>();
        }

        public IList<IPlayerChoice> GetAvailablePlayerChoices(IPlayer player)
        {
            _availableChoices.Clear();
            if (CanPlayerDoHitAction(player))
            {
                _availableChoices.Add(new CardRequestPlayerChoice(new ConsoleInputMethod(1, "hit")));
            }
            
            _availableChoices.Add(new HoldPlayerChoice(new ConsoleInputMethod(2, "hold")));
            
            if (CanPlayerDoSplitAction(player))
            {
                _availableChoices.Add(new SplitRequestPlayerChoice(new ConsoleInputMethod(3, "split")));
            }
            if (CanPlayerDoDoubleBetAction(player))
            {
                _availableChoices.Add(new DoubleBetPlayerChoice(new ConsoleInputMethod(4, "split")));
            }

            return _availableChoices;
        } 

        private bool CanPlayerDoHitAction(IPlayer player)
        {
            if (GetPoints(player.GetHand()) < 21)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool CanPlayerDoSplitAction(IPlayer player)
        {
            //TODO
            return false;
        }

        private bool CanPlayerDoDoubleBetAction(IPlayer player)
        {
            //TODO
            return false;
        }

        public bool CanPlayerContinue(IPlayer p)
        {
            if (GetPoints(p.GetHand()) >= 21 || p.GetDoneWithRound())
            {
                p.SetDoneWithRound(true);
                return false;
            }
            else
            {
                return true;
            }
        }

        public int GetInitialCardsPerPlayer()
        {
            return 2;
        }

        public bool IsRoundOver(IList<IPlayer> players)
        {
            bool isEveryPlayerDone = true;

            foreach (IPlayer player in players)
            {
                if (!player.GetDoneWithRound())
                {
                    isEveryPlayerDone = false;
                }
            }

            return isEveryPlayerDone;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="player"></param>
        /// <param name="competingNumber"></param>
        /// <returns>returns a code that tells if the player won, lost or if it is a match</returns>
        public int IsWinner(IPlayer player, int competingNumber)
        {
            int points = GetPoints(player.GetHand());
            
            if (competingNumber > 21 && points > 21 || competingNumber == points)
            {
                return 0;
            }
            else if (points > competingNumber && points <= 21 || competingNumber > 21 && points <= 21)
            {
                return 1;
            }

            return -1;
        }

        public bool IsPlayerChoiceValid(IPlayerChoice playerChoice)
        {
            foreach (var validChoice in _availableChoices)
            {
                if (playerChoice.GetType() == validChoice.GetType())
                    return true;
            }
            return false;
        }

        public int GetPoints(IHand hand)
        {
            int points = 0;

            List<Card> aces = new List<Card>();
            foreach (Card card in hand.GetCards())
            {
                if (card.Number == 11)
                {
                    aces.Add(card);
                }
                else
                {
                    points += card.Number;
                }
            }

            foreach (Card ace in aces)
            {
                if (points > 10)
                {
                    points += 1;
                }
                else
                {
                    points += ace.Number;
                }
            }
            return points;
        }
    }
}
