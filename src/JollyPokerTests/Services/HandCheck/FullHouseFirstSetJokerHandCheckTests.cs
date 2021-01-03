using JollyPoker.Core;
using JollyPoker.Core.Hand;
using JollyPoker.Services.HandCheck;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace JollyPokerTests.Services.HandCheck
{
	[TestClass]
	public class FullHouseFirstSetJokerHandCheckTests
	{
		[TestMethod]
		public void CheckHand_WithThreeSame()
		{
			// Arrange
			var c1 = new Card(2, new Suite(1));
			var c2 = new Card(3, new Suite(1));
			var c3 = new Card(3, new Suite(1));
			var c4 = new Card(3, new Suite(1));
			var c5 = new Card(15, new Suite(1));
			var service = new FullHouseJokerHandCheck();

			// Act
			var handResult = service.CheckHand(c1, c2, c3, c4, c5);

			// Assert
			Assert.IsInstanceOfType(handResult.Result, typeof(FullHouse), "Result should be FullHouse");
		}

		[TestMethod]
		public void CheckHand_WithTwoSame()
		{
			// Arrange
			var c1 = new Card(2, new Suite(1));
			var c2 = new Card(2, new Suite(1));
			var c3 = new Card(3, new Suite(1));
			var c4 = new Card(3, new Suite(1));
			var c5 = new Card(15, new Suite(1));
			var service = new FullHouseJokerHandCheck();

			// Act
			var handResult = service.CheckHand(c1, c2, c3, c4, c5);

			// Assert
			Assert.IsInstanceOfType(handResult.Result, typeof(FullHouse), "Result should be FullHouse");
		}

		[TestMethod]
		public void CheckHand_WithThreeLowerSame()
		{
			// Arrange
			var c1 = new Card(2, new Suite(1));
			var c2 = new Card(2, new Suite(1));
			var c3 = new Card(2, new Suite(1));
			var c4 = new Card(3, new Suite(1));
			var c5 = new Card(15, new Suite(1));
			var service = new FullHouseJokerHandCheck();

			// Act
			var handResult = service.CheckHand(c1, c2, c3, c4, c5);

			// Assert
			Assert.IsInstanceOfType(handResult.Result, typeof(FullHouse), "Result should be FullHouse");
		}
	}
}
