using System;
namespace calc
{
    public class Tcalc
    {
        public Tcalc()
        {
        }
        public static double Celc(double Fin)
        {
            return (Fin - 32) / 1.8;
        }
        public static double Kalv(double Cin)
        {
            return Cin + 273.15;
        }
        public double OpenCircuitVoltage(double high, double low)
        {
            return (high - low) / high;
        }




    }



}
