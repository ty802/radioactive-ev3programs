using System;
using System.Threading;

namespace calc
{
    internal class Program
    {
        private static double? GetNumber(string prompt)
        {
            Console.Write(prompt);
            string input = Console.ReadLine();
            if (double.TryParse(input, out double number))
            {
                return number;
            }
            else
            {
                Console.WriteLine("\n input invalid ");
                Thread.Sleep(800);
                return null;
            }
        }

        private static void Main(string[] args)
        {
            bool Ok = false;
            while (true)
            {
                Console.Write("do you want to do a calculation ? [y/N]: ");
                if (Console.ReadLine().ToLower().Equals("y"))
                {
                    Console.Write("enter mode\n1 = OpenCircuitVoltage\n: ");
                    // geting mode
                    string mode = Console.ReadLine();
                    switch (mode)
                    {
                        case "1":
                            double? Isc = GetNumber("what system do you want to use \n 1 : Celsius, 2 : Fahrenheit 3 : Kelvin\n: ");
                            if (Isc == null) break;
                            double? highTemp = GetNumber("enter T high: ");
                            if (highTemp == null) break;
                            double? lowTemp = GetNumber("enter T low: ");
                            if (lowTemp == null) break;
                            double high = 0;
                            double low = 0;
                            switch ((double)Isc)
                            {
                                case 1:
                                    //converting C to Kelvin - with an extension method
                                    //high = calc.Tcalc.Kalv((double)highTemp);
                                    high = ((double)highTemp).ToKelvin();
                                    //low = calc.Tcalc.Kalv((double)lowTemp);
                                    low = ((double)lowTemp).ToKelvin();
                                    Ok = true;
                                    break;

                                case 2:
                                    //converting F to C, then to Kelvin - with an extension method
                                    //high = calc.Tcalc.Kalv(calc.Tcalc.Celc((double)highTemp));
                                    high = (((double)highTemp).ToCelsius()).ToKelvin();
                                    //low = calc.Tcalc.Kalv(calc.Tcalc.Celc((double)lowTemp));
                                    low = (((double)lowTemp).ToCelsius()).ToKelvin();
                                    Ok = true;
                                    break;
                                case 3:
                                    high = (double)highTemp;
                                    low = (double)lowTemp;
                                    Ok = true;
                                    break;
                                default:
                                    Console.WriteLine("\n input invalid");
                                    break;
                            }

                            //in order to call static methods without the "this" keyword, we just use the name of the static class
                            if (Ok)
                            {
                                Console.WriteLine(Tcalc.OpenCircuitVoltage(high, low));
                                Console.WriteLine("Press any key to continue...");
                                Console.ReadKey();

                            }
                            Thread.Sleep(5000);
                            break;

                        default:
                            break;
                    }

                    /*Calc c = new Calc();
                    Console.Write($"Multiplying {Number1} and {Number1}\n");
                    double mult = c.MultiplyNumbers(Number1, Number1);
                    Console.WriteLine(mult);*/
                }
                else break;
                Console.Clear();
            }

            /* while (true)
             {
                 Console.Write("do you want to da a calculation ? [y/N]: ");
                 if (Console.ReadLine().ToLower().Equals("y"))
                 {
                     Console.WriteLine("start");
                     Console.Write("enter the first number: ");
                     string input = Console.ReadLine();
                     Console.Write("enter the second number: ");
                     if (!double.TryParse(input, out double Number1))
                     {
                         Console.WriteLine("\n invalid input1 needs number");
                         System.Threading.Thread.Sleep(800);
                         goto end;
                     }
                     input = Console.ReadLine();
                     if (!double.TryParse(input, out double Number2))
                     {
                         Console.WriteLine("\n invalid input2 needs number");
                         System.Threading.Thread.Sleep(800);
                         goto end;
                     }
                     //double mal = Number1 * Number2;
                     double dev = Number1 / Number2;
                     double paw = Math.Pow(Number1, Number2);
                     double sub = Number1 - Number2;
                     double add = Number1 + Number2;
                     double rem = Number1 % Number2;
                     Console.WriteLine(Number1);
                     Console.WriteLine(Number2);
                     //Console.WriteLine($"{Number1} * {Number2} = {Number1 * Number2}");
                     Console.WriteLine(MultiplyNumbers(Number1, Number2));
                     Console.WriteLine($"{Number1} / {Number2} = {Number1 / Number2}");
                     Console.WriteLine($"{Number1} + {Number2} = {add}");
                     Console.WriteLine($"{Number1} - {Number2} = {sub}");
                     Console.WriteLine($"{Number1} ^ {Number2} = {Math.Pow(Number1, Number2)}");
                     Console.WriteLine($"{Number2} % {Number2} = {Number1 % Number2}");
                     Console.Write("press enter to continue...");
                     Console.ReadLine();
                 }
                 else break;
                 end: Console.Clear();       }*/
        }
    }
}