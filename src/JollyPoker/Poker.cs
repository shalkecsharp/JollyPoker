namespace JollyPoker
{
	public class Poker : IWinning
	{
		public string Title => "POKER";

		public int Value => 40;

		public WinningTypes Type => WinningTypes.Poker;
	}
}