using System;

namespace BankATM
{
    public class Program
    {
        static void Main(string[] args)
        {
            decimal balance = 2000M;    //starting user balance
            Console.WriteLine("Welcome To Your Money");
            UserInterface(balance);
        }

        /// <summary>
        /// prompts the user with atm usage options, takes users input and
        /// passes it the the HandleOption method 
        /// </summary>
        /// <param name="balance">decimal type of the users current account balance</param>
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

        /// <summary>
        /// calls on the proper method for viewing balance, making a withdrawl, making a 
        /// deposit or exiting the ATM
        /// </summary>
        /// <param name="val">a byte that is either 1, 2, 3 or 0</param>
        /// <param name="balance">decimal type of the users current account balance</param>
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
                try
                {
                    Console.WriteLine("How much would you like to withdrawl?");
                    decimal withdrawl = Convert.ToDecimal(Console.ReadLine());
                    if (withdrawl < 1)
                    {
                        Console.WriteLine("Please enter a valid amount");
                        HandleOption(val, balance);
                    }
                    decimal currentBalance = MakeWithdrawl(withdrawl, balance);     //updates the balance
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
                try
                {
                    Console.WriteLine("How much would you like to deposit?");
                    decimal deposit = Convert.ToDecimal(Console.ReadLine());
                    if (deposit < 1)
                    {
                        Console.WriteLine("Please enter a valid amount");
                        HandleOption(val, balance);
                    }
                    decimal currentBalance = MakeDeposit(deposit, balance);     //updates the balance
                    UserInterface(currentBalance);
                }
                catch (Exception)
                {
                    Console.WriteLine("Please enter a valid amout.");
                    HandleOption(val, balance);
                }
            }
            if (val == 0)
            {
                Console.WriteLine("Have A Nice Day");
            }
        }

        /// <summary>
        /// takes in the balance and returns the balance
        /// </summary>
        /// <param name="balance">decimal type of the users account balance</param>
        /// <returns>returns the decimal type of the users account balance</returns>
        public static decimal ViewBalance(decimal balance)
        {
            return balance;
        }

        /// <summary>
        /// takes in a requested withdrawl amount and the current balance, subtracts
        /// withdrawl amount from balance and checks to see if the result is greater than
        /// zero. If not greater than zero, it alerts the user to their balance and terminates
        /// the withdrawl. If it is greater than zero, it shows the user the updated balance,
        /// then returns the new balance.
        /// </summary>
        /// <param name="amount">decimal type of how much the user wants to withdraw</param>
        /// <param name="balance">decimal type of the users current account balance</param>
        /// <returns>if balance would be less than zero, returns decimal type of the current 
        /// balance. if balance will be zero or greater, decimal type of the new balance is returned</returns>
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

        /// <summary>
        /// takes in a request deposit amout and the current balance, the
        /// two are then added together, the user is prompted with their
        /// updated balance, and the new balance is returned.
        /// </summary>
        /// <param name="deposit">decimal type of the amount the user wants to deposit</param>
        /// <param name="balance">decimal type of the users current account balance</param>
        /// <returns>decimal type of the new balance after the deposited amount was added</returns>
        public static decimal MakeDeposit(decimal deposit, decimal balance)
        {
            decimal newBalance = deposit + balance;
            Console.WriteLine($"Your balance is now ${newBalance}");
            return newBalance;

        }
    }
}
