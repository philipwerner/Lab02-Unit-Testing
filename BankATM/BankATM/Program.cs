using System;

namespace BankATM
{
    public class Program
    {
        static void Main(string[] args)
        {
            decimal balance = 2000M;
            Console.WriteLine("Welcome To Your Money");
            UserInterface(balance);
        }

        public static void UserInterface(decimal balance)
        {
            Console.WriteLine("1. View Balance");
            Console.WriteLine("2. Make a Withdrawl");
            Console.WriteLine("3. Deposit Money");
            Console.WriteLine("0. Exit");
            Console.WriteLine("Please Select an Option: ");
            try
            {
                byte choice = Convert.ToByte(Console.ReadLine());
                HandleOption(choice, balance);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            
        }

        public static void HandleOption(byte val, decimal balance)
        {

            if (val == 1)
            {
                decimal bal = ViewBalance(balance);
                string displayBalance = bal.ToString();
                Console.WriteLine($"Your available balance is ${displayBalance}.");
                UserInterface(bal);
            }
            if (val == 2)
            {
                //PromptWithdrawl(balance);
                try
                {
                    Console.WriteLine("How much would you like to withdrawl?");
                    decimal withdrawl = Convert.ToDecimal(Console.ReadLine());
                    decimal currentBalance = MakeWithdrawl(withdrawl, balance);
                    UserInterface(currentBalance);
                }
                catch (Exception)
                {
                    Console.WriteLine("Please enter a valid amout.");
                    HandleOption(val, balance);
                }
            }
            if (val == 3)
            {
                PromptDeposit(balance);
                UserInterface(balance);
            }
            if (val == 0)
            {
                Console.WriteLine("Have A Nice Day");
            }
        }

        public static void PromptWithdrawl(decimal balance)
        {
            try
            {
                Console.WriteLine("How much would you like to withdrawl?");
                decimal withdrawl = Convert.ToDecimal(Console.ReadLine());
                MakeWithdrawl(withdrawl, balance);
            }
            catch (Exception)
            {
                Console.WriteLine("Please enter a valid amout.");
                PromptWithdrawl(balance);
            }
        }

        public static void PromptDeposit(decimal balance)
        {
            try
            {
                Console.WriteLine("How much would you like to deposit?");
                decimal deposit = Convert.ToDecimal(Console.ReadLine());
                MakeDeposit(deposit, balance);
            }
            catch (Exception)
            {
                Console.WriteLine("Please enter a valid amout.");
                PromptDeposit(balance);
            }
        }

        public static decimal ViewBalance(decimal balance)
        {
            return balance;
        }

        public static decimal MakeWithdrawl(decimal amount, decimal balance)
        {
            decimal newBalance = balance - amount;
            if (newBalance < 0)
            {
                Console.WriteLine("Insufficient Funds");
                Console.WriteLine($"Your balance is currently ${balance}");
                Console.WriteLine("Transaction has been terminated");

                return balance;
            }
            if (newBalance > -1)
            {
                Console.WriteLine($"Your balance is now ${newBalance}");
            }
            
            return newBalance;

        }
            
        public static decimal MakeDeposit(decimal deposit, decimal balance)
        {
            decimal newBalance = deposit + balance;
            Console.WriteLine($"Your balance is now ${newBalance}");
            return newBalance;

        }
    }
}
