using System;
using System.Collections.Generic;
using System.Text;

namespace FirstRound.Lib
{
    /// <summary>
    /// The guide for change to the customer.
    /// </summary>
    public class ChangeSolution
    {
        /// <summary>
        /// Is there any change?
        /// </summary>
        public bool HasChange { get; set; }

        /// <summary>
        /// The change in rounded value in THB
        /// </summary>
        public double RoundedChange { get; set; }

        /// <summary>
        /// Bank notes and coins for the change
        /// </summary>
        public IDictionary<BankNotesAndCoinsInSatang, int> BankNotesAndCoins { get; set; }
    }
}
