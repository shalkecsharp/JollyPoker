using System;

namespace JollyPoker.UI
{
	public class ChipControl : IControl
	{
		private const string chipLabel = "Chip";

		public ChipControl(int screenWidth, int screenHeight, int currentChip)
		{
			ScreenWidth = screenWidth;
			ScreenHeight = screenHeight;
			CurrentChip = currentChip;
		}

		public int ScreenWidth { get; }
		public int ScreenHeight { get; }
		public int CurrentChip { get; }

		public void Draw()
		{
			Console.SetCursorPosition(ScreenWidth - chipLabel.Length, 4);
			Console.ForegroundColor = ConsoleColor.Yellow;
			Console.Write(chipLabel);

			Console.SetCursorPosition(ScreenWidth - CurrentChip.ToString().Length, 5);
			Console.ForegroundColor = ConsoleColor.White;
			Console.Write(CurrentChip);
		}
	}
}
