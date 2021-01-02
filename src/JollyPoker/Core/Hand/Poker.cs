using JollyPoker.Enums;

namespace JollyPoker.Core.Hand
{
	public class Poker : IHand
	{
		public string Title => "POKER";

		public int Value => 40;

		public HandTypes Type => HandTypes.Poker;
	}
}