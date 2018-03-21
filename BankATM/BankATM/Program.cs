using System;

namespace BankATM
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome To Your Money");
            UserInterface();
        }

        public static void UserInterface()
        {
            Console.WriteLine("1. View Balance");
            Console.WriteLine("2. Make a Withdrawl");
            Console.WriteLine("3. Deposit Money");
            Console.WriteLine("0. Exit");
            Console.WriteLine("Please Select an Option: ");
            try
            {
                byte choice = Convert.ToByte(Console.ReadLine());
                HandleOption(choice);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public static void HandleOption(byte val)
        {
            if (val == 1)
            {
                ViewBalance();
            }
            if (val == 2)
            {
                try
                {
                    Console.WriteLine("How much money you want: ");
                    int withdrawl = Convert.ToInt32(Console.ReadLine());
                    MakeWithdrawl(withdrawl);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            if (val == 3)
            {
                try
                {
                    Console.WriteLine("How much do you wish to deposit: ");
                    int deposit = Convert.ToInt32(Console.ReadLine());
                    MakeDeposit(deposit);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            if (val == 0)
            {
                Console.WriteLine("Have A Nice Day");
            }
        }

        public static string BalanceMath(string x, int val)
        {
            int balance = 2000;
            int amount = val;
            if (x == "+")
            {
                balance = balance + amount;
                return balance.ToString();
            }
            if (x == "-")
            {
                balance = balance - amount;
                return balance.ToString();
            }
            return " ";

        }


        public static void ViewBalance()
        {
            string balance = BalanceMath("+", 0);
            Console.WriteLine("Your available balance is $" + balance + ".");
            UserInterface();
        }

        public static void MakeWithdrawl(int val)
        {
            int result = Convert.ToInt32(BalanceMath("-", val));
            if (result < 0)
            {
                Console.WriteLine("Insufficient Funds");
                Console.WriteLine($"Your balance is ${result}");
                BalanceMath("+", val);
                UserInterface();
            }
            if (result > -1)
            {
                Console.WriteLine($"Your balance is now ${result}");
                UserInterface();
            }
            
        }

        public static void MakeDeposit(int val)
        {
            int balance = Convert.ToInt32(BalanceMath("+", 0));
            int result = Convert.ToInt32(BalanceMath("+", val));
            Console.WriteLine($"Your balance is now ${result}");
            UserInterface();
        }
    }
}
