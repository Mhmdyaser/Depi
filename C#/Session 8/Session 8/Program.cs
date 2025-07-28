namespace Session_8
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            Console.Write("Input the First number :");
            double firstNumber = Convert.ToDouble(Console.ReadLine());
            Console.Write("Input the Second number :");
            double secondNumber = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("What do you want to do with those numbers?");
            Console.WriteLine("[A] Add");
            Console.WriteLine("[S] Subtract");
            Console.WriteLine("[M] Multiply");

            String choice = Console.ReadLine();
            switch (choice)
            {
                case "A":
                case "a":
                    Console.WriteLine($" {firstNumber} + {secondNumber} = {firstNumber + secondNumber}");
                    break;
                case "S":
                case "s":
                    Console.WriteLine($" {firstNumber} - {secondNumber} = {firstNumber - secondNumber}");
                    break;
                case "M":
                case "m":
                    Console.WriteLine($" {firstNumber} * {secondNumber} = {firstNumber * secondNumber}");
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please select A, S, M.");
                    break;

            }

            Console.WriteLine("Press any key to close");
            Console.ReadKey();
        }
    }
}