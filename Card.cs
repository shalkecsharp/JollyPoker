namespace JollyPoker
{
	public class Card
	{
		public Card(int value, Suite sign)
		{
			Value = value;
			Suite = sign;
		}

		public int Value { get; set; }
		
		public Suite Suite { get; set; }

		public override string ToString()
		{
			return $"{Value} {Suite}";
		}


	}

}
