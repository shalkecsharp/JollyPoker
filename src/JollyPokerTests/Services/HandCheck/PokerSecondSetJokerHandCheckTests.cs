using JollyPoker.Core;
using JollyPoker.Core.Hand;
using JollyPoker.Services.HandCheck;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace JollyPokerTests.Services.HandCheck
{
	[TestClass]
	public class PokerSecondSetJokerHandCheckTests
	{
		[TestMethod]
		public void CheckHand_LowCards()
		{
			// Arrange
			var c1 = new Card(2, new Suite(1));
			var c2 = new Card(3, new Suite(1));
			var c3 = new Card(3, new Suite(1));
			var c4 = new Card(3, new Suite(1));
			var c5 = new Card(15, new Suite(1));
			var service = new PokerSecondSetJokerHandCheck();

			// Act
			var handResult = service.CheckHand(c1, c2, c3, c4, c5);

			// Assert
			Assert.IsInstanceOfType(handResult.Result, typeof(Poker), "Result should be Poker");
			Assert.IsTrue(c2.Stop, "Card should be stopped");
			Assert.IsTrue(c3.Stop, "Card should be stopped");
			Assert.IsTrue(c4.Stop, "Card should be stopped");
			Assert.IsTrue(c5.Stop, "Card should be stopped");
		}

		[TestMethod]
		public void CheckHand_HighCards()
		{
			// Arrange
			var c1 = new Card(2, new Suite(1));
			var c2 = new Card(11, new Suite(1));
			var c3 = new Card(11, new Suite(1));
			var c4 = new Card(11, new Suite(1));
			var c5 = new Card(15, new Suite(1));
			var service = new PokerSecondSetJokerHandCheck();

			// Act
			var handResult = service.CheckHand(c1, c2, c3, c4, c5);

			// Assert
			Assert.IsInstanceOfType(handResult.Result, typeof(Poker), "Result should be Poker");
			Assert.IsTrue(c2.Stop, "Card should be stopped");
			Assert.IsTrue(c3.Stop, "Card should be stopped");
			Assert.IsTrue(c4.Stop, "Card should be stopped");
			Assert.IsTrue(c5.Stop, "Card should be stopped");
		}
	}
}
