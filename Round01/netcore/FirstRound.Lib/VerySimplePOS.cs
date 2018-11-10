using System;
using System.Collections.Generic;
using System.Text;

namespace FirstRound.Lib
{
    public class VerySimplePOS : IVerySimplePOS
    {
        public int ComputeChange(double totalAmount, double customerPayment)
        {
            var oneBath = 100;
            var twentyFifthSatang = 25;
            int result = (int)((customerPayment - totalAmount) * oneBath);
            if (result % twentyFifthSatang != 0) result += twentyFifthSatang - result % twentyFifthSatang;
            return result;
        }

        public ChangeSolution GetChangeBankNotesAndCoins(int changeInSatang)
        {
            var result = new ChangeSolution() { BankNotesAndCoins = new Dictionary<BankNotesAndCoinsInSatang, int>() };

            int thousnd, fiveHundreds, oneHundreds, fifty, twenty, ten,
                five, one, fiftieth, twentyFifth;

            if (changeInSatang <= 0)
            {
                result.HasChange = false;
                result.RoundedChange = 0;

            }
            else
            {
                result.HasChange = true;
                result.RoundedChange = changeInSatang / 100.00;

                if (changeInSatang >= 100000)
                {
                    thousnd = changeInSatang / 100000;
                    result.BankNotesAndCoins.Add(BankNotesAndCoinsInSatang.Thousand, thousnd);
                    changeInSatang = changeInSatang - (thousnd * 100000);
                }

                if (changeInSatang >= 50000)
                {
                    fiveHundreds = changeInSatang / 50000;
                    result.BankNotesAndCoins.Add(BankNotesAndCoinsInSatang.FiveHundreds, fiveHundreds);
                    changeInSatang = changeInSatang - (fiveHundreds * 50000);
                }
                if (changeInSatang >= 10000)
                {
                    oneHundreds = changeInSatang / 10000;
                    result.BankNotesAndCoins.Add(BankNotesAndCoinsInSatang.Hundred, oneHundreds);
                    changeInSatang = changeInSatang - (oneHundreds * 10000);
                }
                if (changeInSatang >= 5000)
                {
                    fifty = changeInSatang / 5000;
                    result.BankNotesAndCoins.Add(BankNotesAndCoinsInSatang.Fifty, fifty);
                    changeInSatang = changeInSatang - (fifty * 5000);
                }
                if (changeInSatang >= 2000)
                {
                    twenty = changeInSatang / 2000;
                    result.BankNotesAndCoins.Add(BankNotesAndCoinsInSatang.Twenty, twenty);
                    changeInSatang = changeInSatang - (twenty * 2000);
                }
                if (changeInSatang >= 1000)
                {
                    ten = changeInSatang / 1000;
                    result.BankNotesAndCoins.Add(BankNotesAndCoinsInSatang.Ten, ten);
                    changeInSatang = changeInSatang - (ten * 1000);
                }
                if (changeInSatang >= 500)
                {
                    five = changeInSatang / 500;
                    result.BankNotesAndCoins.Add(BankNotesAndCoinsInSatang.Five, five);
                    changeInSatang = changeInSatang - (five * 500);
                }
                if (changeInSatang >= 100)
                {
                    one = changeInSatang / 100;
                    result.BankNotesAndCoins.Add(BankNotesAndCoinsInSatang.One, one);
                    changeInSatang = changeInSatang - (one * 100);
                }
                if (changeInSatang >= 50)
                {
                    fiftieth = changeInSatang / 50;
                    result.BankNotesAndCoins.Add(BankNotesAndCoinsInSatang.Fiftieth, fiftieth);
                    changeInSatang = changeInSatang - (fiftieth * 50);
                }
                if (changeInSatang >= 25)
                {
                    twentyFifth = changeInSatang / 25;
                    result.BankNotesAndCoins.Add(BankNotesAndCoinsInSatang.TwentyFifth, twentyFifth);
                    changeInSatang = changeInSatang - (twentyFifth * 25);
                }
            }

            return result;

        }

        //private void ComputeBankNote(BankNotesAndCoinsInSatang BankNote, )
        //{
        //}
    }
}
