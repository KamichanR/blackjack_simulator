using System;

namespace Blackjack
{
    public class Deck
    {
        public CardDictionary CardDictionary { get; private set; }
        public int NumDeck { get; init; }

        public Deck(int numDeck)
        {
            int[] numCards = new int[10];
            foreach (Card card in Enum.GetValues(typeof(Card)))
            {
                if (card == Card.Ten)
                    numCards[(int)card - 1] = numDeck * 16;
                else
                    numCards[(int)card - 1] = numDeck * 4;
            }
            CardDictionary = new(numCards);
            NumDeck = numDeck;
        }

        public Deck(CardDictionary cardDictionary)
        {
            CardDictionary = new(cardDictionary);
            NumDeck = 0;
        }

        public void AddCard(Card card)
        {
            CardDictionary.AddCard(card);
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
            Console.Write($"NumDeck: {NumDeck}");

            if (newLine)
                Console.WriteLine();
            else
                Console.Write(" ");
        }

        public double GetCardProbability(Card card)
        {
            return (double)GetNumCard(card) / GetNumAllCard();
        }

        public double GetProbability(CardDictionary cardDictionary)
        {
            double Permutation(int n, int r)
            {
                if (n < r)
                    return 0;

                double result = 1;
                for (int i = n; i > n - r; i--)
                    result *= i;

                return result;
            }

            if (!(cardDictionary <= CardDictionary))
                return 0;

            double probability = 1 / Permutation(GetNumAllCard(), cardDictionary.GetNumAllCard());
            foreach (Card card in Enum.GetValues(typeof(Card)))
                probability *= Permutation(GetNumCard(card), cardDictionary.GetNumCard(card));

            return probability;
        }

        public void RemoveCard(Card card)
        {
            CardDictionary.RemoveCard(card);
        }

        public void Reset()
        {
            CardDictionary.Reset();
        }
    }
}