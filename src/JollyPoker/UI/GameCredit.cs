namespace JollyPoker.UI
{
	public class GameCredit
	{
		public GameCredit(int credit, int chip)
		{
			Credit = credit;
			Chip = chip;
		}

		public int Credit { get; set; }
		public int Chip { get; set; }
	}
}
