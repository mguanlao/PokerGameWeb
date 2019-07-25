using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerGameLibrary.UnitTests
{
    [TestFixture]
    public class PokerSessionGameTest
    {
        private PokerSessionGame CreatePokerGame()
        {
            return new PokerSessionGame();
        }

        [Test]
        public void PokerGameSession_Validate_Card_Deck_Created()
        {
            PokerSessionGame newGame = CreatePokerGame();

            Assert.NotNull(newGame.gameCardDeck);
            Assert.AreEqual(newGame.gameCardDeck.cardDeck.Count, CardDeck.DeckSize);
        }
    }
}
