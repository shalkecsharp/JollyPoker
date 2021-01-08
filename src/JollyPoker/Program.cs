using JollyPoker.Core;
using JollyPoker.Services;
using JollyPoker.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JollyPoker
{
	class Program
	{
		static void Main(string[] args)
		{
			const int width = 70;
			const int height = 20;
			const int chip = 1;
			const int credit = 100;
			
			var game = new Game(width, height, credit, chip);
			while (game.ContinueGame)
			{
				game.Run();
			}
		}
	}
}
