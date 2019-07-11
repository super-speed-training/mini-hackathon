﻿using FirstRound.Lib;
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
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var verySimple = new VerySimplePOS();
            if (double.TryParse(Amount.Text, out double amount) && double.TryParse(Pay.Text, out double pay))
            {
                var change = verySimple.ComputeChange(amount, pay);
                if (change < 0)
                {
                    status.Text = "จำนวนเงินไม่พอจ่าย";
                }
                else
                {
                    status.Text = "จำนวนเงินที่จ่ายพอ";
                    var result = verySimple.GetChangeBankNotesAndCoins(change);
                    Change.Text = result.RoundedChange.ToString();
                    int value = 0;
                    if (result.BankNotesAndCoins.TryGetValue(BankNotesAndCoinsInSatang.Thousand, out value)) Thoundsand.Text = value.ToString();
                    if (result.BankNotesAndCoins.TryGetValue(BankNotesAndCoinsInSatang.FiveHundreds, out value)) FiveHundreds.Text = value.ToString();
                    if (result.BankNotesAndCoins.TryGetValue(BankNotesAndCoinsInSatang.Hundred, out value)) Hundred.Text = value.ToString();
                    if (result.BankNotesAndCoins.TryGetValue(BankNotesAndCoinsInSatang.Fifty, out value)) Fifty.Text = value.ToString();
                    if (result.BankNotesAndCoins.TryGetValue(BankNotesAndCoinsInSatang.Twenty, out value)) Twenty.Text = value.ToString();
                    if (result.BankNotesAndCoins.TryGetValue(BankNotesAndCoinsInSatang.Ten, out value)) Ten.Text = value.ToString();
                    if (result.BankNotesAndCoins.TryGetValue(BankNotesAndCoinsInSatang.Five, out value)) Five.Text = value.ToString();
                    if (result.BankNotesAndCoins.TryGetValue(BankNotesAndCoinsInSatang.One, out value)) One.Text = value.ToString();
                    if (result.BankNotesAndCoins.TryGetValue(BankNotesAndCoinsInSatang.Fiftieth, out value)) Fiftieth.Text = value.ToString();
                    if (result.BankNotesAndCoins.TryGetValue(BankNotesAndCoinsInSatang.TwentyFifth, out value)) TwentyFifth.Text = value.ToString();
                }
            }
            else
            {
                status.Text = "กรุณากรอกจำนวนเงินให้ถูกต้อง";
            }
        }

        private void Button_Reset_Click(object sender, RoutedEventArgs e)
        {
            Amount.Text = Pay.Text = status.Text = Change.Text = Thoundsand.Text =
                FiveHundreds.Text = Hundred.Text = Fifty.Text = Twenty.Text = Ten.Text =
                Five.Text = One.Text = Fiftieth.Text = TwentyFifth.Text = "";
        }

        private void TextBlock_SelectionChanged(object sender, RoutedEventArgs e)
        {

        }

        private void TextBlock_SelectionChanged_1(object sender, RoutedEventArgs e)
        {

        }

        private void TextBlock_SelectionChanged_2(object sender, RoutedEventArgs e)
        {

        }
    }
}
