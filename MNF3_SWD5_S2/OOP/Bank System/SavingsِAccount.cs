using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank_System
{
    internal class SavingAccount : Account
    {
        private double _interestRate;
        public double InterestRate
        {
            get { return _interestRate; }
            set
            {
                if (value >= 0)
                {
                    _interestRate = value;
                }
                else
                {
                    Console.WriteLine("Invalid interest rate");
                }
            }
        }
        public SavingAccount(double interestRate) : base()
        {
            InterestRate = interestRate;
        }

        
        public double CalculateInterest()
        {
            return Balance * InterestRate / 100;
        }

       
        public void ApplyInterest()
        {
            Balance += CalculateInterest();
        }

        public override void DisplayAcount()
        {
            base.DisplayAcount();
            Console.WriteLine($"Interest Rate = {InterestRate}%");
            Console.WriteLine($"Interest Amount = {CalculateInterest()}");
            Console.WriteLine($"Balance after interest = {Balance + CalculateInterest()}");
        }
    }

}
