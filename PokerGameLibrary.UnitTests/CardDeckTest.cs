using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerGameLibrary.UnitTests
{
    [TestFixture]
    public class CardDeckTest
    {
        private CardDeck CreateCardDeck()
        {
            return new CardDeck();
        }

        [Test]
        public void CardDeck_Validate_Number_Of_Cards()
        {
            CardDeck newCardDeck = CreateCardDeck();

            Assert.AreEqual(newCardDeck.cardDeck.Count, CardDeck.DeckSize);
        }

        public void CardDeck_Test_Shuffle()
        {
            CardDeck unshuffledCardDeck = CreateCardDeck();
            CardDeck shuffledCardDeck = CreateCardDeck();

            shuffledCardDeck.Shuffle();
            shuffledCardDeck.Shuffle();
            shuffledCardDeck.Shuffle();

            bool isSameCard = true;

            foreach (Card unshuffledCard in unshuffledCardDeck.cardDeck)
            {
                foreach (Card shuffledCard in shuffledCardDeck.cardDeck)
                {
                    isSameCard = unshuffledCard.suit == shuffledCard.suit && unshuffledCard.cardNumber == shuffledCard.cardNumber;
                }
            }

            Assert.IsFalse(isSameCard);
        }
    }
}
