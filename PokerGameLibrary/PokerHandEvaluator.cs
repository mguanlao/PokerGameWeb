using PokerGameLibrary.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerGameLibrary
{
    /// <summary>
    /// Contains methods for evaluating winning hands
    /// </summary>
    public class PokerHandEvaluator
    {
        public static List<Player> EvaluateHands(List<Player> players)
        {
            List<Player> gameWinners;

            foreach (Player player in players)
            {
                EvaluateHand(player.hand);
            }

            // Get players with highest hand combinations
            var maxHand = players.Max(h => h.hand.handCombination);
            var topHandPlayers = players.Where(c => c.hand.handCombination == maxHand).ToList();

            // If multiple players have the top hand, determine by the high card
            if (topHandPlayers.Count() > 1)
            {
                var maxHighCard = players.Max(h => h.hand.highCardValue);
                var topHighCardPlayers = players.Where(c => c.hand.highCardValue == maxHighCard).ToList();

                gameWinners = topHighCardPlayers;
            }
            else
            {
                gameWinners = topHandPlayers;
            }

            return gameWinners;
        }

        public static void EvaluateHand(PokerHand hand)
        {
            // Determine hand combination
            DetermineHandCombination(hand);

            // Determine high card
            DetermineHighCardValue(hand);
        }

        private static void DetermineHighCardValue(PokerHand hand)
        {
            hand.highCardValue = Convert.ToInt32(hand.cardHands.Max(n => n.cardNumber));
        }

        private static void DetermineHandCombination(PokerHand hand)
        {
            bool hasPair = hand.cardHands.GroupBy(n => n.cardNumber)
                .Where(c => c.Count() == 2)
                .Count() == 1;

            bool hasThreeOfKind = hand.cardHands.GroupBy(n => n.cardNumber)
                .Where(c => c.Count() == 3)
                .Any();

            bool isStraight = true;
            Card[] sortedCards = hand.cardHands.OrderBy(n => n.cardNumber).ToArray();
            int straightStart = (int)sortedCards.First().cardNumber;

            for (int i = 1; i < sortedCards.Length; i++)
            {
                if ((int)sortedCards[i].cardNumber != straightStart + i)
                {
                    isStraight = false;
                    break;
                } 
            }

            bool isFlush = hand.cardHands.GroupBy(s => s.suit).Count() == 1;

            // Pair
            if (hand.cardHands.GroupBy(n => n.cardNumber)
                .Where(c => c.Count() == 3)
                .Count() == 0 && hasPair)
            {
                hand.handCombination = PokerHandCombination.PAIR;
            }

            // Two Pair
            else if (hand.cardHands.GroupBy(n => n.cardNumber)
                .Where(c => c.Count() == 2)
                .Count() == 2)
            {
                hand.handCombination = PokerHandCombination.TWO_PAIRS;
            }

            // Three of a Kind
            else if (hasThreeOfKind && !hasPair)
            {
                hand.handCombination = PokerHandCombination.THREE_OF_A_KIND;
            }

            // Four of a Kind
            else if (hand.cardHands.GroupBy(n => n.cardNumber)
                .Where(c => c.Count() == 4)
                .Any())
            {
                hand.handCombination = PokerHandCombination.FOUR_OF_A_KIND;
            }

            // Straight
            else if (isStraight && !isFlush)
            {
                hand.handCombination = PokerHandCombination.STRAIGHT;
            }

            // Flush
            else if (isFlush && !isStraight)
            {
                hand.handCombination = PokerHandCombination.FLUSH;
            }

            // FullHouse
            else if (hasThreeOfKind && hasPair)
            {
                hand.handCombination = PokerHandCombination.FULLHOUSE;
            }

            // Straight Flush
            else if (isStraight && isFlush && hand.cardHands.Max(n => n.cardNumber) <= CardNumber.KING)
            {
                hand.handCombination = PokerHandCombination.STRAIGHT_FLUSH;
            }

            // Royal Flush
            else if (isStraight && isFlush && hand.cardHands.Min(n => n.cardNumber) >= CardNumber.TEN)
            {
                hand.handCombination = PokerHandCombination.ROYAL_FLUSH;
            }

            else
            {
                hand.handCombination = PokerHandCombination.HIGH_CARD;
            }
        }
    }
}
