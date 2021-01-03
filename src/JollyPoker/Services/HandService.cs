using JollyPoker.Core;
using JollyPoker.Services.HandCheck;
using System.Collections.Generic;
using System.Linq;

namespace JollyPoker.Services
{
	public class HandService
	{
		private readonly List<IHandCheck> _handCheckServices;

		public HandService()
		{
			_handCheckServices = new List<IHandCheck>
			{
				new FiveOfKindHandCheck(),
				new RoyalFlushHandCheck(),
				new RoyalFlushJokerHandCheck(),
				new StreetFlushHandCheck(),
				new StreetFlushJokerHandCheck(),
				new PokerFirstSetHandCheck(),
				new PokerFirstSetJokerHandCheck(),
				new PokerSecondSetHandCheck(),
				new PokerSecondSetJokerHandCheck(),
				new FullHouseFirstSetHandCheck(),
				new FullHouseSecondSetHandCheck(),
				new FullHouseJokerHandCheck(),
				new FlushHandCheck(),
				new FlushJokerHandCheck(),
				new StreetHandCheck(),
				new ThreeOfKindFirstSetHandCheck(),
				new ThreeOfKindFirstSetJokerHandCheck(),
				new ThreeOfKindSecondSetHandCheck(),
				new ThreeOfKindSecondSetJokerHandCheck(),
				new ThreeOfKindThirdSetHandCheck(),
				new ThreeOfKindThirdSetJokerHandCheck(),
				new ThreeOfKindFirstSetJokerHandCheck(),
				new TwoPairsFirstSetHandCheck(),
				new TwoPairsFirstSetJokerHandCheck(),
				new TwoPairsSecondSetHandCheck(),
				new TwoPairsSecondSetJokerHandCheck(),
				new TwoPairsThirdSetHandCheck(),
				new TwoPairsThirdSetJokerHandCheck(),
				new HighPairFirstSetHandCheck(),
				new HighPairFirstSetJokerHandCheck(),
				new HighPairSecondSetHandCheck(),
				new HighPairSecondSetJokerHandCheck(),
				new HighPairThirdSetHandCheck(),
				new HighPairThirdSetJokerHandCheck(),
				new HighPairFourthSetHandCheck(),
				new HighPairFourthSetJokerHandCheck()
			};
		}

		public HandResult CheckHand(List<Card> cards)
		{
			var sortedCards = cards.OrderBy(p => p.Value).ToList();
			var c1 = sortedCards[0];
			var c2 = sortedCards[1];
			var c3 = sortedCards[2];
			var c4 = sortedCards[3];
			var c5 = sortedCards[4];

			foreach (var handCheckService in _handCheckServices)
			{
				var result = handCheckService.CheckHand(c1, c2, c3, c4, c5);
				if (result != null) return result;
			}

			return null;
		}
	}
}