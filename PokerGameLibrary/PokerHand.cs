using PokerGameLibrary.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerGameLibrary
{
    /// <summary>
    /// Represents a set of 5 cards or a single player poker hand
    /// </summary>
    public class PokerHand
    {
        public List<Card> cardHands { get; set; }
        // stores the value of the hand combination if a combination was achieved
        public PokerHandCombination handCombination { get; set; }
        // stored the value of the highest card value if there are no hand combinations achieved
        public int highCardValue { get; set; }
        // stored the number of times cards has been redrawn in the hand. maximum times to redraw is 3.
        public int redrawCount { get; set; }

        public PokerHand(PokerSessionGame currentGamePlayed)
        {
            cardHands = currentGamePlayed.gameCardDeck.GetCardsFromDeck(5);

            for (int i = 0; i < 5; i++)
            {
                cardHands[i].handOrder = i;
            }
        }

        public PokerHand()
        {
        }
    }
}
