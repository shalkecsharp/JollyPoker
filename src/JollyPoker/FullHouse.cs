namespace JollyPoker
{
	public class FullHouse : IWinning
	{
		public string Title => "FULL HOUSE";

		public int Value => 10;

		public WinningTypes Type => WinningTypes.FullHouse;
	}
}