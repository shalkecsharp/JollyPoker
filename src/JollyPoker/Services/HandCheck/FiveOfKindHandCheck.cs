using JollyPoker.Core;
using JollyPoker.Core.Hand;

namespace JollyPoker.Services.HandCheck
{
	public class FiveOfKindHandCheck : IHandCheck
	{
		public HandResult CheckHand(Card c1, Card c2, Card c3, Card c4, Card c5)
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

				return new HandResult(new FiveOfKind());
			}
			return null;
		}
	}
}