namespace JollyPoker
{
	public class CardsHandResult
	{
		public CardsHandResult(IWinning winningResult)
		{
			WinningResult = winningResult;
		}

		public IWinning WinningResult { get; set; }
	}
}