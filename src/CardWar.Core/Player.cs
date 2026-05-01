using System;
using System.Collections.Generic;
using System.Text;

namespace CardWar.Core
{
    /// <summary>
    /// Represent a player in the game
    /// </summary>
    public class Player
    {
        /// <summary>
        /// get players name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets players hand
        /// </summary>
        public Hand Hand { get; set; }


        /// <summary>
        /// initialize a player with a name and an emoty hand of card
        /// </summary>
        /// <param name="name">Player's name</param>
        public Player(string name)
        {
            Name = name;
            Hand = new Hand();
            
        }

        /// <summary>
        /// Add a card to the player's hand
        /// </summary>
        /// <param name="card">The card being added</param>
        public void AddCard(Card card)
        {
            Hand.AddCard(card);
        }

        /// <summary>
        /// play a card from the players hand
        /// </summary>
        /// <returns>The card being played</returns>
        public Card PlayCard()
        {
            return Hand.RemoveCard();
        }

        /// <summary>
        /// keep players card count
        /// </summary>
        /// <returns>The number of card left</returns>
        public int CardCount()
        {
            return Hand.Count();
        }
    }
}
