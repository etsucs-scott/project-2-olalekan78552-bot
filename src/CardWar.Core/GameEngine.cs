using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace CardWar.Core
{
    /// <summary>
    /// Controls the overall flow of the Card War game, including player setup,
    /// dealing cards, playing rounds, eliminating players, and determining the winner.
    /// </summary>
    public class GameEngine
    {
        private Deck deck;
        private List<Player> players;
        private PlayerHands playerHand;
        private PlayedCard playedCard;
        private const int ROUNDMAX = 10000;

        private int userInput;

        /// <summary>
        /// Gets or sets the number of players participating in the game.
        /// Only values between 2 and 4 are allowed.
        /// </summary>
        /// <exception cref="Exception">
        /// Thrown when the number of players is outside the valid range.
        /// </exception>
        public int UserInput
        {
            get { return userInput; }
            set { 
                    if (value < 2 || value > 4)
                    {
                        throw new Exception();   
                    }
                    userInput = value;
            }
        }

        /// <summary>
        /// Initialize game engine with a deck of card and a list of players
        /// </summary>
        /// <param name="deck">Cards used</param>
        /// <param name="players">Participating players</param> 
        public GameEngine(Deck deck, List<Player> players)
        {
            this.deck = deck;
            this.players = players;
            this.playerHand = new PlayerHands();
            this.playedCard = new PlayedCard();
        }

        /// <summary>
        /// Create a player object for the game
        /// </summary>
        public void CreatePlayers()
        {
            for (int i = 0; i < userInput; i++)
            {
                players.Add(new Player($"Player {i + 1}"));

            }
            foreach (Player player in players)
            {
                playerHand.AddHand(player.Name, new Hand());
            }
        }

        /// <summary>
        /// distribute card to each player in robin-hood style. 
        /// </summary>
        public void DealCard()
        {
            while (deck.Count > 0)
            {
                foreach (Player player in players)
                {       
                    if (deck.Count == 0)
                    {
                        break;
                    }

                    Card card = deck.PopCard();
                    playerHand.GetHand(player.Name).AddCard(card);
                }
                 
            }
        }

        /// <summary>
        /// keep player card count in game engine to enable use in the game
        /// </summary>
        /// <param name="name">The name of the player</param>
        /// <returns></returns>
        public int CardCount(string name)
        {
            return playerHand.Count(name);
        }

        /// <summary>
        /// stimulate game round. Player with the highest card rank gets the pot. if 
        /// there is a tie, stimulate tie and determine winner. elimate player without 
        /// any card left to play
        /// </summary>        
        public void PlayRound()  
        {
            
            foreach (Player player in players)
            {
                if (playerHand.Count(player.Name) > 0)
                {
                    Card card = playerHand.GetHand(player.Name).RemoveCard();
                    playedCard.AddCard(player.Name, card);
                    Console.WriteLine($"{player.Name} : {card}");    
                }                
            }
            Player winner = playedCard.Winner(players, playerHand);
            if (winner != null)
            {
                Console.Write($"Round Winner {winner.Name} (Cards: ");
                Console.Write($"{players[0].Name} = {playerHand.Count(players[0].Name)}");

                for (int i = 1; i < players.Count; i++)
                {
                    Console.Write(", ");
                    Console.Write($"{players[i].Name} = {playerHand.Count(players[i].Name)}");
                }                
                Console.Write(")");
                Console.WriteLine();
            }

            else
            {
                Console.Write($"Game is a tie between {players[0].Name}");
                foreach (Player player in players)
                {
                    Console.Write(" and ");
                    Console.Write($"{player.Name}");
                }
            }
        }

        /// <summary>
        /// remove a player with no card left
        /// </summary>
        public void RemovePlayer()
        {
            for (int i = players.Count - 1; i >= 0; i--)
            {
                if (playerHand.Count(players[i].Name) == 0)
                {
                    string name = players[i].Name;
                    playerHand.RemoveHand(players[i].Name);
                    players.RemoveAt(i);
                    Console.WriteLine($"{name} has 0 cards and has been Eliminated");
                }

            }
        }

        /// <summary>
        /// determine overall winner when game ends
        /// </summary>
        /// <returns></returns>
        public string OverallWinner()
        {
            string winner = players[0].Name;
            int highest = -1;

            foreach (Player player in players)
            {
                if (playerHand.Count(player.Name) > highest)
                {
                    highest = playerHand.Count(player.Name);
                    winner = player.Name;
                        
                }
            }

            return winner;

        }

        /// <summary>
        /// check if a winner has been determine or max game round has been reached
        /// </summary>
        /// <param name="gameRound"></param>
        /// <returns>a value to indicate if game is over or not</returns>
        public bool GameOver(int gameRound)
        {

            if (players.Count == 1 || gameRound >= ROUNDMAX)
            {
                return true;
            }
            return false;
        }
        
    }
   
}
