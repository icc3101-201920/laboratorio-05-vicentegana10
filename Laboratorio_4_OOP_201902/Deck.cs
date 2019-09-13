using Laboratorio_4_OOP_201902.Cards;
using System;
using System.Collections.Generic;
using System.Text;

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
            //Agregue la carta card a la lista cards

        }
        public void DestroyCard(int cardId)
        {
            Cards.RemoveAt(cardId);
            /* Debe eliminar la carta segun el parametro cardId. Para esto
                1- Utilice el metodo RemoveAt de las listas para eliminar la carta en cards
            */
            throw new NotImplementedException();
        }
        public void Shuffle()
        {
            Random aaa = new Random();
            shuffledList = cards.OrderBy(x => aaa).ToList();

            cards = shuffledList;

        }
    }
}
