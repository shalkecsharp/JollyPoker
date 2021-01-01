namespace JollyPoker
{
	public interface IWinning
	{
		public string Title { get; }
		public int Value { get; }
		public WinningTypes Type { get; }
	}
}