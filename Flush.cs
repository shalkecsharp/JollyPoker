namespace JollyPoker
{
	public class Flush : IWinning
	{
		public string Title => "FLUSH";

		public int Value => 7;

		public WinningTypes Type => WinningTypes.Flush;
	}
}