using System.Text;
using CardWar.Core;

namespace CardWar
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // create a deck of cards, a list of players and a game object
            Deck deck = new Deck();
            List<Player> players = new List<Player>();
            GameEngine game = new GameEngine(deck, players);


            // accepts a  number of players from the user and validate 
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

            // start the game and print game messages according.
            // End the game if a user has been determine or the game game count has been reached
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
