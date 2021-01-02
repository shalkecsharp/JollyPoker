namespace JollyPoker
{
	public class Street : IWinning
	{
		public string Title => "STREET";

		public int Value => 5;

		public WinningTypes Type => WinningTypes.Street;
	}
}