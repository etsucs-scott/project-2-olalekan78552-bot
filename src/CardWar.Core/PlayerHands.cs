using System;
using System.Collections.Generic;
using System.Text;

namespace CardWar.Core
{
    /// <summary>
    /// Manages the collection of player hands, mapping player names
    /// to their respective card hands.
    /// </summary>
    public class PlayerHands
    {
        private Dictionary<string, Hand> playerHand = new Dictionary<string, Hand>();

        /// <summary>
        /// Add a player's name and their hand to the dictionary
        /// </summary>
        /// <param name="name">The name of the player</param>
        /// <param name="hand">The hand assigned to the player</param>
        public void AddHand(string name, Hand hand)
        {
            playerHand[name] = hand;
        }

        /// <summary>
        /// return the hand that matches player's name
        /// </summary>
        /// <param name="name">Player's name</param>
        /// <returns>The hand belonging to the player</returns>
        public Hand GetHand(string name)
        {
            return playerHand[name];
        }

        /// <summary>
        /// remove a player's hand from the dictionary 
        /// </summary>
        /// <param name="name">Player's name</param>        
        public void RemoveHand(string name)
        {
            playerHand.Remove(name);
        }

        /// <summary>
        /// keep record of the number of card player has left in the player's hand
        /// </summary>
        /// <param name="name">The name of the player</param>
        /// <returns>Number of card left</returns>
        public int Count(string name)
        {
            return GetHand(name).Count();
        }

    }
}
