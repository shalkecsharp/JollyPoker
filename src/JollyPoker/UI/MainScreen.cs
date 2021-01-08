using System;
using System.Collections.Generic;
using System.Text;

namespace JollyPoker.UI
{
	public class MainScreen
	{
		private readonly List<IControl> _controls;

		public MainScreen(int screenWidth, int screenHeight, int currentCredit, int currentChip)
		{
			ScreenWidth = screenWidth;
			ScreenHeight = screenHeight;
			CurrentCredit = currentCredit;
			CurrentChip = currentChip;
			_controls = new List<IControl> 
			{
				new BoardControl(),
				new CreditControl(ScreenWidth, ScreenHeight, CurrentCredit),
				new ChipControl(ScreenWidth, ScreenHeight, CurrentChip),
				new CardsControl()
			};

			InitScreen();
		}

		public int ScreenWidth { get; }
		public int ScreenHeight { get; }
		public int CurrentCredit { get; }
		public int CurrentChip { get; }

		public void Show()
		{
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

	}
}
