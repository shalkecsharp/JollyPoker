using JollyPoker.Enums;
using System;

namespace JollyPoker.Core.Hand
{
	public class TwoPairs : IHand
	{
		public string Title => "TWO PAIRS";

		public int Value => 2;

		public HandTypes Type => HandTypes.TwoPairs;

		public ConsoleColor Color => ConsoleColor.White;

	}
}