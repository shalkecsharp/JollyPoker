﻿using JollyPoker.Enums;
using System;

namespace JollyPoker.Core.Hand
{
	public class FullHouse : IHand
	{
		public string Title => "FULL HOUSE";

		public int Value => 10;

		public HandTypes Type => HandTypes.FullHouse;

		public ConsoleColor Color => ConsoleColor.White;

	}
}