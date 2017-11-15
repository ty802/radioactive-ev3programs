using System;

namespace calc
{
    public static class Tcalc
    {
        public static double Celc(double Fin)
        {
            return (Fin - 32) / 1.8;
        }

        //trying this as an extension method might make it a little cleaner:
        //https://weblogs.asp.net/scottgu/new-orcas-language-feature-extension-methods
        //Scott Guthrie is an amazing programmer that ALWAYS wears a red shirt.
        //that is why there is a red shirt on his blog!
        //if you use the "this" keyword, you can call the static method a bit more efficiently...
        public static double ToCelsius(this double fahrenheit)
        {
            return (fahrenheit - 32) / 1.8;
        }

        public static double Kalv(double Cin)
        {
            return Cin + 273.15;
        }

        //if you use the "this" keyword, you can call the static method a bit more efficiently...
        public static double ToKelvin(this double celsius)
        {
            return celsius + 273.15;
        }

        public static double OpenCircuitVoltage(double high, double low)
        {
            return high - low / high;
        }
        
    }
}