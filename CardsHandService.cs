using System.Collections.Generic;
using System.Linq;

namespace JollyPoker
{
	public class CardsHandService
	{
		public CardsHandResult CheckHand(List<Card> cards)
		{
			var sortedCards = cards.OrderBy(p => p.Value).ToList();
			var c1 = sortedCards[0];
			var c2 = sortedCards[1];
			var c3 = sortedCards[2];
			var c4 = sortedCards[3];
			var c5 = sortedCards[4];

			// FIVE OF A KIND
			var result = CheckFiveOfKind(c1, c2, c3, c4, c5);
			if (result != null) return result;

			// ROYAL FLUSH
			result = CheckRoyalFlush(c1, c2, c3, c4, c5);
			if (result != null) return result;


			// STREET FLUSH
			result = CheckStreetFlush(c1, c2, c3, c4, c5);
			if (result != null) return result;


			// POKER 1
			result = CheckPokerFirstSet(c1, c2, c3, c4);
			if (result != null) return result;


			// POKER 2
			result = CheckPokerSecondSet(c2, c3, c4, c5);
			if (result != null) return result;


			// FULL HOUSE 1
			result = CheckFullHouseFirstSet(c1, c2, c3, c4, c5);
			if (result != null) return result;

			// FULL HOUSE 2
			result = CheckFullHouseSecondSet(c1, c2, c3, c4, c5);
			if (result != null) return result;

			// FLUSH
			result = CheckFlush(c1, c2, c3, c4, c5);
			if (result != null) return result;

			// STREET
			result = CheckStreet(c1, c2, c3, c4, c5);
			if (result != null) return result;

			// THREE OF A KIND 1
			result = CheckThreeOfKindFirstSet(c1, c2, c3);
			if (result != null) return result;

			// THREE OF A KIND 2
			result = CheckThreeOfKindSecondSet(c2, c3, c4);
			if (result != null) return result;

			// THREE OF A KIND 3
			result = CheckThreeOfKindThirdSet(c3, c4, c5);
			if (result != null) return result;

			// TWO PAIRS 1
			result = CheckTwoPairsFirstSet(c1, c2, c3, c4);
			if (result != null) return result;

			// TWO PAIRS 2
			result = CheckTwoPairsSecondSet(c1, c2, c4, c5);
			if (result != null) return result;

			// TWO PAIRS 3
			result = CheckTwoPairsThirdSet(c2, c3, c4, c5);
			if (result != null) return result;


			// HIGH PAIR 1
			result = CheckHighPairFirstSet(c1, c2);
			if (result != null) return result;

			// HIGH PAIR 2
			result = CheckHighPairSecondSet(c2, c3);
			if (result != null) return result;

			// HIGH PAIR 3
			result = CheckHighPairThirdSet(c3, c4);
			if (result != null) return result;

			// HIGH PAIR 4
			result = CheckHighPairFourthSet(c4, c5);
			if (result != null) return result;

			return null;
		}

		private CardsHandResult CheckFiveOfKind(Card c1, Card c2, Card c3, Card c4, Card c5)
		{
			if (
				c1.Value == c2.Value &&
				c2.Value == c3.Value &&
				c3.Value == c4.Value &&
				c5.Value == 15)
			{
				c1.Stop = true;
				c2.Stop = true;
				c3.Stop = true;
				c4.Stop = true;
				c5.Stop = true;

				return new CardsHandResult(new FiveOfKind());
			}
			return null;
		}

		private CardsHandResult CheckRoyalFlush(Card c1, Card c2, Card c3, Card c4, Card c5)
		{
			if (
				c1.Value == 10 &&
				c2.Value == 11 &&
				c3.Value == 12 &&
				c4.Value == 13 &&
				c5.Value == 14 &&
				IsSameSuite(c1, c2, c3, c4, c5))
			{
				c1.Stop = true;
				c2.Stop = true;
				c3.Stop = true;
				c4.Stop = true;
				c5.Stop = true;

				return new CardsHandResult(new RoyalFlush());
			}

			return null;
		}

		private CardsHandResult CheckStreetFlush(Card c1, Card c2, Card c3, Card c4, Card c5)
		{
			if (
				IsStreet(c1, c2, c3, c4, c5) &&
				IsSameSuite(c1, c2, c3, c4, c5))
			{
				c1.Stop = true;
				c2.Stop = true;
				c3.Stop = true;
				c4.Stop = true;
				c5.Stop = true;

				return new CardsHandResult(new StreetFlush());
			}
			return null;
		}

		private CardsHandResult CheckPokerFirstSet(Card c1, Card c2, Card c3, Card c4)
		{
			if (
				c1.Value == c2.Value &&
				c2.Value == c3.Value &&
				c3.Value == c4.Value)
			{
				c1.Stop = true;
				c2.Stop = true;
				c3.Stop = true;
				c4.Stop = true;

				return new CardsHandResult(new Poker());
			}
			return null;
		}

		private CardsHandResult CheckPokerSecondSet(Card c2, Card c3, Card c4, Card c5)
		{
			if (
				c2.Value == c3.Value &&
				c3.Value == c4.Value &&
				c4.Value == c5.Value)
			{
				c2.Stop = true;
				c3.Stop = true;
				c4.Stop = true;
				c5.Stop = true;
				return new CardsHandResult(new Poker());
			}
			return null;
		}

		private CardsHandResult CheckFullHouseFirstSet(Card c1, Card c2, Card c3, Card c4, Card c5)
		{
			if (
				c1.Value == c2.Value &&
				c3.Value == c4.Value &&
				c4.Value == c5.Value)
			{
				c1.Stop = true;
				c2.Stop = true;
				c3.Stop = true;
				c4.Stop = true;
				c5.Stop = true;

				return new CardsHandResult(new FullHouse());
			}
			return null;
		}

		private CardsHandResult CheckFullHouseSecondSet(Card c1, Card c2, Card c3, Card c4, Card c5)
		{
			if (
				c1.Value == c2.Value &&
				c2.Value == c3.Value &&
				c4.Value == c5.Value)
			{
				c1.Stop = true;
				c2.Stop = true;
				c3.Stop = true;
				c4.Stop = true;
				c5.Stop = true;
				return new CardsHandResult(new FullHouse());
			}
			return null;
		}

		private CardsHandResult CheckFlush(Card c1, Card c2, Card c3, Card c4, Card c5)
		{
			if (IsSameSuite(c1, c2, c3, c4, c5))
			{
				c1.Stop = true;
				c2.Stop = true;
				c3.Stop = true;
				c4.Stop = true;
				c5.Stop = true;
				return new CardsHandResult(new Flush());
			}
			return null;
		}

		private CardsHandResult CheckStreet(Card c1, Card c2, Card c3, Card c4, Card c5)
		{
			if (IsStreet(c1, c2, c3, c4, c5))
			{
				c1.Stop = true;
				c2.Stop = true;
				c3.Stop = true;
				c4.Stop = true;
				c5.Stop = true;
				return new CardsHandResult(new Street());
			}
			return null;
		}

		private CardsHandResult CheckThreeOfKindFirstSet(Card c1, Card c2, Card c3)
		{
			if (
				c1.Value == c2.Value &&
				c2.Value == c3.Value)
			{
				c1.Stop = true;
				c2.Stop = true;
				c3.Stop = true;
				return new CardsHandResult(new ThreeOfKind());
			}
			return null;
		}

		private CardsHandResult CheckThreeOfKindSecondSet(Card c2, Card c3, Card c4)
		{
			if (
				c2.Value == c3.Value &&
				c3.Value == c4.Value)
			{
				c2.Stop = true;
				c3.Stop = true;
				c4.Stop = true;

				return new CardsHandResult(new ThreeOfKind());
			}
			return null;
		}

		private CardsHandResult CheckThreeOfKindThirdSet(Card c3, Card c4, Card c5)
		{
			if (
				c3.Value == c4.Value &&
				c4.Value == c5.Value)
			{
				c3.Stop = true;
				c4.Stop = true;
				c5.Stop = true;
				return new CardsHandResult(new ThreeOfKind());
			}
			return null;
		}

		private CardsHandResult CheckTwoPairsFirstSet(Card c1, Card c2, Card c3, Card c4)
		{
			if (
				c1.Value == c2.Value &&
				c3.Value == c4.Value)
			{
				c1.Stop = true;
				c2.Stop = true;
				c3.Stop = true;
				c4.Stop = true;
				return new CardsHandResult(new TwoPairs());
			}
			return null;
		}

		private CardsHandResult CheckTwoPairsSecondSet(Card c1, Card c2, Card c4, Card c5)
		{
			if (
				c1.Value == c2.Value &&
				c4.Value == c5.Value)
			{
				c1.Stop = true;
				c2.Stop = true;
				c4.Stop = true;
				c5.Stop = true;
				return new CardsHandResult(new TwoPairs());
			}
			return null;
		}

		private CardsHandResult CheckTwoPairsThirdSet(Card c2, Card c3, Card c4, Card c5)
		{
			if (
				c2.Value == c3.Value &&
				c4.Value == c5.Value)
			{
				c2.Stop = true;
				c3.Stop = true;
				c4.Stop = true;
				c5.Stop = true;
				return new CardsHandResult(new TwoPairs());
			}
			return null;
		}

		private CardsHandResult CheckHighPairFirstSet(Card c1, Card c2)
		{
			if (
				c1.Value == c2.Value &&
				c1.Value >= 10 &&
				c2.Value >= 10)
			{
				c1.Stop = true;
				c2.Stop = true;
				return new CardsHandResult(new HighPair());
			}
			return null;
		}

		private CardsHandResult CheckHighPairSecondSet(Card c2, Card c3)
		{
			if (
				c2.Value == c3.Value &&
				c2.Value >= 10 &&
				c3.Value >= 10)
			{
				c2.Stop = true;
				c3.Stop = true;
				return new CardsHandResult(new HighPair());
			}
			return null;
		}

		private CardsHandResult CheckHighPairThirdSet(Card c3, Card c4)
		{
			if (
				c3.Value == c4.Value &&
				c3.Value >= 10 &&
				c4.Value >= 10)
			{
				c3.Stop = true;
				c4.Stop = true;
				return new CardsHandResult(new HighPair());
			}
			return null;
		}

		private CardsHandResult CheckHighPairFourthSet(Card c4, Card c5)
		{
			if (
				c4.Value == c5.Value &&
				c4.Value >= 10 &&
				c5.Value >= 10)
			{
				c4.Stop = true;
				c5.Stop = true;
				return new CardsHandResult(new HighPair());
			}
			return null;
		}


		private bool IsSameSuite(Card c1, Card c2, Card c3, Card c4, Card c5)
		{
			return
				c1.Suite.Value == c2.Suite.Value &&
				c2.Suite.Value == c3.Suite.Value &&
				c3.Suite.Value == c4.Suite.Value &&
				c4.Suite.Value == c5.Suite.Value;
		}

		private bool IsStreet(Card c1, Card c2, Card c3, Card c4, Card c5)
		{
			return
				c1.Value == c2.Value - 1 &&
				c2.Value == c3.Value - 1 &&
				c3.Value == c4.Value - 1 &&
				c4.Value == c5.Value - 1;
		}

	}
}