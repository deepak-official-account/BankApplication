using System.Security.Principal;

namespace BankApplication
{
    internal class Program
    {
//        1. Deposit Money 
//2. Withdraw Money 
//3. Check Balance
//4. Account Details 
//5. Exit
        private int choice;
        private string name;
        private string accountNumber;
        private double depositAmount;
        void GetUserInformation()
        {

            Console.WriteLine("Welcome to Simple Bank");
            Console.WriteLine("Please Enter your Name");
            name = Console.ReadLine();
            Console.WriteLine("Please Enter your Account Number");
            accountNumber = Console.ReadLine();
            Console.WriteLine("Please Enter Initial Deposit Amount");
            depositAmount = Convert.ToDouble(Console.ReadLine());


        }
        static void Main(string[] args)
        {
            do
            {

            } while ();
        }
    }
}
