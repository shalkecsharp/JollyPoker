using JollyPoker.Core;
using System;
using System.Collections.Generic;

namespace JollyPoker.UI
{
	public class CardsControl : IControl
	{
		
		public CardsControl(List<Card> cards)
		{
			Cards = cards;
		}

		public List<Card> Cards { get; set; }

		public void Draw()
		{
			for (int i = 0; i < Cards.Count; i++)
			{
				var card = Cards[i];
				Console.SetCursorPosition(i * 12, 11);
				card.Draw(Console.CursorLeft, Console.CursorTop);
			}
		}
	}
}
