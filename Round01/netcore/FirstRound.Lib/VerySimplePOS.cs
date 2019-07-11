using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace FirstRound.Lib
{
    public class VerySimplePOS : IVerySimplePOS
    {
        public int ComputeChange(double totalAmount, double customerPayment)
        {
            var result = customerPayment - totalAmount;
            var satang = (result - Math.Floor(result)) * 100;
            if (satang > 75)
            {
                satang = 100;
            }
            else if (satang > 50)
            {
                satang = 75;
            }
            else if (satang > 25)
            {
                satang = 50;
            }
            else if (satang > 0)
            {
                satang = 25;
            }
            result = Math.Floor(result) * 100 + satang;

            return (int)result;
        }

        public ChangeSolution GetChangeBankNotesAndCoins(int changeInSatang)
        {
            var result = new ChangeSolution();
            result.HasChange = (changeInSatang >= 0) ? true : false;
            result.RoundedChange = (double)changeInSatang / 100;
            result.BankNotesAndCoins = new Dictionary<BankNotesAndCoinsInSatang,int>();

            var roundedChange = result.RoundedChange;

            if (roundedChange >= 1000)
            {
                var amount = (int)roundedChange / 1000;
                roundedChange -= 1000 * amount;
                result.BankNotesAndCoins.Add(BankNotesAndCoinsInSatang.Thousand, amount);
            }
            if (roundedChange >= 500)
            {
                var amount = (int)roundedChange / 500;
                roundedChange -= 500 * amount;
                result.BankNotesAndCoins.Add(BankNotesAndCoinsInSatang.FiveHundreds, amount);
            }
            if (roundedChange >= 100)
            {
                var amount = (int)roundedChange / 100;
                roundedChange -= 100 * amount;
                result.BankNotesAndCoins.Add(BankNotesAndCoinsInSatang.Hundred, amount);
            }
            if (roundedChange >= 50)
            {
                var amount = (int)roundedChange / 50;
                roundedChange -= 50 * amount;
                result.BankNotesAndCoins.Add(BankNotesAndCoinsInSatang.Fifty, amount);
            }
            if (roundedChange >= 20)
            {
                var amount = (int)roundedChange / 20;
                roundedChange -= 20 * amount;
                result.BankNotesAndCoins.Add(BankNotesAndCoinsInSatang.Twenty, amount);
            }
            if (roundedChange >= 10)
            {
                var amount = (int)roundedChange / 10;
                roundedChange -= 10 * amount;
                result.BankNotesAndCoins.Add(BankNotesAndCoinsInSatang.Ten, amount);
            }
            if (roundedChange >= 5)
            {
                var amount = (int)roundedChange / 5;
                roundedChange -= 5 * amount;
                result.BankNotesAndCoins.Add(BankNotesAndCoinsInSatang.Five, amount);
            }
            if (roundedChange >= 1)
            {
                var amount = (int)roundedChange / 1;
                roundedChange -= 1 * amount;
                result.BankNotesAndCoins.Add(BankNotesAndCoinsInSatang.One, amount);
            }
            roundedChange *= 100;
            if (roundedChange >= 50)
            {
                var amount = (int)roundedChange / 50;
                roundedChange -= 50 * amount;
                result.BankNotesAndCoins.Add(BankNotesAndCoinsInSatang.Fiftieth, amount);
            }
            if (roundedChange >= 25)
            {
                var amount = (int)roundedChange / 25;
                roundedChange -= 25 * amount;
                result.BankNotesAndCoins.Add(BankNotesAndCoinsInSatang.TwentyFifth, amount);
            }

            return result;
        }
    }
}
