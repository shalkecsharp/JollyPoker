using JollyPoker.Core;
using JollyPoker.Core.Hand;
using JollyPoker.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace JollyPokerTests
{
	[TestClass]
	public class CardsHandServiceTests
	{
		[TestMethod]
		public void CheckHand_WhenFiveOfKinds()
		{
			// Arrange
			var cards = new List<Card> 
			{
				new Card(2, new Suite(0)),
				new Card(2, new Suite(0)),
				new Card(2, new Suite(0)),
				new Card(2, new Suite(0)),
				new Card(15, new Suite(0)),
			};
			var winService = new HandService();

			// Act
			var result = winService.CheckHand(cards);

			// Assert
			Assert.IsInstanceOfType(result.Result, typeof(FiveOfKind), "Result should be FiveOfKind.");
			Assert.IsTrue(cards.TrueForAll(p => p.Stop), "All cards should be stopped");
		}

		[TestMethod]
		public void CheckHand_WhenFiveOfKinds_AndJollyInTheMiddle()
		{
			// Arrange
			var cards = new List<Card>
			{
				new Card(2, new Suite(0)),
				new Card(2, new Suite(0)),
				new Card(15, new Suite(0)),
				new Card(2, new Suite(0)),
				new Card(2, new Suite(0)),
			};
			var winService = new HandService();

			// Act
			var result = winService.CheckHand(cards);

			// Assert
			Assert.IsInstanceOfType(result.Result, typeof(FiveOfKind), "Result should be FiveOfKind.");
			Assert.IsTrue(cards.TrueForAll(p => p.Stop), "All cards should be stopped");
		}

		[TestMethod]
		public void CheckHand_WhenFiveOfKinds_AndJollyInTheBeginning()
		{
			// Arrange
			var cards = new List<Card>
			{
				new Card(15, new Suite(0)),
				new Card(2, new Suite(0)),
				new Card(2, new Suite(0)),
				new Card(2, new Suite(0)),
				new Card(2, new Suite(0)),
			};
			var winService = new HandService();

			// Act
			var result = winService.CheckHand(cards);

			// Assert
			Assert.IsInstanceOfType(result.Result, typeof(FiveOfKind), "Result should be FiveOfKind.");
			Assert.IsTrue(cards.TrueForAll(p => p.Stop), "All cards should be stopped");
		}		
		
		[TestMethod]
		public void CheckHand_WhenRoyalFlush()
		{
			// Arrange
			var cards = new List<Card>
			{
				new Card(10, new Suite(1)),
				new Card(12, new Suite(1)),
				new Card(13, new Suite(1)),
				new Card(14, new Suite(1)),
				new Card(11, new Suite(1)),
			};
			var winService = new HandService();

			// Act
			var result = winService.CheckHand(cards);

			// Assert
			Assert.IsInstanceOfType(result.Result, typeof(RoyalFlush), "Result should be RoyalFlush.");
			Assert.IsTrue(cards.TrueForAll(p => p.Stop), "All cards should be stopped");
		}

		[TestMethod]
		public void CheckHand_WhenRoyalFlush_WhenAceIsFirst()
		{
			// Arrange
			var cards = new List<Card>
			{
				new Card(11, new Suite(1)),
				new Card(12, new Suite(1)),
				new Card(13, new Suite(1)),
				new Card(14, new Suite(1)),
				new Card(10, new Suite(1)),
			};
			var winService = new HandService();

			// Act
			var result = winService.CheckHand(cards);

			// Assert
			Assert.IsInstanceOfType(result.Result, typeof(RoyalFlush), "Result should be RoyalFlush.");
			Assert.IsTrue(cards.TrueForAll(p => p.Stop), "All cards should be stopped");
		}

		[TestMethod]
		public void CheckHand_RoyalFlush_NotAllSuites_ThenNoRoyalFlush()
		{
			// Arrange
			var cards = new List<Card>
			{
				new Card(10, new Suite(1)),
				new Card(11, new Suite(1)),
				new Card(12, new Suite(1)),
				new Card(13, new Suite(1)),
				new Card(14, new Suite(2)),
			};
			var winService = new HandService();

			// Act
			var result = winService.CheckHand(cards);

			// Assert
			Assert.IsNotInstanceOfType(result.Result, typeof(RoyalFlush), "Result should not be RoyalFlush.");
		}

		[TestMethod]	
		public void CheckHand_StreetFlush_StartsWithThree_ThenStreetFlush()
		{
			// Arrange
			var cards = new List<Card>
			{
				new Card(3, new Suite(1)),
				new Card(4, new Suite(1)),
				new Card(5, new Suite(1)),
				new Card(6, new Suite(1)),
				new Card(7, new Suite(1)),
			};
			var winService = new HandService();

			// Act
			var result = winService.CheckHand(cards);

			// Assert
			Assert.IsInstanceOfType(result.Result, typeof(StreetFlush), "Result should be StreetFlush.");
			Assert.IsTrue(cards.TrueForAll(p => p.Stop), "All cards should be stopped");
		}

		[TestMethod]
		public void CheckHand_StreetFlush_NotInAscendingOrder_ThenStreetFlush()
		{
			// Arrange
			var cards = new List<Card>
			{
				new Card(4, new Suite(1)),
				new Card(3, new Suite(1)),
				new Card(5, new Suite(1)),
				new Card(7, new Suite(1)),
				new Card(6, new Suite(1)),
			};
			var winService = new HandService();

			// Act
			var result = winService.CheckHand(cards);

			// Assert
			Assert.IsInstanceOfType(result.Result, typeof(StreetFlush), "Result should be StreetFlush.");
			Assert.IsTrue(cards.TrueForAll(p => p.Stop), "All cards should be stopped");
		}

		[TestMethod]
		public void CheckHand_StreetFlush_WithAce_ThenStreetFlush()
		{
			// Arrange
			var cards = new List<Card>
			{
				new Card(7, new Suite(1)),
				new Card(8, new Suite(1)),
				new Card(9, new Suite(1)),
				new Card(10, new Suite(1)),
				new Card(11, new Suite(1)),
			};
			var winService = new HandService();

			// Act
			var result = winService.CheckHand(cards);

			// Assert
			Assert.IsInstanceOfType(result.Result, typeof(StreetFlush), "Result should be StreetFlush.");
			Assert.IsTrue(cards.TrueForAll(p => p.Stop), "All cards should be stopped");
		}

		[TestMethod]
		public void CheckHand_StreetFlush_WithAceAsLowerCard_ThenStreetFlush()
		{
			// Arrange
			var cards = new List<Card>
			{
				new Card(11, new Suite(1)),
				new Card(2, new Suite(1)),
				new Card(3, new Suite(1)),
				new Card(4, new Suite(1)),
				new Card(5, new Suite(1)),
			};
			var winService = new HandService();

			// Act
			var result = winService.CheckHand(cards);

			// Assert
			Assert.IsInstanceOfType(result.Result, typeof(StreetFlush), "Result should be StreetFlush.");
			Assert.IsTrue(cards.TrueForAll(p => p.Stop), "All cards should be stopped");
		}

		[TestMethod]
		public void CheckHand_Poker_FirstFour()
		{
			// Arrange
			var cards = new List<Card>
			{
				new Card(3, new Suite(1)),
				new Card(3, new Suite(2)),
				new Card(3, new Suite(1)),
				new Card(3, new Suite(2)),
				new Card(5, new Suite(1)),
			};
			var winService = new HandService();

			// Act
			var result = winService.CheckHand(cards);

			// Assert
			Assert.IsInstanceOfType(result.Result, typeof(Poker), "Result should be Poker.");
			Assert.IsTrue(cards[0].Stop, "Card should be stopped");
			Assert.IsTrue(cards[1].Stop, "Card should be stopped");
			Assert.IsTrue(cards[2].Stop, "Card should be stopped");
			Assert.IsTrue(cards[3].Stop, "Card should be stopped");
		}

		[TestMethod]
		public void CheckHand_Poker_SecondFour()
		{
			// Arrange
			var cards = new List<Card>
			{
				new Card(5, new Suite(1)),
				new Card(3, new Suite(3)),
				new Card(3, new Suite(1)),
				new Card(3, new Suite(3)),
				new Card(3, new Suite(1)),
			};
			var winService = new HandService();

			// Act
			var result = winService.CheckHand(cards);

			// Assert
			Assert.IsInstanceOfType(result.Result, typeof(Poker), "Result should be Poker.");
			Assert.IsTrue(cards[1].Stop, "Card should be stopped");
			Assert.IsTrue(cards[2].Stop, "Card should be stopped");
			Assert.IsTrue(cards[3].Stop, "Card should be stopped");
			Assert.IsTrue(cards[4].Stop, "Card should be stopped");
		}

		[TestMethod]
		public void CheckHand_Poker_MiddleFour()
		{
			// Arrange
			var cards = new List<Card>
			{
				new Card(3, new Suite(1)),
				new Card(3, new Suite(2)),
				new Card(5, new Suite(3)),
				new Card(3, new Suite(1)),
				new Card(3, new Suite(1)),
			};
			var winService = new HandService();

			// Act
			var result = winService.CheckHand(cards);

			// Assert
			Assert.IsInstanceOfType(result.Result, typeof(Poker), "Result should be Poker.");
			Assert.IsTrue(cards[0].Stop, "Card should be stopped");
			Assert.IsTrue(cards[1].Stop, "Card should be stopped");
			Assert.IsTrue(cards[3].Stop, "Card should be stopped");
			Assert.IsTrue(cards[4].Stop, "Card should be stopped");
		}

		[TestMethod]
		public void CheckHand_FullHouse_TwoPlusThree()
		{
			// Arrange
			var cards = new List<Card>
			{
				new Card(3, new Suite(1)),
				new Card(3, new Suite(2)),
				new Card(5, new Suite(3)),
				new Card(5, new Suite(1)),
				new Card(5, new Suite(1)),
			};
			var winService = new HandService();

			// Act
			var result = winService.CheckHand(cards);

			// Assert
			Assert.IsInstanceOfType(result.Result, typeof(FullHouse), "Result should be FullHouse.");
			Assert.IsTrue(cards.TrueForAll(p => p.Stop), "All cards should be stopped");
		}

		[TestMethod]
		public void CheckHand_FullHouse_ThreePlusTwo()
		{
			// Arrange
			var cards = new List<Card>
			{
				new Card(3, new Suite(1)),
				new Card(3, new Suite(2)),
				new Card(3, new Suite(3)),
				new Card(5, new Suite(1)),
				new Card(5, new Suite(1)),
			};
			var winService = new HandService();

			// Act
			var result = winService.CheckHand(cards);

			// Assert
			Assert.IsInstanceOfType(result.Result, typeof(FullHouse), "Result should be FullHouse.");
			Assert.IsTrue(cards.TrueForAll(p => p.Stop), "All cards should be stopped");
		}

		[TestMethod]
		public void CheckHand_Flush()
		{
			// Arrange
			var cards = new List<Card>
			{
				new Card(1, new Suite(1)),
				new Card(3, new Suite(1)),
				new Card(3, new Suite(1)),
				new Card(4, new Suite(1)),
				new Card(5, new Suite(1)),
			};
			var winService = new HandService();

			// Act
			var result = winService.CheckHand(cards);

			// Assert
			Assert.IsInstanceOfType(result.Result, typeof(Flush), "Result should be Flush.");
			Assert.IsTrue(cards.TrueForAll(p => p.Stop), "All cards should be stopped");
		}

		[TestMethod]
		public void CheckHand_Street_Ordered()
		{
			// Arrange
			var cards = new List<Card>
			{
				new Card(2, new Suite(2)),
				new Card(3, new Suite(1)),
				new Card(4, new Suite(1)),
				new Card(5, new Suite(1)),
				new Card(6, new Suite(1)),
			};
			var winService = new HandService();

			// Act
			var result = winService.CheckHand(cards);

			// Assert
			Assert.IsInstanceOfType(result.Result, typeof(Street), "Result should be Street.");
			Assert.IsTrue(cards.TrueForAll(p => p.Stop), "All cards should be stopped");
		}

		[TestMethod]
		public void CheckHand_Street_NotOrdered()
		{
			// Arrange
			var cards = new List<Card>
			{
				new Card(3, new Suite(2)),
				new Card(2, new Suite(1)),
				new Card(5, new Suite(1)),
				new Card(4, new Suite(1)),
				new Card(6, new Suite(1)),
			};
			var winService = new HandService();

			// Act
			var result = winService.CheckHand(cards);

			// Assert
			Assert.IsInstanceOfType(result.Result, typeof(Street), "Result should be Street.");
			Assert.IsTrue(cards.TrueForAll(p => p.Stop), "All cards should be stopped");
		}

		[TestMethod]
		public void CheckHand_ThreeOfKind_FirstThree()
		{
			// Arrange
			var cards = new List<Card>
			{
				new Card(3, new Suite(1)),
				new Card(3, new Suite(2)),
				new Card(3, new Suite(3)),
				new Card(4, new Suite(1)),
				new Card(5, new Suite(1)),
			};
			var winService = new HandService();

			// Act
			var result = winService.CheckHand(cards);

			// Assert
			Assert.IsInstanceOfType(result.Result, typeof(ThreeOfKind), "Result should be ThreeOfKind.");
			Assert.IsTrue(cards[0].Stop, "Card should be stopped");
			Assert.IsTrue(cards[1].Stop, "Card should be stopped");
			Assert.IsTrue(cards[2].Stop, "Card should be stopped");
		}

		[TestMethod]
		public void CheckHand_ThreeOfKind_MidThree()
		{
			// Arrange
			var cards = new List<Card>
			{
				new Card(2, new Suite(1)),
				new Card(3, new Suite(2)),
				new Card(3, new Suite(3)),
				new Card(3, new Suite(1)),
				new Card(5, new Suite(1)),
			};
			var winService = new HandService();

			// Act
			var result = winService.CheckHand(cards);

			// Assert
			Assert.IsInstanceOfType(result.Result, typeof(ThreeOfKind), "Result should be ThreeOfKind.");
			Assert.IsTrue(cards[1].Stop, "Card should be stopped");
			Assert.IsTrue(cards[2].Stop, "Card should be stopped");
			Assert.IsTrue(cards[3].Stop, "Card should be stopped");
		}

		[TestMethod]
		public void CheckHand_ThreeOfKind_LastThree()
		{
			// Arrange
			var cards = new List<Card>
			{
				new Card(2, new Suite(1)),
				new Card(3, new Suite(2)),
				new Card(4, new Suite(3)),
				new Card(4, new Suite(1)),
				new Card(4, new Suite(1)),
			};
			var winService = new HandService();

			// Act
			var result = winService.CheckHand(cards);

			// Assert
			Assert.IsInstanceOfType(result.Result, typeof(ThreeOfKind), "Result should be ThreeOfKind.");
			Assert.IsTrue(cards[2].Stop, "Card should be stopped");
			Assert.IsTrue(cards[3].Stop, "Card should be stopped");
			Assert.IsTrue(cards[4].Stop, "Card should be stopped");
		}

		[TestMethod]
		public void CheckHand_ThreeOfKind_RandomThree()
		{
			// Arrange
			var cards = new List<Card>
			{
				new Card(4, new Suite(1)),
				new Card(3, new Suite(2)),
				new Card(4, new Suite(3)),
				new Card(2, new Suite(1)),
				new Card(4, new Suite(1)),
			};
			var winService = new HandService();

			// Act
			var result = winService.CheckHand(cards);

			// Assert
			Assert.IsInstanceOfType(result.Result, typeof(ThreeOfKind), "Result should be ThreeOfKind.");
			Assert.IsTrue(cards[0].Stop, "Card should be stopped");
			Assert.IsTrue(cards[2].Stop, "Card should be stopped");
			Assert.IsTrue(cards[4].Stop, "Card should be stopped");
		}

		[TestMethod]
		public void CheckHand_TwoPairs_FirstSet()
		{
			// Arrange
			var cards = new List<Card>
			{
				new Card(3, new Suite(1)),
				new Card(3, new Suite(2)),
				new Card(4, new Suite(3)),
				new Card(4, new Suite(1)),
				new Card(6, new Suite(1)),
			};
			var winService = new HandService();

			// Act
			var result = winService.CheckHand(cards);

			// Assert
			Assert.IsInstanceOfType(result.Result, typeof(TwoPairs), "Result should be TwoPairs.");
			Assert.IsTrue(cards[0].Stop, "Card should be stopped");
			Assert.IsTrue(cards[1].Stop, "Card should be stopped");
			Assert.IsTrue(cards[2].Stop, "Card should be stopped");
			Assert.IsTrue(cards[3].Stop, "Card should be stopped");
		}

		[TestMethod]
		public void CheckHand_TwoPairs_SecondSet()
		{
			// Arrange
			var cards = new List<Card>
			{
				new Card(3, new Suite(1)),
				new Card(3, new Suite(2)),
				new Card(4, new Suite(3)),
				new Card(5, new Suite(1)),
				new Card(5, new Suite(1)),
			};
			var winService = new HandService();

			// Act
			var result = winService.CheckHand(cards);

			// Assert
			Assert.IsInstanceOfType(result.Result, typeof(TwoPairs), "Result should be TwoPairs.");
			Assert.IsTrue(cards[0].Stop, "Card should be stopped");
			Assert.IsTrue(cards[1].Stop, "Card should be stopped");
			Assert.IsTrue(cards[3].Stop, "Card should be stopped");
			Assert.IsTrue(cards[4].Stop, "Card should be stopped");
		}

		[TestMethod]
		public void CheckHand_TwoPairs_ThirdSet()
		{
			// Arrange
			var cards = new List<Card>
			{
				new Card(3, new Suite(1)),
				new Card(4, new Suite(2)),
				new Card(4, new Suite(3)),
				new Card(5, new Suite(1)),
				new Card(5, new Suite(1)),
			};
			var winService = new HandService();

			// Act
			var result = winService.CheckHand(cards);

			// Assert
			Assert.IsInstanceOfType(result.Result, typeof(TwoPairs), "Result should be TwoPairs.");
			Assert.IsTrue(cards[1].Stop, "Card should be stopped");
			Assert.IsTrue(cards[2].Stop, "Card should be stopped");
			Assert.IsTrue(cards[3].Stop, "Card should be stopped");
			Assert.IsTrue(cards[4].Stop, "Card should be stopped");
		}

		[TestMethod]
		public void CheckHand_HighPair_FirstSet()
		{
			// Arrange
			var cards = new List<Card>
			{
				new Card(10, new Suite(1)),
				new Card(10, new Suite(2)),
				new Card(11, new Suite(3)),
				new Card(12, new Suite(1)),
				new Card(13, new Suite(1)),
			};
			var winService = new HandService();

			// Act
			var result = winService.CheckHand(cards);

			// Assert
			Assert.IsInstanceOfType(result.Result, typeof(HighPair), "Result should be HighPair.");
			Assert.IsTrue(cards[0].Stop, "Card should be stopped");
			Assert.IsTrue(cards[1].Stop, "Card should be stopped");
		}

		[TestMethod]
		public void CheckHand_HighPair_SecondSet()
		{
			// Arrange
			var cards = new List<Card>
			{
				new Card(9, new Suite(1)),
				new Card(10, new Suite(2)),
				new Card(10, new Suite(3)),
				new Card(12, new Suite(1)),
				new Card(13, new Suite(1)),
			};
			var winService = new HandService();

			// Act
			var result = winService.CheckHand(cards);

			// Assert
			Assert.IsInstanceOfType(result.Result, typeof(HighPair), "Result should be HighPair.");
			Assert.IsTrue(cards[1].Stop, "Card should be stopped");
			Assert.IsTrue(cards[2].Stop, "Card should be stopped");
		}

		[TestMethod]
		public void CheckHand_HighPair_ThirdSet()
		{
			// Arrange
			var cards = new List<Card>
			{
				new Card(8, new Suite(1)),
				new Card(9, new Suite(2)),
				new Card(10, new Suite(3)),
				new Card(10, new Suite(1)),
				new Card(13, new Suite(1)),
			};
			var winService = new HandService();

			// Act
			var result = winService.CheckHand(cards);

			// Assert
			Assert.IsInstanceOfType(result.Result, typeof(HighPair), "Result should be HighPair.");
			Assert.IsTrue(cards[2].Stop, "Card should be stopped");
			Assert.IsTrue(cards[3].Stop, "Card should be stopped");
		}

		[TestMethod]
		public void CheckHand_HighPair_FourthSet()
		{
			// Arrange
			var cards = new List<Card>
			{
				new Card(7, new Suite(1)),
				new Card(8, new Suite(2)),
				new Card(9, new Suite(3)),
				new Card(10, new Suite(1)),
				new Card(10, new Suite(1)),
			};
			var winService = new HandService();

			// Act
			var result = winService.CheckHand(cards);

			// Assert
			Assert.IsInstanceOfType(result.Result, typeof(HighPair), "Result should be HighPair.");
			Assert.IsTrue(cards[3].Stop, "Card should be stopped");
			Assert.IsTrue(cards[4].Stop, "Card should be stopped");
		}

		[TestMethod]
		public void CheckHand_HighPair_RandomSet()
		{
			// Arrange
			var cards = new List<Card>
			{
				new Card(10, new Suite(1)),
				new Card(8, new Suite(2)),
				new Card(9, new Suite(3)),
				new Card(13, new Suite(1)),
				new Card(10, new Suite(1)),
			};
			var winService = new HandService();

			// Act
			var result = winService.CheckHand(cards);

			// Assert
			Assert.IsInstanceOfType(result.Result, typeof(HighPair), "Result should be HighPair.");
			Assert.IsTrue(cards[0].Stop, "Card should be stopped");
			Assert.IsTrue(cards[4].Stop, "Card should be stopped");
		}

	}
}
