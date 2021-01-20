using JollyPoker.Core;
using JollyPoker.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JollyPoker.UI
{

	public class MainScreen
	{
		private readonly List<IControl> _controls;
		private readonly CardsControl _cardsControl;
		private readonly StopControl _stopControl;
		private readonly GameCredit _gameCredit;
		private readonly MessageControl _messageControl;
		private readonly HandService _handService;

		public int ScreenWidth { get; }
		public int ScreenHeight { get; }


		public MainScreen(int screenWidth, int screenHeight, GameCredit gameCredit)
		{
			List<Card> emptyCards = GetEmptyCards();

			ScreenWidth = screenWidth;
			ScreenHeight = screenHeight;
			_gameCredit = gameCredit;

			_cardsControl = new CardsControl(emptyCards);
			_stopControl = new StopControl(emptyCards);
			_messageControl = new MessageControl(ScreenWidth);

			_controls = new List<IControl> 
			{
				new BoardControl(_gameCredit),
				new CreditControl(ScreenWidth, ScreenHeight, _gameCredit),
				new ChipControl(ScreenWidth, ScreenHeight, _gameCredit),
				_cardsControl,
				_messageControl,
				_stopControl
			};

			_handService = new HandService();

			InitScreen();
		}



		private List<Card> GetEmptyCards()
		{
			return new List<Card> 
			{
				new EmptyCard(),
				new EmptyCard(),
				new EmptyCard(),
				new EmptyCard(),
				new EmptyCard(),
			};
		}

		public void Show()
		{
			Console.BackgroundColor = ConsoleColor.Black;
			Console.ForegroundColor = ConsoleColor.White;
			Console.Clear();

			foreach (var control in _controls)
			{
				control.Draw();
			}

			_messageControl.Title = "Use UP/DOWN to change chip. Press ENTER to deal cards.";
		}

		private void InitScreen()
		{
			Console.OutputEncoding = Encoding.UTF8;
			Console.BackgroundColor = ConsoleColor.Black;
			Console.CursorVisible = false;
			Console.SetWindowSize(ScreenWidth, ScreenHeight);
			Console.SetBufferSize(ScreenWidth, ScreenHeight);
			Console.SetWindowPosition(0, 0);
			Console.Clear();
		}

		public void DealFirstHand(List<Card> cards)
		{
			var handResult = _handService.CheckHand(cards);

			_cardsControl.Cards = cards;
			_cardsControl.Draw();

			_stopControl.Cards = cards;
			_stopControl.Draw();

			_messageControl.Title = "Use 1,2,3,4 and 5 to stop cards. Press ENTER to deal new cards.";
		}

		public void DealSecondHand(List<Card> cards)
		{
			ResetStops(cards);
			var secondHandResult = _handService.CheckHand(cards);

			_cardsControl.Cards = cards;
			_cardsControl.Draw();

			_stopControl.Cards = cards;
			_stopControl.Draw();

			_messageControl.Title = $"Your result: {secondHandResult?.Result.Title}";
		}

		public void WaitForChipInput()
		{
			var waitForInput = true;
			while (waitForInput)
			{
				var keyInfo = Console.ReadKey(true);
				switch (keyInfo.Key)
				{
					case ConsoleKey.DownArrow:
						if (_gameCredit.Chip > 1)
						{
							_gameCredit.Chip -= 1;
							Show();
						}
						break;
					case ConsoleKey.UpArrow:
						if (_gameCredit.Chip < 50)
						{
							_gameCredit.Chip += 1;
							Show();
						}
						break;
					case ConsoleKey.Enter:
						waitForInput = false;
						break;
					default:
						continue;
				}
			}
		}

		public void WaitForCardStop(List<Card> cards)
		{
			var stoppingCards = true;
			while (stoppingCards)
			{
				var keyInfo = Console.ReadKey(true);
				switch (keyInfo.Key)
				{
					case ConsoleKey.D1:
						cards[0].Stop = !cards[0].Stop;
						_stopControl.Draw();
						break;
					case ConsoleKey.D2:
						cards[1].Stop = !cards[1].Stop;
						_stopControl.Draw();
						break;
					case ConsoleKey.D3:
						cards[2].Stop = !cards[2].Stop;
						_stopControl.Draw();
						break;
					case ConsoleKey.D4:
						cards[3].Stop = !cards[3].Stop;
						_stopControl.Draw();
						break;
					case ConsoleKey.D5:
						cards[4].Stop = !cards[4].Stop;
						_stopControl.Draw();
						break;
					case ConsoleKey.Enter:
						stoppingCards = false;
						break;
				}
			}
		}

		private void ResetStops(List<Card> cards)
		{
			foreach (var card in cards)
			{
				card.Stop = false;
			}
		}
	}
}
