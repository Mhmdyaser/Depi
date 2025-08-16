using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank_System
{
    internal class Account
    {
        private static int _accountCounter = 1;

        private int _accountNumber;
        private double _balance;

        public DateTime DateOpened { get; }
        public int AccountNumber
        {
            get { return _accountNumber; }
            set { _accountNumber = value; }
        }
        public double Balance
        {
            get { return _balance; }
            set
            {
                if (value >= 0)
                {
                    _balance = value;
                }
                else
                    Console.WriteLine("Invalid balance");
            }
        }

        public Account()
        {
            AccountNumber = _accountCounter++;  
            DateOpened = DateTime.Now;
        }

        public void Deposit(double amount)
        {
            if (amount <= 0)
            {
                Console.WriteLine("Invalid deposit");
            }
            else
            {
                Balance += amount;
            }
        }

        public virtual void Withdraw(double amount)
        {
            if (amount <= 0)
            {
                Console.WriteLine("Amount must be positive.");
                return;
            }
            if (Balance < amount)
            {
                Console.WriteLine("Invalid.");
                return;
            }
            Balance -= amount;
        }

        public void Transfer(Account DestenationAccount)
        {
            Console.WriteLine("Enter Transfer Amount :");
            double TAmount = Convert.ToDouble(Console.ReadLine());
            if (TAmount > Balance)
            {
                Console.WriteLine("Invalid Transfer");
            }
            else
            {
                DestenationAccount.Balance += TAmount;
                Balance -= TAmount;
            }
        }

        public virtual void DisplayAcount()
        {
            Console.WriteLine($"Account Number : {AccountNumber}");
            Console.WriteLine($"Balance : {Balance}");
            Console.WriteLine($"DateOpened : {DateOpened}");
        }
    }


}
