using System;

namespace JollyPoker.UI
{
	public class ChipControl : IControl
	{
		private const string chipLabel = "Chip";
		private readonly GameCredit _gameCredit;

		public ChipControl(int screenWidth, int screenHeight, GameCredit gameCredit)
		{
			ScreenWidth = screenWidth;
			ScreenHeight = screenHeight;
			_gameCredit = gameCredit;
		}

		public int ScreenWidth { get; }
		public int ScreenHeight { get; }

		public void Draw()
		{
			Console.SetCursorPosition(ScreenWidth - chipLabel.Length, 4);
			Console.ForegroundColor = ConsoleColor.Yellow;
			Console.Write(chipLabel);

			Console.SetCursorPosition(ScreenWidth - _gameCredit.Chip.ToString().Length, 5);
			Console.ForegroundColor = ConsoleColor.White;
			Console.Write(_gameCredit.Chip);
		}
	}
}
