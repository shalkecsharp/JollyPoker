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

		protected bool IsStreet(Card c1, Card c2, Card c3, Card c4, Card c5)
		{
			return
				c1.Value == c2.Value - 1 &&
				c2.Value == c3.Value - 1 &&
				c3.Value == c4.Value - 1 &&
				c4.Value == c5.Value - 1;
		}
	}
}