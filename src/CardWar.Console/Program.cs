using System.Text;
using CardWar.Core;

namespace CardWar
{
   internal class Program
    {
        /// <summary>
        /// Starts the Card War game, collects the number of players,
        /// deals cards, runs each round, and displays the overall winner.
        /// </summary>
        /// <param name="args">Command-line arguments passed to the program.</param>
        static void Main(string[] args)
        {
            Deck deck = new Deck();
            List<Player> players = new List<Player>();
            GameEngine game = new GameEngine(deck, players);
 
            while(true)
            {
                int userInput;
                try
                {
                    Console.Write($"Enter number of players: ");
                    while (!int.TryParse(Console.ReadLine(), out userInput))
                    {
                        Console.Write($"Enter a valid number.: ");
                    }

                    game.UserInput = userInput;
                    break;
                }

                catch (Exception)
                {
                    Console.WriteLine($"Player must be between 2 and 4");
                }
            }

            game.CreatePlayers();
            game.DealCard();
            Console.WriteLine($"\n----Dealing Cards-----\n");

            foreach (Player player in players)
            {
                Console.WriteLine($"{player.Name} : {game.CardCount(player.Name)} Card");
            }

            int count = 1;
            while (!game.GameOver(count))
            {
                Console.WriteLine($"\nRound {count}\n");
                game.PlayRound();
                game.RemovePlayer();
                count++;
            }

            string winner = game.OverallWinner();
            Console.WriteLine($"\nGame Over");
            Console.WriteLine($"\nOverall Winner is {winner} with {game.CardCount(winner)} cards");
        }
    }
}
