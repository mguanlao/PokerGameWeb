using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerGameLibrary.Enums
{
    public enum CardNumber
    {
        [Description("2")]
        TWO =2,
        [Description("3")]
        THREE,
        [Description("4")]
        FOUR,
        [Description("5")]
        FIVE,
        [Description("6")]
        SIX,
        [Description("7")]
        SEVEN,
        [Description("8")]
        EIGHT,
        [Description("9")]
        NINE,
        [Description("10")]
        TEN,
        [Description("J")]
        JACK,
        [Description("Q")]
        QUEEN,
        [Description("K")]
        KING,
        [Description("A")]
        ACE
    }
}
