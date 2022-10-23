using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Blackjack
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static Dictionary<Tuple<int, bool>, Dictionary<Tuple<CardDictionary, int, bool>, int>> EachStateDealerCardDictionaries = GetEachStateDealerCardDictionaries();

        public static Dictionary<Tuple<int, bool>, Dictionary<Tuple<CardDictionary, int, int, bool>, int>> EachStateTargetAndOverPlayerCardDictionaries = GetEachStateTargetAndOverPlayerCardDictionaries();

        public MainWindow()
        {
            InitializeComponent();

            Uri uri = new("Pages/Simulator.xaml", UriKind.Relative);
            frame.Source = uri;
        }

        public static List<Tuple<int, bool>> GetPlayerAllStates()
        {
            List<Tuple<int, bool>> playerAllStates = new()
            {
                new(21, false),
                new(20, false),
                new(19, false),
                new(18, false),
                new(17, false),
                new(16, false),
                new(15, false),
                new(14, false),
                new(13, false),
                new(12, false),
                new(21, true),
                new(20, true),
                new(19, true),
                new(18, true),
                new(17, true),
                new(16, true),
                new(15, true),
                new(14, true),
                new(13, true),
                new(12, true),
                new(11, true),
                new(11, false),
                new(10, false),
                new(9, false),
                new(8, false),
                new(7, false),
                new(6, false),
                new(5, false),
                new(4, false),
                new(3, false),
                new(2, false),
                new(0, false),
            };

            return playerAllStates;
        }

        public static List<Tuple<int, bool>> GetDealerAllStates()
        {
            List<Tuple<int, bool>> dealerAllStates = new()
            {
                new(0, false),
                new(2, false),
                new(3, false),
                new(4, false),
                new(5, false),
                new(6, false),
                new(7, false),
                new(8, false),
                new(9, false),
                new(10, false),
                new(11, true),
            };

            return dealerAllStates;
        }

        public static Dictionary<Tuple<int, bool>, Dictionary<Tuple<CardDictionary, int, bool>, int>> GetEachStateDealerCardDictionaries()
        {
            void RecursiveAddCard(Hand initHand, Dictionary<Tuple<CardDictionary, int, bool>, int> dealerCardDictionaries, CardDictionary naturalBlackjackCardDictionary)
            {
                if (initHand.Point > 16)
                {
                    Tuple<CardDictionary, int, bool> key = new(initHand.CardDictionary, initHand.Point, initHand.CardDictionary == naturalBlackjackCardDictionary);
                    dealerCardDictionaries.TryAdd(key, 0);
                    dealerCardDictionaries[key]++;
                    return;
                }

                foreach (Card card in Enum.GetValues(typeof(Card)))
                {
                    Hand hand = new(initHand);
                    hand.AddCard(card);
                    RecursiveAddCard(hand, dealerCardDictionaries, naturalBlackjackCardDictionary);
                }
            }

            Dictionary<Tuple<int, bool>, Dictionary<Tuple<CardDictionary, int, bool>, int>> eachStateDealerCardDictionaries = new();
            foreach (Tuple<int, bool> state in GetDealerAllStates())
            {
                eachStateDealerCardDictionaries.Add(state, new());
                Hand hand = new(false, state.Item2, state.Item1);
                CardDictionary naturalBlackjackCardDictionary = new();
                if (hand.Point == 0 || hand.Point == 10)
                    naturalBlackjackCardDictionary.AddCard(Card.Ace);
                if (hand.Point == 0 || hand.Point == 11)
                    naturalBlackjackCardDictionary.AddCard(Card.Ten);
                RecursiveAddCard(hand, eachStateDealerCardDictionaries[state], naturalBlackjackCardDictionary);
            }

            return eachStateDealerCardDictionaries;
        }

        public static Dictionary<Tuple<int, bool>, Dictionary<Tuple<CardDictionary, int, int, bool>, int>> GetEachStateTargetAndOverPlayerCardDictionaries()
        {
            void AddCard(
                Tuple<int, bool> initState,
                Dictionary<Tuple<int, bool>, Dictionary<Tuple<CardDictionary, int, int, bool>, int>> eachStateTargetAndOverPlayerCardDictionaries,
                int lowBorder,
                CardDictionary? naturalBlackjackCardDictionary
            )
            {
                Hand initHand = new(false, initState.Item2, initState.Item1);
                if (initHand.Point > 16)
                {
                    Tuple<CardDictionary, int, int, bool> key = new(initHand.CardDictionary, lowBorder, initHand.Point, initHand.CardDictionary == naturalBlackjackCardDictionary);
                    eachStateTargetAndOverPlayerCardDictionaries[initState].Add(key, 1);
                }

                foreach (Card card in Enum.GetValues(typeof(Card)))
                {
                    Hand hand = new(initHand);
                    hand.AddCard(card);

                    if (hand.IsBust)
                        break;

                    Tuple<int, bool> state = new(hand.Point, hand.IsSoft);
                    foreach (KeyValuePair<Tuple<CardDictionary, int, int, bool>, int> targetAndOverPlayerCardDictionaryData in eachStateTargetAndOverPlayerCardDictionaries[state])
                    {
                        if (initHand.Point >= targetAndOverPlayerCardDictionaryData.Key.Item3)
                            continue;
                        CardDictionary cardDictionary = targetAndOverPlayerCardDictionaryData.Key.Item1 + hand.CardDictionary;
                        if (hand.Point == targetAndOverPlayerCardDictionaryData.Key.Item2)
                            lowBorder = Math.Max(initHand.Point + 1, 17);
                        else
                            lowBorder = targetAndOverPlayerCardDictionaryData.Key.Item2;
                        if (lowBorder <= initHand.Point)
                            continue;
                        int highBorder = targetAndOverPlayerCardDictionaryData.Key.Item3;
                        bool isNaturalBlackjack = cardDictionary == naturalBlackjackCardDictionary;
                        Tuple<CardDictionary, int, int, bool> key = new(cardDictionary, lowBorder, highBorder, isNaturalBlackjack);
                        eachStateTargetAndOverPlayerCardDictionaries[initState].TryAdd(key, 0);
                        eachStateTargetAndOverPlayerCardDictionaries[initState][key] += targetAndOverPlayerCardDictionaryData.Value;
                    }
                }
            }

            Dictionary<Tuple<int, bool>, Dictionary<Tuple<CardDictionary, int, int, bool>, int>> eachStateTargetAndOverCardDictionaries = new();
            Tuple<int, bool> bustState = new(22, false);
            eachStateTargetAndOverCardDictionaries.Add(bustState, new());
            eachStateTargetAndOverCardDictionaries[bustState].Add(new(new(), 22, 22, false), 1);

            foreach (Tuple<int, bool> state in GetPlayerAllStates())
            {
                Hand hand = new(false, state.Item2, state.Item1);
                CardDictionary? naturalBlackjackCardDictionary = null;
                if (hand.Point == 0 || hand.Point == 10 || (hand.IsSoft && (hand.Point == 11 || hand.Point == 21)))
                {
                    naturalBlackjackCardDictionary = new();
                    if (hand.Point == 0 || hand.Point == 10)
                        naturalBlackjackCardDictionary.AddCard(Card.Ace);
                    if (hand.Point == 0 || hand.Point == 11)
                        naturalBlackjackCardDictionary.AddCard(Card.Ten);
                }
                eachStateTargetAndOverCardDictionaries.Add(state, new());
                AddCard(state, eachStateTargetAndOverCardDictionaries, hand.Point, naturalBlackjackCardDictionary);
            }

            return eachStateTargetAndOverCardDictionaries;
        }

    }
}
