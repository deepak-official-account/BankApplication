
using System.Security.Principal;
using System.Text.Json;
using BankApplication.Models;

namespace BankApplication
{
    class Program
    {


        private static string FilePath = @"D:\Deepak Bisht\csharp\BankApplication\UserInfo.json";


        private static int choice;
        private static List<Account> Accounts = new List<Account>();
        private static void SaveDataInFile()
        {
            List<Account> accounts = ReadData();
            if (accounts == null)
            {
                var JsonData = JsonSerializer.Serialize(Accounts);
                File.WriteAllText(FilePath, JsonData);

            }
            else
            {
                accounts.AddRange(Accounts);
                var JsonData = JsonSerializer.Serialize(accounts);
                File.WriteAllText(FilePath, JsonData);

            }

        }

        private static List<Account> ReadData()
        {

            var FileData = File.ReadAllText(FilePath);
            var Data = JsonSerializer.Deserialize<List<Account>>(FileData);
            return Data;
        }
        public static void ShowMessage()
        {
            Console.WriteLine("Please choose an option:");
            Console.WriteLine("1. Deposit Money");
            Console.WriteLine("2. Withdraw Money");
            Console.WriteLine("3. Check Balance");
            Console.WriteLine("4. Account Details");
            Console.WriteLine("5. Exit");
            Console.WriteLine();
        }

        public static Account CreateAccount()
        {

            string Name;
            string AccountNumber;
            double BalanceAmount;

            Console.WriteLine("Welcome to Simple Bank");
            Console.WriteLine("Please Enter your Name");
            Name = Console.ReadLine();
            Console.WriteLine("Please Enter your Account Number");
            AccountNumber = Console.ReadLine();
            Console.WriteLine("Please Enter Initial Deposit Amount");
            BalanceAmount = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Account Created Successfully");
            return new Account(Name, AccountNumber, BalanceAmount);
        }

        public static void ExitApplication()
        {
            Console.WriteLine("Press Key Enter to Exit");
            if (Console.ReadKey().Equals(ConsoleKey.Enter))
            {
                Environment.Exit(0);
            }
        }
        public static void ProcessUserChoice(Account account)
        {

            do
            {
                ShowMessage();
                Console.WriteLine("Enter Your Choice");
                choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        Account.DepositMoney(account);
                     
                        break;
                    case 2:
                        Account.WithdrawMoney(account);
                 
                        break;
                    case 3:
                        Account.CheckBalance(account);
                 
                        break;
                    case 4:
                        Account.ShowDetails(account);

                        break;
                    case 5:
                        SaveDataInFile();
                        Console.WriteLine("Exiting...");
                        ExitApplication();
                        break;

                }
            }
            while (choice != 5);
        }
        static void Main(string[] args)
        {
            // var data = ReadData();
            // Console.Write(data);
            ShowMessage();
            Account account = CreateAccount();
            Accounts.Add(account);
            ProcessUserChoice(account);


        }
    }
}
