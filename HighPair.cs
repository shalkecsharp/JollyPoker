namespace JollyPoker
{
	public class HighPair : IWinning
	{
		public string Title => "HIGH PAIR";

		public int Value => 1;

		public WinningTypes Type => WinningTypes.HighPair;
	}
}