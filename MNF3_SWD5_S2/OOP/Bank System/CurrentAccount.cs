using Bank_System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank_System
{
    internal class CurrentAccount : Account
    {
        private double _overdraftLimit;
        public double OverdraftLimit
        {
            get { return _overdraftLimit; }
            set
            {
                if (value >= 0)
                {
                    _overdraftLimit = value;
                }
                else
                {
                    Console.WriteLine("Invalid overdraft limit");
                }
            }
        }
        public CurrentAccount(double overdraftLimit) : base()
        {
            OverdraftLimit = overdraftLimit;
        }
        public override void Withdraw(double amount)
        {
            if (amount <= 0)
            {
                Console.WriteLine("Invalid withdrawal amount");
            }
            else if (Balance + OverdraftLimit < amount)
            {
                Console.WriteLine("Withdrawal exceeds overdraft limit");
            }
            else
            {
                Balance -= amount;
            }
        }
        public override void DisplayAcount()
        {
            base.DisplayAcount();
            Console.WriteLine($"Overdraft Limit = {OverdraftLimit}");
        }
    }

}
