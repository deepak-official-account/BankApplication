using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankApplication.Enums;

namespace BankApplication.Models
{
    public class Transaction
    {
        public BankingActions Action { get; set; }
        public double Amount { get; set; }
        public DateTime Timestamp { get; set; }

        public Transaction(BankingActions Action, double Amount)
        {
            this.Action = Action;
            this.Amount = Amount;
            this.Timestamp = DateTime.UtcNow;
        }
        public override string ToString()
        {

            return $"Action: {Action}, Amount: {Amount}, TimeStamp: {Timestamp} ";


        }
    }
}
