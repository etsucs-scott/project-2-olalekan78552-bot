using System;
using System.Collections.Generic;
using System.Text;

// cards suit and ranks arranged in the order of lowest to highest for easy comparison in game engine
public enum Suits
{
    Hearts,
    Diamonds,
    Clubs,
    Spades
}
public enum Ranks
{
    Two = 2,
    Three,
    Four,
    Five,
    Six,
    Seven,
    Eight,
    Nine,
    Ten,
    Jack,
    Queen,
    King,
    Ace

}

namespace CardWar.Core
{
    public class Card
    {
        public Suits Suit { get; set; }
        public Ranks Rank { get; set; }

        // override tostring method to display card them
        public override string ToString()
        {
            return $"{Rank.ConvertRank()} {Suit}";
        }
    }


}
