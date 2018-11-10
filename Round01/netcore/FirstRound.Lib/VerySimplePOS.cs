using System;
using System.Collections.Generic;
using System.Text;

namespace FirstRound.Lib
{
    public class VerySimplePOS : IVerySimplePOS
    {
        public int ComputeChange(double totalAmount, double customerPayment)
        {

            var result = customerPayment - totalAmount;
            var x = result % 1;
            if (x == 0.00)
            {
                var xxx = (Math.Floor(result));
                return (int)(result * 100);
            }
            else if (x > 0.75)
            {
                var xxx = (Math.Ceiling(result));
                return (int)(xxx * 100);
            }
            else if (x <= 0.75 && x > 0.50)
            {
                var xxx = (Math.Floor(result));
                return (int)((xxx + 0.75) * 100);
            }
            else if (x <= 0.50 && x > 0.25)
            {
                var xxx = (Math.Floor(result));
                return (int)((xxx + 0.50) * 100);
            }
            else
            {
                var xxx = (Math.Floor(result));
                return (int)((xxx + 0.25) * 100);
            }


        }

        public ChangeSolution GetChangeBankNotesAndCoins(int changeInSatang)
        {
            var result = new ChangeSolution() { BankNotesAndCoins = new Dictionary<BankNotesAndCoinsInSatang, int>() };
            result.HasChange = true;
            var amount = 0;
            result.RoundedChange = ((double)changeInSatang / 100);
            var sut = result.RoundedChange;
            if (sut >= 1000)
            {

                amount = (int)sut / 1000;
                sut -= amount * 1000;
                result.BankNotesAndCoins.Add(BankNotesAndCoinsInSatang.Thousand, amount);
            }
            if (sut >= 500)
            {
                amount = (int)sut / 500;
                sut -= amount * 500;
                result.BankNotesAndCoins.Add(BankNotesAndCoinsInSatang.FiveHundreds, amount);
            }
            if (sut >= 100)
            {
                amount = (int)sut / 100;
                sut -= amount * 100;
                result.BankNotesAndCoins.Add(BankNotesAndCoinsInSatang.Hundred, amount);
            }
            if (sut >= 50)
            {
                amount = (int)sut / 50;
                sut -= amount * 50;
                result.BankNotesAndCoins.Add(BankNotesAndCoinsInSatang.Fifty, amount);
            }
            if (sut >= 20)
            {
                amount = (int)sut / 20;
                sut -= amount * 20;
                result.BankNotesAndCoins.Add(BankNotesAndCoinsInSatang.Twenty, amount);
            }

            if (sut >= 10)
            {
                amount = (int)sut / 10;
                sut -= amount * 10;
                result.BankNotesAndCoins.Add(BankNotesAndCoinsInSatang.Ten, amount);
            }
            if (sut >= 5)
            {
                amount = (int)sut / 5;
                sut -= amount * 5;
                result.BankNotesAndCoins.Add(BankNotesAndCoinsInSatang.Five, amount);
            }
            if (sut >= 1)
            {
                amount = (int)sut;
                sut -= amount;
                result.BankNotesAndCoins.Add(BankNotesAndCoinsInSatang.One, amount);
            }

            if (sut >= 0.50)
            {
                amount = (int)((sut * 100) / 50);
                sut -= amount * 0.50;
                result.BankNotesAndCoins.Add(BankNotesAndCoinsInSatang.Fiftieth, amount);
            }
            if (sut >= 0.25)
            {
                amount = (int)((sut * 100) / 25);
                sut -= amount * 0.25;
                result.BankNotesAndCoins.Add(BankNotesAndCoinsInSatang.TwentyFifth, amount);
            }
            return result;
        }
    }
}
