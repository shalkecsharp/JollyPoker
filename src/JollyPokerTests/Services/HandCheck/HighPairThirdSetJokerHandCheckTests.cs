﻿using JollyPoker.Core;
using JollyPoker.Core.Hand;
using JollyPoker.Services.HandCheck;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace JollyPokerTests.Services.HandCheck
{
	[TestClass]
	public class HighPairThirdSetJokerHandCheckTests
	{
		[TestMethod]
		public void CheckHand()
		{
			// Arrange
			var c1 = new Card(2, new Suite(1));
			var c2 = new Card(3, new Suite(1));
			var c3 = new Card(10, new Suite(1));
			var c4 = new Card(12, new Suite(1));
			var c5 = new Card(15, new Suite(0));
			var service = new HighPairThirdSetJokerHandCheck();

			// Act
			var handResult = service.CheckHand(c1, c2, c3, c4, c5);

			// Assert
			Assert.IsInstanceOfType(handResult.Result, typeof(HighPair), "Result should be HighPair");
			Assert.IsTrue(c3.Stop, "Card should be stopped");
			Assert.IsTrue(c5.Stop, "Card should be stopped");
		}
	}
}
