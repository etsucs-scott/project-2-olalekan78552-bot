using System;
using System.Collections.Generic;
using System.Text;

namespace CardWar.Core
{
    public class Player
    {
        public string Name { get; set; }
        private Hand hand;

        public Player(string name)
        {
            Name = name;
            hand = new Hand();
        }

        // pick a card using the hand and add it to the players' queue
        public void PickCard(Card card)
        {
            hand.DrawCard(card);
        }

        // play a card from the top card in the player's queue
        public Card PlayCard()
        {
            return hand.PlayCard();
        }

        // keep players card count by invoking the queue's card count
        public int CardCount()
        {
            return hand.Count;
        }

    }
}
