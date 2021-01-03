using JollyPoker.Core;
using JollyPoker.Core.Hand;

namespace JollyPoker.Services.HandCheck
{
	public class ThreeOfKindThirdSetJokerHandCheck : IHandCheck
	{
		public HandResult CheckHand(Card c1, Card c2, Card c3, Card c4, Card c5)
		{
			if (c3.Value == c4.Value &&	c5.Value == 15)
			{
				c3.Stop = true;
				c4.Stop = true;
				c5.Stop = true;
				return new HandResult(new ThreeOfKind());
			}
			return null;
		}
	}
}