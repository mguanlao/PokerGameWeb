using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerGameLibrary.Enums
{
    public enum PokerHandCombination
    {
        [Description("High Card")]
        HIGH_CARD = 0,
        [Description("Pair")]
        PAIR,
        [Description("Two Pairs")]
        TWO_PAIRS,
        [Description("Three of a Kind")]
        THREE_OF_A_KIND,
        [Description("Straight")]
        STRAIGHT,
        [Description("Flush")]
        FLUSH,
        [Description("Full House")]
        FULLHOUSE,
        [Description("Four of a Kind")]
        FOUR_OF_A_KIND,
        [Description("Straight Flush")]
        STRAIGHT_FLUSH,
        [Description("Royal Flush")]
        ROYAL_FLUSH
    }
}
