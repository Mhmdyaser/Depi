using Bank_account;
using System.Net;
using System.Runtime.Serialization.DataContracts;

namespace Bank_account
{ 
    public class BankAcount
    {
        const string BankCode = "BNK001";
       public readonly DateTime CreatedDate;
        private int _accountNumber;
        private string _fullName;
       private long _nationalID;
       private string  _phoneNumber;
         private string _address;
        private double _balance;

        public string FullName
        {
            get { return _fullName; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    Console.WriteLine("Full name cannot be empty.");
                else
                {
                    _fullName = value;
                }
            }
        }

        public long NationalID
        {
            get { return _nationalID; }
            set
            {
                if (Convert.ToString(value).Length==14)
                    _nationalID = value;
                else
                {
                    Console.WriteLine(" Invalid National ID.");
                }
            }
           
        }
            
        public string PhoneNumber
        {
            get { return _phoneNumber; }
            set
            {
                if (value.Length == 11  && value.StartsWith("01"))
                    _phoneNumber = value;
                else
                {
                    Console.WriteLine("Invalid phone number.");
                }
            }
        }

        public double Balance
        {
            get { return _balance; }
            set
            {
                if (value >= 0)
                    _balance = value;
                else
                {
                     Console.WriteLine("Invalid Balance.");
                }
            }
        }

        public string Address { get; set; }
        public int AccountNumber{get; set; }

        public BankAcount()
        {
            CreatedDate = DateTime.Now;
            AccountNumber = 1;
            FullName = "Mohamed Yaser";
            NationalID = 12345678901234;
            PhoneNumber = "01012345678";
            Address = "Cairo";
            Balance = 1000.0;
        }

        public BankAcount(int accountNumber, string fullName, long nationalID, string phoneNumber, string address)
        {
            AccountNumber = accountNumber;
            FullName = fullName;
            NationalID = nationalID;
            PhoneNumber = phoneNumber;
            Address = address;
           
        }

        public BankAcount(int accountNumber, string fullName, long nationalID, string phoneNumber, string address ,double balnce) : this(accountNumber,fullName, nationalID, phoneNumber, address)
        {
            Balance = balnce;
        }

        public void ShowAccountDetails()
        {
            Console.WriteLine("------------------------------------ Account Details ---------------------------------------------");
            Console.WriteLine($"Account Number: {AccountNumber}");
            Console.WriteLine($"Full Name: {FullName}");
            Console.WriteLine($"National ID: {NationalID}");
            Console.WriteLine($"Phone Number: {PhoneNumber}");
            Console.WriteLine($"Address: {Address}");
            Console.WriteLine($"Balance: {Balance}");
            Console.WriteLine($"Created Date: {CreatedDate}");
        }

        
        public bool IsValidNationalID()
        {
            return Convert.ToString(NationalID).Length == 14;
        }

        public bool IsValidPhoneNumber()
        {
            return Convert.ToString(PhoneNumber).Length == 11 && Convert.ToString(PhoneNumber).StartsWith("01");
        }

    }


    
    internal class Program
    {
        static void Main(string[] args)
        {
        BankAcount b1 = new BankAcount();
        b1.ShowAccountDetails();

           BankAcount b3 = new BankAcount(3, "Sara Ahmed", 12345678901234, "01012345678", "Alexandria", 5000.0);
            b3.ShowAccountDetails();
            

        }
    }
}

