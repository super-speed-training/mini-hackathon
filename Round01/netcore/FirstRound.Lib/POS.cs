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
                change.RoundedChange = changeInSatang/100;
                change.BankNotesAndCoins = new Dictionary<BankNotesAndCoinsInSatang, int>
                    {
                        { BankNotesAndCoinsInSatang.Hundred, 4 },
                        { BankNotesAndCoinsInSatang.Twenty, 2 },
                        { BankNotesAndCoinsInSatang.Five, 1 },
                        { BankNotesAndCoinsInSatang.One, 3 },
                    };
            }


            return change;

        }
    }
}
