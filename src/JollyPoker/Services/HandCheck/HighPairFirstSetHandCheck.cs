using JollyPoker.Core;
using JollyPoker.Core.Hand;

namespace JollyPoker.Services.HandCheck
{
	public class HighPairFirstSetHandCheck : IHandCheck
	{
		public HandResult CheckHand(Card c1, Card c2, Card c3, Card c4, Card c5)
		{
			if (
				c1.Value == c2.Value &&
				c1.Value >= 10 &&
				c2.Value >= 10)
			{
				c1.Stop = true;
				c2.Stop = true;
				return new HandResult(new HighPair());
			}
			return null;
		}
	}
}