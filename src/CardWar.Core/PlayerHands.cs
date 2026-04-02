using System;
using System.Collections.Generic;
using System.Text;

namespace CardWar.Core
{
    public class PlayerHands
    {
        // create a collection to hold player Name and player's Queue of card
        private Dictionary<string, Hand> playerHand = new Dictionary<string, Hand>();

        // Add a player's name and their hand to the dictionary
        public void AddHand(string name, Hand hand)
        {
            playerHand[name] = hand;
        }

        // return the hand that matches player's name
        public Hand GetHand(string name)
        {
            return playerHand[name];
        }

        // remove a player's hand from the dictionary  
        public void RemoveHand(string name)
        {
            playerHand.Remove(name);
        }

        // keep record of the number of card player has left in the dictionary
        public int Count(string name)
        {
            return GetHand(name).Count();
        }

    }
}
