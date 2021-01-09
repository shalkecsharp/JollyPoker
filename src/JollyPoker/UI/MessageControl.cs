using System;

namespace JollyPoker.UI
{
	public class MessageControl : IControl
	{
		public void Draw()
		{
			Console.SetCursorPosition(0, 20);
			Console.ForegroundColor = ConsoleColor.Red;
			Console.BackgroundColor = ConsoleColor.Black;
			Console.Write("Use UP/DOWN to change chip. Press ENTER to deal cards.");
		}
	}
}
