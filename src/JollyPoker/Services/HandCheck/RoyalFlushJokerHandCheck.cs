using JollyPoker.Core;
using JollyPoker.Core.Hand;

namespace JollyPoker.Services.HandCheck
{
	public class RoyalFlushJokerHandCheck : HandCheckBase
	{
		public override HandResult CheckHand(Card c1, Card c2, Card c3, Card c4, Card c5)
		{
			if (HasJoker(c1, c2, c3, c4, c5) && IsSameSuite(c1, c2, c3, c4, c5))
			{
				c1.Stop = true;
				c2.Stop = true;
				c3.Stop = true;
				c4.Stop = true;
				c5.Stop = true;

				return new HandResult(new RoyalFlush());
			}

			return null;
		}

		private bool HasJoker(Card c1, Card c2, Card c3, Card c4, Card c5)
		{
			return
				IsJokerFirst(c1, c2, c3, c4, c5) ||
				IsJokerSecond(c1, c2, c3, c4, c5) ||
				IsJokerThird(c1, c2, c3, c4, c5) ||
				IsJokerFourth(c1, c2, c3, c4, c5) ||
				IsJokerFifth(c1, c2, c3, c4, c5);
		}

		private bool IsJokerFirst(Card c1, Card c2, Card c3, Card c4, Card c5)
		{
			return
				c1.Value == 11 &&
				c2.Value == 12 &&
				c3.Value == 13 &&
				c4.Value == 14 &&
				c5.Value == 15;
		}

		private bool IsJokerSecond(Card c1, Card c2, Card c3, Card c4, Card c5)
		{
			return
				c1.Value == 10 &&
				c2.Value == 12 &&
				c3.Value == 13 &&
				c4.Value == 14 &&
				c5.Value == 15;
		}

		private bool IsJokerThird(Card c1, Card c2, Card c3, Card c4, Card c5)
		{
			return
				c1.Value == 10 &&
				c2.Value == 11 &&
				c3.Value == 13 &&
				c4.Value == 14 &&
				c5.Value == 15;
		}

		private bool IsJokerFourth(Card c1, Card c2, Card c3, Card c4, Card c5)
		{
			return
				c1.Value == 10 &&
				c2.Value == 11 &&
				c3.Value == 12 &&
				c4.Value == 14 &&
				c5.Value == 15;
		}

		private bool IsJokerFifth(Card c1, Card c2, Card c3, Card c4, Card c5)
		{
			return
				c1.Value == 10 &&
				c2.Value == 11 &&
				c3.Value == 12 &&
				c4.Value == 13 &&
				c5.Value == 15;
		}
	}
}