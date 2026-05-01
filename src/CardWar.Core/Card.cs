using System;
using System.Collections.Generic;
using System.Text;

/// <summary>
/// cards suit and ranks arranged in the order of lowest to highest for easy comparison in game engine
/// </summary>
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
    /// <summary>
    /// create a card object which comparises of rank and suits
    /// Override the card object to print the card name
    /// </summary>
    public class Card
    {
        public Suits Suit { get; set; }
        public Ranks Rank { get; set; }

        /// <summary>
        /// Replace tostring method with an enum card representation
        /// </summary>
        /// <returns>Return rank and suit of card</returns>
        public override string ToString()
        {
            return $"{Rank.ConvertRank()} {Suit}";
        }
    }


}
