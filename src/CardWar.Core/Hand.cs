using System;
using System.Collections.Generic;
using System.Text;

namespace CardWar.Core
{
    public class Hand
    {
        public Queue<Card> cards = new Queue<Card>();

        // keep the number of cards left in the queue
        public int Count()
        {
            return cards.Count;
        }

        // add a card to back of queue using the FIFO method
        public void AddCard(Card card)
        {
            cards.Enqueue(card);
            
        }

        // remove card from queue using the FIFO method 
        public Card RemoveCard()
        {
            return cards.Dequeue();
        }


    }
}
