using JollyPoker.Enums;
using System;

namespace JollyPoker.Core.Hand
{
	public class Street : IHand
	{
		public string Title => "STREET";

		public int Value => 5;

		public HandTypes Type => HandTypes.Street;

		public ConsoleColor Color => ConsoleColor.White;

	}
}