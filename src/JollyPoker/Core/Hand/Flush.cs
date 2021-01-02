using JollyPoker.Enums;

namespace JollyPoker.Core.Hand
{
	public class Flush : IHand
	{
		public string Title => "FLUSH";

		public int Value => 7;

		public HandTypes Type => HandTypes.Flush;
	}
}