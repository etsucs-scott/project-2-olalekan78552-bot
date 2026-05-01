using System;
using System.Collections.Generic;
using System.Text;

namespace CardWar.Core
{
    /// <summary>
    /// format rank for abbrevated display of ranks
    /// </summary>
    public static class CardExtensions
    {
        /// <summary>
        /// Convert Ranks to abbreviation for game display purpose
        /// </summary>
        /// <param name="rank"></param>
        /// <returns>Abbrevated rank representation</returns>
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
