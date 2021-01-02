using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace JollyPoker.Tests
{
	[TestClass]
	public class DeckOfCardsTests
	{
		[TestMethod]
		public void InitDeckTest()
		{
			// Arrange
			var deckOfCards = new DeckOfCards();

			// Act
			deckOfCards.InitDeck();

			// Assert
			Assert.AreEqual(53, deckOfCards.Count, "There should be 53 cards in the deck.");
		}

		[TestMethod]
		public void DealCardsTest()
		{
			// Arrange
			DeckOfCards deckOfCards = GenerateTestDeck();

			// Act
			var cards = deckOfCards.DealCards(3);

			// Assert
			Assert.AreEqual(3, cards.Count, "There should be 3 cards in the dealing.");
			Assert.AreEqual(2, deckOfCards.Count, "There should be 2 cards left in the deck.");
		}

		[TestMethod]
		public void RandomizeDeckTest()
		{
			// Arrange
			DeckOfCards deckOfCards = GenerateTestDeck();

			// Act
			deckOfCards.RandomizeDeck();

			// Assert
			Assert.AreEqual(5, deckOfCards.Count, "Number of cards should be 5.");
		}

		private static DeckOfCards GenerateTestDeck()
		{
			var deckOfCards = new DeckOfCards();
			deckOfCards.Add(new Card(2, new Suite(1)));
			deckOfCards.Add(new Card(3, new Suite(1)));
			deckOfCards.Add(new Card(4, new Suite(1)));
			deckOfCards.Add(new Card(5, new Suite(1)));
			deckOfCards.Add(new Card(6, new Suite(1)));
			return deckOfCards;
		}
	}
}