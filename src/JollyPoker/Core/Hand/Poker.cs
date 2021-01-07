using JollyPoker.Enums;
using System;

namespace JollyPoker.Core.Hand
{
	public class Poker : IHand
	{
		public string Title => "POKER";

		public int Value => 40;

		public HandTypes Type => HandTypes.Poker;

		public ConsoleColor Color => ConsoleColor.White;

	}
}