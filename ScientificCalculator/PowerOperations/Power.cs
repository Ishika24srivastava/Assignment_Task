using System;
using System.CodeDom.Compiler;
namespace PowerOperations
{
    public class Power
    {
        public static double AngleChanger(double angle, String Status)
        {
            if (Status == "DEG")
            {
                if (angle >= 360)
                {
                    angle %= 360;
                }
                angle = (angle * Math.PI) / 180;
            }
            else if (Status == "GRAD")
            {
                if (angle >= 400)
                {
                    angle %= 400;
                }
                angle = (angle * Math.PI) / 200;
            }
            else
            {
                if (angle >= (2 * Math.PI))
                {
                    angle %= (2 * Math.PI);
                }
            }
            return angle;
        }

        /*public static double ValueChanger(double angle, String Status)
        {
            if (Status == "DEG")
            {
                angle *= 180 / Math.PI;
            }
            else if (Status == "GRAD")
            {
                angle *= 200 / Math.PI;
            }
            return angle;
        }*/

        //Trignometric Functions
        public static double Sine(double angle, string status)
        {
            angle = AngleChanger(angle, status);
            double result;
            try
            {
                result = Math.Sin(angle);
            }
            catch (Exception)
            {
                throw new ArgumentException("Invalid input or operation");
            }
            return result;
        }

        public static double Cosine(double angle, string status)
        {
            double modifiedAngle = AngleChanger(angle, status);

            
            if (IsSpecialAngle(modifiedAngle))
            {
                return GetSpecialAngleResult(modifiedAngle);
            }

            try
            {
                return Math.Cos(modifiedAngle);
            }
            catch (Exception)
            {
                Console.WriteLine("Invalid input or operation");
                return double.NaN; 
            }
        }

        private static bool IsSpecialAngle(double angle)
        {
           
            return Math.Abs(angle - (Math.PI / 2)) < double.Epsilon; 
        }

        private static double GetSpecialAngleResult(double angle)
        {
            
            if (IsSpecialAngle(angle))
            {
                return 0; 
            }
            return double.NaN;
        }


        public static double Tangent(double angle, string status)
        {
            angle = AngleChanger(angle, status);

            
            if (Math.Abs(angle % (Math.PI / 2)) < double.Epsilon)
            {
                Console.WriteLine("Invalid Input.");
                return double.NaN; 
            }

            
            double result = Math.Tan(angle);

            return result;
        }

        public static double Cot(double angle, string status)
        {
            angle = AngleChanger(angle, status);

            
            if (Math.Abs(angle % Math.PI) < double.Epsilon)
            {
                Console.WriteLine("Invalid Input.");
                return double.NaN; 
            }

            double tangentValue = Math.Tan(angle);

            
            if (Math.Abs(tangentValue) < double.Epsilon)
            {
                Console.WriteLine("Warning: Cotangent is very close to zero. Considered undefined.");
                return double.NaN; 
            }

            return 1 / tangentValue;
        }



        public static double Sec(double angle, string status)
        {
            angle = AngleChanger(angle, status);

            
            if (Math.Abs(angle % (Math.PI / 2)) < double.Epsilon)
            {
                Console.WriteLine("Invalid input.");
                return double.NaN;
            }

            double cosineValue = Math.Cos(angle);

            if (Math.Abs(cosineValue) < double.Epsilon)
            {
                Console.WriteLine("Invalid input or cannot divide by zero");
                return double.NaN; 
            }

            return 1 / cosineValue;
        }

        public static double Cosec(double angle, string status)
        {
            double sineValue = Sine(angle, status);
            if (Math.Abs(sineValue) < double.Epsilon)
            {
                throw new ArgumentException("Invalid input.");
            }
            return 1 / sineValue;
        }



        //Inverse Trignometric Function
        public static double SineInverse(double angle)
        {
            // angle = AngleChanger(angle, Status);
            return Math.Asin(angle);
        }

        public static double CosineInverse(double angle)
        {
            //  angle = AngleChanger(angle, Status);
            return Math.Acos(angle);
            //return Temp=ValueChanger
        }

        public static double TangentInverse(double angle, string Status)
        {
           // angle = AngleChanger(angle, Status);
            return Math.Atan(angle);
        }

        public static double CotInverse(double angle,string Status)
        {
            return TangentInverse(1/angle,Status);
        }


        public static double SecInverse(double angle)
        {
            return 1/CosineInverse(angle);
        }
        public static double CosecInverse(double angle)
        {
            return 1/SineInverse(angle);
        }

        //Hyperbolic Function
        public static double SineHyp(double angle)
        {
            //angle = AngleChanger(angle, Status);
            return Math.Sinh(angle);
        }



        public static double CosineHyp(double angle)
        {
            //  angle = AngleChanger(angle, Status);
            return Math.Cosh(angle);
        }

        public static double TangentHyp(double angle)
        {
            // angle = AngleChanger(angle, Status);
            return Math.Tanh(angle);
        }
        public static double CotHyp(double angle)
        {
            return 1 / TangentHyp(angle);
        }

        public static double SecHyp(double angle)
        {
            return 1 / CosineHyp(angle);
        }

        public static double CosecHyp(double angle)
        {
            return 1 / SineHyp(angle);
        }
        //Function
        public static double AbsoluteFunction(double input)
        {
            return Math.Abs(input);
        }

        public static double FloorFunction(double input)
        {
            return Math.Floor(input);
        }
        public static double CeilingFunction(double input)
        {
            return Math.Ceiling(input);
        }

        public static double RandomFunction()
        {
            return new Random().NextDouble();
        }

        public static double ConvertToDMS(double angle1)
        {
            int degrees = (int)Math.Floor(angle1);
            double minutes = (angle1 - degrees) * 60;
            int minutesInt = (int)Math.Floor(minutes);
            double seconds = (minutes - minutesInt) * 60;
            double result = degrees + minutesInt / 100.0 + seconds / 10000.0;
            return result;
        }
        public static double DMSToDegree(double angle1)
        {
            int degrees = (int)Math.Floor(angle1);
            double minutes = (angle1 - degrees);
            double result = degrees + (minutes / 60);
            return result;
        }
        public static string ConvertToScientificNotation(double number)
        {
            string scientificNotation = number.ToString("E");
            return scientificNotation;
        }
        //Power Functions
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
                Console.WriteLine("Invalid input.");
                return double.NaN;
            }

            return Math.Sqrt(number);
        }


        public static double CubeRoot(double number)
        {
            if (number < 0)
            {
                number = Math.Abs(number);
                double temp = Math.Pow(number, 1.0 / 3.0);
                return (0 - temp);
                throw new ArgumentException("Invalid input.");
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

        public static double ePowerx(double x)
        {
            return Math.Exp(x);
        }
        public static double Absolute(double x)
        {
            return Math.Abs(x);
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
