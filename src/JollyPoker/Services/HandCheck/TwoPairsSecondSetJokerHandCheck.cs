using JollyPoker.Core;
using JollyPoker.Core.Hand;

namespace JollyPoker.Services.HandCheck
{
	public class TwoPairsSecondSetJokerHandCheck : IHandCheck
	{
		public HandResult CheckHand(Card c1, Card c2, Card c3, Card c4, Card c5)
		{
			if (c2.Value == c3.Value && c5.Value == 15)
			{
				c2.Stop = true;
				c3.Stop = true;
				c4.Stop = true;
				c5.Stop = true;
				return new HandResult(new TwoPairs());
			}
			return null;
		}
	}
}