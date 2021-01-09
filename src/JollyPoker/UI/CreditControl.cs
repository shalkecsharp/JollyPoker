using System;

namespace JollyPoker.UI
{
	public class CreditControl : IControl
	{
		private const string creditLabel = "Kredit";
		private readonly GameCredit _gameCredit;

		public CreditControl(int screenWidth, int screenHeight, GameCredit gameCredit)
		{
			ScreenWidth = screenWidth;
			ScreenHeight = screenHeight;
			_gameCredit = gameCredit;
		}

		public int ScreenWidth { get; }
		public int ScreenHeight { get; }

		public void Draw()
		{
			Console.SetCursorPosition(ScreenWidth - creditLabel.Length, 1);
			Console.ForegroundColor = ConsoleColor.Red;
			Console.Write(creditLabel);

			Console.SetCursorPosition(ScreenWidth - _gameCredit.Credit.ToString().Length, 2);
			Console.ForegroundColor = ConsoleColor.White;
			Console.Write(_gameCredit.Credit);
		}
	}
}
