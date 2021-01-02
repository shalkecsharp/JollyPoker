namespace JollyPoker
{
	public class FiveOfKind : IWinning
	{
		public string Title => "FIVE OF A KIND";

		public int Value => 1100;

		public WinningTypes Type => WinningTypes.FiveOfKind;
	}
}