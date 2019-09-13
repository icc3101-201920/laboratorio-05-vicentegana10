using Laboratorio_4_OOP_201902.Cards;
using System;
using System.Collections.Generic;
using System.Text;
using System.Random;

namespace Laboratorio_4_OOP_201902
{
    public class Deck
    {

        private List<Card> cards;

        public Deck()
        {
        
        }

        public List<Card> Cards { get => cards; set => cards = value; }

        public void AddCard(Card card)
        {
            Cards.Add(card);


        }
        public void DestroyCard(int cardId)
        {
            Cards.RemoveAt(cardId);

        }
        public void Shuffle()
        {
            Random aaa = new Random();
            shuffledList = cards.OrderBy(x => aaa).ToList();

            cards = shuffledList;

        }
    }
}
