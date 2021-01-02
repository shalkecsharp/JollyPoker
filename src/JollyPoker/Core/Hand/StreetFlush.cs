using JollyPoker.Enums;

namespace JollyPoker.Core.Hand
{
	public class StreetFlush : IHand
	{
		public string Title => "STREET FLUSH";

		public int Value => 100;

		public HandTypes Type => HandTypes.StreetFlush;
	}
}