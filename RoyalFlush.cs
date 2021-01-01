namespace JollyPoker
{
	public class RoyalFlush : IWinning
	{
		public string Title => "ROYAL FLUSH";

		public int Value => 500;

		public WinningTypes Type => WinningTypes.RoyalFlush;
	}
}