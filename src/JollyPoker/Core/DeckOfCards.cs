using System;
using System.Collections.Generic;
using System.Linq;

namespace JollyPoker.Core
{
	public class DeckOfCards : List<Card>
	{
		public void InitDeck()
		{
			for (int i = 2; i < 15; i++)
			{
				for (int j = 1; j < 5; j++)
				{
					Add(new Card(i, new Suite(j)));
				}
			}
			Add(new Card(15, new Suite(0)));

			RandomizeDeck();
		}

		public void RandomizeDeck()
		{
			// Randomize deck of cards
			for (int i = 0; i < Count; i++)
			{
				var tempCard = this[i];
				var randomPosition = new Random().Next(i, Count);
				this[i] = this[randomPosition];
				this[randomPosition] = tempCard;
			}
		}

		public List<Card> DealCards(int numberOfCards)
		{
			var cards = this.Take(numberOfCards).ToList();

			RemoveRange(0, numberOfCards);

			return cards;
		}
	}

}
