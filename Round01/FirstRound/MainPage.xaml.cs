using FirstRound.Lib;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

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

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            var Res = new POS();
            double Amount = Convert.ToDouble(AmountInput.Text);
            double Payment = Convert.ToDouble(PaymentInput.Text);
            if (Amount <= 0 || Payment <= 0)
            {
                var msg = new MessageDialog("จ่ายเงินติดลบไม่ได้โว้ยยยยยยยยยย");
                await msg.ShowAsync();
            }
            else if (Amount == Payment)
            {
                ChangeText.Text = "จ่ายพอดี ไม่มีทอน";
            }
            else if (Amount > Payment)
            {
                var msg = new MessageDialog("จ่ายเงินให้มากกว่าราคาสินค้าสิจ๊ะ");
                await msg.ShowAsync();
            }
            else
            {
                var resuly = Res.ComputeChange(Amount, Payment);
                var Change = Res.GetChangeBankNotesAndCoins(resuly);
                ChangeText.Text = Change.RoundedChange.ToString();
                if (Change.BankNotesAndCoins.ContainsKey(BankNotesAndCoinsInSatang.Thousand))
                {
                    Thousand.Text = Change.BankNotesAndCoins[BankNotesAndCoinsInSatang.Thousand].ToString();
                }
                if (Change.BankNotesAndCoins.ContainsKey(BankNotesAndCoinsInSatang.FiveHundreds))
                {
                    FiveHundreds.Text = Change.BankNotesAndCoins[BankNotesAndCoinsInSatang.FiveHundreds].ToString();
                }
                if (Change.BankNotesAndCoins.ContainsKey(BankNotesAndCoinsInSatang.Hundred))
                {
                    Hundred.Text = Change.BankNotesAndCoins[BankNotesAndCoinsInSatang.Hundred].ToString();
                }
                if (Change.BankNotesAndCoins.ContainsKey(BankNotesAndCoinsInSatang.Fifty))
                {
                    Fifty.Text = Change.BankNotesAndCoins[BankNotesAndCoinsInSatang.Fifty].ToString();
                }
                if (Change.BankNotesAndCoins.ContainsKey(BankNotesAndCoinsInSatang.Twenty))
                {
                    Twenty.Text = Change.BankNotesAndCoins[BankNotesAndCoinsInSatang.Twenty].ToString();
                }
                if (Change.BankNotesAndCoins.ContainsKey(BankNotesAndCoinsInSatang.Ten))
                {
                    Ten.Text = Change.BankNotesAndCoins[BankNotesAndCoinsInSatang.Ten].ToString();
                }
                if (Change.BankNotesAndCoins.ContainsKey(BankNotesAndCoinsInSatang.Five))
                {
                    Five.Text = Change.BankNotesAndCoins[BankNotesAndCoinsInSatang.Five].ToString();
                }
                if (Change.BankNotesAndCoins.ContainsKey(BankNotesAndCoinsInSatang.One))
                {
                    One.Text = Change.BankNotesAndCoins[BankNotesAndCoinsInSatang.One].ToString();
                }
                if (Change.BankNotesAndCoins.ContainsKey(BankNotesAndCoinsInSatang.Fiftieth))
                {
                    Fiftieth.Text = Change.BankNotesAndCoins[BankNotesAndCoinsInSatang.Fiftieth].ToString();
                }
                if (Change.BankNotesAndCoins.ContainsKey(BankNotesAndCoinsInSatang.TwentyFifth))
                {
                    TwentyFifth.Text = Change.BankNotesAndCoins[BankNotesAndCoinsInSatang.TwentyFifth].ToString();
                }
            }

        }
    }
}
