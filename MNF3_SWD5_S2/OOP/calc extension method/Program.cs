namespace calc_extension_method
{
    using System;

  
    public delegate double CalcOperation(double x, double y);

    public static class Extensions_Methood
    {
        public static double Calculate(this double x, double y, CalcOperation op)
        {
            return op(x, y);
        }
    }

    class Program
    {
        static void Main()
        {
       
            CalcOperation add = (a, b) => a + b;
            CalcOperation subtract = (a, b) => a - b;
            CalcOperation multiply = (a, b) => a * b;
            CalcOperation divide = (a, b) =>  a / b ;

            double num1 = 10;
            double num2 = 25;

            
            Console.WriteLine(num1.Calculate(num2, add));       
            Console.WriteLine(num1.Calculate(num2, subtract));  
            Console.WriteLine(num1.Calculate(num2, multiply));  
            Console.WriteLine(num1.Calculate(num2, divide));    
        }
    }
}
