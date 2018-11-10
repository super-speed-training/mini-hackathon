using System;
using System.Collections.Generic;
using System.Text;

namespace FirstRound.Lib
{
    public class VerySimplePOS : IVerySimplePOS
    {
        public int ComputeChange(double totalAmount, double customerPayment)
        {
            var result = (customerPayment - totalAmount);
            int result2 = (int)(customerPayment - totalAmount);
            var stang = (result - result2) * 100;
            int resultFinal = 0;

            if (stang % 25 == 0)
            {
                resultFinal = (int)(result * 100);
            }
            else {
                if (stang > 0 && stang < 25) {
                    resultFinal = (result2 * 100) + 25;
                }
                if(stang > 25 && stang < 50)
                {
                    resultFinal = (result2 * 100) + 50; 
                }
                if (stang > 50 && stang < 75) {
                    resultFinal = (result2 * 100) + 75;
                }
                if (stang > 75 && stang < 100) {
                    resultFinal = (result2 * 100) + 100;
                } 
            }
            return resultFinal;
        }

        public ChangeSolution GetChangeBankNotesAndCoins(int changeInSatang)
        {
            var posCalculator = new ChangeSolution();
            posCalculator.BankNotesAndCoins = new Dictionary<BankNotesAndCoinsInSatang, int>();
            int stang = 0;
            int money = 0;
            int result = 0;
            int resultStang = 0;
            int countThousandBank = 0;
            int countFiveHundredBank = 0;
            int countOneHundredBank = 0;
            int countFiftyBank = 0;
            int countTwentyBank = 0;
            int countTenCoin = 0;
            int countFiveCoin = 0;
            int countOneCoin = 0;
            int count25StangCoin = 0;
            int count50StangCoin = 0;

            stang = changeInSatang - ((changeInSatang / 100)*100);
            resultStang = stang;

            if (changeInSatang > 0) {
           
                posCalculator.HasChange = true;
                posCalculator.RoundedChange = Convert.ToDouble(changeInSatang) / 100;
                
                money = changeInSatang / 100;
                result = money;
                if (result >= 1000)
                {
                    countThousandBank = result / 1000;
                    result = result - (countThousandBank * 1000);
                    posCalculator.BankNotesAndCoins.Add(BankNotesAndCoinsInSatang.Thousand, countThousandBank);
                }
                if (result >= 500)
                {
                    countFiveHundredBank = result / 500;
                    result = result - (countFiveHundredBank * 500);
                    posCalculator.BankNotesAndCoins.Add(BankNotesAndCoinsInSatang.FiveHundreds, countFiveHundredBank);
                }
                if (result >= 100)
                {
                    countOneHundredBank = result / 100;
                    result = result - (countOneHundredBank * 100);
                    posCalculator.BankNotesAndCoins.Add(BankNotesAndCoinsInSatang.Hundred, countOneHundredBank);
                }
                if(result >= 50)
                {
                    countFiftyBank = result / 50;
                    result = result - (countFiftyBank * 50);
                    posCalculator.BankNotesAndCoins.Add(BankNotesAndCoinsInSatang.Fifty, countFiftyBank);
                }
                if (result >= 20)
                {
                    countTwentyBank = result / 20;
                    result = result - (countTwentyBank * 20);
                    posCalculator.BankNotesAndCoins.Add(BankNotesAndCoinsInSatang.Twenty, countTwentyBank);

                }
                if (result >= 10)
                {
                    countTenCoin = result / 10;
                    result = result - (countTenCoin * 10);
                    posCalculator.BankNotesAndCoins.Add(BankNotesAndCoinsInSatang.Ten, countTenCoin);
                }
                if (result >= 5)
                {
                    countFiveCoin = result / 5;
                    result = result - (countFiveCoin * 5);
                    posCalculator.BankNotesAndCoins.Add(BankNotesAndCoinsInSatang.Five, countFiveCoin);
                }
                if (result >= 1)
                {
                    countOneCoin = result / 1;
                    posCalculator.BankNotesAndCoins.Add(BankNotesAndCoinsInSatang.One, countOneCoin);
                }
                if (resultStang >= 50) {
                    count50StangCoin = resultStang / 50;
                    resultStang = resultStang - (count50StangCoin * 50);
                    posCalculator.BankNotesAndCoins.Add(BankNotesAndCoinsInSatang.Fiftieth, count50StangCoin);
                }
                if (resultStang >= 25) {
                    count25StangCoin = resultStang / 25;
                    posCalculator.BankNotesAndCoins.Add(BankNotesAndCoinsInSatang.TwentyFifth, count25StangCoin);
                }

            }
            return posCalculator;
         
         
        }
    }
}

