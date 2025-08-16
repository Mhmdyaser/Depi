
namespace Bank_System
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Bank System!");
            Console.Write("Enter Bank Name: ");
            string bankName = Console.ReadLine();

            Console.Write("Enter Branch Code: ");
            string branchCode = Console.ReadLine();

            Bank bank = new Bank(bankName, branchCode);
            bank.DisplayBank();
            Console.WriteLine("================================");

            Console.Write("Enter Customer Full Name: ");
            string fullName = Console.ReadLine();

            Console.Write("Enter National ID: ");
            string nationalId = Console.ReadLine();

            Console.Write("Enter Date of Birth (yyyy-mm-dd): ");
            DateOnly dob = DateOnly.Parse(Console.ReadLine());

            Customer customer = new Customer(fullName, nationalId, dob);
            Console.WriteLine("Customer created successfully!");
            Customer.DisplayAll();

            Console.WriteLine("================================");

            Console.WriteLine("Choose account type (1 = Saving, 2 = Current): ");
            int choice = int.Parse(Console.ReadLine());

            Account account;
            if (choice == 1)
            {
                Console.Write("Enter Interest Rate (%): ");
                double rate = double.Parse(Console.ReadLine());
                account = new SavingAccount(rate);
            }
            else
            {
                Console.Write("Enter Overdraft Limit: ");
                double limit = double.Parse(Console.ReadLine());
                account = new CurrentAccount(limit);
            }

            customer.Accounts.Add(account);
            Console.WriteLine("Account created successfully!");
            account.DisplayAcount();
            Console.WriteLine("================================");

            
            bool runn = true;
            while (runn)
            {
                Console.WriteLine("Choose operation:");
                Console.WriteLine("1 = Deposit");
                Console.WriteLine("2 = Withdraw");
                Console.WriteLine("3 = Apply Interest (Saving only)");
                Console.WriteLine("4 = Show Account Details");
                Console.WriteLine("5 = Remove Customer");
                Console.WriteLine("6 = Exit");

                Console.Write("Enter choice: ");
                int op = int.Parse(Console.ReadLine());

                switch (op)
                {
                    case 1:
                        Console.Write("Enter deposit amount: ");
                        double dep = double.Parse(Console.ReadLine());
                        account.Deposit(dep);
                        break;

                    case 2:
                        Console.Write("Enter withdraw amount: ");
                        double wd = double.Parse(Console.ReadLine());
                        account.Withdraw(wd);
                        break;

                    case 3:
                        if (account is SavingAccount saving)
                        {
                            saving.ApplyInterest();
                        }
                        else
                        {
                            Console.WriteLine("This is not a saving account.");
                        }
                        break;

                    case 4:
                        Console.WriteLine("Final Account Details:");
                        account.DisplayAcount();
                        break;

                    case 5:
                        if (Customer.Remove(customer.Id))
                            Console.WriteLine("Customer removed successfully.");
                        else
                            Console.WriteLine("Customer NOT removed (has active accounts).");
                        break;

                    case 6:
                        Console.WriteLine("Exiting system...");
                        runn = false;
                        break;

                    default:
                        Console.WriteLine("Invalid choice");
                        break;
                }
            }
        }
    }
}
