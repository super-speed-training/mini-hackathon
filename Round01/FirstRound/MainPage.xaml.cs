using FirstRound.Lib;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace FirstRound
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ResetBankNotes();

            var ui = new VerySimplePOS();

            var amount = 0.0;
            var pay = 0.0;
            var canParseAmount = double.TryParse(Amount.Text, out amount);
            var canParsePay = double.TryParse(Pay.Text, out pay);

            if (canParseAmount && canParsePay)
            {
                var change = ui.ComputeChange(amount, pay);
                var result = ui.GetChangeBankNotesAndCoins(change);

                Change.Text = result.RoundedChange.ToString("0.00");
                int value = 0;

                ResultGrid.Visibility = Visibility.Visible;

                if (result.BankNotesAndCoins.TryGetValue(BankNotesAndCoinsInSatang.Thousand, out value)) Thoundsand.Text = value.ToString("0.00");
                if (result.BankNotesAndCoins.TryGetValue(BankNotesAndCoinsInSatang.FiveHundreds, out value)) FiveHundreds.Text = value.ToString("0.00");
                if (result.BankNotesAndCoins.TryGetValue(BankNotesAndCoinsInSatang.Hundred, out value)) Hundred.Text = value.ToString("0.00");
                if (result.BankNotesAndCoins.TryGetValue(BankNotesAndCoinsInSatang.Fifty, out value)) Fifty.Text = value.ToString("0.00");
                if (result.BankNotesAndCoins.TryGetValue(BankNotesAndCoinsInSatang.Twenty, out value)) Twenty.Text = value.ToString("0.00");
                if (result.BankNotesAndCoins.TryGetValue(BankNotesAndCoinsInSatang.Ten, out value)) Ten.Text = value.ToString("0.00");
                if (result.BankNotesAndCoins.TryGetValue(BankNotesAndCoinsInSatang.Five, out value)) Five.Text = value.ToString("0.00");
                if (result.BankNotesAndCoins.TryGetValue(BankNotesAndCoinsInSatang.One, out value)) One.Text = value.ToString("0.00");
                if (result.BankNotesAndCoins.TryGetValue(BankNotesAndCoinsInSatang.Fiftieth, out value)) Fiftieth.Text = value.ToString("0.00");
                if (result.BankNotesAndCoins.TryGetValue(BankNotesAndCoinsInSatang.TwentyFifth, out value)) TwentyFifth.Text = value.ToString("0.00");
            }
            else
            {
                //TODO: show error message
                Change.Text = "Input error.";
                ResultGrid.Visibility = Visibility.Collapsed;
            }

        }

        private void ResetBankNotes()
        {
            Thoundsand.Text = "";
            FiveHundreds.Text = "";
            Hundred.Text = "";
            Fifty.Text = "";
            Twenty.Text = "";
            Ten.Text = "";
            Five.Text = "";
            One.Text = "";
            Fiftieth.Text = "";
            TwentyFifth.Text = "";
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void TextBox_TextChanged_1(object sender, TextChangedEventArgs e)
        {

        }

        private void Amount_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}