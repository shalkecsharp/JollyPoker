using JollyPoker.Enums;

namespace JollyPoker.Core.Hand
{
	public class HighPair : IHand
	{
		public string Title => "HIGH PAIR";

		public int Value => 1;

		public HandTypes Type => HandTypes.HighPair;
	}
}