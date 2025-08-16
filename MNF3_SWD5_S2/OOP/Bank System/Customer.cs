using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank_System
{
    internal class Customer
    {
        private int _Id;
        private string _FullName;
        private string _NationalId;
        private DateOnly _DateOfBirth;

        private static List<Customer> _customers = new List<Customer>();
        private static int _idCounter = 1;

        
        public List<Account> Accounts { get; } = new List<Account>();

        public int Id
        {
            get { return _Id; }
            private set { _Id = value; }
        }

        public string FullName
        {
            get { return _FullName; }
            set { _FullName = value; }
        }

        public string NationalId
        {
            get { return _NationalId; }
            set { _NationalId = value; }
        }

        public DateOnly DateofBirth
        {
            get { return _DateOfBirth; }
            set { _DateOfBirth = value; }
        }

        public Customer(string fullName, string nationalId, DateOnly dateOfBirth)
        {
            Id = _idCounter++;
            FullName = fullName;
            NationalId = nationalId;
            DateofBirth = dateOfBirth;

            _customers.Add(this);  
        }

        public void Update()
        {
            Console.WriteLine("Enter Full Name:");
            string fullName = Console.ReadLine();
            FullName = fullName;

            Console.WriteLine("Enter DOB:");
            DateOnly dateOfBirth = DateOnly.Parse(Console.ReadLine());
            DateofBirth = dateOfBirth;
        }

        public static bool Remove(int id) 
        { 
            Customer customer = _customers.FirstOrDefault(c => c.Id == id);
            if (customer != null)
            { 
                _customers.Remove(customer);
                return true;
            } 
            return false;
        }

        public static List<Customer> SearchByName(string name)
        {
            return _customers.Where(c => c.FullName.Contains(name, StringComparison.OrdinalIgnoreCase)).ToList();
        }

        public static Customer SearchByNationalId(string nationalId)
        {
            return _customers.FirstOrDefault(c => c.NationalId == nationalId);
        }

        public static void DisplayAll()
        {
            foreach (Customer c in _customers)
            {
                Console.WriteLine($"ID: {c.Id}");
                Console.WriteLine($"Full Name: {c.FullName}");
                Console.WriteLine($"National ID: {c.NationalId}");
                Console.WriteLine($"Date of Birth: {c.DateofBirth}");
                Console.WriteLine("-----------------------------");
            }
        }
    }


}
