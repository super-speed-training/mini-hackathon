using FirstRound.Lib;
using System;
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
        private readonly IVerySimplePOS sut;

        public MainPage()
        {
            sut = new VerySimplePOS();
            this.InitializeComponent();
            MoneyChangeResult.Text = "";
            countThousand.Text = "";
            countFiveHundred.Text = "";
            countHundred.Text = "";
            countFifty.Text = "";
            countTwenty.Text = "";
            countTen.Text = "";
            countFive.Text = "";
            countOne.Text = "";
            countTwentyFiveStang.Text = "";
            countFiftyStang.Text = "";
            StatusChange.Text = "";
        }

        private void Calculate_Click(object sender, RoutedEventArgs e)
        {
            var IsValidatePrice = Double.TryParse(InputPrice.Text, out var price);
            var IsValidateCustomerPay = Double.TryParse(InputCustomerPay.Text, out var customerPay);
            var change = sut.ComputeChange(price, customerPay);
            var result = sut.GetChangeBankNotesAndCoins(change);
            result.BankNotesAndCoins.TryGetValue(BankNotesAndCoinsInSatang.Thousand, out var Thousand);
            result.BankNotesAndCoins.TryGetValue(BankNotesAndCoinsInSatang.FiveHundreds, out var FiveHundred);
            result.BankNotesAndCoins.TryGetValue(BankNotesAndCoinsInSatang.Hundred, out var Hundred);
            result.BankNotesAndCoins.TryGetValue(BankNotesAndCoinsInSatang.Fifty, out var Fifty);
            result.BankNotesAndCoins.TryGetValue(BankNotesAndCoinsInSatang.Twenty, out var Twenty);
            result.BankNotesAndCoins.TryGetValue(BankNotesAndCoinsInSatang.Ten, out var Ten);
            result.BankNotesAndCoins.TryGetValue(BankNotesAndCoinsInSatang.Five, out var Five);
            result.BankNotesAndCoins.TryGetValue(BankNotesAndCoinsInSatang.One, out var One);
            result.BankNotesAndCoins.TryGetValue(BankNotesAndCoinsInSatang.TwentyFifth, out var TwentyFiveStang);
            result.BankNotesAndCoins.TryGetValue(BankNotesAndCoinsInSatang.Fiftieth, out var FiftyStang);
            if (IsValidatePrice && IsValidateCustomerPay && price >=0 && customerPay >= 0 && customerPay >= price)
            {
                MoneyChangeResult.Text = result.RoundedChange.ToString();
                countThousand.Text = Thousand.ToString();
                countFiveHundred.Text = FiveHundred.ToString();
                countHundred.Text = Hundred.ToString();
                countFifty.Text = Fifty.ToString();
                countTwenty.Text = Twenty.ToString();
                countTen.Text = Ten.ToString();
                countFive.Text = Five.ToString();
                countOne.Text = One.ToString();
                countTwentyFiveStang.Text = TwentyFiveStang.ToString();
                countFiftyStang.Text = FiftyStang.ToString();
                StatusChange.Text = "จ่ายเงินเรียบร้อย";
            }
            else
            {
                MoneyChangeResult.Text = "";
                countThousand.Text = "";
                countFiveHundred.Text = "";
                countHundred.Text = "";
                countFifty.Text = "";
                countTwenty.Text = "";
                countTen.Text = "";
                countFive.Text = "";
                countOne.Text = "";
                countTwentyFiveStang.Text = "";
                countFiftyStang.Text = "";
                StatusChange.Text = "";
                StatusChange.Text = "กรอกจำนวนเงินไม่ถูกต้อง";
            }
            
        }

    }
}
