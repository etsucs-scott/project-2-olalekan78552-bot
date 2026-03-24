using System;
using System.Collections.Generic;
using System.Text;

namespace CardWar.Core
{
    public class Hand
    {
        // create a queue to hold card in card in hand
        public Queue<Card> Cards { get; set; }

        public Hand()
        {
            Cards = new Queue<Card>();
        }

        // Add a card to the end of the queue using the FIFO method
        public void DrawCard(Card card)
        {
            Cards.Enqueue(card);
        }

        // Remove a card from the top of the queue using the FIFO method
        public Card PlayCard()
        {
            return Cards.Dequeue();
        }


        // Return card left in the queue
        public int Count
        {
            get { return Cards.Count; }
        }
    }
}
