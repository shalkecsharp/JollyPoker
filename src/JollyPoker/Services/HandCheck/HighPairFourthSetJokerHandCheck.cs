﻿using JollyPoker.Core;
using JollyPoker.Core.Hand;

namespace JollyPoker.Services.HandCheck
{
	public class HighPairFourthSetJokerHandCheck : IHandCheck
	{
		public HandResult CheckHand(Card c1, Card c2, Card c3, Card c4, Card c5)
		{
			if (c4.Value >= 10 && c5.Value == 15)
			{
				c4.Stop = true;
				c5.Stop = true;
				return new HandResult(new HighPair());
			}
			return null;
		}
	}
}