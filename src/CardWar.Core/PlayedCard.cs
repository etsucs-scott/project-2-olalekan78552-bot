using System;
using System.Collections.Generic;
using System.Text;

namespace CardWar.Core
{
    /// <summary>
    /// Tracks the cards played during a round, stores the pot,
    /// determines the round winner, and resolves ties.
    /// </summary>
    public class PlayedCard
    {
         
        private Dictionary<string, Card> playedCards = new Dictionary<string, Card>();
        private List<Card> pot = new List<Card>();


        /// <summary>
        /// Add a card to the dictionary and add card to pot for collection after win
        /// </summary>
        /// <param name="name">The name of the player who played the card</param>
        /// <param name="card">The card being played</param>
        public void AddCard(string name, Card card)
        {
            playedCards[name] = card;
            pot.Add(card);
        }


        /// <summary>
        /// Determines the winner of the current round by comparing played card ranks.
        /// If multiple players tie, additional cards are played until a winner is found.
        /// </summary>
        /// <param name="players">The players currently participating in the round.</param>
        /// <param name="playerHand">The collection of player hands used to draw and award cards.</param>
        /// <returns>
        /// The player who wins the round, or null if no winner can be determined.
        /// </returns>
        public Player Winner(List<Player> players, PlayerHands playerHand)
        {
            if (playedCards.Count == 0)
            {
                return null;
            }

            List<string> tiePlayers = new List<string>();
            int highestRank = -1;

            foreach(var entry in playedCards)
            {
                string playerName = entry.Key;
                Card card = entry.Value;

                int cardRank = (int)card.Rank;
                
                if (cardRank > highestRank)
                {
                    highestRank = cardRank;

                    tiePlayers.Clear();
                    tiePlayers.Add(playerName);
                }

                else if (cardRank == highestRank)
                {
                    tiePlayers.Add(playerName);
                }
            }

            if (tiePlayers.Count == 1)
            {
                string winner = tiePlayers[0];

                foreach (Player player in players)
                {
                    if (player.Name == winner)
                    {
                        foreach(Card card in pot)
                        {
                            playerHand.GetHand(player.Name).AddCard(card);
                            
                        }

                        playedCards.Clear();
                        pot.Clear();
                        return player;
                    }
                }
            }

            List<Player> warTiePlayers = new List<Player>();

            foreach (Player player in players)
            {
                if (tiePlayers.Contains(player.Name) && playerHand.Count(player.Name) > 0)
                {
                    warTiePlayers.Add(player);
                }
            }

            if (warTiePlayers.Count == 0)
            {
                return null;
            }

            if (warTiePlayers.Count == 1)
            {
                foreach(Card card in pot)
                {
                    playerHand.GetHand(warTiePlayers[0].Name).AddCard(card);
                }

                playedCards.Clear();
                pot.Clear();
                return warTiePlayers[0];
            }
            playedCards.Clear();
            Console.Write($"Tie players are: ");
            Console.Write($"{warTiePlayers[0].Name}");
            for (int i = 1; i < warTiePlayers.Count; i++)
            {
                Console.Write(" and ");
                Console.Write($"{warTiePlayers[i].Name}");
            }         

            Console.Write($"\nTieBreaker: ");
            if (playerHand.Count($"{warTiePlayers[0].Name}") > 0)
            {
                Card firstCard = playerHand.GetHand($"{warTiePlayers[0].Name}").RemoveCard();
                Console.Write($"{warTiePlayers[0].Name}: {firstCard}");
                AddCard($"{warTiePlayers[0].Name}", firstCard);
            }

            for (int i = 1; i < warTiePlayers.Count(); i++)
            {
                if (playerHand.Count($"{warTiePlayers[i].Name}") > 0)
                {
                    Console.Write(" | ");
                    Card TieBreakCard = playerHand.GetHand($"{warTiePlayers[i].Name}").RemoveCard();
                    Console.Write($"{warTiePlayers[i].Name}: {TieBreakCard}");

                    AddCard($"{warTiePlayers[i].Name}", TieBreakCard);
                }

            }
            Console.WriteLine();
            return Winner(warTiePlayers, playerHand);
        }
    }
}
