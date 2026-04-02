using System;
using System.Collections.Generic;
using System.Text;

namespace CardWar.Core
{
    public class Player
    {
        // declare a name object for the player and players hand
        public string Name { get; set; }
        public Hand Hand { get; set; }


        // initialize a player and a hand object
        public Player(string name)
        {
            Name = name;
            Hand = new Hand();
            
        }

        // Add a card to the player's hand
        public void AddCard(Card card)
        {
            Hand.AddCard(card);
        }

        // play a card from the players hand
        public Card PlayCard()
        {
            return Hand.RemoveCard();
        }

        // keep players card count
        public int CardCount()
        {
            return Hand.Count();
        }
    }
}
