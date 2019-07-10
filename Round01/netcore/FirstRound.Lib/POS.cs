using System;
using System.Collections.Generic;
using System.Text;

namespace FirstRound.Lib
{
    public class POS : IVerySimplePOS
    {
        public int ComputeChange(double totalAmount, double customerPayment)
        {
            var changeInSatang = (customerPayment - totalAmount) * 100;
            if (changeInSatang % 25 != 0)
            {
                changeInSatang = changeInSatang + (25 - (changeInSatang % 25));
            }

            return Convert.ToInt32(changeInSatang);
        }

        public ChangeSolution GetChangeBankNotesAndCoins(int changeInSatang)
        {
            var change = new ChangeSolution();
            if (changeInSatang != 0)
            {
                change.HasChange = true;
                change.RoundedChange = Convert.ToDouble(changeInSatang) / 100;
                change.BankNotesAndCoins = new Dictionary<BankNotesAndCoinsInSatang, int>();
                int[] a = exchange(change.RoundedChange);
                if (a[0] > 0) change.BankNotesAndCoins.Add(BankNotesAndCoinsInSatang.Thousand, a[0]);
                if (a[1] > 0) change.BankNotesAndCoins.Add(BankNotesAndCoinsInSatang.FiveHundreds, a[1]);
                if (a[2] > 0) change.BankNotesAndCoins.Add(BankNotesAndCoinsInSatang.Hundred, a[2]);
                if (a[3] > 0) change.BankNotesAndCoins.Add(BankNotesAndCoinsInSatang.Fifty, a[3]);
                if (a[4] > 0) change.BankNotesAndCoins.Add(BankNotesAndCoinsInSatang.Twenty, a[4]);
                if (a[5] > 0) change.BankNotesAndCoins.Add(BankNotesAndCoinsInSatang.Ten, a[5]);
                if (a[6] > 0) change.BankNotesAndCoins.Add(BankNotesAndCoinsInSatang.Five, a[6]);
                if (a[7] > 0) change.BankNotesAndCoins.Add(BankNotesAndCoinsInSatang.One, a[7]);
                if (a[8] > 0) change.BankNotesAndCoins.Add(BankNotesAndCoinsInSatang.Fiftieth, a[8]);
                if (a[9] > 0) change.BankNotesAndCoins.Add(BankNotesAndCoinsInSatang.TwentyFifth, a[9]);
                
                //     { BankNotesAndCoinsInSatang.Thousand, a[0]},
                //     { BankNotesAndCoinsInSatang.FiveHundreds, a[1]},
                //     { BankNotesAndCoinsInSatang.Hundred, a[2]},
                //     { BankNotesAndCoinsInSatang.Fifty, a[3]},
                //     { BankNotesAndCoinsInSatang.Twenty, a[4]},
                //     { BankNotesAndCoinsInSatang.Ten, a[5]},
                //     { BankNotesAndCoinsInSatang.Five, a[6]},
                //     { BankNotesAndCoinsInSatang.One, a[7]},
                //     { BankNotesAndCoinsInSatang.Fiftieth, a[8]},
                //     { BankNotesAndCoinsInSatang.TwentyFifth, a[9]},
               
            }

            return change;

        }

        public int[] exchange(double input)
        {
            int[] t = new int[10];
            double[] Banknotes = { 1000, 500, 100, 50, 20, 10, 5, 1, 0.5, 0.25 };
            for (int i = 0; i < Banknotes.Length; i++)
            {
                if (input >= Banknotes[i])
                {
                    t[i] = (int)Math.Floor( input / Banknotes[i]);
                    input = input % Banknotes[i];
                }
            }
            return t;
        }
    }
}
