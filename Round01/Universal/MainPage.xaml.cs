using FirstRound.Lib;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Universal
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

        private void button_Click(object sender, RoutedEventArgs e)
        {
            var result = new VerySimplePOS();
            var checkStringP = double.TryParse(inputPrice.Text, out var price);
            var checkStringM = double.TryParse(inputMoney.Text, out var money);
            textshow1.Text = "";

            if (!checkStringM || !checkStringP)
            {
                textshow1.Text = "ใส่ตัวเลขฟร้ะะะะะ 55555";
            }
            else if (money >= price)
            {
                var chanheSatang = result.ComputeChange(price, money);
                var textP = result.GetChangeBankNotesAndCoins(chanheSatang);

                textP.BankNotesAndCoins.TryGetValue(BankNotesAndCoinsInSatang.Thousand, out var textThousand);
                textP.BankNotesAndCoins.TryGetValue(BankNotesAndCoinsInSatang.FiveHundreds, out var textFiveHundreds);
                textP.BankNotesAndCoins.TryGetValue(BankNotesAndCoinsInSatang.Hundred, out var textOneHundreds);
                textP.BankNotesAndCoins.TryGetValue(BankNotesAndCoinsInSatang.Fifty, out var textFiftyHundreds);
                textP.BankNotesAndCoins.TryGetValue(BankNotesAndCoinsInSatang.Twenty, out var textTwenty);
                textP.BankNotesAndCoins.TryGetValue(BankNotesAndCoinsInSatang.Ten, out var textTen);
                textP.BankNotesAndCoins.TryGetValue(BankNotesAndCoinsInSatang.Five, out var textFive);
                textP.BankNotesAndCoins.TryGetValue(BankNotesAndCoinsInSatang.One, out var textOne);
                textP.BankNotesAndCoins.TryGetValue(BankNotesAndCoinsInSatang.Fiftieth, out var textFiftieth);
                textP.BankNotesAndCoins.TryGetValue(BankNotesAndCoinsInSatang.TwentyFifth, out var textTwentyFifth);

                inputPrice_1000.Text = textThousand.ToString();
                inputPrice_500.Text = textFiveHundreds.ToString();
                inputPrice_100.Text = textOneHundreds.ToString();
                inputPrice_50.Text = textFiftyHundreds.ToString();
                inputPrice_20.Text = textTwenty.ToString();
                inputPrice_10.Text = textTen.ToString();
                inputPrice_5.Text = textFive.ToString();
                inputPrice_1.Text = textOne.ToString();
                inputPrice_050.Text = textFiftieth.ToString();
                inputPrice_025.Text = textTwentyFifth.ToString();
                tbChange.Text = textP.RoundedChange.ToString();

                textshow1.Text = "จ่ายเงินเรียบร้อย จ้าาาา ";
            }
            else if(money <= 0 || price <= 0 || money < price)
            {
                textshow1.Text = "เงินติดลบ นะจ้ะ 55555";
            }

        }

        private void TextBlock_SelectionChanged(object sender, RoutedEventArgs e)
        {

        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void TextBlock_SelectionChanged_1(object sender, RoutedEventArgs e)
        {

        }
    }
}
