using System;

namespace JollyPoker.Core
{
	public class Card
	{
		public Card(int value, Suite sign)
		{
			Value = value;
			Suite = sign;
			Width = 9;
			Height = 7;
		}

		public int Value { get; set; }

		public Suite Suite { get; set; }

		public int Width { get; }

		public int Height { get; }

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
							throw new ArgumentOutOfRangeException("Value is not allowed.");
					}
				}
			}
		}

		public override string ToString()
		{
			return $"{DisplayValue}{Suite}";
		}

		public virtual void Draw(int currentLeft, int currentTop)
		{
			DrawNormalCard(currentLeft, currentTop);
		}

		private void DrawNormalCard(int currentLeft, int currentTop)
		{
			Console.BackgroundColor = ConsoleColor.White;
			Console.ForegroundColor = Suite.Color;

			// Draw first line
			Console.Write($"{this}");
			for (int i = 0; i <= Width - this.ToString().Length; i++)
			{
				Console.Write(" ");
			}

			// Draw middle of the card
			for (int i = 1; i < 6; i++)
			{
				Console.SetCursorPosition(currentLeft, currentTop + i);
				for (int j = 0; j <= Width; j++)
				{
					Console.Write(" ");
				}
			}

			// Draw last line
			Console.SetCursorPosition(currentLeft, currentTop + 6);
			for (int i = 0; i < Width - this.ToString().Length; i++)
			{
				Console.Write(" ");
			}
			Console.Write($"{this} ");
		}

	}

}
