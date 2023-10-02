using CasinoLib.InputMethod;
using System;
using System.Collections.Generic;

namespace CasinoConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to lbh Casino");
            IPlayable game = AskForGame(GetAvailableGames());
            game.Play();
        }

        private static IPlayable AskForGame(List<IPlayable> availableGames)
        {
            IPlayable result = null;

            Console.WriteLine("What game would you like to play?");
            foreach (IPlayable game in availableGames)
            {
                IInputMethod inputMethod = game.GetInputMethod();
                Console.WriteLine($"{inputMethod.GetKey()} {inputMethod.GetDescription()}");
            }

            string userChoice = Console.ReadLine();

            foreach (IPlayable option in availableGames)
            {
                IInputMethod inputMethod = option.GetInputMethod();
                if (inputMethod.GetKey().ToString() == userChoice)
                {
                    Console.WriteLine($"You chose: {inputMethod.GetDescription()}");
                    result = option;
                    break;
                }
                else
                {
                    result = availableGames[0];
                }
            }

            return result;
        }

        private static List<IPlayable> GetAvailableGames()
        {
            List<IPlayable> availableGames = new List<IPlayable>
            {
                new BlackJackMain(new ConsoleInputMethod(1,"Black Jack")),
                new PokerMain(new ConsoleInputMethod(2,"Poker"))
            };

            return availableGames;
        }
    }
}

