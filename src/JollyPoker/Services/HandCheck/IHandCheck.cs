using JollyPoker.Core;

namespace JollyPoker.Services.HandCheck
{
	public interface IHandCheck
	{
		HandResult CheckHand(Card c1, Card c2, Card c3, Card c4, Card c5);
	}
}