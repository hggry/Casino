using CasinoLib.GameRules;
using CasinoLib.GameRules.PlayerChoice;
using CasinoLib.GameRules.PlayerChoice.Blackjack;
using System.Collections.Generic;
using System.Linq;

namespace CasinoLib.GameFlow
{
    public class BlackJackGameFlow : IGameFlow
    {
        private IDealer _dealer;
        private IList<IPlayer> _players;
        private IGameRules _gameRules;

        private int _playerIndex;

        public BlackJackGameFlow(IGameRules gameRules, IDealer dealer, List<IPlayer> players)
        {
            _gameRules = gameRules;
            _dealer = dealer;
            _players = players;
            _playerIndex = -1;
        }

        public IList<IPlayer> GetPlayers()
        {
            return _players;
        }

        public IPlayer GetNextPlayer()
        {
            if(_players != null)
            {
                _playerIndex++;
                if (_playerIndex < _players.Count)
                {
                    return _players[_playerIndex];
                }
                else
                {
                    _playerIndex = -1;
                }
            }

            return null;
        }

        public IPlayer GetCurrentPlayer()
        {
            return _players[_playerIndex];
        }

        public void DealInitialCards()
        {
            for (int i = 0; i < _gameRules.GetInitialCardsPerPlayer(); i++)
            {
                foreach (Player player in _players)
                {
                    _dealer.Deal(player.GetHand());
                }
                _dealer.Deal(_dealer.GetHand());
            }
        }

        public bool IsRoundOver()
        {
            return _gameRules.IsRoundOver(_players);
        }

        public void PerformPlayerChoice(IPlayerChoice playerChoice)
        {
            IPlayer player = GetCurrentPlayer();
            if (!_gameRules.IsPlayerChoiceValid(playerChoice))
            {
                throw new System.Exception("user is not allowed to perform this action");
            }
            
            if (playerChoice is ICardRequestPlayerChoice)
            {
                _dealer.Deal(player.GetHand());
            }
            else if (playerChoice is IHoldPlayerChoice)
            {
                player.SetDoneWithRound(true);
            }
        }

        public IList<IPlayerChoice> GetAvailablePlayerChoices(IPlayer p)
        {
            return _gameRules.GetAvailablePlayerChoices(p);
        }

        public bool CanPlayerContinue()
        {
            return _gameRules.CanPlayerContinue(GetCurrentPlayer());
        }

        public int GetPoints(IHand hand)
        {
            return _gameRules.GetPoints(hand);
        }

        public IHand DoDealersTurn()
        {
            bool needToTakeCard;
            do
            {
                int points = GetPoints(_dealer.GetHand());
                if (points < 17)
                {
                    needToTakeCard = true;
                    _dealer.Deal(_dealer.GetHand());
                }
                else
                {
                    needToTakeCard = false;
                }
            } while (needToTakeCard);

            return _dealer.GetHand();
        }

        public bool SetPlayerBet(int betAmount, IPlayer p)
        {
            bool isValid = ValidateBetAmount(betAmount, p);
            
            if(isValid && betAmount == 0)
            {
                p.SetDoneWithRound(true);
            }
            else if(isValid)
            {
                p.SetChips(p.GetChips() - betAmount);
                p.SetBetAmount(betAmount);
            }

            return isValid;
        }

        public bool ValidateBetAmount(int betAmount, IPlayer p)
        {
            if (betAmount < 0 || betAmount > p.GetChips())
            {
                return false;
            }
            return true;
        }

        public void PourOutWinnings()
        {
            foreach (IPlayer player in _players)
            {
                int code = _gameRules.IsWinner(player, GetPoints(_dealer.GetHand()));
                if (code == 1)
                {
                    //win - player gets the amount he bet plus his winnings
                    player.SetChips(player.GetChips() + player.GetBetAmount() * 2);
                }
                else if (code == 0)
                {
                    //draw, player gets his bets again
                    player.SetChips(player.GetChips() + player.GetBetAmount());
                }
                else if (code == -1)
                {
                    //lost, player lost his bets
                }
            }
        }

        public void ResetValues()
        {
            foreach (IPlayer p in _players)
            {
                p.Reset();
            }
            _dealer.Reset();
            _playerIndex = -1;
        }
    }
}
