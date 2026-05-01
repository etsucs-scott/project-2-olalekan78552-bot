namespace CardWar.Core
{
    public class Deck
    {
        /// <summary>
        /// Represents a standard deck of 52 playing cards.
        /// Handles deck creation, shuffling, and drawing cards.
        /// </summary>

        private Stack<Card> Cards = new Stack<Card>();

        /// <summary>
        /// get the number of cards in deck
        /// </summary>
        public int Count
        { 
            get { return Cards.Count; } 
        }

        /// <summary>
        /// building a 52 card set by combining card-set (4 suits x 13) ranks to deck
        /// </summary>
        public Deck()
        {
            List<Card> card = new List<Card>();
            foreach (Suits suit in Enum.GetValues(typeof(Suits)))
            {
                foreach (Ranks rank in Enum.GetValues(typeof(Ranks)))
                {
                    card.Add(new Card { Suit = suit, Rank = rank });
                }
            }

            Shuffle(card);

            Cards = new Stack<Card>(card);
        }

        /// <summary>
        /// using the Fisher-Yates shuffle to ensure random distribution
        /// </summary>
        /// <param name="card">The list of card to shuffle</param>    
        public void Shuffle(List<Card> card)
        {
            Random rand = new Random();

            int lastIndex = card.Count() - 1;

            while (lastIndex > 0)
            {
                int randomIndex = rand.Next(lastIndex + 1);
                Card tempCard = card[lastIndex];
                card[lastIndex] = card[randomIndex];
                card[randomIndex] = tempCard;

                lastIndex--;
            }
        }

        /// <summary>
        /// draw the next card from the deck
        /// </summary>
        /// <returns>the nezxt card from the deck</returns>
        public Card PopCard()
        {
            return Cards.Pop();
        }
    }
}
