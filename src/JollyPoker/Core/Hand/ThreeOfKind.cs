using JollyPoker.Enums;

namespace JollyPoker.Core.Hand
{
	public class ThreeOfKind : IHand
	{
		public string Title => "THREE OF A KIND";

		public int Value => 3;

		public HandTypes Type => HandTypes.ThreeOfKind;
	}
}