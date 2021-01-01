namespace JollyPoker
{
	public class ThreeOfKind : IWinning
	{
		public string Title => "THREE OF A KIND";

		public int Value => 3;

		public WinningTypes Type => WinningTypes.ThreeOfKind;
	}
}