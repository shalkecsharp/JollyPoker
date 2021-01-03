using JollyPoker.Core;

namespace JollyPoker.Services.HandCheck
{
	public abstract class HandCheckBase : IHandCheck
	{
		public abstract HandResult CheckHand(Card c1, Card c2, Card c3, Card c4, Card c5);

		protected bool IsSameSuite(Card c1, Card c2, Card c3, Card c4, Card c5)
		{
			return
				c1.Suite.Value == c2.Suite.Value &&
				c2.Suite.Value == c3.Suite.Value &&
				c3.Suite.Value == c4.Suite.Value &&
				c4.Suite.Value == c5.Suite.Value;
		}

		protected bool IsSameSuiteWithJoker(Card c1, Card c2, Card c3, Card c4, Card c5)
		{
			return
				c1.Suite.Value == c2.Suite.Value &&
				c2.Suite.Value == c3.Suite.Value &&
				c3.Suite.Value == c4.Suite.Value &&
				c5.Value == 15;
		}

		protected bool IsStreet(Card c1, Card c2, Card c3, Card c4, Card c5)
		{
			return IsGeneralStreet(c1, c2, c3, c4, c5) || IsStreetStartingWithAce(c1, c2, c3, c4, c5);
		}

		private bool IsGeneralStreet(Card c1, Card c2, Card c3, Card c4, Card c5)
		{
			return 
				c1.Value == c2.Value - 1 &&
				c2.Value == c3.Value - 1 &&
				c3.Value == c4.Value - 1 &&
				c4.Value == c5.Value - 1;
		}

		private bool IsStreetStartingWithAce(Card c1, Card c2, Card c3, Card c4, Card c5)
		{
			return c1.Value == 2 &&
				c2.Value == 3 &&
				c3.Value == 4 &&
				c4.Value == 5 &&
				c5.Value == 11;
		}


		protected bool IsStreetWithJoker(Card c1, Card c2, Card c3, Card c4, Card c5)
		{
			return IsGeneralStreetWithJoker(c1, c2, c3, c4, c5) || IsStreetWithJokerIncludingAce(c1, c2, c3, c4, c5);
		}

		private bool IsGeneralStreetWithJoker(Card c1, Card c2, Card c3, Card c4, Card c5)
		{
			return
				IsStreetWithJokerFirstOrLast(c1, c2, c3, c4, c5) ||
				IsStreetWithJokerSecond(c1, c2, c3, c4, c5) ||
				IsStreetWithJokerThird(c1, c2, c3, c4, c5) ||
				IsStreetWithJokerFourth(c1, c2, c3, c4, c5);
		}

		private bool IsStreetWithJokerFirstOrLast(Card c1, Card c2, Card c3, Card c4, Card c5)
		{
			return
				c1.Value == c2.Value - 1 &&
				c2.Value == c3.Value - 1 &&
				c3.Value == c4.Value - 1 &&
				c5.Value == 15;
		}

		private bool IsStreetWithJokerSecond(Card c1, Card c2, Card c3, Card c4, Card c5)
		{
			return
				c1.Value == c2.Value - 2 &&
				c2.Value == c3.Value - 1 &&
				c3.Value == c4.Value - 1 &&
				c5.Value == 15;
		}

		private bool IsStreetWithJokerThird(Card c1, Card c2, Card c3, Card c4, Card c5)
		{
			return
				c1.Value == c2.Value - 1 &&
				c2.Value == c3.Value - 2 &&
				c3.Value == c4.Value - 1 &&
				c5.Value == 15;
		}

		private bool IsStreetWithJokerFourth(Card c1, Card c2, Card c3, Card c4, Card c5)
		{
			return
				c1.Value == c2.Value - 1 &&
				c2.Value == c3.Value - 1 &&
				c3.Value == c4.Value - 2 &&
				c5.Value == 15;
		}


		private bool IsStreetWithJokerIncludingAce(Card c1, Card c2, Card c3, Card c4, Card c5)
		{
			return
				IsStreetWithJokerFirstOrLastIncludingAce(c1, c2, c3, c4, c5) ||
				IsStreetWithJokerSecondIncludingAce(c1, c2, c3, c4, c5) ||
				IsStreetWithJokerThirdIncludingAce(c1, c2, c3, c4, c5) ||
				IsStreetWithJokerFourthIncludingAce(c1, c2, c3, c4, c5);
		}

		private bool IsStreetWithJokerFirstOrLastIncludingAce(Card c1, Card c2, Card c3, Card c4, Card c5)
		{
			return
				c1.Value == 2 &&
				c2.Value == 3 &&
				c3.Value == 4 &&
				c4.Value == 11 &&
				c5.Value == 15;
		}

		private bool IsStreetWithJokerSecondIncludingAce(Card c1, Card c2, Card c3, Card c4, Card c5)
		{
			return
				c1.Value == 3 &&
				c2.Value == 4 &&
				c3.Value == 5 &&
				c4.Value == 11 &&
				c5.Value == 15;
		}

		private bool IsStreetWithJokerThirdIncludingAce(Card c1, Card c2, Card c3, Card c4, Card c5)
		{
			return
				c1.Value == 2 &&
				c2.Value == 4 &&
				c3.Value == 5 &&
				c4.Value == 11 &&
				c5.Value == 15;
		}

		private bool IsStreetWithJokerFourthIncludingAce(Card c1, Card c2, Card c3, Card c4, Card c5)
		{
			return
				c1.Value == 2 &&
				c2.Value == 3 &&
				c3.Value == 5 &&
				c4.Value == 11 &&
				c5.Value == 15;
		}

	}
}