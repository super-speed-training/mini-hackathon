using FluentAssertions;
using System.Collections.Generic;
using Xunit;

namespace FirstRound.Lib.Tests
{
    public class VerySimplePosTests
    {
        private readonly IVerySimplePOS sut;

        public VerySimplePosTests()
        {
            // TODO: instantiate SUT with your implementation of IVerySimplePOS.
            sut = new VerySimplePOS();

        }

        [Theory]
        [InlineData(552, 1000, 44800)]
        [InlineData(175.30, 500, 32475)]
        public void ComputeChangeInBahtAndSatangCorrectly(double amount, double payment, int expected)
        {
            var result = this.sut.ComputeChange(amount, payment);

            result.Should().Be(expected);
        }

        [Theory]
        [MemberData(nameof(GetChangeBankNotesAndCoinsCases))]
        public void GetChangeBankNotesAndCoinsReturnsCorrectSolution(int change, ChangeSolution expected)
        {
            var result = this.sut.GetChangeBankNotesAndCoins(change);

            result.Should().BeEquivalentTo(expected);
        }

        public static IEnumerable<object[]> GetChangeBankNotesAndCoinsCases = new List<object[]>
        {
            new object[] { 44800,
                new ChangeSolution
                {
                    HasChange = true,
                    RoundedChange = 448.00,
                    BankNotesAndCoins = new Dictionary<BankNotesAndCoinsInSatang, int>
                    {
                        { BankNotesAndCoinsInSatang.Hundred, 4 },
                        { BankNotesAndCoinsInSatang.Twenty, 2 },
                        { BankNotesAndCoinsInSatang.Five, 1 },
                        { BankNotesAndCoinsInSatang.One, 3 },
                    },
                },
            },
            new object[] { 32475,
                new ChangeSolution
                {
                    HasChange = true,
                    RoundedChange = 324.75,
                    BankNotesAndCoins = new Dictionary<BankNotesAndCoinsInSatang, int>
                    {
                        { BankNotesAndCoinsInSatang.Hundred, 3 },
                        { BankNotesAndCoinsInSatang.Twenty, 1 },
                        { BankNotesAndCoinsInSatang.One, 4 },
                        { BankNotesAndCoinsInSatang.Fiftieth, 1 },
                        { BankNotesAndCoinsInSatang.TwentyFifth, 1 },
                    },
                },
            },
        };
    }
}
