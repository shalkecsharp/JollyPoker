using JollyPoker.Core;
using JollyPoker.Core.Hand;
using JollyPoker.Services.HandCheck;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace JollyPokerTests.Services.HandCheck
{
	[TestClass]
	public class RoyalFlushJokerHandCheckTests
	{
		[TestMethod]
		public void CheckHand_WithJokerFirst()
		{
			// Arrange
			var c1 = new Card(11, new Suite(1));
			var c2 = new Card(12, new Suite(1));
			var c3 = new Card(13, new Suite(1));
			var c4 = new Card(14, new Suite(1));
			var c5 = new Card(15, new Suite(1));
			var service = new RoyalFlushJokerHandCheck();

			// Act
			var handResult = service.CheckHand(c1, c2, c3, c4, c5);

			// Assert
			Assert.IsInstanceOfType(handResult.Result, typeof(RoyalFlush), "Result should be RoyalFlush");
		}

		[TestMethod]
		public void CheckHand_WithJokerSecond()
		{
			// Arrange
			var c1 = new Card(10, new Suite(1));
			var c2 = new Card(12, new Suite(1));
			var c3 = new Card(13, new Suite(1));
			var c4 = new Card(14, new Suite(1));
			var c5 = new Card(15, new Suite(1));
			var service = new RoyalFlushJokerHandCheck();

			// Act
			var handResult = service.CheckHand(c1, c2, c3, c4, c5);

			// Assert
			Assert.IsInstanceOfType(handResult.Result, typeof(RoyalFlush), "Result should be RoyalFlush");
		}

		[TestMethod]
		public void CheckHand_WithJokerThird()
		{
			// Arrange
			var c1 = new Card(10, new Suite(1));
			var c2 = new Card(11, new Suite(1));
			var c3 = new Card(13, new Suite(1));
			var c4 = new Card(14, new Suite(1));
			var c5 = new Card(15, new Suite(1));
			var service = new RoyalFlushJokerHandCheck();

			// Act
			var handResult = service.CheckHand(c1, c2, c3, c4, c5);

			// Assert
			Assert.IsInstanceOfType(handResult.Result, typeof(RoyalFlush), "Result should be RoyalFlush");
		}

		[TestMethod]
		public void CheckHand_WithJokerFourth()
		{
			// Arrange
			var c1 = new Card(10, new Suite(1));
			var c2 = new Card(11, new Suite(1));
			var c3 = new Card(12, new Suite(1));
			var c4 = new Card(14, new Suite(1));
			var c5 = new Card(15, new Suite(1));
			var service = new RoyalFlushJokerHandCheck();

			// Act
			var handResult = service.CheckHand(c1, c2, c3, c4, c5);

			// Assert
			Assert.IsInstanceOfType(handResult.Result, typeof(RoyalFlush), "Result should be RoyalFlush");
		}

		[TestMethod]
		public void CheckHand_WithJokerFifth()
		{
			// Arrange
			var c1 = new Card(10, new Suite(1));
			var c2 = new Card(11, new Suite(1));
			var c3 = new Card(12, new Suite(1));
			var c4 = new Card(13, new Suite(1));
			var c5 = new Card(15, new Suite(1));
			var service = new RoyalFlushJokerHandCheck();

			// Act
			var handResult = service.CheckHand(c1, c2, c3, c4, c5);

			// Assert
			Assert.IsInstanceOfType(handResult.Result, typeof(RoyalFlush), "Result should be RoyalFlush");
		}

		[TestMethod]
		public void CheckHand_WithJoker_NotRoyalFlush_ReturnsNull()
		{
			// Arrange
			var c1 = new Card(9, new Suite(1));
			var c2 = new Card(11, new Suite(1));
			var c3 = new Card(12, new Suite(1));
			var c4 = new Card(13, new Suite(1));
			var c5 = new Card(15, new Suite(1));
			var service = new RoyalFlushJokerHandCheck();

			// Act
			var handResult = service.CheckHand(c1, c2, c3, c4, c5);

			// Assert
			Assert.IsNull(handResult, "Result should not be RoyalFlush");
		}

		[TestMethod]
		public void CheckHand_WithJokerFifth_NotAllSuites_ReturnsNull()
		{
			// Arrange
			var c1 = new Card(10, new Suite(1));
			var c2 = new Card(11, new Suite(2));
			var c3 = new Card(12, new Suite(1));
			var c4 = new Card(13, new Suite(1));
			var c5 = new Card(15, new Suite(1));
			var service = new RoyalFlushJokerHandCheck();

			// Act
			var handResult = service.CheckHand(c1, c2, c3, c4, c5);

			// Assert
			Assert.IsNull(handResult, "Result should not be RoyalFlush");
		}
	}
}
