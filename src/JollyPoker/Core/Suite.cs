using System;

namespace JollyPoker.Core
{
	public class Suite
	{
		public Suite(int value)
		{
			Value = value;
		}

		public int Value { get; set; }

		public ConsoleColor Color
		{
			get
			{
				switch (Value)
				{
					case 0:
						return ConsoleColor.DarkBlue;
					case 1:
						return ConsoleColor.Red;
					case 2:
						return ConsoleColor.Black;
					case 3:
						return ConsoleColor.Black;
					case 4:
						return ConsoleColor.Red;
					default:
						throw new ArgumentException("Passed value is not supported.");
				}
			}
		}

		public override string ToString()
		{
			switch (Value)
			{
				case 0:
					return "";
				case 1:
					return "♥";
				case 2:
					return "♣";
				case 3:
					return "♠";
				case 4:
					return "♦";
				default:
					throw new ArgumentException("Passed value is not supported.");
			}
		}
	}

}
