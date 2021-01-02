namespace JollyPoker
{
	public class TwoPairs : IWinning
	{
		public string Title => "TWO PAIRS";

		public int Value => 2;

		public WinningTypes Type => WinningTypes.TwoPairs;
	}
}