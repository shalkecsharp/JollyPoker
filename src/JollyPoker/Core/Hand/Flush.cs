using JollyPoker.Enums;
using System;

namespace JollyPoker.Core.Hand
{
	public class Flush : IHand
	{
		public string Title => "FLUSH";

		public int Value => 7;

		public HandTypes Type => HandTypes.Flush;

		public ConsoleColor Color => ConsoleColor.White;
	}
}