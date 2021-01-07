using JollyPoker.Enums;
using System;

namespace JollyPoker.Core.Hand
{
	public class FiveOfKind : IHand
	{
		public string Title => "FIVE OF A KIND";

		public int Value => 1100;

		public HandTypes Type => HandTypes.FiveOfKind;

		public ConsoleColor Color => ConsoleColor.Yellow;
	}
}