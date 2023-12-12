using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerOperations
{
    
    
        public class PowerCalculator
        {
            public static double ConvertAngle(double angle, string status)
            {
                if (status == "DEG")
                {
                    angle = (angle * Math.PI) / 180;
                }
                else if (status == "GRAD")
                {
                    angle = (angle * Math.PI) / 200;
                }
                return angle;
            }

            // Trigonometric Functions
            public static double Sin(double angle, string status)
            {
                angle = ConvertAngle(angle, status);
                return Math.Sin(angle);
            }

            public static double Cos(double angle, string status)
            {
                angle = ConvertAngle(angle, status);
                return Math.Cos(angle);
            }

            public static double Tan(double angle, string status)
            {
                angle = ConvertAngle(angle, status);
                return Math.Tan(angle);
            }

            public static double Cot(double angle, string status)
            {
                return 1 / Tan(angle, status);
            }

            public static double Sec(double angle, string status)
            {
                return 1 / Cos(angle, status);
            }

            public static double Cosec(double angle, string status)
            {
                return 1 / Sin(angle, status);
            }

            // Inverse Trigonometric Functions
            public static double ArcSin(double angle, string status)
            {
                angle = ConvertAngle(angle, status);
                return Math.Asin(angle);
            }

            public static double ArcCos(double angle, string status)
            {
                angle = ConvertAngle(angle, status);
                return Math.Acos(angle);
            }

            public static double ArcTan(double angle, string status)
            {
                angle = ConvertAngle(angle, status);
                return Math.Atan(angle);
            }

            public static double ArcCot(double angle, string status)
            {
                return 1 / ArcTan(angle, status);
            }

            public static double ArcSec(double angle, string status)
            {
                return 1 / ArcCos(angle, status);
            }

            public static double ArcCosec(double angle, string status)
            {
                return 1 / ArcSin(angle, status);
            }

            // Hyperbolic Functions
            public static double Sinh(double angle, string status)
            {
                angle = ConvertAngle(angle, status);
                return Math.Sinh(angle);
            }

            public static double Cosh(double angle, string status)
            {
                angle = ConvertAngle(angle, status);
                return Math.Cosh(angle);
            }

            public static double Tanh(double angle, string status)
            {
                angle = ConvertAngle(angle, status);
                return Math.Tanh(angle);
            }

            public static double Coth(double angle, string status)
            {
                return 1 / Tanh(angle, status);
            }

            public static double Sech(double angle, string status)
            {
                return 1 / Cosh(angle, status);
            }

            public static double Cosech(double angle, string status)
            {
                return 1 / Sinh(angle, status);
            }

            // General Functions
            public static double Absolute(double input)
            {
                return Math.Abs(input);
            }

            public static double Floor(double input)
            {
                return Math.Floor(input);
            }

            public static double Ceiling(double input)
            {
                return Math.Ceiling(input);
            }

            public static double Random()
            {
                return new Random().NextDouble();
            }

            public static double ToDMS(double angle)
            {
                int degrees = (int)Math.Floor(angle);
                double minutes = (angle - degrees) * 60;
                int minutesInt = (int)Math.Floor(minutes);
                double seconds = (minutes - minutesInt) * 60;
                double result = degrees + minutesInt / 100.0 + seconds / 10000.0;
                return result;
            }

            public static double DMSToDegree(double angle)
            {
                int degrees = (int)Math.Floor(angle);
                double minutes = (angle - degrees);
                double result = degrees + (minutes / 60);
                return result;
            }

            public static string ToScientificNotation(double number)
            {
                string scientificNotation = number.ToString("E");
                return scientificNotation;
            }

            // Power Functions
            public static double Exponentiation(double baseValue, double exponent)
            {
                return Math.Pow(baseValue, exponent);
            }

            public static double Root(double baseValue, double rootValue)
            {
                return Math.Pow(baseValue, 1.0 / rootValue);
            }

            public static double SquareRoot(double number)
            {
                if (number < 0)
                {
                    throw new ArgumentException("Invalid input");
                }
                return Math.Sqrt(number);
            }

            public static double CubeRoot(double number)
            {
                if (number < 0)
                {
                    throw new ArgumentException("Invalid input");
                }
                return Math.Pow(number, 1.0 / 3.0);
            }

            public static double Log10(double x)
            {
                return Math.Log10(x);
            }

            public static double Ln(double x)
            {
                return Math.Log(x);
            }

            public static double Exp(double x)
            {
                return Math.Exp(x);
            }

            public static double Factorial(double n)
            {
                if (n < 0)
                {
                    throw new ArgumentException("Invalid input");
                }

                if (n == 0 || n == 1)
                {
                    return 1;
                }

                double result = 1;
                for (int i = 2; i <= n; i++)
                {
                    result *= i;
                }

                return result;
            }
        }
    }


