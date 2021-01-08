using System;

namespace JollyPoker.UI
{
	public class CreditControl : IControl
	{
		private const string creditLabel = "Kredit";

		public CreditControl(int screenWidth, int screenHeight, int currentCredit)
		{
			ScreenWidth = screenWidth;
			ScreenHeight = screenHeight;
			CurrentCredit = currentCredit;
		}

		public int ScreenWidth { get; }
		public int ScreenHeight { get; }
		public int CurrentCredit { get; }

		public void Draw()
		{
			Console.SetCursorPosition(ScreenWidth - creditLabel.Length, 1);
			Console.ForegroundColor = ConsoleColor.Red;
			Console.Write(creditLabel);

			Console.SetCursorPosition(ScreenWidth - CurrentCredit.ToString().Length, 2);
			Console.ForegroundColor = ConsoleColor.White;
			Console.Write(CurrentCredit);
		}
	}
}
