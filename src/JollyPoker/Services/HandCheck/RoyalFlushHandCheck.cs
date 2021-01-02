using JollyPoker.Core;
using JollyPoker.Core.Hand;

namespace JollyPoker.Services.HandCheck
{
	public class RoyalFlushHandCheck : HandCheckBase
	{
		public override HandResult CheckHand(Card c1, Card c2, Card c3, Card c4, Card c5)
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

				return new HandResult(new RoyalFlush());
			}

			return null;
		}
	}
}