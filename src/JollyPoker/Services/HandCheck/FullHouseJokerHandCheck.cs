using JollyPoker.Core;
using JollyPoker.Core.Hand;

namespace JollyPoker.Services.HandCheck
{
	public class FullHouseJokerHandCheck : IHandCheck
	{
		public HandResult CheckHand(Card c1, Card c2, Card c3, Card c4, Card c5)
		{
			if (WithThreeSame(c1, c2, c3, c4, c5) || WithTwoSame(c1, c2, c3, c4, c5) || WithLastTwoSame(c1, c2, c3, c4, c5))
			{
				c1.Stop = true;
				c2.Stop = true;
				c3.Stop = true;
				c4.Stop = true;
				c5.Stop = true;

				return new HandResult(new FullHouse());
			}
			return null;
		}

		private bool WithThreeSame(Card c1, Card c2, Card c3, Card c4, Card c5)
		{
			return
				c2.Value == c3.Value &&
				c3.Value == c4.Value &&
				c5.Value == 15;
		}

		private bool WithTwoSame(Card c1, Card c2, Card c3, Card c4, Card c5)
		{
			return
				c1.Value == c2.Value &&
				c3.Value == c4.Value &&
				c5.Value == 15;
		}

		private bool WithLastTwoSame(Card c1, Card c2, Card c3, Card c4, Card c5)
		{
			return
				c1.Value == c2.Value &&
				c2.Value == c3.Value &&
				c5.Value == 15;
		}
	}
}