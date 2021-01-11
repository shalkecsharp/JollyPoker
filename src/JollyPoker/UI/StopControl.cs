using JollyPoker.Core;
using System;
using System.Collections.Generic;

namespace JollyPoker.UI
{
	public class StopControl : IControl
	{
		private const string label = "Stop";

		public List<Card> Cards { get; set; }

		public StopControl(List<Card> cards)
		{
			Cards = cards;
		}

		public void Draw()
		{
			Console.BackgroundColor = ConsoleColor.Black;
			Console.ForegroundColor= ConsoleColor.Yellow;
			for (int i = 0; i < Cards.Count; i++)
			{
				var card = Cards[i];
				Console.SetCursorPosition(i * (card.Width + 4), 18);
				if (card.Stop)
				{
					Console.Write(label.PadLeft(card.Width / 2 + label.Length - 1));
				}
				else
				{
					Console.Write(" ".PadLeft(card.Width));
				}
			}
		}
	}
}
