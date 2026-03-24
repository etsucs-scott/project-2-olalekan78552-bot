namespace CardWar.Core;

public class Deck
{
    public Stack<Card> Cards { get; private set; }

    public Deck()
    {
        Cards = new Stack<Card>();

        // building a 52 card set by combining card-set (4 suits x 13) ranks to deck
        foreach (Suits suit in Enum.GetValues(typeof(Suits)))
        {
            foreach (Ranks rank in Enum.GetValues(typeof(Ranks)))
            {
                Cards.Push(new Card { Rank = rank, Suit = suit});
            }
        }

    }

    // using the Fisher-Yates shuffle to ensure random distribution.
    // convert card stack to list for easy shuffle and reverse order after operation is concluded
    public void Shuffle()
    {
        List<Card> tempList = Cards.ToList();
        Random rand = new Random();
        int lastIndex = tempList.Count - 1;

        while(lastIndex > 0)
        { 
            int randomCard = rand.Next(lastIndex + 1);
            Card holder = tempList[lastIndex];
            tempList[lastIndex] = tempList[randomCard];
            tempList[randomCard] = holder;
            lastIndex--;
        }

        tempList.Reverse();
        Cards = new Stack<Card>(tempList);
    }


    // Remove card from the top of the stack
    public Card DrawCard()
    {
        return Cards.Pop();
    }

    // keep count of the number of cards left in the deck
    public int Count
    {
        get { return Cards.Count; }
    }



}
