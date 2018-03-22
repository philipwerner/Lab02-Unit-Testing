using System;
using Xunit;
using BankATM;
using static BankATM.Program;


namespace BankATMTests
{
    public class UnitTest1
    {
        [Theory]
        [InlineData(3500, 3500)]
        [InlineData(500, 500)]
        [InlineData(300, 300)]
        [InlineData(35, 35)]
        public void CanViewBalance(decimal testBalance, decimal testResult)
        {
            Assert.Equal(testResult, ViewBalance(testBalance));
        }
        
        [Theory]
        [InlineData(50, 500, 450)]
        [InlineData(150, 1500, 1350)]
        [InlineData(500, 500, 0)]
        [InlineData(250, 5500, 5250)]
        public void CanWithdrawMoney(decimal testAmount, decimal testBalance, decimal testResult)
        {
            Assert.Equal(testResult, MakeWithdrawl(testAmount, testBalance));
        }

        [Theory]
        [InlineData(500, 500, 1000)]
        [InlineData(150, 500, 650)]
        [InlineData(500, 0, 500)]
        [InlineData(250, 3500, 3750)]
        public void CanDepositMoney(decimal testAmount, decimal testBalance, decimal testResult)
        {
            Assert.Equal(testResult, MakeDeposit(testAmount, testBalance));
        }

    }
}
