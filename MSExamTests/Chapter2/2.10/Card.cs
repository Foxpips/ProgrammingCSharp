using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using SealedClassMocking.Extensions;

namespace MSExamTests.Chapter2._2._10
{
    public class Card
    {
        public string Name { get; set; }
        public int Number { get; set; }
    }

    public class Deck
    {
        //default parameter
        public Deck(ICollection<Card> cards = null)
        {
            Cards = cards ?? new List<Card>();
        }

        public Deck(params Card[] cards) 
        {
            Cards = new List<Card>();
            Cards.AddAll(cards);
        }

        //private set: can only be set in this class
        public ICollection<Card> Cards { get; private set; }

        public Card this[int index]
        {
            get { return Cards.ElementAt(index); }
        }
    }

    public class TestIndexer
    {
        [Test]
        public void Indexer_Test_Cards()
        {
            var deck = new Deck(new Card { Name = "Queen of Hearts", Number = 12 });
            deck.Cards.Add(new Card { Name = "King of Hearts", Number = 12 });
            deck.Cards.Add(new Card { Name = "Ace of Hearts", Number = 11 });

            Assert.That(deck[0].Name.Equals("Queen of Hearts"));
        }
    }
}