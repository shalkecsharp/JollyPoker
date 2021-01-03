using JollyPoker.Core;
using JollyPoker.Core.Hand;
using JollyPoker.Services.HandCheck;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace JollyPokerTests.Services.HandCheck
{
	[TestClass]
	public class FlushJokerHandCheckTests
	{
		[TestMethod]
		public void CheckHand()
		{
			// Arrange
			var c1 = new Card(2, new Suite(1));
			var c2 = new Card(5, new Suite(1));
			var c3 = new Card(7, new Suite(1));
			var c4 = new Card(8, new Suite(1));
			var c5 = new Card(15, new Suite(0));
			var service = new FlushJokerHandCheck();

			// Act
			var handResult = service.CheckHand(c1, c2, c3, c4, c5);

			// Assert
			Assert.IsInstanceOfType(handResult.Result, typeof(Flush), "Result should be Flush");

		}

		[TestMethod]
		public void CheckHand_NotAllSuitesSame_ReturnNull()
		{
			// Arrange
			var c1 = new Card(2, new Suite(1));
			var c2 = new Card(5, new Suite(1));
			var c3 = new Card(7, new Suite(2));
			var c4 = new Card(8, new Suite(1));
			var c5 = new Card(15, new Suite(0));
			var service = new FlushJokerHandCheck();

			// Act
			var handResult = service.CheckHand(c1, c2, c3, c4, c5);

			// Assert
			Assert.IsNull(handResult, "Result should be null");

		}

	}
}
