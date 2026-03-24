using System;
using System.Collections.Generic;
using System.Text;

namespace CardWar.Core
{
    public class GameEngine
    {
        private List<Player> players = new List<Player>();
        
        public Deck deck;
        private int numberOfPlayers;
        public GameEngine(Deck deck)
        {
            this.deck = deck;
        }

        // get the number of players from the user and add
        // players to player list
        public void AddPlayers()
        {   
            Console.Write("Enter the number of players: ");
            while (!int.TryParse(Console.ReadLine(), out numberOfPlayers) || numberOfPlayers > 4 || numberOfPlayers < 2)
            {
                Console.Write("Enter a number between 2 and 4: ");
            }

            for (int i = 1; i <= numberOfPlayers; i++)
            {
                players.Add(new Player("Player " + i));
            }
        }

        // Distribute card among players using the robin hood method
        public void DealCard()
        {
            int index = 0;
            while (deck.Count > 0)
            {
                Card card = deck.DrawCard();
                players[index].PickCard(card);

                index = (index + 1) % numberOfPlayers;
            }
        }

        public void RemovePlayer()
        {
            int playerCount = players.Count - 1;
            for (int i = playerCount; i >=0; i--)
            {
                if (players[i].CardCount() == 0)
                {
                    Console.WriteLine($"{players[i].Name} is Eliminated");
                    players.RemoveAt(i);
                }
            }
        }

        // Remove any tie players that do not have any card left from the game
        public List<Player> RemoveTiePlayers(List<Player> tiePlayer)
        {
            List<Player> playersLeft = new List<Player>();
            foreach (Player player in tiePlayer)
            {
                if (player.CardCount() > 0)          
                {
                    playersLeft.Add(player);
                }
                else
                {
                    Console.WriteLine($"{player.Name} has no card left and is Eliminated!");
                }
            }


            return playersLeft;
        }

        // Stimulate game rounds and determine if there was a tie
        // Give card in the pot to the winner of the each rounds and keep card count. Eliminate players without any card left untill a winner is determine
        public Player PlayRound(List<Player> players, List<Card> pot)
        {
            RemovePlayer();

            List<Player> tiePlayers = new List<Player>();
            Player winner = players[0];
            Card highestCard = players[0].PlayCard();
            Console.WriteLine("Playing Card.......\n");
            Console.WriteLine($"{players[0].Name}: {highestCard}");
            pot.Add(highestCard);
            int playersCount = players.Count;

            tiePlayers.Add(players[0]);
            for (int i = 1; i < playersCount; i++)
            {
                Card cardPlayed = players[i].PlayCard();
                Console.WriteLine($"{players[i].Name}: {cardPlayed}");
                pot.Add(cardPlayed);
                if (cardPlayed.Rank > highestCard.Rank)
                {
                    highestCard = cardPlayed;
                    winner = players[i];

                    tiePlayers.Clear();
                    tiePlayers.Add(players[i]);
                }

                else if (highestCard.Rank == cardPlayed.Rank)
                {
                    tiePlayers.Add(players[i]);
                }
            }

            if (tiePlayers.Count > 1)
            {
                Console.WriteLine($"\nTie between: {string.Join(" and ", tiePlayers.Select(p => p.Name))}!\n");

                tiePlayers = RemoveTiePlayers(tiePlayers);
                if (tiePlayers.Count == 1)
                {
                    winner = tiePlayers[0];
                    foreach (Card card in pot)
                    {
                        winner.PickCard(card);
                    }
                    Console.WriteLine($"\nWinner {winner.Name}\n");
                    
                    foreach (Player player in players)
                    {
                        Console.WriteLine($"{player.Name}: {player.CardCount()} cards");
                    }
                    return winner;
                }
                Console.WriteLine($"Pot includes: {string.Join(", ", pot)}");
                Console.WriteLine();
                return PlayRound(tiePlayers, pot);
            }

            
            foreach (Card card in pot)
            {
                winner.PickCard(card);
            }
            Console.WriteLine($"\nWinner {winner.Name}\n");
            foreach(Player player in players)
            {
                Console.WriteLine($"{player.Name}: {player.CardCount()} cards");
            }

            return winner;    
        }

        // Determine overall winner by checking the number of cards left if no winner is game round
        public Player OverallWinner()
        {
            Player currentWinner = null;
            int winningCard = -1;
            List<Player> tiePlayer = new List<Player>();
            
            for (int i = 0; i < players.Count; i++)
            {
                int cardCount = players[i].CardCount();
                if (cardCount > winningCard)
                {
                    winningCard = players[i].CardCount();
                    currentWinner = players[i];

                    tiePlayer.Clear();
                    tiePlayer.Add(players[i]);
                }

                else if (players[i].CardCount() == winningCard)
                {
                    tiePlayer.Add(players[i]);
                }

            }

            if (tiePlayer.Count > 1)
            {
                Console.WriteLine($"Tie Game between {string.Join(" and ", tiePlayer.Select(p => p.Name))} with {winningCard} cards");
                return null;
            }

            return currentWinner;
        }

        // Start the game function by combining component of the game engine
        public void StartGame()
        {
            int rounds;

            Console.Write("Enter the number of rounds: ");
            while (!int.TryParse(Console.ReadLine(), out rounds))
            {
                Console.WriteLine("Enter a valid number");
            }
            int gameRound = 1;

            while (gameRound <= rounds)
            {
                Console.WriteLine($"\n-----Round {gameRound} -----\n");
                List<Card> pot = new List<Card>();

                PlayRound(players, pot);
                
                if(GameOver(gameRound, rounds))
                {
                    Console.WriteLine("\nGame Over!");
                    break;
                }

                Console.Write("\nPress Enter to play Next Rounds or Q to quit Game!: ");
                string answer = Console.ReadLine();

                if (answer == "Q" || answer == "q")
                {
                    Console.WriteLine("\nGame Over");
                    break;
                }

                gameRound++;
            }

            if (gameRound == rounds)
            {
                Player finalWinner = OverallWinner();

                if (finalWinner != null)
                {
                    Console.WriteLine($"The overall winner is {finalWinner.Name} with {finalWinner.CardCount()} cards");
                }

                return;
            }

            Player winner = OverallWinner();
            Console.WriteLine($"The overall winner is {winner.Name} with {winner.CardCount()} cards");


        }

        // function to determine if end of game has been reached.
        public bool GameOver(int gameRound, int rounds)
        {
            int roundMax = 10000;

            if (players.Count == 1 || gameRound >= roundMax || gameRound == rounds)
            {
                return true;
            }

            return false;

        }


    }
}
