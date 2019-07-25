using NUnit.Framework;
using PokerGameLibrary.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerGameLibrary.UnitTests
{
    public class PokerHandEvaluatorTest
    {
        static IEnumerable<Card[]> GetTestHand(PokerHandCombination handCombination)
        {
            if (handCombination == PokerHandCombination.FLUSH)
            {
                yield return new Card[]
                {
                    new Card(Suit.Club, CardNumber.TWO),
                    new Card(Suit.Club, CardNumber.JACK),
                    new Card(Suit.Club, CardNumber.TEN),
                    new Card(Suit.Club, CardNumber.THREE),
                    new Card(Suit.Club, CardNumber.NINE)
                };

                yield return new Card[]
                {
                    new Card(Suit.Diamond, CardNumber.ACE),
                    new Card(Suit.Diamond, CardNumber.THREE),
                    new Card(Suit.Diamond, CardNumber.FOUR),
                    new Card(Suit.Diamond, CardNumber.FIVE),
                    new Card(Suit.Diamond, CardNumber.SIX)
                };

                yield return new Card[]
                {
                    new Card(Suit.Spade, CardNumber.ACE),
                    new Card(Suit.Spade, CardNumber.THREE),
                    new Card(Suit.Spade, CardNumber.FOUR),
                    new Card(Suit.Spade, CardNumber.FIVE),
                    new Card(Suit.Spade, CardNumber.SIX)
                };

                yield return new Card[]
                {
                    new Card(Suit.Heart, CardNumber.ACE),
                    new Card(Suit.Heart, CardNumber.THREE),
                    new Card(Suit.Heart, CardNumber.FOUR),
                    new Card(Suit.Heart, CardNumber.FIVE),
                    new Card(Suit.Heart, CardNumber.SIX)
                };
            }

            if (handCombination == PokerHandCombination.STRAIGHT)
            {
                yield return new Card[]
                {
                    new Card(Suit.Club, CardNumber.TWO),
                    new Card(Suit.Diamond, CardNumber.THREE),
                    new Card(Suit.Spade, CardNumber.FOUR),
                    new Card(Suit.Heart, CardNumber.FIVE),
                    new Card(Suit.Club, CardNumber.SIX)
                };

                yield return new Card[]
                {
                    new Card(Suit.Club, CardNumber.THREE),
                    new Card(Suit.Diamond, CardNumber.FOUR),
                    new Card(Suit.Spade, CardNumber.FIVE),
                    new Card(Suit.Heart, CardNumber.SIX),
                    new Card(Suit.Club, CardNumber.SEVEN)
                };

                yield return new Card[]
                {
                    new Card(Suit.Club, CardNumber.FOUR),
                    new Card(Suit.Diamond, CardNumber.FIVE),
                    new Card(Suit.Spade, CardNumber.SIX),
                    new Card(Suit.Heart, CardNumber.SEVEN),
                    new Card(Suit.Club, CardNumber.EIGHT)
                };

                yield return new Card[]
                {
                    new Card(Suit.Club, CardNumber.FIVE),
                    new Card(Suit.Diamond, CardNumber.SIX),
                    new Card(Suit.Spade, CardNumber.SEVEN),
                    new Card(Suit.Heart, CardNumber.EIGHT),
                    new Card(Suit.Club, CardNumber.NINE)
                };
            }

            if (handCombination == PokerHandCombination.STRAIGHT_FLUSH)
            {
                yield return new Card[]
                {
                    new Card(Suit.Club, CardNumber.TWO),
                    new Card(Suit.Club, CardNumber.THREE),
                    new Card(Suit.Club, CardNumber.FOUR),
                    new Card(Suit.Club, CardNumber.FIVE),
                    new Card(Suit.Club, CardNumber.SIX)
                };

                yield return new Card[]
                {
                    new Card(Suit.Diamond, CardNumber.THREE),
                    new Card(Suit.Diamond, CardNumber.FOUR),
                    new Card(Suit.Diamond, CardNumber.FIVE),
                    new Card(Suit.Diamond, CardNumber.SIX),
                    new Card(Suit.Diamond, CardNumber.SEVEN)
                };

                yield return new Card[]
                {
                    new Card(Suit.Spade, CardNumber.FOUR),
                    new Card(Suit.Spade, CardNumber.FIVE),
                    new Card(Suit.Spade, CardNumber.SIX),
                    new Card(Suit.Spade, CardNumber.SEVEN),
                    new Card(Suit.Spade, CardNumber.EIGHT)
                };

                yield return new Card[]
                {
                    new Card(Suit.Heart, CardNumber.FIVE),
                    new Card(Suit.Heart, CardNumber.SIX),
                    new Card(Suit.Heart, CardNumber.SEVEN),
                    new Card(Suit.Heart, CardNumber.EIGHT),
                    new Card(Suit.Heart, CardNumber.NINE)
                };
            }

            if (handCombination == PokerHandCombination.ROYAL_FLUSH)
            {
                yield return new Card[]
                {
                    new Card(Suit.Club, CardNumber.TEN),
                    new Card(Suit.Club, CardNumber.JACK),
                    new Card(Suit.Club, CardNumber.QUEEN),
                    new Card(Suit.Club, CardNumber.KING),
                    new Card(Suit.Club, CardNumber.ACE)
                };

                yield return new Card[]
                {
                    new Card(Suit.Diamond, CardNumber.TEN),
                    new Card(Suit.Diamond, CardNumber.JACK),
                    new Card(Suit.Diamond, CardNumber.QUEEN),
                    new Card(Suit.Diamond, CardNumber.KING),
                    new Card(Suit.Diamond, CardNumber.ACE)
                };

                yield return new Card[]
                {
                    new Card(Suit.Heart, CardNumber.TEN),
                    new Card(Suit.Heart, CardNumber.JACK),
                    new Card(Suit.Heart, CardNumber.QUEEN),
                    new Card(Suit.Heart, CardNumber.KING),
                    new Card(Suit.Heart, CardNumber.ACE)
                };

                yield return new Card[]
                {
                    new Card(Suit.Spade, CardNumber.TEN),
                    new Card(Suit.Spade, CardNumber.JACK),
                    new Card(Suit.Spade, CardNumber.QUEEN),
                    new Card(Suit.Spade, CardNumber.KING),
                    new Card(Suit.Spade, CardNumber.ACE)
                };
            }

            if (handCombination == PokerHandCombination.FULLHOUSE)
            {
                yield return new Card[]
                {
                    new Card(Suit.Club, CardNumber.KING),
                    new Card(Suit.Spade, CardNumber.KING),
                    new Card(Suit.Diamond, CardNumber.KING),
                    new Card(Suit.Heart, CardNumber.THREE),
                    new Card(Suit.Club, CardNumber.THREE)
                };

                yield return new Card[]
                {
                    new Card(Suit.Club, CardNumber.TWO),
                    new Card(Suit.Spade, CardNumber.TWO),
                    new Card(Suit.Diamond, CardNumber.TWO),
                    new Card(Suit.Heart, CardNumber.ACE),
                    new Card(Suit.Club, CardNumber.ACE)
                };

                yield return new Card[]
                {
                    new Card(Suit.Club, CardNumber.FOUR),
                    new Card(Suit.Spade, CardNumber.FOUR),
                    new Card(Suit.Diamond, CardNumber.TEN),
                    new Card(Suit.Heart, CardNumber.TEN),
                    new Card(Suit.Club, CardNumber.TEN)
                };

                yield return new Card[]
                {
                    new Card(Suit.Club, CardNumber.FIVE),
                    new Card(Suit.Spade, CardNumber.FIVE),
                    new Card(Suit.Diamond, CardNumber.SEVEN),
                    new Card(Suit.Heart, CardNumber.SEVEN),
                    new Card(Suit.Club, CardNumber.SEVEN)
                };
            }

            if (handCombination == PokerHandCombination.FOUR_OF_A_KIND)
            {
                yield return new Card[]
                {
                    new Card(Suit.Club, CardNumber.ACE),
                    new Card(Suit.Spade, CardNumber.ACE),
                    new Card(Suit.Diamond, CardNumber.ACE),
                    new Card(Suit.Heart, CardNumber.ACE),
                    new Card(Suit.Club, CardNumber.THREE)
                };

                yield return new Card[]
                {
                    new Card(Suit.Club, CardNumber.JACK),
                    new Card(Suit.Spade, CardNumber.JACK),
                    new Card(Suit.Diamond, CardNumber.JACK),
                    new Card(Suit.Heart, CardNumber.JACK),
                    new Card(Suit.Club, CardNumber.TWO)
                };

                yield return new Card[]
                {
                    new Card(Suit.Club, CardNumber.TEN),
                    new Card(Suit.Spade, CardNumber.TEN),
                    new Card(Suit.Diamond, CardNumber.FIVE),
                    new Card(Suit.Heart, CardNumber.TEN),
                    new Card(Suit.Club, CardNumber.TEN)
                };

                yield return new Card[]
               {
                    new Card(Suit.Club, CardNumber.KING),
                    new Card(Suit.Spade, CardNumber.QUEEN),
                    new Card(Suit.Diamond, CardNumber.QUEEN),
                    new Card(Suit.Heart, CardNumber.QUEEN),
                    new Card(Suit.Club, CardNumber.QUEEN)
               };
            }

            if (handCombination == PokerHandCombination.THREE_OF_A_KIND)
            {
                yield return new Card[]
                {
                    new Card(Suit.Club, CardNumber.ACE),
                    new Card(Suit.Spade, CardNumber.ACE),
                    new Card(Suit.Diamond, CardNumber.ACE),
                    new Card(Suit.Heart, CardNumber.TWO),
                    new Card(Suit.Club, CardNumber.THREE)
                };

                yield return new Card[]
                {
                    new Card(Suit.Club, CardNumber.FIVE),
                    new Card(Suit.Spade, CardNumber.ACE),
                    new Card(Suit.Diamond, CardNumber.ACE),
                    new Card(Suit.Heart, CardNumber.ACE),
                    new Card(Suit.Club, CardNumber.JACK)
                };

                yield return new Card[]
                {
                    new Card(Suit.Club, CardNumber.FIVE),
                    new Card(Suit.Spade, CardNumber.TEN),
                    new Card(Suit.Diamond, CardNumber.ACE),
                    new Card(Suit.Heart, CardNumber.ACE),
                    new Card(Suit.Club, CardNumber.ACE)
                };

                yield return new Card[]
                {
                    new Card(Suit.Club, CardNumber.ACE),
                    new Card(Suit.Spade, CardNumber.QUEEN),
                    new Card(Suit.Diamond, CardNumber.KING),
                    new Card(Suit.Heart, CardNumber.ACE),
                    new Card(Suit.Club, CardNumber.ACE)
                };

                yield return new Card[]
                {
                    new Card(Suit.Club, CardNumber.ACE),
                    new Card(Suit.Spade, CardNumber.ACE),
                    new Card(Suit.Diamond, CardNumber.EIGHT),
                    new Card(Suit.Heart, CardNumber.NINE),
                    new Card(Suit.Club, CardNumber.ACE)
                };
            }

            if (handCombination == PokerHandCombination.TWO_PAIRS)
            {
                yield return new Card[]
                {
                    new Card(Suit.Club, CardNumber.ACE),
                    new Card(Suit.Spade, CardNumber.ACE),
                    new Card(Suit.Diamond, CardNumber.THREE),
                    new Card(Suit.Heart, CardNumber.THREE),
                    new Card(Suit.Club, CardNumber.EIGHT)
                };

                yield return new Card[]
                {
                    new Card(Suit.Club, CardNumber.NINE),
                    new Card(Suit.Spade, CardNumber.ACE),
                    new Card(Suit.Diamond, CardNumber.ACE),
                    new Card(Suit.Heart, CardNumber.FIVE),
                    new Card(Suit.Club, CardNumber.FIVE)
                };

                yield return new Card[]
                {
                    new Card(Suit.Club, CardNumber.ACE),
                    new Card(Suit.Spade, CardNumber.ACE),
                    new Card(Suit.Diamond, CardNumber.QUEEN),
                    new Card(Suit.Heart, CardNumber.KING),
                    new Card(Suit.Club, CardNumber.KING)
                };
            }

            if (handCombination == PokerHandCombination.PAIR)
            {
                yield return new Card[]
                {
                    new Card(Suit.Club, CardNumber.ACE),
                    new Card(Suit.Spade, CardNumber.ACE),
                    new Card(Suit.Diamond, CardNumber.FIVE),
                    new Card(Suit.Heart, CardNumber.JACK),
                    new Card(Suit.Club, CardNumber.THREE)
                };

                yield return new Card[]
                {
                    new Card(Suit.Club, CardNumber.FIVE),
                    new Card(Suit.Spade, CardNumber.ACE),
                    new Card(Suit.Diamond, CardNumber.ACE),
                    new Card(Suit.Heart, CardNumber.JACK),
                    new Card(Suit.Club, CardNumber.THREE)
                };

                yield return new Card[]
                {
                    new Card(Suit.Club, CardNumber.FIVE),
                    new Card(Suit.Spade, CardNumber.SIX),
                    new Card(Suit.Diamond, CardNumber.ACE),
                    new Card(Suit.Heart, CardNumber.ACE),
                    new Card(Suit.Club, CardNumber.THREE)
                };

                yield return new Card[]
                {
                    new Card(Suit.Club, CardNumber.FIVE),
                    new Card(Suit.Spade, CardNumber.TWO),
                    new Card(Suit.Diamond, CardNumber.THREE),
                    new Card(Suit.Heart, CardNumber.ACE),
                    new Card(Suit.Club, CardNumber.ACE)
                };
            }

            if (handCombination == PokerHandCombination.HIGH_CARD)
            {
                yield return new Card[]
                {
                    new Card(Suit.Club, CardNumber.TWO),
                    new Card(Suit.Spade, CardNumber.ACE),
                    new Card(Suit.Diamond, CardNumber.EIGHT),
                    new Card(Suit.Heart, CardNumber.FIVE),
                    new Card(Suit.Club, CardNumber.SIX)
                };

                yield return new Card[]
                {
                    new Card(Suit.Club, CardNumber.THREE),
                    new Card(Suit.Spade, CardNumber.EIGHT),
                    new Card(Suit.Diamond, CardNumber.ACE),
                    new Card(Suit.Heart, CardNumber.FIVE),
                    new Card(Suit.Club, CardNumber.SIX)
                };

                yield return new Card[]
                {
                    new Card(Suit.Club, CardNumber.TWO),
                    new Card(Suit.Spade, CardNumber.ACE),
                    new Card(Suit.Diamond, CardNumber.JACK),
                    new Card(Suit.Heart, CardNumber.FIVE),
                    new Card(Suit.Club, CardNumber.SIX)
                };

                yield return new Card[]
                {
                    new Card(Suit.Club, CardNumber.TWO),
                    new Card(Suit.Spade, CardNumber.QUEEN),
                    new Card(Suit.Diamond, CardNumber.JACK),
                    new Card(Suit.Heart, CardNumber.KING),
                    new Card(Suit.Club, CardNumber.FOUR)
                };
            }
        }

        private PokerHand CreatePokerHand(Card[] testHand)
        {
            PokerHand hand = new PokerHand();
            hand.cardHands = testHand.ToList();

            return hand;
        }

        [TestCaseSource(nameof(GetTestHand), new object[] { PokerHandCombination.FLUSH })]
        public void Flush_IsFlush_ReturnsTrue(Card[] testHand)
        {
            PokerHand flushHand = CreatePokerHand(testHand);

            PokerHandEvaluator.EvaluateHand(flushHand);

            Assert.AreEqual(PokerHandCombination.FLUSH, flushHand.handCombination);
        }

        [TestCaseSource(nameof(GetTestHand), new object[] { PokerHandCombination.STRAIGHT })]
        public void Straight_IsStraight_ReturnsTrue(Card[] testHand)
        {
            PokerHand straightHand = CreatePokerHand(testHand);

            PokerHandEvaluator.EvaluateHand(straightHand);

            Assert.AreEqual(PokerHandCombination.STRAIGHT, straightHand.handCombination);
        }

        [TestCaseSource(nameof(GetTestHand), new object[] { PokerHandCombination.STRAIGHT_FLUSH })]
        public void StraightFlush_IsStraightFlush_ReturnsTrue(Card[] testHand)
        {
            PokerHand straightFlushHand = CreatePokerHand(testHand);

            PokerHandEvaluator.EvaluateHand(straightFlushHand);

            Assert.AreEqual(PokerHandCombination.STRAIGHT_FLUSH, straightFlushHand.handCombination);
        }

        [TestCaseSource(nameof(GetTestHand), new object[] { PokerHandCombination.ROYAL_FLUSH })]
        public void RoyalFlush_IsRoyalFlush_ReturnsTrue(Card[] testHand)
        {
            PokerHand royalFlushHand = CreatePokerHand(testHand);

            PokerHandEvaluator.EvaluateHand(royalFlushHand);

            Assert.AreEqual(PokerHandCombination.ROYAL_FLUSH, royalFlushHand.handCombination);
        }

        [TestCaseSource(nameof(GetTestHand), new object[] { PokerHandCombination.FULLHOUSE })]
        public void FullHouse_IsFullHouse_ReturnsTrue(Card[] testHand)
        {
            PokerHand fullHouseHand = CreatePokerHand(testHand);

            PokerHandEvaluator.EvaluateHand(fullHouseHand);

            Assert.AreEqual(PokerHandCombination.FULLHOUSE, fullHouseHand.handCombination);
        }

        [TestCaseSource(nameof(GetTestHand), new object[] { PokerHandCombination.FOUR_OF_A_KIND })]
        public void FourOfAKind_IsFourOfAKind_ReturnsTrue(Card[] testHand)
        {
            PokerHand fourOfAKindHand = CreatePokerHand(testHand);

            PokerHandEvaluator.EvaluateHand(fourOfAKindHand);

            Assert.AreEqual(PokerHandCombination.FOUR_OF_A_KIND, fourOfAKindHand.handCombination);
        }

        [TestCaseSource(nameof(GetTestHand), new object[] { PokerHandCombination.THREE_OF_A_KIND })]
        public void ThreeOfAKind_IsThreeOfAKind_ReturnsTrue(Card[] testHand)
        {
            PokerHand threeOfAKindHand = CreatePokerHand(testHand);

            PokerHandEvaluator.EvaluateHand(threeOfAKindHand);

            Assert.AreEqual(PokerHandCombination.THREE_OF_A_KIND, threeOfAKindHand.handCombination);
        }

        [TestCaseSource(nameof(GetTestHand), new object[] { PokerHandCombination.FOUR_OF_A_KIND })]
        public void ThreeOfAKind_IsNot_FourOfAKind(Card[] testHand)
        {
            PokerHand fourOfAKindHand = CreatePokerHand(testHand);

            PokerHandEvaluator.EvaluateHand(fourOfAKindHand);

            Assert.AreNotEqual(PokerHandCombination.THREE_OF_A_KIND, fourOfAKindHand.handCombination);
        }

        [TestCaseSource(nameof(GetTestHand), new object[] { PokerHandCombination.TWO_PAIRS })]
        public void TwoPair_IsTwoPair_ReturnsTrue(Card[] testHand)
        {
            PokerHand twoPairsHand = CreatePokerHand(testHand);

            PokerHandEvaluator.EvaluateHand(twoPairsHand);

            Assert.AreEqual(PokerHandCombination.TWO_PAIRS, twoPairsHand.handCombination);
        }

        [TestCaseSource(nameof(GetTestHand), new object[] { PokerHandCombination.FOUR_OF_A_KIND })]
        [TestCaseSource(nameof(GetTestHand), new object[] { PokerHandCombination.THREE_OF_A_KIND })]
        public void TwoPair_IsNot_FourOrThree(Card[] testHand)
        {
            PokerHand threeOrFourOfAKindHand = CreatePokerHand(testHand);

            PokerHandEvaluator.EvaluateHand(threeOrFourOfAKindHand);

            Assert.AreNotEqual(PokerHandCombination.TWO_PAIRS, threeOrFourOfAKindHand.handCombination);
        }

        [TestCaseSource(nameof(GetTestHand), new object[] { PokerHandCombination.PAIR })]
        public void OnePair_IsOnePair_ReturnsTrue(Card[] testHand)
        {
            PokerHand pairHand = CreatePokerHand(testHand);

            PokerHandEvaluator.EvaluateHand(pairHand);

            Assert.AreEqual(PokerHandCombination.PAIR, pairHand.handCombination); ;
        }

        [TestCaseSource(nameof(GetTestHand), new object[] { PokerHandCombination.FOUR_OF_A_KIND })]
        [TestCaseSource(nameof(GetTestHand), new object[] { PokerHandCombination.THREE_OF_A_KIND })]
        [TestCaseSource(nameof(GetTestHand), new object[] { PokerHandCombination.TWO_PAIRS })]
        public void OnePair_IsNot_TwoThreeOrFour(Card[] testHand)
        {
            PokerHand twoThreeOrFourOfAKindHand = CreatePokerHand(testHand);

            PokerHandEvaluator.EvaluateHand(twoThreeOrFourOfAKindHand);

            Assert.AreNotEqual(PokerHandCombination.PAIR, twoThreeOrFourOfAKindHand.handCombination);
        }
    }
}
