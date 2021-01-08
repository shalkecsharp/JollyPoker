using JollyPoker.Core.Hand;
using System;
using System.Collections.Generic;

namespace JollyPoker.UI
{
	public class BoardControl : IControl
	{
		public void Draw()
		{
			var boards = GetHands();
			Console.SetCursorPosition(0, 0);
			foreach (var boardItem in boards)
			{
				Console.ForegroundColor = boardItem.Color;
				Console.Write(boardItem.Title);
				Console.SetCursorPosition(30, Console.CursorTop);
				Console.Write(boardItem.Value);
				Console.WriteLine();
			}
		}

		private List<IHand> GetHands()
		{
			return new List<IHand>
			{
				new FiveOfKind(),
				new RoyalFlush(),
				new StreetFlush(),
				new Poker(),
				new FullHouse(),
				new Flush(),
				new Street(),
				new ThreeOfKind(),
				new TwoPairs(),
				new HighPair()
			};
		}
	}

}
