using JollyPoker.Core;
using JollyPoker.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace JollyPoker.UI
{

	public class MainScreen
	{
		private readonly List<IControl> _controls;
		private readonly CardsControl _cardsControl;
		private readonly StopControl _stopControl;
		private readonly GameCredit _gameCredit;

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

			_controls = new List<IControl> 
			{
				new BoardControl(_gameCredit),
				new CreditControl(ScreenWidth, ScreenHeight, _gameCredit),
				new ChipControl(ScreenWidth, ScreenHeight, _gameCredit),
				_cardsControl,
				new MessageControl(),
				_stopControl
			};

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
			var handService = new HandService();
			var handResult = handService.CheckHand(cards);

			_cardsControl.Cards = cards;
			_cardsControl.Draw();

			_stopControl.Cards = cards;
			_stopControl.Draw();
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
	}
}
