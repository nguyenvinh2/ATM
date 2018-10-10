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
        if (input == (char) 50)
        {
          ChangeBalance("withdraw");
        }
        if (input == (char) 51)
        {
          ChangeBalance("deposit");
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

    public static void ChangeBalance(string option)
    {
      Console.WriteLine();
      if (option == "deposit")
      {
        Console.WriteLine("How much money would you like to add?");
      }
      if (option == "withdraw")
      {
        Console.WriteLine("How much money would you like to withdraw?");
      }
      string amount = Console.ReadLine();
      try
      {
        UInt64 value = Convert.ToUInt64(amount);
        if (option == "deposit")
        {
          SumBalance(value);
        }
        if (option == "withdraw")
        {
          SubtractBalance(value);
        }

        Console.WriteLine($"You new balance is {myBalance.ToString("C")}. Press any key to back to Main Menu");
        Console.ReadKey();
      }

      catch (Exception e)
      {
        if (e is FormatException || e is OverflowException)
        {
          Console.WriteLine($"Please enter a positive number in whole amounts.");
          Console.WriteLine("Press any key to return to Main Menu");
          Console.ReadKey();
        }
        else
        {
          Console.WriteLine(e.Message);
          Console.WriteLine("Press any key to return to Main Menu");
          Console.ReadKey();
        }
      }
    }

    public static UInt64 SumBalance(UInt64 addValue)
    {
      myBalance += addValue;
      return myBalance;
    }

    public static UInt64 SubtractBalance(UInt64 minusValue)
    {
      if (minusValue > myBalance)
      {
        throw new Exception($"You cannot withdraw more than your balance of {myBalance.ToString("C")}");
      }
      myBalance -= minusValue;
      return myBalance;
    }


  }
}
