using System;
using System.Collections.Generic;
using System.Text;

namespace FirstRound.Lib
{
    /// <summary>
    /// An abstract interface for very simple POS.
    /// For the first round it just only for change.
    /// </summary>
    public interface IVerySimplePOS
    {
        /// <summary>
        /// Compute the change for the checkout payment.
        /// </summary>
        /// <param name="totalAmount">The total amount for the products checkout.</param>
        /// <param name="customerPayment">The payment from the customer.</param>
        /// <returns>The rounded change in Satang after rounding.</returns>
        /// <remarks>
        /// Please note that the inputs is in THB. But output is in Satang (100th BTH).
        /// </remarks>
        int ComputeChange(double totalAmount, double customerPayment);

        /// <summary>
        /// Gets rounded change in the bank notes and coins.
        /// </summary>
        /// <param name="changeInSatang">The rounded change in Satang.</param>
        /// <returns>The change solution.</returns>
        ChangeSolution GetChangeBankNotesAndCoins(int changeInSatang);
    }
}
