namespace CardWar.Core;

public class Deck
{
    // a stack object is declared to hold the stack of cards
    // a count object is created to keep the count of cards in the stack
    private Stack<Card> Cards = new Stack<Card>();
    public int Count { get { return Cards.Count; } }


    // building a 52 card set by combining card-set (4 suits x 13) ranks to deck
    public Deck()
    {
        List<Card> card = new List<Card>();
        foreach (Suits suit in Enum.GetValues(typeof(Suits)))
        {
            foreach (Ranks rank in Enum.GetValues(typeof(Ranks)))
            {
                card.Add(new Card{ Suit = suit, Rank = rank});
            }
        }

        Shuffle(card);

        Cards = new Stack<Card>(card);
    }

    // using the Fisher-Yates shuffle to ensure random distribution 
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

    // draw the next card from the deck
    public Card PopCard()
    {
        return Cards.Pop();
    }



}
