﻿using JollyPoker.Core;
using JollyPoker.Core.Hand;
using JollyPoker.Services.HandCheck;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace JollyPokerTests.Services.HandCheck
{
	[TestClass]
	public class StreetFlushJokerHandCheckTests
	{
		[TestMethod]
		public void CheckHand_JokerFirstOrLast()
		{
			// Arrange
			var c1 = new Card(2, new Suite(1));
			var c2 = new Card(3, new Suite(1));
			var c3 = new Card(4, new Suite(1));
			var c4 = new Card(5, new Suite(1));
			var c5 = new Card(15, new Suite(1));

			var service = new StreetFlushJokerHandCheck();

			// Act
			var handResult = service.CheckHand(c1, c2, c3, c4, c5);

			// Assert
			Assert.IsInstanceOfType(handResult.Result, typeof(StreetFlush), "Result should be StreetFlush");
		}

		[TestMethod]
		public void CheckHand_JokerSecond()
		{
			// Arrange
			var c1 = new Card(2, new Suite(1));
			var c2 = new Card(4, new Suite(1));
			var c3 = new Card(5, new Suite(1));
			var c4 = new Card(6, new Suite(1));
			var c5 = new Card(15, new Suite(1));

			var service = new StreetFlushJokerHandCheck();

			// Act
			var handResult = service.CheckHand(c1, c2, c3, c4, c5);

			// Assert
			Assert.IsInstanceOfType(handResult.Result, typeof(StreetFlush), "Result should be StreetFlush");
		}

		[TestMethod]
		public void CheckHand_JokerThird()
		{
			// Arrange
			var c1 = new Card(2, new Suite(1));
			var c2 = new Card(3, new Suite(1));
			var c3 = new Card(5, new Suite(1));
			var c4 = new Card(6, new Suite(1));
			var c5 = new Card(15, new Suite(1));

			var service = new StreetFlushJokerHandCheck();

			// Act
			var handResult = service.CheckHand(c1, c2, c3, c4, c5);

			// Assert
			Assert.IsInstanceOfType(handResult.Result, typeof(StreetFlush), "Result should be StreetFlush");
		}

		[TestMethod]
		public void CheckHand_JokerFourth()
		{
			// Arrange
			var c1 = new Card(2, new Suite(1));
			var c2 = new Card(3, new Suite(1));
			var c3 = new Card(4, new Suite(1));
			var c4 = new Card(6, new Suite(1));
			var c5 = new Card(15, new Suite(1));

			var service = new StreetFlushJokerHandCheck();

			// Act
			var handResult = service.CheckHand(c1, c2, c3, c4, c5);

			// Assert
			Assert.IsInstanceOfType(handResult.Result, typeof(StreetFlush), "Result should be StreetFlush");
		}

		[TestMethod]
		public void CheckHand_JokerFirstOrLast_WithAceInTheMiddle()
		{
			// Arrange
			var c1 = new Card(9, new Suite(1));
			var c2 = new Card(10, new Suite(1));
			var c3 = new Card(11, new Suite(1));
			var c4 = new Card(12, new Suite(1));
			var c5 = new Card(15, new Suite(1));

			var service = new StreetFlushJokerHandCheck();

			// Act
			var handResult = service.CheckHand(c1, c2, c3, c4, c5);

			// Assert
			Assert.IsInstanceOfType(handResult.Result, typeof(StreetFlush), "Result should be StreetFlush");
		}

		[TestMethod]
		public void CheckHand_JokerFirstOrLast_WithAce()
		{
			// Arrange
			var c1 = new Card(2, new Suite(1));
			var c2 = new Card(3, new Suite(1));
			var c3 = new Card(4, new Suite(1));
			var c4 = new Card(11, new Suite(1));
			var c5 = new Card(15, new Suite(1));

			var service = new StreetFlushJokerHandCheck();

			// Act
			var handResult = service.CheckHand(c1, c2, c3, c4, c5);

			// Assert
			Assert.IsInstanceOfType(handResult.Result, typeof(StreetFlush), "Result should be StreetFlush");
		}

		[TestMethod]
		public void CheckHand_JokerSecond_WithAce()
		{
			// Arrange
			var c1 = new Card(3, new Suite(1));
			var c2 = new Card(4, new Suite(1));
			var c3 = new Card(5, new Suite(1));
			var c4 = new Card(11, new Suite(1));
			var c5 = new Card(15, new Suite(1));

			var service = new StreetFlushJokerHandCheck();

			// Act
			var handResult = service.CheckHand(c1, c2, c3, c4, c5);

			// Assert
			Assert.IsInstanceOfType(handResult.Result, typeof(StreetFlush), "Result should be StreetFlush");
		}

		[TestMethod]
		public void CheckHand_JokerThird_WithAce()
		{
			// Arrange
			var c1 = new Card(2, new Suite(1));
			var c2 = new Card(4, new Suite(1));
			var c3 = new Card(5, new Suite(1));
			var c4 = new Card(11, new Suite(1));
			var c5 = new Card(15, new Suite(1));

			var service = new StreetFlushJokerHandCheck();

			// Act
			var handResult = service.CheckHand(c1, c2, c3, c4, c5);

			// Assert
			Assert.IsInstanceOfType(handResult.Result, typeof(StreetFlush), "Result should be StreetFlush");
		}

		[TestMethod]
		public void CheckHand_JokerFourth_WithAce()
		{
			// Arrange
			var c1 = new Card(2, new Suite(1));
			var c2 = new Card(3, new Suite(1));
			var c3 = new Card(5, new Suite(1));
			var c4 = new Card(11, new Suite(1));
			var c5 = new Card(15, new Suite(1));

			var service = new StreetFlushJokerHandCheck();

			// Act
			var handResult = service.CheckHand(c1, c2, c3, c4, c5);

			// Assert
			Assert.IsInstanceOfType(handResult.Result, typeof(StreetFlush), "Result should be StreetFlush");
		}
	}
}
