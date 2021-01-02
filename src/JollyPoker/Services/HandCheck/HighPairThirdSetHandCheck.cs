using JollyPoker.Core;
using JollyPoker.Core.Hand;

namespace JollyPoker.Services.HandCheck
{
	public class HighPairThirdSetHandCheck : IHandCheck
	{
		public HandResult CheckHand(Card c1, Card c2, Card c3, Card c4, Card c5)
		{
			if (
				c3.Value == c4.Value &&
				c3.Value >= 10 &&
				c4.Value >= 10)
			{
				c3.Stop = true;
				c4.Stop = true;
				return new HandResult(new HighPair());
			}
			return null;
		}
	}
}