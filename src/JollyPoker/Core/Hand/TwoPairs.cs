using JollyPoker.Enums;

namespace JollyPoker.Core.Hand
{
	public class TwoPairs : IHand
	{
		public string Title => "TWO PAIRS";

		public int Value => 2;

		public HandTypes Type => HandTypes.TwoPairs;
	}
}