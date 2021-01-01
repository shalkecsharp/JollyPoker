namespace JollyPoker
{
	public class StreetFlush : IWinning
	{
		public string Title => "STREET FLUSH";

		public int Value => 100;

		public WinningTypes Type => WinningTypes.StreetFlush;
	}
}