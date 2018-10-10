using System;

namespace Lab02UnitTesting
{
  public class Program
  {
    public static UInt64 myBalance = 1000;
    public static void Main(string[] args)
    {
      Console.WriteLine("Hello World!");
      Console.WriteLine("Welcome to ATM");
      introScreen();
    }

    public static void introScreen()
    {
      Console.WriteLine("Enter your selection number:");
      Console.WriteLine("1. View Balance");
      Console.WriteLine("2. Withdraw Money");
      Console.WriteLine("3. Add Money");
      Console.WriteLine("4. Exit");
      char input = Console.ReadKey().KeyChar;
      try
      {
        CheckSelectionInput(input);
        if (input == (char)49)
        {
          Console.WriteLine();
          Console.WriteLine($"Your balance is {myBalance.ToString("C")}");
          Console.WriteLine("Press any key to go back to Main Menu");
          Console.ReadKey();
        }
        if (input == (char)51)
        {
          AddBalance();
        }
        if (input == (char)52)
        {
          Environment.Exit(0);
        }
      }
      catch (Exception e)
      {
        Console.WriteLine();
        Console.WriteLine(e.Message);
        Console.WriteLine("Press any key to go back to Main Menu");
        Console.ReadKey();
      }
      finally
      {
        Console.WriteLine();
        introScreen();
      }
    }

    public static void CheckSelectionInput(char input)
    {
      if (input != (char)49 && input != (char)50 && input != (char)51 && input != (char)52)
      {
        throw new Exception("Sorry, but that is an invalid input. Your options are 1, 2, 3, or 4");
      }

    }

    public static void AddBalance()
    {
      Console.WriteLine();
      Console.WriteLine("How much money would you like to add?");
      string amount = Console.ReadLine();

      try
      {
        UInt64 addValue = Convert.ToUInt64(amount);
        UInt64 totalValue = SumBalance(addValue);
        Console.WriteLine($"You new balance is {totalValue}. Press any key to back to Main Menu");
        Console.ReadKey();
      }
      catch (Exception)
      {
        Console.WriteLine($"Please enter a positive number in whole amounts.");
        Console.WriteLine("Returning to Main Menu");
      }
    }

    public static UInt64 SumBalance(UInt64 addValue)
    {
      myBalance += addValue;
      return myBalance;
    }


  }
}
