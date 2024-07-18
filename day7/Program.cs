using System.ComponentModel;

namespace day7
{
    public class Calculator<T> where T : struct, IComparable, IFormattable, IConvertible, IComparable<T>, IEquatable<T>
    {
    
        public Func<T, T, T> Add { get; set; }
        public Func<T, T, T> Subtract { get; set; }
        public Func<T, T, T> Multiply { get; set; }
        public Func<T, T, T> Divide { get; set; }


        public Calculator()
        {
            Add = (x, y) => (dynamic)x + y;
            Subtract = (x, y) => (dynamic)x - y;
            Multiply = (x, y) => (dynamic)x * y;
            Divide = (x, y) => (dynamic)x / y;
        }
        public void Calculate(T x, T y)
        {
            if (y.Equals(default(T)))
            {
                Console.WriteLine("Cannot divide by zero!");
                return;
            }
            Console.WriteLine($"x + y = {Add(x, y)}");
            Console.WriteLine($"x - y = {Subtract(x, y)}");
            Console.WriteLine($"x * y = {Multiply(x, y)}");
            Console.WriteLine($"x / y = {Divide(x, y)}");
        }



    }
    internal class Progr_am
    {
        static void Main(string[] args)
        {
            Console.Write("Enter the type of calculator (int or double): ");
            string type = Console.ReadLine();

            if (type.ToLower() == "int")
            {
                Console.Write("Enter the first integer: ");
                int x = int.Parse(Console.ReadLine());
                Console.Write("Enter the second integer: ");
                int y = int.Parse(Console.ReadLine());

                var intCalculator = new Calculator<int>();
                intCalculator.Calculate(x, y);
            }
            else if (type.ToLower() == "double")
            {
                Console.Write("Enter the first double: ");
                double x = double.Parse(Console.ReadLine());
                Console.Write("Enter the second double: ");
                double y = double.Parse(Console.ReadLine());

                var doubleCalculator = new Calculator<double>();
                doubleCalculator.Calculate(x, y);
            }
            else
            {
                Console.WriteLine("Invalid type. Please enter 'int' or 'double'.");

            }
        }
    }
}
