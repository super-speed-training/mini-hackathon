using System;
using System.Collections.Generic;

namespace FirstRound.Lib
{
    public class VerySimplePOS : IVerySimplePOS
    {
        public int ComputeChange(double totalAmount, double customerPayment)
        {
            var change = (customerPayment - totalAmount) * 100;
            var changeFinal = change;
            double stang = change % 100;

            if (customerPayment < 0 || totalAmount < 0)
            {
                return 0;
            }
            if (customerPayment < totalAmount)
            {
                return 0;
            }
            if (stang > 0 && stang < 25)
            {
                var newStang = 25;
                changeFinal = change + newStang - stang;
            }
            else if (stang > 25 && stang < 50)
            {
                var newStang = 50;
                changeFinal = change + newStang - stang;
            }
            else if (stang > 50 && stang < 75)
            {
                var newStang = 75;
                changeFinal = change + newStang - stang;
            }
            else if (stang > 75 && stang < 100)
            {
                var newStang = 100;
                changeFinal = change + newStang - stang;
            }
            return (int)changeFinal;
        }

        public ChangeSolution GetChangeBankNotesAndCoins(int changeInSatang)
        {
            var result = new ChangeSolution();
            result.HasChange = true;
            result.RoundedChange = (double)changeInSatang / 100;

            Math.Round(result.RoundedChange, 2);

            var bankLists = new Dictionary<BankNotesAndCoinsInSatang, int>();

            var change = result.RoundedChange;
            var updateChange = change;

            if (change > 1000)
            {
                var thousandBank = updateChange / 1000;
                updateChange = change % 1000;
                bankLists.Add(BankNotesAndCoinsInSatang.Thousand, (int)thousandBank);
            }
            if (updateChange >= 500 && updateChange <= 1000)
            {
                var fiveHundredsBank = updateChange / 500;
                updateChange = updateChange % 500;
                bankLists.Add(BankNotesAndCoinsInSatang.FiveHundreds, (int)fiveHundredsBank);
            }
            if (updateChange >= 100 && updateChange <= 500)
            {
                var hundredsBank = updateChange / 100;
                updateChange = updateChange % 100;
                bankLists.Add(BankNotesAndCoinsInSatang.Hundred, (int)hundredsBank);
            }
            if (updateChange >= 50 && updateChange <= 100)
            {
                var fiftyBank = updateChange / 50;
                updateChange = updateChange % 50;
                bankLists.Add(BankNotesAndCoinsInSatang.Fifty, (int)fiftyBank);
            }
            if (updateChange >= 20 && updateChange <= 50)
            {
                var twentyBank = updateChange / 20;
                updateChange = updateChange % 20;
                bankLists.Add(BankNotesAndCoinsInSatang.Twenty, (int)twentyBank);
            }
            if (updateChange >= 10 && updateChange <= 20)
            {
                var tenCoins = updateChange / 10;
                updateChange = updateChange % 10;
                bankLists.Add(BankNotesAndCoinsInSatang.Ten, (int)tenCoins);
            }
            if (updateChange >= 5 && updateChange <= 10)
            {
                var fivenCoins = updateChange / 5;
                updateChange = updateChange % 5;
                bankLists.Add(BankNotesAndCoinsInSatang.Five, (int)fivenCoins);
            }
            if (updateChange >= 1 && updateChange <= 5)
            {
                var oneCoins = updateChange / 1;
                updateChange = updateChange % 1;
                bankLists.Add(BankNotesAndCoinsInSatang.One, (int)oneCoins);
            }
            if (updateChange >= 0.50 && updateChange <= 1)
            {
                var fiftiethCoins = updateChange / 0.50;
                updateChange = updateChange % 0.50;
                bankLists.Add(BankNotesAndCoinsInSatang.Fiftieth, (int)fiftiethCoins);
            }
            if (updateChange >= 0.25 && updateChange <= 0.50)
            {
                var twentyFifthCoins = updateChange / 0.25;
                updateChange = updateChange % 0.25;
                bankLists.Add(BankNotesAndCoinsInSatang.TwentyFifth, (int)twentyFifthCoins);
            }

            result.BankNotesAndCoins = bankLists;
            return result;
        }
    }
}
