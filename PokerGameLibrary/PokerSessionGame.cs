using PokerGameLibrary.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerGameLibrary
{
    /// <summary>
    /// Represents a single poker game
    /// </summary>
    public class PokerSessionGame
    {
        public const int shuffleXTimes = 3;
        public int gameNumber { get; set; }
        public string gameWinner { get; set; }
        public CardDeck gameCardDeck { get; set; }
        public bool isActive { get; set; }
        public string winningHand { get; set; }

        public PokerSessionGame()
        {
            gameCardDeck = new CardDeck();

            for (int i = 0; i <= shuffleXTimes; i++)
            {
                gameCardDeck.Shuffle();
            }

            isActive = true;
        }
    }
}
