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

            PaymentTextBox.KeyDown += (sender, e) => { if (e.Key == Windows.System.VirtualKey.Enter) Compute(); };
            TotalAmountTextBox.KeyDown += (sender, e) => { if (e.Key == Windows.System.VirtualKey.Enter) Compute(); };
            ComputeButton.Click += (sender, e) => Compute();
        }
        
        private void Compute()
        {
            if (double.TryParse(PaymentTextBox.Text, out double payment) &&
                double.TryParse(TotalAmountTextBox.Text, out double totalAmount))
            {
                const int MinimumValue = 0;
                var isValidateData = payment > MinimumValue && totalAmount > MinimumValue;
                if (!isValidateData)
                {
                    BalanceText.Text = "กรุณากรอกจำนวนเงินที่มากกว่า 0";
                    return;
                }

                var isValidatePayment = payment - totalAmount >= MinimumValue;
                if (!isValidatePayment)
                {
                    BalanceText.Text = "เงินไม่เพียงพอต่อการจ่ายเงิน";
                    return;
                }

                var pos = new VerySimplePOS();
                var result = pos.ComputeChange(totalAmount, payment);
                var resutlInSatang = pos.GetChangeBankNotesAndCoins(result);

                var displayText = "ไม่มีเงินทอน";
                if (resutlInSatang.HasChange)
                {
                    resutlInSatang.BankNotesAndCoins.TryGetValue(BankNotesAndCoinsInSatang.Thousand, out int Thousand);
                    resutlInSatang.BankNotesAndCoins.TryGetValue(BankNotesAndCoinsInSatang.FiveHundreds, out int FiveHundreds);
                    resutlInSatang.BankNotesAndCoins.TryGetValue(BankNotesAndCoinsInSatang.Hundred, out int Hundred);
                    resutlInSatang.BankNotesAndCoins.TryGetValue(BankNotesAndCoinsInSatang.Fifty, out int Fifty);
                    resutlInSatang.BankNotesAndCoins.TryGetValue(BankNotesAndCoinsInSatang.Twenty, out int Twenty);
                    resutlInSatang.BankNotesAndCoins.TryGetValue(BankNotesAndCoinsInSatang.Ten, out int Ten);
                    resutlInSatang.BankNotesAndCoins.TryGetValue(BankNotesAndCoinsInSatang.Five, out int Five);
                    resutlInSatang.BankNotesAndCoins.TryGetValue(BankNotesAndCoinsInSatang.One, out int One);
                    resutlInSatang.BankNotesAndCoins.TryGetValue(BankNotesAndCoinsInSatang.Fiftieth, out int Fiftieth);
                    resutlInSatang.BankNotesAndCoins.TryGetValue(BankNotesAndCoinsInSatang.TwentyFifth, out int TwentyFifth);

                    displayText = $"RoundedChange: {resutlInSatang.RoundedChange}\n" +
                        (Thousand > 0 ? $"\t1000 x {Thousand}\n" : string.Empty) +
                        (FiveHundreds > 0 ? $"\t500 x {FiveHundreds}\n" : string.Empty) +
                        (Hundred > 0 ? $"\t100 x {Hundred}\n" : string.Empty) +
                        (Fifty > 0 ? $"\t50 x {Fifty}\n" : string.Empty) +
                        (Twenty > 0 ? $"\t20 x {Twenty}\n" : string.Empty) +
                        (Ten > 0 ? $"\t10 x {Ten}\n" : string.Empty) +
                        (Five > 0 ? $"\t5 x {Five}\n" : string.Empty) +
                        (One > 0 ? $"\t1 x {One}\n" : string.Empty) +
                        (Fiftieth > 0 ? $"\t0.50 x {Fiftieth}\n" : string.Empty) +
                        (TwentyFifth > 0 ? $"\t0.25 x {TwentyFifth}\n" : string.Empty);
                }
                BalanceText.Text = displayText;
            }
            else
            {
                BalanceText.Text = "กรุณากรอกตัวเลขเท่านั้น";
            }
        }
    }
}
