using System;
using System.Collections.Generic;

namespace Blackjack
{
    public class Hand
    {
        public CardDictionary CardDictionary { get; private set; }
        private readonly bool InitIsBust; 
        private readonly bool InitIsSoft; 
        private readonly int InitPoint;
        public bool IsBust { get; private set; }
        public bool IsSoft { get; private set; }
        public int Point { get; private set; }

        public Hand()
        {
            CardDictionary = new();
            InitIsBust = false;
            InitIsSoft = false;
            InitPoint = 0;
            IsBust = InitIsBust;
            IsSoft = InitIsSoft;
            Point = InitPoint;
        }

        public Hand(CardDictionary cardDictionary)
        {
            CardDictionary = new(cardDictionary);
            foreach (KeyValuePair<Card, int> keyValuePair in CardDictionary.NumCardMap)
            {
                for (int i = 0; i < keyValuePair.Value; i++)
                    AddCard(keyValuePair.Key);
            }
            InitIsBust = false;
            InitIsSoft = false;
            InitPoint = 0;
            IsBust = InitIsBust;
            IsSoft = InitIsSoft;
            Point = InitPoint;
        }

        public Hand(bool initIsBust, bool initIsSoft, int initPoint)
        {
            if (initIsBust && (initIsSoft || initPoint != 22))
                throw new ArgumentException($"Invalid Hand. (IsBust:{initIsBust}, IsSoft:{initIsSoft}, Point:{initPoint})");
            if (initIsSoft && !(initPoint > 10 && initPoint < 22))
                throw new ArgumentException($"Invalid Hand. (IsBust:{initIsBust}, IsSoft:{initIsSoft}, Point:{initPoint})");
            if (initPoint < 0 || initPoint == 1 || initPoint > 21)
                throw new ArgumentException($"Invalid Hand. (IsBust:{initIsBust}, IsSoft:{initIsSoft}, Point:{initPoint})");

            CardDictionary = new();
            InitIsBust = initIsBust;
            InitIsSoft = initIsSoft;
            InitPoint = initPoint;
            IsBust = InitIsBust;
            IsSoft = InitIsSoft;
            Point = InitPoint;
        }

        public Hand(Hand hand)
        {
            CardDictionary = new(hand.CardDictionary);
            InitIsBust = hand.InitIsBust;
            InitIsSoft = hand.InitIsSoft;
            InitPoint= hand.InitPoint;
            IsBust = hand.IsBust;
            IsSoft = hand.IsSoft;
            Point = hand.Point;
        }

        public void AddCard(Card card, bool updateCardDictionary = true)
        {
            if (updateCardDictionary)
            CardDictionary.AddCard(card);

            if (IsBust)
                return;

            Point += (int)card;
            if (card == Card.Ace && Point < 12)
            {
                IsSoft = true;
                Point += 10;
            }
            else if (IsSoft && Point > 21)
            {
                IsSoft = false;
                Point -= 10;
            }
            Point = Math.Min(Point, 22);
            IsBust = Point == 22;
        }

        public int GetNumAllCard()
        {
            return CardDictionary.GetNumAllCard();
        }

        public int GetNumCard(Card card)
        {
            return CardDictionary.GetNumCard(card);
        }

        public void Information(bool newLine = true)
        {
            CardDictionary.Information(newLine: false);
            Console.Write($"IsBust:{IsBust} IsSoft:{IsSoft} Point:{Point}");

            if (newLine)
                Console.WriteLine();
            else
                Console.Write(" ");
        }

        public void RemoveCard(Card card)
        {
            CardDictionary.RemoveCard(card);
            IsBust = InitIsBust;
            IsSoft = InitIsSoft;
            Point = InitPoint;
            foreach (KeyValuePair<Card, int> keyValuePair in CardDictionary.NumCardMap)
            {
                for (int i = 0; i < keyValuePair.Value; i++)
                    AddCard(keyValuePair.Key, updateCardDictionary: false);
            }
        }

        public void Reset()
        {
            CardDictionary.Reset();
            IsBust = InitIsBust;
            IsSoft = InitIsSoft;
            Point = InitPoint;
        }
    }
}