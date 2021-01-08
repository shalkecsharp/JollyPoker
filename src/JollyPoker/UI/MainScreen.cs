using System.Collections.Generic;

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
		}

		public int ScreenWidth { get; }
		public int ScreenHeight { get; }
		public int CurrentCredit { get; }
		public int CurrentChip { get; }

		public void Draw()
		{
			foreach (var control in _controls)
			{
				control.Draw();
			}
		}

	}
}
