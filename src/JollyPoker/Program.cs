using JollyPoker.Core;
using JollyPoker.Core.Hand;
using JollyPoker.Services;
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

			// Draw board
			var boards = GetHands();
			Console.SetCursorPosition(0, 0);
			foreach (var boardItem in boards)
			{
				Console.ForegroundColor = boardItem.Color;
				Console.Write(boardItem.Title);
				Console.SetCursorPosition(30, Console.CursorTop);
				Console.Write(boardItem.Value);
				Console.WriteLine();
			}

			// Draw credit
			const string creditLabel = "Kredit";
			Console.SetCursorPosition(width - creditLabel.Length, 1);
			Console.ForegroundColor = ConsoleColor.Red;
			Console.Write(creditLabel);

			Console.SetCursorPosition(width - credit.ToString().Length, 2);
			Console.ForegroundColor = ConsoleColor.White;
			Console.Write(credit);

			// Draw chip
			const string chipLabel = "Chip";
			Console.SetCursorPosition(width - chipLabel.Length, 4);
			Console.ForegroundColor = ConsoleColor.Yellow;
			Console.Write(chipLabel);

			Console.SetCursorPosition(width - chip.ToString().Length, 5);
			Console.ForegroundColor = ConsoleColor.White;
			Console.Write(chip);

			// Draw empty cards
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

		private static List<IHand> GetHands()
		{
			return new List<IHand> 
			{
				new FiveOfKind(),
				new RoyalFlush(),
				new StreetFlush(),
				new Poker(),
				new FullHouse(),
				new Flush(),
				new Street(),
				new ThreeOfKind(),
				new TwoPairs(),
				new HighPair()
			};
		}

	}

}
