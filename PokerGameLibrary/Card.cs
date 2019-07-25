using PokerGameLibrary.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerGameLibrary
{
    /// <summary>
    /// Represents a single poker game card
    /// </summary>
    public class Card
    {
        public Suit suit { get; set; }
        public CardNumber cardNumber { get; set; }

        /// <summary>
        /// Indicates the order of the card in the player's hand. Initialized as -1 which means the card is not yet in
        /// a player's hand.
        /// </summary>
        public int handOrder { get; set; }

        public Card(Suit paramSuit, CardNumber paramCardNumber)
        {
            suit = paramSuit;
            cardNumber = paramCardNumber;
            handOrder = -1;
        }
    }
}
