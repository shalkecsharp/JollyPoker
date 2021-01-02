using JollyPoker;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace JollyPokerTests
{
	[TestClass]
	public class CardTests
	{
		[TestMethod, ExpectedException(typeof(ArgumentOutOfRangeException))]
		public void DisplayValue_WhenInvalid_ShouldRaiseException()
		{
			// Arrange
			var card = new Card(0, new Suite(0));

			// Act
			var displayValue = card.DisplayValue;
		}

		[TestMethod]
		public void DisplayValue_WhenLowerCard()
		{
			// Arrange
			var card = new Card(2, new Suite(0));

			// Act
			var displayValue = card.DisplayValue;

			// Assert
			Assert.AreEqual("2", displayValue, "Display value should be 2.");
		}

		[TestMethod]
		public void DisplayValue_WhenHigherCard()
		{
			// Arrange
			var card = new Card(12, new Suite(0));

			// Act
			var displayValue = card.DisplayValue;

			// Assert
			Assert.AreEqual("J", displayValue, "Display value should be 2.");
		}


		[TestMethod]
		public void ToString_WhenHigherCard()
		{
			// Arrange
			var card = new Card(12, new Suite(1));

			// Act
			var displayValue = card.ToString();

			// Assert
			Assert.AreEqual("J♥", displayValue, "Display value should be J♥.");
		}

	}
}
