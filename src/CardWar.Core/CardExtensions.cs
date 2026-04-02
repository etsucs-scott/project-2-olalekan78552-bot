using System;
using System.Collections.Generic;
using System.Text;

namespace CardWar.Core
{
    public static class CardExtensions
    {
        // Convert Ranks to abbreviation for game display purpose
        public static string ConvertRank(this Ranks rank)
        {
            return rank switch
            {
                Ranks.Ace => "A",
                Ranks.King => "K",
                Ranks.Queen => "Q",
                Ranks.Jack => "J",
                _=> ((int)rank).ToString()

            };
        }



    }
}
