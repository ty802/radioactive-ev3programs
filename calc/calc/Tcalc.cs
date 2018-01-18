using System;

namespace calc
{
    public static class Tcalc
    {

        //trying this as an extension method might make it a little cleaner:
        //https://weblogs.asp.net/scottgu/new-orcas-language-feature-extension-methods
        //Scott Guthrie is an amazing programmer that ALWAYS wears a red shirt.
        //that is why there is a red shirt on his blog!
        //if you use the "this" keyword, you can call the static method a bit more efficiently...
        public static double ToCelsiusFromFahrenheit(this double fahrenheit)
        {
            return (fahrenheit - 32) / 1.8;
        }

        //if you use the "this" keyword, you can call the static method a bit more efficiently...
        public static double ToKelvinFromCelsius(this double celsius)
        {
            return celsius + 273.15;
        }
        public static double ToCelsiusFromKelvin(this double kelvin){
            return kelvin - 273.15;
        }
        public static double ToFahrenheitFromCelsius(this double celsius)
        {
            return (celsius * 1.8) + 32;
        }

        public static double OpenCircuitVoltage(double high, double low) => (high - low)/high;

        //Specific Heat of Water, roughly 1BTU/pound mass degrees F
        public static double CP = 1D;

        //Temperature Difference - it is best to use the abs 
        public static double ToDeltaTemp(double high, double low)
        {
            return Math.Abs(high - low);
        }

        /****
         * http://www.ucsusa.org/sites/default/files/legacy/assets/documents/nuclear_power/20071204-ucs-brief-got-water.pdf
         * The minimum flow rate of water needed in a once-through cooling system to remove the waste
         * heat from a nuclear power reactor is given by the following equation:
         * Q = m* CP * ΔT
         * or
         * m = Q / ( CP * ΔT) 
         * where:
         *      Q = waste heat load, BTU per hour
         *      m = once - through cooling system flow rate, pounds mass per hour
         *      CP = specific heat of water, ≈ 1 BTU/pound mass ºF
         *      ΔT = temperature difference, ºF
         ****/

        // Q = m* CP * ΔT
        public static double wastHeatLoad (double onceThroughCoolingSystFlowRate, double highTemp, double lowTemp)
        {
            return onceThroughCoolingSystFlowRate * CP * ToDeltaTemp(highTemp, lowTemp);
        }

        // m = Q / ( CP * ΔT)
        public static double CalcOnceThroughCoolingSystFlowRate(this double wasteHeatLoad, double highTemp, double lowTemp)
        {
            return wasteHeatLoad / (CP * ToDeltaTemp(highTemp, lowTemp));
        }





        public static double? GetTemp(this double incoming,double fromSystem, double toSystem)
        {
            
            double? returnValue = null;
            if (!((double?)fromSystem).CheckValidConversionTarget()) return null;
            if (!((double?)toSystem).CheckValidConversionTarget()) return null;
            //1 = c, 2 = f, 3 = k
            switch (fromSystem)
            {
                case 1:
                    if (toSystem == 1D) return incoming;
                    if (toSystem == 2D) return incoming.ToKelvinFromCelsius();
                    if (toSystem == 3D) return incoming.ToFahrenheitFromCelsius();
                    break;
                case 2:
                    if (toSystem == 1D) return incoming.ToCelsiusFromFahrenheit();
                    if (toSystem == 2D) return incoming;
                    if (toSystem == 3D) return incoming.ToCelsiusFromFahrenheit().ToKelvinFromCelsius();
                    break;
                case 3:
                    if (toSystem == 1D) return incoming.ToCelsiusFromKelvin();
                    if (toSystem == 2D) return incoming.ToCelsiusFromKelvin().ToFahrenheitFromCelsius();
                    if (toSystem == 3D) return incoming;
                    break;
            }

            return returnValue;
        }

        public static bool CheckValidConversionTarget(this double? convTarget){
            if(convTarget != null && convTarget >= 1 && convTarget <= 3 ){
                return true;
            }
            Console.WriteLine($"Input Invalid {convTarget}");
            System.Threading.Thread.Sleep(1000);
            return false;
        }
    }
}