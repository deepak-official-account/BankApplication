using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankApplication.Enums;

namespace BankApplication.Models
{

    public class Account
    {

        public string Name { get; set; }
        public int AccountId { get; set; }
        public string AccountNumber { get; set; }
        public double BalanceAmount { get; set; }
        public List<Transaction> Transactions { get; set; } = new List<Transaction>();


        public Account(string Name, string AccountNumber, double BalanceAmount)
        {
            this.Name = Name;
            this.AccountNumber = AccountNumber;
            this.BalanceAmount = BalanceAmount;
            this.Transactions = new List<Transaction>();
            Random random = new Random();
            this.AccountId = random.Next(10000);
        }
        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            builder.Append($"Name: {Name}, Account: {AccountNumber}, BalanceAmount: {BalanceAmount}, ");
            builder.Append("Transactions: ");
            foreach (var transaction in Transactions)
            {
                builder.Append(transaction.ToString() + " ");
            }
            return builder.ToString();
        }




        public static void CheckBalance(Account account)
        {
            Console.WriteLine($"Your Current balance is {account.BalanceAmount}");
            Transaction transaction = new Transaction(BankingActions.CheckBalance, account.BalanceAmount);
            account.Transactions.Add(transaction);
            Console.WriteLine("");
        }

        public static void DepositMoney(Account account)

        {
            Console.WriteLine("Enter Amount you want to Deposit");
            double amount = double.Parse(Console.ReadLine());

            if (amount <= 0)
            {
           
                Console.WriteLine("Amount must be greater than 0");
                return;

            }

            account.BalanceAmount += amount;
            Transaction transaction = new Transaction(BankingActions.Deposit, amount);
            account.Transactions.Add(transaction);
            Console.WriteLine("Amount Added Successfully");
            Console.WriteLine($"Your Updated Amount is {account.BalanceAmount}");
            Console.WriteLine("");
        }

        public static void WithdrawMoney(Account account)
        {
            Console.WriteLine("Enter Amount you want to Withdraw");
            double amount = double.Parse(Console.ReadLine());
            if (amount <= 0)
            {

            
                Console.WriteLine("Amount must be greater than 0");
                return;
            }


            if (amount > account.BalanceAmount)
            {
                Console.WriteLine("Amount must be less than or Equal to the balance Amount");
                return;
            }
            account.BalanceAmount -= amount;
            Transaction transaction = new Transaction(BankingActions.Withdraw, amount);
            account.Transactions.Add(transaction);
            Console.WriteLine($"{amount} Amount Deducted Successfully");
            Console.WriteLine("");

        }

        public static void ShowDetails(Account account)
        {
            Console.WriteLine($"Account Information: {account}");
            Console.WriteLine("");
        }
    }
}
