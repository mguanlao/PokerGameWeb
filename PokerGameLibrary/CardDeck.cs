using PokerGameLibrary.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerGameLibrary
{
    /// <summary>
    /// Represents a full card set
    /// </summary>
    public class CardDeck
    {
        public const int DeckSize = 52;

        public List<Card> cardDeck;
        private static Random rng = new Random();

        public CardDeck()
        {
            cardDeck = new List<Card>();

            foreach (Suit suit in Enum.GetValues(typeof(Suit)))
            {
                foreach (CardNumber cardNumber in Enum.GetValues(typeof(CardNumber)))
                {
                    Card card = new Card(suit, cardNumber);
                    cardDeck.Add(card);
                }
            }
        }

        public void Shuffle()
        {
            Card card = null;

            for (int i = 0; i < DeckSize; i++)
            {
                int newPosition = rng.Next(DeckSize);
                card = cardDeck[i];
                cardDeck[i] = cardDeck[newPosition];
                cardDeck[newPosition] = card;
            }
        }

        public List<Card> GetCardsFromDeck(int numberOfCards)
        {
            List<Card> drawnCards = new List<Card>();

            for (int i = 0; i < numberOfCards; i++)
            {
                drawnCards.Add(GetSingleCardFromDeck());
            }

            return drawnCards;
        }

        private Card GetSingleCardFromDeck()
        {
            if (cardDeck.Count < 0)
            {
                throw new Exception("Card deck has been depleted.");
            }

            Card drawnCard = cardDeck[0];
            cardDeck.Remove(drawnCard);

            return drawnCard;
        }
    }
}
