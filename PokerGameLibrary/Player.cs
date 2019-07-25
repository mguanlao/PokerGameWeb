using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerGameLibrary
{
    /// <summary>
    /// Represents a poker player
    /// </summary>
    public class Player
    {
        public string name { get; set; }
        public PokerHand hand { get; set; }
        int wins { get; set; }

        public Player(string playerName)
        {
            name = playerName;
        }
    }
}
