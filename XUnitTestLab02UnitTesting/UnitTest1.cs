using System;
using Xunit;
using Lab02UnitTesting;
using static Lab02UnitTesting.Program;


namespace XUnitTestLab02UnitTesting
{
  public class UnitTest1
  {
    //checks to see that balance won't change if user sets 0 input
    [Fact]
    public void AddTestZeroAdd()
    {
      Assert.Equal(myBalance, SumBalance(0));
    }
    //checks to see that calculation is working correctly
    [Fact]
    public void AddTestRandomAdd()
    {
      Assert.Equal(myBalance + 1000, SumBalance(1000));
    }
    //checks to see if function will add anything
    [Fact]
    public void AddTestDoesItSum()
    {
      Assert.NotEqual(myBalance, SumBalance(1000));
    }
    //checking across the range of add amounts
    [Theory]
    [InlineData(0, 0)]
    [InlineData(1, 1)]
    [InlineData(22, 22)]
    [InlineData(333, 333)]
    [InlineData(4444, 4444)]
    [InlineData(55555, 55555)]
    [InlineData(666666, 666666)]
    [InlineData(7777777, 7777777)]
    public void AddTestRange(UInt64 expected, UInt64 input)
    {
      myBalance = 0;
      Assert.Equal(expected, SumBalance(input));
    }
    [Fact]
    //see if ending balance is correct from subtracting
    public void SubtractTestRandom()
    {
      myBalance = 1000;
      Assert.Equal(myBalance - 500, SubtractBalance(500));
    }
    //checks to see that balance will not change if user inputs 0
    [Fact]
    public void SubtractTestZeroSubtract()
    {
      myBalance = 1000;
      Assert.Equal(myBalance, SubtractBalance(0));
    }
    //checks to see method subtracts inputs
    [Fact]
    public void SubtractTestDoesItSubtract()
    {
      myBalance = 1000;
      Assert.NotEqual(myBalance, SubtractBalance(20));
    }
    //Test if the correct exception is thrown if user withdraws more than available balance
    [Fact]
    public void SubtractTestGreater()
    {
      Exception e = Assert.Throws<Exception>(delegate { SubtractBalance(2000); });

      Assert.Equal($"You cannot withdraw more than your balance of {myBalance.ToString("C")}", e.Message);
    }
  }
}
