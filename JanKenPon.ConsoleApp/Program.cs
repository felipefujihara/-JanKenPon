using JanKenPon.AssemblyLoaders;
using JanKenPon.Common;
using JanKenPon.MatchMaker;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace JanKenPon.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var loop = true;
            var numberOfPlayers = 0;
            var players = new Dictionary<string, ISignal>();
            var signals = new List<ISignal>();

            DisplayWelcomeMessage();
            signals = LoadSignals<ISignal>();
            while (loop)
            {
                Console.WriteLine();
                numberOfPlayers = EnterNumberOfPlayers();
                players = EnterPlayersName(numberOfPlayers, signals);
                Fight(players);
                loop = PlayAgain();
            }
            Console.WriteLine("Bye!");
            Console.ReadKey();
        }

        private static bool PlayAgain()
        {
            var repeat = false;
            var options = new[] { "y", "n" };
            while (!repeat)
            {
                Console.Write("Play again? (y/n):");
                var playAgain = Console.ReadLine().ToLower();

                if (!options.Any(p => string.Compare(p, playAgain, true) != -1))
                {
                    Console.WriteLine("Invalid Entry...");
                    continue;
                }
                return playAgain == "y";
            }
            throw new ApplicationException("Invalid Output...");
        }

        private static void Fight(Dictionary<string, ISignal> players)
        {
            string output = new MatchBuilder().Build(players);
            Console.WriteLine(output);
        }

        private static List<ISignal> LoadSignals<T>() where T : class
        {
            return Loader<ISignal>.LoadAssemblies(Assembly.GetExecutingAssembly().Location);
        }

        private static Dictionary<string, ISignal> EnterPlayersName(int numberOfPlayers, List<ISignal> signals)
        {
            var result = new Dictionary<string, ISignal>();

            for (int i = 0; i < numberOfPlayers; i++)
            {
                Console.Write("Enter the name of player{0}: ", i);
                var playerName = Console.ReadLine();
                Console.Write("Enter the signal: ");
                var playerSignal = Console.ReadLine();

                var signal = signals.Find(p => p.Name == playerSignal);

                result.Add(playerName, signal);
            }
            return result;
        }

        static void DisplayWelcomeMessage()
        {
            const string welcomeMessage = "** Welcome to Jan  Ken Pon! **";

            Console.WriteLine(new String('*', welcomeMessage.Length));
            Console.WriteLine(welcomeMessage);
            Console.WriteLine(new String('*', welcomeMessage.Length));
        }

        static int EnterNumberOfPlayers()
        {
            var isValid = false;
            var numberOfPlayers = 0;
            while (!isValid)
            {
                Console.Write("Enter the number of players: ");
                var userEntry = Console.ReadLine();
                
                isValid = int.TryParse(userEntry, out numberOfPlayers);

                if (!isValid)
                {
                    Console.WriteLine("Invalid entry, try again...");
                    continue;
                }
                if (numberOfPlayers != 2)
                {
                    Console.WriteLine("Invalid number of players. Try 2 instead.");
                    isValid = false;
                }
                else
                    return numberOfPlayers;
            }
            return 0;
        }
    }
}
