﻿using System;

namespace JollyPoker.Core
{
	public class Card
	{
		public Card(int value, Suite sign)
		{
			Value = value;
			Suite = sign;
		}

		public int Value { get; set; }

		public Suite Suite { get; set; }

		public bool Stop { get; set; }

		public string DisplayValue
		{
			get
			{
				if (Value > 1 && Value < 10)
				{
					return $" {Value}";
				}
				else if (Value == 10)
				{
					return Value.ToString();
				}
				else
				{
					switch (Value)
					{
						case 11:
							return " A";
						case 12:
							return " J";
						case 13:
							return " D";
						case 14:
							return " K";
						case 15:
							return " @";
						default:
							throw new System.ArgumentOutOfRangeException("Value is not allowed.");
					}
				}
			}
		}

		public override string ToString()
		{
			return $"{DisplayValue}{Suite}";
		}

		public string IsStopped
		{
			get
			{
				return Stop ? " S " : "   ";
			}
		}

		public void Draw(int currentLeft, int currentTop)
		{
			Console.BackgroundColor = ConsoleColor.White;
			Console.ForegroundColor = Suite.Color;
			Console.Write($"{this}      ");
			for (int i = 1; i < 6; i++)
			{
				Console.SetCursorPosition(currentLeft, currentTop + i);
				Console.Write("         ");
			}
			Console.SetCursorPosition(currentLeft, currentTop + 6);
			Console.Write($"     {this} ");
		}

	}

}
