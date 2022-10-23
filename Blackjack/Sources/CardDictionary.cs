using System;
using System.Collections.Generic;
using System.Linq;

namespace Blackjack
{
    public class CardDictionary
    {
        private readonly Dictionary<Card, int> InitNumCardMap;
        public Dictionary<Card, int> NumCardMap { get; private set; }
        
        public CardDictionary()
        {
            InitNumCardMap = new();
            foreach (Card card in Enum.GetValues(typeof(Card)))
                InitNumCardMap.Add(card, 0);
            NumCardMap = new(InitNumCardMap);
        }

        public CardDictionary(CardDictionary cardDictionary)
        {
            InitNumCardMap = new(cardDictionary.InitNumCardMap);
            NumCardMap = new(cardDictionary.NumCardMap);
        }

        public CardDictionary(int[] numCards)
        {
            if (numCards.Rank != 1 || numCards.Length != 10)
                throw new ArgumentException("Invalid NumCards Array.");

            InitNumCardMap = new();
            foreach (Card card in Enum.GetValues(typeof(Card)))
                InitNumCardMap.Add(card, numCards[(int)card - 1]);
            NumCardMap = new(InitNumCardMap);
        }

        public void AddCard(Card card)
        {
            NumCardMap[card]++;
        }

        public int GetNumAllCard()
        {
            return NumCardMap.Sum(numCard => numCard.Value);
        }

        public int GetNumCard(Card card)
        {
            return NumCardMap[card];
        }

        public void Information(bool newLine = true)
        {
            foreach (Card card in Enum.GetValues(typeof(Card)))
                Console.Write($"{card}:{GetNumCard(card)} ");
            Console.Write($"NumAllCard:{GetNumAllCard()}");

            if (newLine)
                Console.WriteLine();
            else
                Console.Write(" ");
        }

        public void RemoveCard(Card card)
        {
            if (GetNumCard(card) <= 0)
                throw new ArgumentException($"Cannot Remove {card}");
            NumCardMap[card]--;
        }

        public void Reset(int numCard = 0)
        {
            NumCardMap = new(InitNumCardMap);
        }


        public bool Equals(CardDictionary? cardDictionary)
        {
            if (cardDictionary is null)
                return false;
            if (ReferenceEquals(this, cardDictionary))
                return true;
            if (GetType() != cardDictionary.GetType())
                return false;

            foreach (Card card in Enum.GetValues(typeof(Card)))
            {
                if (GetNumCard(card) != cardDictionary.GetNumCard(card))
                    return false;
            }

            return true;
        }

        public override bool Equals(object? obj)
        {
            return Equals(obj as CardDictionary);
        }

        public override int GetHashCode()
        {
            System.Text.StringBuilder stringBuilder = new();

            foreach (Card card in Enum.GetValues(typeof(Card)))
            {
                stringBuilder.Append(card.ToString());
                stringBuilder.Append(GetNumCard(card));
            }

            return stringBuilder.ToString().GetHashCode();
        }

        public static bool operator ==(CardDictionary? cardDictionary1, CardDictionary? cardDictionary2)
        {
            if (cardDictionary1 is null || cardDictionary2 is null)
                return Object.Equals(cardDictionary1, cardDictionary2);

            return cardDictionary1.Equals(cardDictionary2);
        }

        public static bool operator !=(CardDictionary? cardDictionary1, CardDictionary? cardDictionary2)
        {
            return !(cardDictionary1 == cardDictionary2);
        }

        public static CardDictionary operator +(CardDictionary cardDictionary1, CardDictionary cardDictionary2)
        {
            CardDictionary cardDictionary = new();
            cardDictionary.Reset();

            foreach (Card card in Enum.GetValues(typeof(Card)))
                cardDictionary.NumCardMap[card] = cardDictionary1.GetNumCard(card) + cardDictionary2.GetNumCard(card);

            return cardDictionary;
        }

        public static bool operator <=(CardDictionary cardDictionary1, CardDictionary cardDictionary2)
        {
            foreach (Card card in Enum.GetValues(typeof(Card)))
            {
                if (cardDictionary1.GetNumCard(card) > cardDictionary2.GetNumCard(card))
                    return false;
            }

            return true;
        }

        public static bool operator >=(CardDictionary cardDictionary1, CardDictionary cardDictionary2)
        {
            foreach (Card card in Enum.GetValues(typeof(Card)))
            {
                if (cardDictionary1.GetNumCard(card) < cardDictionary2.GetNumCard(card))
                    return false;
            }

            return true;
        }
    }
}