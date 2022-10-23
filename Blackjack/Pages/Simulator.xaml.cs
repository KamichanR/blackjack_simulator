using System;
using System.Collections.Generic;
using System.Diagnostics;
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

namespace Blackjack.Pages
{
    /// <summary>
    /// Simulator.xaml の相互作用ロジック
    /// </summary>
    public partial class Simulator : Page
    {
        public Deck Deck { get; private set; }
        public Hand PlayerHand { get; private set; }
        public Hand DealerHand { get; private set; }

        public Simulator()
        {
            Deck = new(8);
            PlayerHand = new();
            DealerHand = new();
            InitializeComponent();
            UpdateScreen();
        }

        public void UpdateScreen()
        {
            AceNumCardTextBlock.Text = Deck.GetNumCard(Card.Ace).ToString();
            TwoNumCardTextBlock.Text = Deck.GetNumCard(Card.Two).ToString();
            ThreeNumCardTextBlock.Text = Deck.GetNumCard(Card.Three).ToString();
            FourNumCardTextBlock.Text = Deck.GetNumCard(Card.Four).ToString();
            FiveNumCardTextBlock.Text = Deck.GetNumCard(Card.Five).ToString();
            SixNumCardTextBlock.Text = Deck.GetNumCard(Card.Six).ToString();
            SevenNumCardTextBlock.Text = Deck.GetNumCard(Card.Seven).ToString();
            EightNumCardTextBlock.Text = Deck.GetNumCard(Card.Eight).ToString();
            NineNumCardTextBlock.Text = Deck.GetNumCard(Card.Nine).ToString();
            TenNumCardTextBlock.Text = Deck.GetNumCard(Card.Ten).ToString();

            AceProbabilityTextBlock.Text = (Deck.GetCardProbability(Card.Ace) * 100).ToString("0.000") + "%";
            TwoProbabilityTextBlock.Text = (Deck.GetCardProbability(Card.Two) * 100).ToString("0.000") + "%";
            ThreeProbabilityTextBlock.Text = (Deck.GetCardProbability(Card.Three) * 100).ToString("0.000") + "%";
            FourProbabilityTextBlock.Text = (Deck.GetCardProbability(Card.Four) * 100).ToString("0.000") + "%";
            FiveProbabilityTextBlock.Text = (Deck.GetCardProbability(Card.Five) * 100).ToString("0.000") + "%";
            SixProbabilityTextBlock.Text = (Deck.GetCardProbability(Card.Six) * 100).ToString("0.000") + "%";
            SevenProbabilityTextBlock.Text = (Deck.GetCardProbability(Card.Seven) * 100).ToString("0.000") + "%";
            EightProbabilityTextBlock.Text = (Deck.GetCardProbability(Card.Eight) * 100).ToString("0.000") + "%";
            NineProbabilityTextBlock.Text = (Deck.GetCardProbability(Card.Nine) * 100).ToString("0.000") + "%";
            TenProbabilityTextBlock.Text = (Deck.GetCardProbability(Card.Ten) * 100).ToString("0.000") + "%";

            string playerHandText = "";
            if (PlayerHand.IsSoft)
                playerHandText += "Soft";
            else
                playerHandText += "Hard";
            playerHandText += PlayerHand.Point.ToString();
            PlayerHandTextBlock.Text = playerHandText;

            string dealerHandText = "";
            if (DealerHand.IsSoft)
                dealerHandText += "Soft";
            else
                dealerHandText += "Hard";
            dealerHandText += DealerHand.Point.ToString();
            DealerHandTextBlock.Text = dealerHandText;

            PlayerSeventeenAndOverTextBlock.Text = "";
            PlayerEighteenAndOverTextBlock.Text = "";
            PlayerNineteenAndOverTextBlock.Text = "";
            PlayerTwentyAndOverTextBlock.Text = "";
            PlayerTwentyOneAndOverTextBlock.Text = "";
            PlayerBustTextBlock.Text = "";
            DealerSeventeenAndOverTextBlock.Text = "";
            DealerEighteenAndOverTextBlock.Text = "";
            DealerNineteenAndOverTextBlock.Text = "";
            DealerTwentyAndOverTextBlock.Text = "";
            DealerTwentyOneAndOverTextBlock.Text = "";
            DealerBustTextBlock.Text = "";
        }

        private void AceAddButton_Click(object sender, RoutedEventArgs e)
        {
            Deck.AddCard(Card.Ace);
            UpdateScreen();
        }

        private void AcePlayerButton_Click(object sender, RoutedEventArgs e)
        {
            Deck.RemoveCard(Card.Ace);
            PlayerHand.AddCard(Card.Ace);
            UpdateScreen();
        }

        private void AceRemoveButton_Click(object sender, RoutedEventArgs e)
        {
            Deck.RemoveCard(Card.Ace);
            UpdateScreen();
        }

        private void AceDealerButton_Click(object sender, RoutedEventArgs e)
        {
            Deck.RemoveCard(Card.Ace);
            DealerHand.AddCard(Card.Ace);
            UpdateScreen();
        }

        private void TwoAddButton_Click(object sender, RoutedEventArgs e)
        {
            Deck.AddCard(Card.Two);
            UpdateScreen();
        }

        private void TwoPlayerButton_Click(object sender, RoutedEventArgs e)
        {
            Deck.RemoveCard(Card.Two);
            PlayerHand.AddCard(Card.Two);
            UpdateScreen();
        }

        private void TwoRemoveButton_Click(object sender, RoutedEventArgs e)
        {
            Deck.RemoveCard(Card.Two);
            UpdateScreen();
        }

        private void TwoDealerButton_Click(object sender, RoutedEventArgs e)
        {
            Deck.RemoveCard(Card.Two);
            DealerHand.AddCard(Card.Two);
            UpdateScreen();
        }

        private void ThreeAddButton_Click(object sender, RoutedEventArgs e)
        {
            Deck.AddCard(Card.Three);
            UpdateScreen();
        }

        private void ThreePlayerButton_Click(object sender, RoutedEventArgs e)
        {
            Deck.RemoveCard(Card.Three);
            PlayerHand.AddCard(Card.Three);
            UpdateScreen();
        }

        private void ThreeRemoveButton_Click(object sender, RoutedEventArgs e)
        {
            Deck.RemoveCard(Card.Three);
            UpdateScreen();
        }

        private void ThreeDealerButton_Click(object sender, RoutedEventArgs e)
        {
            Deck.RemoveCard(Card.Three);
            DealerHand.AddCard(Card.Three);
            UpdateScreen();
        }

        private void FourAddButton_Click(object sender, RoutedEventArgs e)
        {
            Deck.AddCard(Card.Four);
            UpdateScreen();
        }

        private void FourPlayerButton_Click(object sender, RoutedEventArgs e)
        {
            Deck.RemoveCard(Card.Four);
            PlayerHand.AddCard(Card.Four);
            UpdateScreen();
        }

        private void FourRemoveButton_Click(object sender, RoutedEventArgs e)
        {
            Deck.RemoveCard(Card.Four);
            UpdateScreen();
        }

        private void FourDealerButton_Click(object sender, RoutedEventArgs e)
        {
            Deck.RemoveCard(Card.Four);
            DealerHand.AddCard(Card.Four);
            UpdateScreen();
        }

        private void FiveAddButton_Click(object sender, RoutedEventArgs e)
        {
            Deck.AddCard(Card.Five);
            UpdateScreen();
        }

        private void FivePlayerButton_Click(object sender, RoutedEventArgs e)
        {
            Deck.RemoveCard(Card.Five);
            PlayerHand.AddCard(Card.Five);
            UpdateScreen();
        }

        private void FiveRemoveButton_Click(object sender, RoutedEventArgs e)
        {
            Deck.RemoveCard(Card.Five);
            UpdateScreen();
        }

        private void FiveDealerButton_Click(object sender, RoutedEventArgs e)
        {
            Deck.RemoveCard(Card.Five);
            DealerHand.AddCard(Card.Five);
            UpdateScreen();
        }

        private void SixAddButton_Click(object sender, RoutedEventArgs e)
        {
            Deck.AddCard(Card.Six);
            UpdateScreen();
        }

        private void SixPlayerButton_Click(object sender, RoutedEventArgs e)
        {
            Deck.RemoveCard(Card.Six);
            PlayerHand.AddCard(Card.Six);
            UpdateScreen();
        }

        private void SixRemoveButton_Click(object sender, RoutedEventArgs e)
        {
            Deck.RemoveCard(Card.Six);
            UpdateScreen();
        }

        private void SixDealerButton_Click(object sender, RoutedEventArgs e)
        {
            Deck.RemoveCard(Card.Six);
            DealerHand.AddCard(Card.Six);
            UpdateScreen();
        }

        private void SevenAddButton_Click(object sender, RoutedEventArgs e)
        {
            Deck.AddCard(Card.Seven);
            UpdateScreen();
        }

        private void SevenPlayerButton_Click(object sender, RoutedEventArgs e)
        {
            Deck.RemoveCard(Card.Seven);
            PlayerHand.AddCard(Card.Seven);
            UpdateScreen();
        }

        private void SevenRemoveButton_Click(object sender, RoutedEventArgs e)
        {
            Deck.RemoveCard(Card.Seven);
            UpdateScreen();
        }

        private void SevenDealerButton_Click(object sender, RoutedEventArgs e)
        {
            Deck.RemoveCard(Card.Seven);
            DealerHand.AddCard(Card.Seven);
            UpdateScreen();
        }

        private void EightAddButton_Click(object sender, RoutedEventArgs e)
        {
            Deck.AddCard(Card.Eight);
            UpdateScreen();
        }

        private void EightPlayerButton_Click(object sender, RoutedEventArgs e)
        {
            Deck.RemoveCard(Card.Eight);
            PlayerHand.AddCard(Card.Eight);
            UpdateScreen();
        }

        private void EightRemoveButton_Click(object sender, RoutedEventArgs e)
        {
            Deck.RemoveCard(Card.Eight);
            UpdateScreen();
        }

        private void EightDealerButton_Click(object sender, RoutedEventArgs e)
        {
            Deck.RemoveCard(Card.Eight);
            DealerHand.AddCard(Card.Eight);
            UpdateScreen();
        }

        private void NineAddButton_Click(object sender, RoutedEventArgs e)
        {
            Deck.AddCard(Card.Nine);
            UpdateScreen();
        }

        private void NinePlayerButton_Click(object sender, RoutedEventArgs e)
        {
            Deck.RemoveCard(Card.Nine);
            PlayerHand.AddCard(Card.Nine);
            UpdateScreen();
        }

        private void NineRemoveButton_Click(object sender, RoutedEventArgs e)
        {
            Deck.RemoveCard(Card.Nine);
            UpdateScreen();
        }

        private void NineDealerButton_Click(object sender, RoutedEventArgs e)
        {
            Deck.RemoveCard(Card.Nine);
            DealerHand.AddCard(Card.Nine);
            UpdateScreen();
        }

        private void TenAddButton_Click(object sender, RoutedEventArgs e)
        {
            Deck.AddCard(Card.Ten);
            UpdateScreen();
        }

        private void TenPlayerButton_Click(object sender, RoutedEventArgs e)
        {
            Deck.RemoveCard(Card.Ten);
            PlayerHand.AddCard(Card.Ten);
            UpdateScreen();
        }

        private void TenRemoveButton_Click(object sender, RoutedEventArgs e)
        {
            Deck.RemoveCard(Card.Ten);
            UpdateScreen();
        }

        private void TenDealerButton_Click(object sender, RoutedEventArgs e)
        {
            Deck.RemoveCard(Card.Ten);
            DealerHand.AddCard(Card.Ten);
            UpdateScreen();
        }

        private void NextDealButton_Click(object sender, RoutedEventArgs e)
        {
            PlayerHand.Reset();
            DealerHand.Reset();
            UpdateScreen();
        }

        private void DeckResetButton_Click(object sender, RoutedEventArgs e)
        {
            Deck.Reset();
            UpdateScreen();
        }

        private void SimulateButton_Click(object sender, RoutedEventArgs e)
        {
            Tuple<int, bool> playerState = new(PlayerHand.Point, PlayerHand.IsSoft);
            Dictionary<int, double> eachPointPlayerProbability = new() { { 17, 0 }, { 18, 0 }, { 19, 0 }, { 20, 0 }, { 21, 0 } };
            foreach (KeyValuePair<Tuple<CardDictionary, int, int, bool>, int> playerCardDictionaryData in MainWindow.EachStateTargetAndOverPlayerCardDictionaries[playerState])
            {
                for (int point = playerCardDictionaryData.Key.Item2; point <= playerCardDictionaryData.Key.Item3; point++)
                    eachPointPlayerProbability[point] += Deck.GetProbability(playerCardDictionaryData.Key.Item1) * playerCardDictionaryData.Value;
            }
            PlayerSeventeenAndOverTextBlock.Text = (eachPointPlayerProbability[17] * 100).ToString("0.000") + "%";
            PlayerEighteenAndOverTextBlock.Text = (eachPointPlayerProbability[18] * 100).ToString("0.000") + "%";
            PlayerNineteenAndOverTextBlock.Text = (eachPointPlayerProbability[19] * 100).ToString("0.000") + "%";
            PlayerTwentyAndOverTextBlock.Text = (eachPointPlayerProbability[20] * 100).ToString("0.000") + "%";
            PlayerTwentyOneAndOverTextBlock.Text = (eachPointPlayerProbability[21] * 100).ToString("0.000") + "%";
            if (PlayerHand.IsSoft)
                PlayerBustTextBlock.Text = "0%";
            else
            {
                double bustProbability = 0;
                for (int i = 10; i > 21 - PlayerHand.Point; i--)
                    bustProbability += Deck.GetCardProbability((Card)Enum.ToObject(typeof(Card), i));
                PlayerBustTextBlock.Text = (bustProbability * 100).ToString("0.000") + "%";
            }

            Tuple<int, bool> dealerState = new(DealerHand.Point, DealerHand.IsSoft);
            Dictionary<int, double> eachPointDealerProbability = new() { { 17, 0 }, { 18, 0 }, { 19, 0 }, { 20, 0 }, { 21, 0 }, { 22, 0} };
            foreach (KeyValuePair<Tuple<CardDictionary, int, bool>, int> dealerCardDictionaryData in MainWindow.EachStateDealerCardDictionaries[dealerState])
                eachPointDealerProbability[dealerCardDictionaryData.Key.Item2] += Deck.GetProbability(dealerCardDictionaryData.Key.Item1) * dealerCardDictionaryData.Value;
            DealerSeventeenAndOverTextBlock.Text = (eachPointDealerProbability[17] * 100).ToString("0.000") + "%";
            DealerEighteenAndOverTextBlock.Text = (eachPointDealerProbability[18] * 100).ToString("0.000") + "%";
            DealerNineteenAndOverTextBlock.Text = (eachPointDealerProbability[19] * 100).ToString("0.000") + "%";
            DealerTwentyAndOverTextBlock.Text = (eachPointDealerProbability[20] * 100).ToString("0.000") + "%";
            DealerTwentyOneAndOverTextBlock.Text = (eachPointDealerProbability[21] * 100).ToString("0.000") + "%";
            DealerBustTextBlock.Text = (eachPointDealerProbability[22] * 100).ToString("0.000") + "%";
        }

        private void PlayerAndDealerResetButton_Click(object sender, RoutedEventArgs e)
        {
            PlayerHand.Reset();
            DealerHand.Reset();
            UpdateScreen();
        }
    }
}
