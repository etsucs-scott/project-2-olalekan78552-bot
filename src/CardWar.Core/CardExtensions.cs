using System;
using System.Collections.Generic;
using System.Text;

namespace CardWar.Core
{
    public static class CardExtensions
    {
        public static string ConvertRank(this Ranks rank)
        {
            return rank switch
            {
                Ranks.Ace => "A",
                Ranks.King => "K",
                Ranks.Queen => "Q",
                Ranks.Jack => "J",
                Ranks.Ten => "10",
                _=> ((int)rank).ToString()

            };
        }


        //public static string ConvertSuit(this Suits suit)
        //{
        //    return suit switch
        //    {
        //        Suits.Hearts => "♥",
        //        Suits.Diamonds => "♦",
        //        Suits.Spades => "♠",
        //        Suits.Clubs => "♣",
        //        _ => "?"

        //    };

        //}
    }
}
