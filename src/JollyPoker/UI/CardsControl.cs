using JollyPoker.Core;
using JollyPoker.UI.Templates;
using System;
using System.Collections.Generic;
using System.Linq;

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
			const int CardTop = 11;
			Console.BackgroundColor = ConsoleColor.White;
			
			for (int i = 0; i < Cards.Count; i++)
			{
				var card = Cards[i];
				Console.ForegroundColor = card.Suite.Color;

				int left = i * (card.Width + 4);

				var template = GetCardTemplate(card);
				var renderedCard = RenderTemplate(card, template);

				for (int j = 0; j < renderedCard.Length; j++)
				{
					Console.SetCursorPosition(left, CardTop + j);
					Console.Write(renderedCard[j]);
				}
			}
		}

		private string GetCardTemplate(Card card)
		{
			switch (card.Value)
			{
				case 2:
					return CardTemplates._2;
				case 3:
					return CardTemplates._3;
				case 4:
					return CardTemplates._4;
				case 5:
					return CardTemplates._5;
				case 6:
					return CardTemplates._6;
				case 7:
					return CardTemplates._7;
				case 8:
					return CardTemplates._8;
				case 9:
					return CardTemplates._9;
				case 10:
					return CardTemplates._10;
				case 11:
					return CardTemplates._1;
				case 12:
					return CardTemplates._12;
				case 13:
					return CardTemplates._13;
				case 14:
					return CardTemplates._14;
				case 15:
					return CardTemplates._15;
				default:
					return CardTemplates._0;
			}
		}

		private string[] RenderTemplate(Card card, string template)
		{
			var rendered = template.Replace("$", card.Suite.ToString()).Split('\n');
			return rendered;
		}
	}
}
