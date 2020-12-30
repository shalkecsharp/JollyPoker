using System;
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
				var deckOfCards = new DeckOfCards();
				deckOfCards.InitDeck();

				// Deal first 5 cards
				var cards = deckOfCards.DealCards(5);
				foreach (var card in cards)
				{
					Console.ForegroundColor = card.Suite.Color;
					Console.Write($"{card} ");
				}

				Console.ReadKey();
			}
		}
	}

}
