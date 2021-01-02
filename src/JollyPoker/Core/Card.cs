namespace JollyPoker.Core
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

		public bool Stop { get; set; }

		public string DisplayValue
		{
			get
			{
				if (Value > 1 && Value < 11)
				{
					return Value.ToString();
				}
				else
				{
					switch (Value)
					{
						case 11:
							return "A";
						case 12:
							return "J";
						case 13:
							return "D";
						case 14:
							return "K";
						case 15:
							return "@";
						default:
							throw new System.ArgumentOutOfRangeException("Value is not allowed.");
					}
				}
			}
		}

		public override string ToString()
		{
			return $"{DisplayValue}{Suite}";
		}


	}

}
