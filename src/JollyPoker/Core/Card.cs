namespace JollyPoker.Core
{
	public class Card
	{
		public Card(int value, Suite sign)
		{
			Value = value;
			Suite = sign;
			Width = 12;
			Height = 9;
		}

		public int Value { get; set; }

		public Suite Suite { get; set; }

		public int Width { get; }

		public int Height { get; }

		public bool Stop { get; set; }
	}
}
