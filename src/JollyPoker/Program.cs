using JollyPoker.Core;
using JollyPoker.Services;
using JollyPoker.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JollyPoker
{
	class Program
	{
		static void Main(string[] args)
		{
			const int width = 70;
			const int height = 20;

			Console.OutputEncoding = Encoding.UTF8;
			Console.BackgroundColor = ConsoleColor.Black;
			Console.CursorVisible = false;
			Console.SetWindowSize(width, height);
			Console.SetBufferSize(width, height);
			Console.SetWindowPosition(0, 0);
			Console.Clear();

			var continueGame = true;

			// Start of the game
			var chip = 1;
			var credit = 100;

			// Draw main screen
			var mainScreen = new MainScreen(width, height, credit, chip);
			mainScreen.Draw();


			Console.ReadKey();

			while (continueGame)
			{
				Console.ForegroundColor = ConsoleColor.Black;
				Console.BackgroundColor = ConsoleColor.DarkBlue;
				Console.Clear();
				var deckOfCards = new DeckOfCards();
				deckOfCards.InitDeck();

				// Deal first 5 cards
				var cards = deckOfCards.DealCards(5);

				var handService = new HandService();
				var handResult = handService.CheckHand(cards);
				StopCards(cards);

				var newCardsToDeal = 5 - cards.Count(p => p.Stop);
				var secondHand = deckOfCards.DealCards(newCardsToDeal);
				var newHand = cards.Where(p => p.Stop).Concat(secondHand).ToList();

				ResetStops(newHand);
				var secondHandResult = handService.CheckHand(newHand);
				PrintCards(newHand);
				PrintResult(secondHandResult);

				Console.ReadKey();
			}

			Console.ReadKey();
		}



		private static void PrintResult(HandResult secondHandResult)
		{
			if (secondHandResult != null)
			{
				Console.WriteLine();
				Console.WriteLine($"{secondHandResult.Result.Title}");
			}
		}

		private static void ResetStops(List<Card> newHand)
		{
			foreach (var card in newHand)
			{
				card.Stop = false;
			}
		}

		private static void StopCards(List<Card> cards)
		{
			var stoppingCards = true;
			while (stoppingCards)
			{
				PrintCards(cards);
				var keyInfo = Console.ReadKey(true);
				switch (keyInfo.Key)
				{
					case ConsoleKey.D1:
						cards[0].Stop = !cards[0].Stop;
						break;
					case ConsoleKey.D2:
						cards[1].Stop = !cards[1].Stop;
						break;
					case ConsoleKey.D3:
						cards[2].Stop = !cards[2].Stop;
						break;
					case ConsoleKey.D4:
						cards[3].Stop = !cards[3].Stop;
						break;
					case ConsoleKey.D5:
						cards[4].Stop = !cards[4].Stop;
						break;
					case ConsoleKey.Enter:
						stoppingCards = false;
						break;
				}
			}
		}

		private static void PrintCards(List<Card> cards)
		{
			Console.Clear();
			foreach (var card in cards)
			{
				Console.ForegroundColor = card.Suite.Color;
				Console.BackgroundColor = ConsoleColor.White;
				Console.Write($"{card} ");
			}
			Console.WriteLine("");
			foreach (var card in cards)
			{
				Console.Write($"{card.IsStopped} ");
			}

			Console.WriteLine("");

			Console.WriteLine("Oznacite karte koje zelite da ostavite za sledece deljenje pomocu tastera 1, 2, 3, 4 i 5.");
			Console.WriteLine("Za nastavak deljenja pritisnite taster ENTER.");
		}

		

	}

}
