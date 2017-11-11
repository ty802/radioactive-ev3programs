using System;
namespace calc
{
    public class Calc
    {
        
        public double MultiplyNumbers(double num1, double num2)
        {
            double mal = num1 * num2;

            return (mal);
        }
        public double DivideNumbers(double num1, double num2)
        {
            double dev = num1 / num2;
            Console.Write($"Dividing {num1} and {num2}");
            return (dev);
        }
        public double AddNumbers(double num1, double num2){
            double add = num1 + num2;
            Console.Write($"Adding {num1} and {num2}");
            return (add);
        }
        public double SubtractNumbers(double num1, double num2)
        {
            double sub = num1 + num2;
            Console.Write($"subtracting {num1} and {num2}");
            return (sub);
        }
    }
}   