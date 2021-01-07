using JollyPoker.Enums;
using System;

namespace JollyPoker.Core.Hand
{
	public class ThreeOfKind : IHand
	{
		public string Title => "THREE OF A KIND";

		public int Value => 3;

		public HandTypes Type => HandTypes.ThreeOfKind;

		public ConsoleColor Color => ConsoleColor.White;

	}
}