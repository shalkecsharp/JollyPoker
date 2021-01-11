using System;

namespace JollyPoker.Core
{
	public class EmptyCard : Card
	{
		public EmptyCard() : base(0, new Suite(0))
		{
			
		}

		public override void Draw(int currentLeft, int currentTop)
		{
			Console.BackgroundColor = ConsoleColor.White;
			Console.ForegroundColor = Suite.Color;
			for (int i = 0; i < 7; i++)
			{
				Console.SetCursorPosition(currentLeft, currentTop + i);
				Console.Write("▒▒▒▒▒▒▒▒▒▒");
			}
		}
	}

}
