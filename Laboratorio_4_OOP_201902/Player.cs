using Laboratorio_4_OOP_201902.Cards;
using Laboratorio_4_OOP_201902.Enums;
using System;
using System.Collections.Generic;
using System.Text;
using System.Random;

namespace Laboratorio_4_OOP_201902
{
    public class Player
    {
        //Constantes
        private const int LIFE_POINTS = 2;
        private const int START_ATTACK_POINTS = 0;

        //Static
        private static int idCounter;

        //Atributos
        private int id;
        private int lifePoints;
        private int attackPoints;
        private Deck deck;
        private Hand hand;
        private Board board;
        private SpecialCard captain;

        //Constructor
        public Player()
        {
            LifePoints = LIFE_POINTS;
            AttackPoints = START_ATTACK_POINTS;
            Deck = new Deck();
            Hand = new Hand();
            Id = idCounter++;
        }

        //Propiedades
        public int Id { get => id; set => id = value; }
        public int LifePoints
        {
            get
            {
                return this.lifePoints;
            }
            set
            {
                this.lifePoints = value;
            }
        }
        public int AttackPoints
        {
            get
            {
                return this.attackPoints;
            }
            set
            {
                this.attackPoints = value;
            }
        }
        public Deck Deck
        {
            get
            {
                return this.deck;
            }
            set
            {
                this.deck = value;
            }
        }
        public Hand Hand
        {
            get
            {
                return this.hand;
            }
            set
            {
                this.hand = value;
            }
        }
        public Board Board
        {
            get
            {
                return this.board;
            }
            set
            {
                this.board = value;
            }
        }
        public SpecialCard Captain
        {
            get
            {
                return this.captain;
            }
            set
            {
                this.captain = value;
            }
        }

        //Metodos
        public void DrawCard(int cardId = 0)
        {
            if (deck.Cards[cardId] == typeof(SpecialCard))
            {
                SpecialCard card = deck.Cards[cardId];
                hand.AddCard(card);
                deck.DestroyCard(cardId);
             }
            else
            {
                CombatCard card = deck.Cards[cardId];
                hand.AddCard(card);
                deck.DestroyCard(cardId);

            }
            /*
            1- Definir si la carta a robada del mazo es CombatCard o SpecialCard
            2- Luego deberá agregar la carta robada al mazo. En este paso debe respetar el tipo por referencia, para esto:
                2.1- Asigne una variable a la carta robada del mazo, ejemplo, CombatCard card = deck.Cards[cardId]
                2.2- Cree una CombatCard o SpecialCard (dependiendo del caso) con los valores de la carta del mazo.
                2.3- Agregue la nueva carta a la mano
            Elimine la carta del mazo.
            Hint: Utilice los métodos ya creados en Hand y Deck (AddCard y DestroyCard), no se preocupe de la implementacion de estos aun.*/
            
        }
        public void PlayCard(int cardId, EnumType buffRow = EnumType.None)
        {
            if (hand.Cards[cardId] == typeof(CombatCard))
            {
                CombatCard card = hand.Cards[cardId];
                board.AddCard(card,Id);
                hand.DestroyCard(cardId);
            }
            else
            {
                if (hand.Cards[cardId] == typeof(SpecialCard))
                {
                    SpecialCard card = hand.Cards[cardId];

                    if (card.BuffType == (buffmelee || buffrange || bufflongRange || buff))
                    {
                        board.AddCard(card, Id, buffRow);
                    }
                    else
                    {
                        board.AddCard(card, Id);
                    }
                    hand.DestroyCard(cardId);
                }
            }

            /*Realice el mismo procedimiento que en DrawCard, solo que ahora es desde Hand a Board.
              En caso de CombatCard siga el mismo procedimiento, recuerde que el método AddCard de Board requiere el id del usuario.
              En caso de SpecialCard:
                1- Realice los pasos 2.1 y 2.2 de DrawCard
                2- Identifique el tipo de la carta, 
                    2.1- Si es buff:
                        -El metodo AddCard de Board requiere el Id del usuario
                        -El metodo requiere la entrada buff{fila a la que se va a jugar}. Ejemplo buffmelee, este dato viene en el parámetro buffRow.
                    2.2- Si es weather:
                        -El metodo AddCard solo requiere la carta.
                3- Elimine la carta de la mano. 
             */

        }
        public void ChangeCard(int cardId) 
        {
            if (hand.Cards[cardId] == typeof(CombatCard))
            {
                CombatCard card = hand.Cards[cardId];
            }
            else if((hand.Cards[cardId] == typeof(SpecialCard)))
            {
                SpecialCard card = hand.Cards[cardId];
            }
            hand.DestroyCard(cardId);

            Random aa = new Random();
            int numberOfCardsInMazo = deck.Cards.Count;
            int idcartaAa = aa.Next(0, numberOfCardsInMazo - 1);

            Card newCard = DrawCard(idcartaAa);
            hand.AddCard(newCard);
            deck.DestroyCard(cardId);
            deck.AddCard(cardId);


            /* Debe cambiar la carta en la posicion cardId de la mano por una carta aleatoria del mazo.
                1- Defina si la carta a cambiar de la mano es CombatCard o SpecialCard. Luego (Esto permite cambiar la referencia):
                        1.1- Asigne una variable a la carta a cambiar de la mano, ejemplo, CombatCard card = hand.Cards[cardId]
                        1.2- Cree una CombatCard o SpecialCard (dependiendo del caso) con los valores de la carta de la mano a cambiar.
                2- Elimine la carta de la mano
                3- Implemente Random
                4- Cree una variable que obtenga un numero aleatorio dentro del total de cartas del mazo.
                5- Obtenga la carta aleatoria del mazo (puede utilizar el método DrawCard) y cree una nueva carta con sus valores. Agreguela a la mano. 
                6- Elimine la carta aleatoria escogida del mazo.
                7- Agregue la carta original de la mano al mazo.
            */

        }

        public void FirstHand()
        {
            Random aa = new Random();
            int numberOfCardsInMazo = deck.Cards.Count;
            int aaCardId = aa.Next(0, numberOfCardsInMazo - 1);
            hand.AddCard(aaCardId);
            deck.DestroyCard(aaCardId);

            Random aa2 = new Random();
            int numberOfCardsInMazo2 = deck.Cards.Count;
            int aaCardId2 = aa2.Next(0, numberOfCardsInMazo2 - 1);
            hand.AddCard(aaCardId2);
            deck.DestroyCard(aaCardId2);

            Random aa3 = new Random();
            int numberOfCardsInMazo3 = deck.Cards.Count;
            int aaCardId3 = aa3.Next(0, numberOfCardsInMazo3 - 1);
            hand.AddCard(aaCardId3);
            deck.DestroyCard(aaCardId3);

            Random aa4 = new Random();
            int numberOfCardsInMazo4 = deck.Cards.Count;
            int aaCardId4 = aa4.Next(0, numberOfCardsInMazo4 - 1);
            hand.AddCard4(aaCardId4);
            deck.DestroyCard(aaCardId4);

            Random aa5 = new Random();
            int numberOfCardsInMazo5 = deck.Cards.Count;
            int aaCardId5 = aa5.Next(0, numberOfCardsInMazo5 - 1);
            hand.AddCard(aaCardId5);
            deck.DestroyCard(aaCardId5);

            Random aa6 = new Random();
            int numberOfCardsInMazo6 = deck.Cards.Count;
            int aaCardId = aa6.Next(0, numberOfCardsInMazo6 - 1);
            hand.AddCard(aaCardId6);
            deck.DestroyCard(aaCardId6);

            Random aa7 = new Random();
            int numberOfCardsInMazo7 = deck.Cards.Count;
            int aaCardId7 = aa7.Next(0, numberOfCardsInMazo7 - 1);
            hand.AddCard(aaCardId7);
            deck.DestroyCard(aaCardId7);

            Random aa8 = new Random();
            int numberOfCardsInMazo8 = deck.Cards.Count;
            int aaCardId8 = aa78.Next(0, numberOfCardsInMazo8 - 1);
            hand.AddCard(aaCardId8);
            deck.DestroyCard(aaCardId8);

            Random aa9 = new Random();
            int numberOfCardsInMazo9 = deck.Cards.Count;
            int aaCardId9 = aa9.Next(0, numberOfCardsInMazo9 - 1);
            hand.AddCard(aaCardId9);
            deck.DestroyCard(aaCardId9);

            Random aa10 = new Random();
            int numberOfCardsInMazo10 = deck.Cards.Count;
            int aaCardId10 = aa10.Next(0, numberOfCardsInMazo10 - 1);
            hand.AddCard(aaCardId10);
            deck.DestroyCard(aaCardId10);


            /*Debe obtener 10 cartas aleatorias del mazo y asignarlas a la mano.
            Utilice el metodo DrawCard con 10 numeros de id aleatorios.
            */

        }

        public void ChooseCaptainCard(SpecialCard captainCard)
        {
            Captain = captainCard;
        }

    }
}
