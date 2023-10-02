using CasinoLib;
using CasinoLib.GameFlow;
using CasinoLib.GameRules.PlayerChoice;
using CasinoLib.InputMethod;
using CasinoLib.TimeOnTableAllowed;
using System;
using System.Collections.Generic;

namespace CasinoConsole
{
    public class BlackJackMain : IPlayable
    {
        private IInputMethod _inputMethod;

        public BlackJackMain(IInputMethod inputMethod)
        {
            _inputMethod = inputMethod;
        }

        public IInputMethod GetInputMethod()
        {
            return _inputMethod;
        }
        
        public void Play()
        {
            Player p1 = new Player("Gregor", new U20TimeOnTableAllowed());
            Player p2 = new Player("Bledi", new U40TimeOnTableAllowed());
            List<IPlayer> players = new List<IPlayer> { p1, p2 };

            BlackJackFactory.Instance.SetPlayers(players);
            BlackJackFactory.Instance.Initialise();
            IGameFlow game = BlackJackFactory.Instance.Resolve<IGameFlow>();

            do
            {
                AskForBets(game.GetPlayers());
                StartRound();
                game.PourOutWinnings();
                PrintEveryPlayersChips(game.GetPlayers());

            } while (AskForAnotherRound());

            Console.WriteLine("Press a key to close the window...");
            Console.ReadKey();
        }

        private void StartRound()
        {
            IGameFlow game = BlackJackFactory.Instance.Resolve<IGameFlow>();

            game.DealInitialCards();
            
            PrintSeperationLine();
            PrintDealersOpenCard();

            while (!game.IsRoundOver())
            {
                Player currentPlayer = (Player)game.GetNextPlayer();
                if (!currentPlayer.GetDoneWithRound())
                {
                    PrintSeperationLine();
                    Console.WriteLine($"{currentPlayer.Name}, it is your turn");
                    PrintHand(game.GetCurrentPlayer().GetHand());
                }
                else
                {
                    continue;
                }

                while (!currentPlayer.GetDoneWithRound())
                {
                    IPlayerChoice playerChoice = AskForPlayerChoice(currentPlayer);
                    game.PerformPlayerChoice(playerChoice);
                    game.CanPlayerContinue();
                    PrintHand(game.GetCurrentPlayer().GetHand());
                }

                Console.WriteLine("Press a key to end your turn...");
                Console.ReadKey();
            }

            PrintSeperationLine();
            Console.WriteLine("It is the dealers turn");

            IHand dealerHand = game.DoDealersTurn();

            PrintHand(dealerHand);
        }

        private void PrintDealersOpenCard()
        {
            Card c = BlackJackFactory.Instance.Resolve<IDealer>().GetHand().GetCards()[0];
            Console.WriteLine($"Dealers cards: {c.Suit} {c.DisplayName}\t *second card is turned upside down*");
        }

        private void PrintHand(IHand h)
        {
            Console.Write($"Points: {BlackJackFactory.Instance.Resolve<IGameFlow>().GetPoints(h)} | ");

            foreach (Card c in h.GetCards())
            {
                Console.Write($"{c.Suit} {c.DisplayName}\t");
            }
            Console.WriteLine();
        }

        private void PrintEveryPlayersChips(IList<IPlayer> players)
        {
            PrintSeperationLine();
            foreach (Player player in players)
            {
                PrintPlayerChips(player);
            }
            PrintSeperationLine();
        }

        private void PrintPlayerChips(Player player)
        {
            Console.WriteLine($"{player.Name}'s chips: {player.GetChips()}");
        }

        private void PrintSeperationLine()
        {
            Console.WriteLine("-----------------------------------------------");
        }

        private IPlayerChoice AskForPlayerChoice(Player player)
        {
            IList<IPlayerChoice> playerChoices = BlackJackFactory.Instance.Resolve<IGameFlow>().GetAvailablePlayerChoices(player);

            Console.WriteLine("Choose an action");

            foreach (var playerChoice in playerChoices)
            {
                IInputMethod inputMethod = playerChoice.GetInputMethod();
                Console.WriteLine($"({inputMethod.GetKey()}) {inputMethod.GetDescription()}");
            }

            string userChoice = Console.ReadLine();

            IPlayerChoice result = null;
            foreach (IPlayerChoice playerChoice in playerChoices)
            {
                IInputMethod inputMethod = playerChoice.GetInputMethod();
                if (inputMethod.GetKey().ToString() == userChoice)
                {
                    Console.WriteLine($"You chose: {inputMethod.GetDescription()}");
                    result = playerChoice;
                    break;
                }
            }

            if (result == null)
            {
                result = playerChoices[1];
            }
            return result;
        }

        private void AskForBets(IList<IPlayer> players)
        {
            foreach (Player player in players)
            {
                AskForBetAmount(player);
            }
        }

        private void AskForBetAmount(Player player)
        {
            bool correctInput = false;
            PrintSeperationLine();
            PrintPlayerChips(player);

            if (player.GetChips() >= 0)
            {
                do
                {
                    Console.WriteLine($"How much would you like to bet?");
                    string userInput = Console.ReadLine();
                    try
                    {
                        int bet = Convert.ToInt32(userInput);
                        
                        if(BlackJackFactory.Instance.Resolve<IGameFlow>().SetPlayerBet(bet, player))
                        {
                            correctInput = true;
                        }
                        else
                        {
                            throw new Exception();
                        }
                    }
                    catch
                    {
                        correctInput = false;
                        Console.WriteLine($"please enter a valid number (0-{player.GetChips()})");
                    }
                } while (!correctInput);
            }
        }

        private bool AskForAnotherRound()
        {
            Console.WriteLine("Do you want to play another round?");
            Console.WriteLine("y/n");

            string userinput = Console.ReadLine();

            if (userinput == "n")
            {
                return false;
            }
            else
            {
                BlackJackFactory.Instance.Resolve<IGameFlow>().ResetValues();
                return true;
            }
        }
    }
}
