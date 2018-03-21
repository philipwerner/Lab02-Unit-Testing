using System;
using Xunit;
using BankATM;
using static BankATM.Program;


namespace BankATMTests
{
    public class UnitTest1
    {
        [Fact]
        public void CanViewBalance()
        {
            Assert.Equal("2000", BalanceMath("+", 0));
        }

        [Fact]
        public void CanAddToBalance()
        {
            Assert.Equal("2500", BalanceMath("+", 500));
        }

        [Fact]
        public void CanSubtractFromBalance()
        {
            Assert.Equal("1500", BalanceMath("-", 500));
        }


    }
}
