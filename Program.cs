using System;
using System.Collections.Generic;
using System.Text;

namespace JollyPoker
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.OutputEncoding = Encoding.UTF8;
			Console.BackgroundColor = ConsoleColor.DarkBlue;
			Console.Clear();

			Console.WriteLine("Pritisnite ENTER za pocetak igre.");
			var keyInfo = Console.ReadKey();
			if (keyInfo.Key == ConsoleKey.Enter)
			{
				// Start of the game

				var deckOfCards = new List<Card>();
				for (int i = 2; i < 15; i++)
				{
					for (int j = 1; j < 5; j++)
					{
						deckOfCards.Add(new Card(i, new Suite(j)));
					}
				}
				deckOfCards.Add(new Card(15, new Suite(0)));

				// Randomize deck of cards
				for (int i = 0; i < deckOfCards.Count; i++)
				{
					var tempCard = deckOfCards[i];
					var randomPosition = new Random().Next(i, deckOfCards.Count);
					deckOfCards[i] = deckOfCards[randomPosition];
					deckOfCards[randomPosition] = tempCard;
				}

				// Deal first 5 cards
				for (int i = 0; i < 5; i++)
				{
					Card card = deckOfCards[i];
					Console.ForegroundColor = card.Suite.Color;
					Console.Write($"{card} ");
				}



				Console.ReadKey();
			}
		}
	}

}
