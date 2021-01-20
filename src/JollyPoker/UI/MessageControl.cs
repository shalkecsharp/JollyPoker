using System;

namespace JollyPoker.UI
{
	public class MessageControl : IControl
	{
		private string _title = "";
		private readonly int _screenWidth;
		
		
		public MessageControl(int screenWidth)
		{
			_screenWidth = screenWidth;
		}

		public string Title
		{
			get
			{
				return _title;
			}
			set
			{
				_title = value;
				Draw();
			}
		}

		public void Draw()
		{
			Console.SetCursorPosition(0, 20);
			Console.ForegroundColor = ConsoleColor.Red;
			Console.BackgroundColor = ConsoleColor.Black;
			Console.Write(Title.PadRight(_screenWidth-1));
		}
	}
}
