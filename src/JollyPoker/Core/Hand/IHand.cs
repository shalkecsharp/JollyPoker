using JollyPoker.Enums;
using System;

namespace JollyPoker.Core.Hand
{
	public interface IHand
	{
		public string Title { get; }
		public int Value { get; }
		public HandTypes Type { get; }
		public ConsoleColor Color { get; }
	}
}