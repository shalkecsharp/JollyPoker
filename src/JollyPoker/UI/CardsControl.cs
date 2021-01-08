using JollyPoker.Core;
using System;
using System.Collections.Generic;

namespace JollyPoker.UI
{
	public class CardsControl : IControl
	{
		public void Draw()
		{
			var emptyCards = new List<Card>
			{
				new Card(2, new Suite(1)),
				new Card(5, new Suite(2)),
				new Card(6, new Suite(3)),
				new Card(14, new Suite(4)),
				new Card(11, new Suite(1)),
			};

			for (int i = 0; i < emptyCards.Count; i++)
			{
				var card = emptyCards[i];
				Console.SetCursorPosition(i * 10, 11);
				card.Draw(Console.CursorLeft, Console.CursorTop);
			}
		}
	}
}
