using System;

namespace Lab02UnitTesting
{
  public class Program
  {
    public static void Main(string[] args)
    {
      double myBalance = 1000;
      Console.WriteLine("Hello World!");
      Console.WriteLine("Welcome to ATM");
      introScreen(myBalance);
      Console.ReadKey();
    }

    public static void introScreen(double balance)
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
          Console.WriteLine($"Your balance is {balance.ToString("C")}");
          Console.WriteLine("Press any key to go back");
          Console.ReadKey();
        }
        if (input == (char)50)
        {
          AddBalance(balance);
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
      }
      finally
      {
        Console.WriteLine();
        introScreen(balance);
      }
    }

    public static void CheckSelectionInput(char input)
    {
      if (input != (char)49 && input != (char)50 && input != (char)51 && input != (char)52)
      {
        throw new Exception("Sorry, but that is an invalid input. Your options are 1, 2, 3, or 4)");
      }

    }

    public static void AddBalance(double balance)
    {
      Console.WriteLine();
      Console.WriteLine("How much money would you like to add?");
      string amount = Console.ReadLine();

      try
      {
        Convert.ToUInt32(amount);
      }
      catch (Exception)
      {
        Console.WriteLine($"Please enter a positive numerical amount");
        Console.WriteLine("Returning to Main Menu");
      }


    }


  }
}
