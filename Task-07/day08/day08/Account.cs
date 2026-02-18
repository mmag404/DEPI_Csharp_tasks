using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace day08
{
    public struct Account
    {
        private int accountId;
        private string accountHolder;
        private double balance;

        // Properties (Encapsulation)
        public int AccountId
        {
            get { return accountId; }
            set { accountId = value; }
        }

        public string AccountHolder
        {
            get { return accountHolder; }
            set { accountHolder = value; }
        }

        public double Balance
        {
            get { return balance; }
            set
            {
                if (value >= 0)
                    balance = value;
                else
                    Console.WriteLine("Balance cannot be negative");
            }
        }

        public void Display()
        {
            Console.WriteLine($"Id: {accountId}, Holder: {accountHolder}, Balance: {balance}");
        }
    }
}
