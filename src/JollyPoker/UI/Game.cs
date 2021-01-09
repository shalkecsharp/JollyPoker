using JollyPoker.Core;
using JollyPoker.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace JollyPoker.UI
{
	public class Game
	{
		private MainScreen _mainScreen;
		private GameCredit _gameCredit { get; set; }

		public int ScreenWidth { get; }
		public int ScreenHeight { get; }
		public bool ContinueGame { get; set; } = true;
		
		public Game(int screenWidth, int screenHeight, int currentCredit, int currentChip)
		{
			ScreenWidth = screenWidth;
			ScreenHeight = screenHeight;
			_gameCredit = new GameCredit(currentCredit, currentChip);
		}

		public void Run()
		{
			var deckOfCards = new DeckOfCards();
			deckOfCards.InitDeck();
			var cards = deckOfCards.DealCards(5);

			// Draw main screen
			_mainScreen = new MainScreen(ScreenWidth, ScreenHeight, _gameCredit);
			_mainScreen.Show();

			// Wait for ENTER
			_mainScreen.WaitForChipInput();

			_mainScreen.DealFirstHand(cards);

			_mainScreen.WaitForCardStop(cards);

			//_mainScreen.DealSecondHand();


			Console.ReadKey();


			//// First hand
			//StopCards(cards);

			//// Second hand
			//var newCardsToDeal = 5 - cards.Count(p => p.Stop);
			//var secondHand = deckOfCards.DealCards(newCardsToDeal);
			//var newHand = cards.Where(p => p.Stop).Concat(secondHand).ToList();

			//ResetStops(newHand);
			//var secondHandResult = handService.CheckHand(newHand);
			//PrintCards(newHand);
			//PrintResult(secondHandResult);

			Console.ReadKey();
		}


		private void ResetStops(List<Card> newHand)
		{
			foreach (var card in newHand)
			{
				card.Stop = false;
			}
		}

	}
}
