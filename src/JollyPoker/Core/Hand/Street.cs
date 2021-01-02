using JollyPoker.Enums;

namespace JollyPoker.Core.Hand
{
	public class Street : IHand
	{
		public string Title => "STREET";

		public int Value => 5;

		public HandTypes Type => HandTypes.Street;
	}
}