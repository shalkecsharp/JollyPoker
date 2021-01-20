using JollyPoker.Core;
using System;
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

			// Second hand
			var newCardsToDeal = 5 - cards.Count(p => p.Stop);
			var secondHand = deckOfCards.DealCards(newCardsToDeal);

			deckOfCards.ReplaceWithNewCards(cards, secondHand);
			_mainScreen.DealSecondHand(cards);


			Console.ReadKey();

		}


	}
}
