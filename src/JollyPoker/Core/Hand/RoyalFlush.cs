using JollyPoker.Enums;
using System;

namespace JollyPoker.Core.Hand
{
	public class RoyalFlush : IHand
	{
		public string Title => "ROYAL FLUSH";

		public int Value => 500;

		public HandTypes Type => HandTypes.RoyalFlush;

		public ConsoleColor Color => ConsoleColor.Red;
	}
}