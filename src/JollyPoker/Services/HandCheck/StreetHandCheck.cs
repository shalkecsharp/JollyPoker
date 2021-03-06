﻿using JollyPoker.Core;
using JollyPoker.Core.Hand;

namespace JollyPoker.Services.HandCheck
{
	public class StreetHandCheck : HandCheckBase
	{
		public override HandResult CheckHand(Card c1, Card c2, Card c3, Card c4, Card c5)
		{
			if (IsStreet(c1, c2, c3, c4, c5) || IsStreetWithJoker(c1, c2, c3, c4, c5))
			{
				c1.Stop = true;
				c2.Stop = true;
				c3.Stop = true;
				c4.Stop = true;
				c5.Stop = true;
				return new HandResult(new Street());
			}
			return null;
		}
	}
}