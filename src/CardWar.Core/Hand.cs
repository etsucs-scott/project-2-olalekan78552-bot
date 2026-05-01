using System;
using System.Collections.Generic;
using System.Text;

namespace CardWar.Core
{
    /// <summary>
    /// Represent player's hand of card in the game
    /// </summary>
    public class Hand
    {
        public Queue<Card> cards = new Queue<Card>();

        /// <summary>
        /// keep the number of cards left in the queue
        /// </summary>
        /// <returns>The number of card left</returns>
        public int Count()
        {
            return cards.Count;
        }

        /// <summary>
        /// add a card to back of queue using the FIFO method
        /// </summary>
        /// <param name="card">The card being added</param>
        public void AddCard(Card card)
        {
            cards.Enqueue(card);
            
        }

        /// <summary>
        /// remove card from queue using the FIFO method 
        /// </summary>
        /// <returns>The card being removed</returns>
        public Card RemoveCard()
        {
            return cards.Dequeue();
        }


    }
}
