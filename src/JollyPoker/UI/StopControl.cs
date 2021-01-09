using JollyPoker.Core;
using System;
using System.Collections.Generic;

namespace JollyPoker.UI
{
	public class StopControl : IControl
	{
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
				Console.SetCursorPosition(i * 12, 18);
				if (card.Stop)
				{
					Console.Write("   Stop");
				}
				else
				{
					Console.Write("       ");
				}
			}
		}
	}
}
