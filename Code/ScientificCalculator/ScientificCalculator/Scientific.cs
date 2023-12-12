using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArithmeticCalculator;
using PowerOperations;

namespace ScientificCalculator
{
    public class Scientific
    {
        static bool dividebyzero = false;
        static bool nexttimeCall = false;
        static string number = "";
        static string angleStatus = "DEG";
        static int angleCountTap = 0;
        static string outputStatus = "F-E";
        static bool ScientificNotation = false;
        static int outputCountTap = 0;
        static double memory = 0;
        static bool memoryChecker = false;
        static bool Isfunction = false;
        static StringBuilder output = new StringBuilder();
        static void Main()
        {
            Console.Title = "Scientific Calculator";
            Console.WriteLine("Scientific Calcualtor");
            ConsoleKeyInfo input;
            bool sequentialOperatorCame;
            double result = 0;
            Console.WriteLine(angleStatus + "\t" + outputStatus + "\t" + String.Format(memoryChecker ? "M" : ""));
            Console.WriteLine(output.ToString());
            while (true)
            {
                do
                {
                    input = Console.ReadKey(true);
                    sequentialOperatorCame = false;
                    Isfunction = false;
                    string currentstring = InputValue(input);
                    Console.Clear();
                    Console.WriteLine(angleStatus + "\t" + outputStatus + "\t" + String.Format(memoryChecker ? "M" : ""));
                    Console.WriteLine(output.ToString());

                    if (IsOperator(currentstring) && output.Length != 0 && IsOperator(output[output.Length - 1].ToString()))
                    {
                        sequentialOperatorCame = true;
                        output.Remove(output.Length - 1, 1);
                        output.Append(currentstring);
                        Console.Clear();
                        Console.WriteLine(angleStatus + "\t" + outputStatus + "\t" + String.Format(memoryChecker ? "M" : ""));
                        Console.WriteLine(output.ToString());
                    }
                    else if (IsOperator(currentstring) && output.Length == 0)
                    {
                        sequentialOperatorCame = true;
                        output.Append("0");
                        output.Append(currentstring);
                        Console.Clear();
                        Console.WriteLine(angleStatus + "\t" + outputStatus + "\t" + String.Format(memoryChecker ? "M" : ""));
                        Console.WriteLine(output.ToString());
                    }
                    else
                    {
                        if (currentstring == "" && input.Key != ConsoleKey.Backspace)
                        {
                            continue;
                        }
                        string temp = currentstring;


                        output.Append(temp);
                        if (IsOperand(temp) && nexttimeCall == false)
                        {
                            number += temp;

                        }
                        else
                        {
                            number = "";

                        }
                        Console.Clear();
                        Console.WriteLine(angleStatus + "\t" + outputStatus + "\t" + String.Format(memoryChecker ? "M" : ""));
                        Console.WriteLine(output.ToString());

                    }
                    if (nexttimeCall == true)
                    {
                        if (output[output.Length - 1] >= '0' && output[output.Length - 1] <= '9' && Isfunction == false)
                        {
                            Console.Clear();
                            output.Clear();
                            Console.WriteLine(angleStatus + "\t" + outputStatus + "\t" + String.Format(memoryChecker ? "M" : ""));
                            Console.WriteLine(output.ToString());
                            output.Append(currentstring);
                            number = currentstring;
                        }
                        nexttimeCall = false;
                    }

                    if (output.Length > 0 && sequentialOperatorCame == false && Isfunction == false)
                    {
                        //Console.Write(currentstring);
                        Console.Write(number);
                    }

                    if (input.Key == ConsoleKey.Backspace)
                    {
                        if (output.Length > 0)
                        {
                            output.Remove(output.Length - 1, 1);
                        }
                        Console.Clear();
                        Console.WriteLine(angleStatus + "\t" + outputStatus + "\t" + String.Format(memoryChecker ? "M" : ""));
                        Console.Write(output.ToString());
                    }
                } while ((input.Key != ConsoleKey.Enter) && (input.Key != ConsoleKey.OemPlus));

                Console.Clear();
                if (output.Length > 0)
                {
                    try
                    {
                        result = Arithmetic.Evaluate(output.ToString());
                        Console.WriteLine(angleStatus + "\t" + outputStatus + "\t" + String.Format(memoryChecker ? "M" : ""));
                        Console.WriteLine(output.ToString() + "=");
                        if (ScientificNotation)
                        {
                            Console.Write(PowerCalculator.ToScientificNotation(Convert.ToDouble(result)));
                        }
                        else
                        {
                            Console.WriteLine(result);
                        }
                    }
                    catch (DivideByZeroException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
                else
                {
                    output.Append(0);
                    Console.WriteLine(output.ToString() + "=");
                    Console.Write(0);
                }
                output.Clear();
                output.Append(result);
                number = result.ToString();
                nexttimeCall = true;
            }
        }
        static string InputValue(ConsoleKeyInfo inputKey)
        {
            switch (inputKey.Key)
            {
                case ConsoleKey.D:
                    if ((inputKey.Modifiers & ConsoleModifiers.Alt) != 0)
                    {
                        FormatCall();
                        Console.Write($"{output}dms({number})");
                        return PowerCalculator.ToDMS(Convert.ToDouble(number)).ToString();
                    }
                    else
                    {
                        FormatCall();
                        Console.Write($"{output}deg({number})");
                        return PowerCalculator.DMSToDegree(Convert.ToDouble(number)).ToString();
                    }
                case ConsoleKey.M:
                    if (number == "")
                    {
                        number = "0";
                    }
                    if ((inputKey.Modifiers & ConsoleModifiers.Control) != 0)   //MS
                    {
                        memory = Convert.ToDouble(number);
                        memoryChecker = true;
                        return "";
                    }
                    else if ((inputKey.Modifiers & ConsoleModifiers.Shift) != 0) //M+
                    {
                        memory += Convert.ToDouble(number);
                        memoryChecker = true;
                        return "";
                    }
                    else if ((inputKey.Modifiers & ConsoleModifiers.Alt) != 0)  //M-
                    {
                        memory -= Convert.ToDouble(number);
                        memoryChecker = true;
                        return "";
                    }
                    else      //MR
                    {
                        if (memoryChecker == false)
                        {
                            return "";
                        }
                        else
                        {
                            if (memory >= 0)
                            {
                                return memory.ToString();
                            }
                            else
                                return "(" + memory.ToString() + ")";
                        }
                    }
                case ConsoleKey.B:  //MC
                    memory = 0;
                    memoryChecker = false;
                    return "";
                case ConsoleKey.S:
                    if ((inputKey.Modifiers & ConsoleModifiers.Control) != 0)
                    {
                        FormatCall();
                        Double.TryParse(number, out double newNumber);
                        Console.Write($"{output}sinh({newNumber})");
                        string tempValue = "(" + PowerCalculator.Sinh(newNumber, angleStatus).ToString() + ")";
                        return tempValue;
                    }
                    else if ((inputKey.Modifiers & ConsoleModifiers.Alt) != 0)
                    {
                        FormatCall();
                        Double.TryParse(number, out double newNumber);
                        Console.Write($"{output}sin^(-1)({newNumber})");
                        string tempValue = "(" + PowerCalculator.ArcSin(newNumber, angleStatus).ToString() + ")";
                        return tempValue;
                    }
                    else
                    {
                        FormatCall();
                        Double.TryParse(number, out double newNumber);
                        Console.Write($"{output}sin({number})");
                        string tempValue = PowerCalculator.Sin(newNumber, angleStatus).ToString();
                        return "(" + tempValue + ")";
                    }
                case ConsoleKey.Q:
                    if ((inputKey.Modifiers & ConsoleModifiers.Control) != 0)
                    {
                        FormatCall();
                        Double.TryParse(number, out double newNumber);
                        Console.Write($"{output}Csch({newNumber})");
                        string tempValue = "(" + PowerCalculator.Cosech(newNumber, angleStatus).ToString() + ")";
                        return tempValue;
                    }
                    else if ((inputKey.Modifiers & ConsoleModifiers.Alt) != 0)
                    {
                        FormatCall();
                        Double.TryParse(number, out double newNumber);
                        Console.Write($"{output}Csc^(-1)({newNumber})");
                        string tempValue = "(" + PowerCalculator.ArcCosec(newNumber, angleStatus).ToString() + ")";
                        return tempValue;
                    }
                    else
                    {
                        FormatCall();
                        Double.TryParse(number, out double newNumber);
                        Console.Write($"{output}Csc({newNumber})");
                        string tempValue = "(" + PowerCalculator.Cosec(newNumber, angleStatus).ToString() + ")";
                        number = "";
                        return tempValue;
                    }
                case ConsoleKey.C:
                    if ((inputKey.Modifiers & ConsoleModifiers.Control) != 0)
                    {
                        FormatCall();
                        Double.TryParse(number, out double newNumber);
                        Console.Write($"{output}Cosh({newNumber})");
                        string tempValue = "(" + PowerCalculator.Cosh(newNumber, angleStatus).ToString() + ")";
                        number = "";
                        return tempValue;
                    }
                    else if ((inputKey.Modifiers & ConsoleModifiers.Alt) != 0)
                    {
                        FormatCall();
                        Double.TryParse(number, out double newNumber);
                        Console.Write($"{output}Cos^(-1)({newNumber})");
                        string tempValue = "(" + PowerCalculator.ArcCos(newNumber, angleStatus).ToString() + ")";
                        number = "";
                        return tempValue;
                    }
                    else
                    {
                        FormatCall();
                        Double.TryParse(number, out double newNumber);
                        Console.Write($"{output}Cos({newNumber})");
                        string tempValue = "(" + PowerCalculator.Cos(newNumber, angleStatus).ToString() + ")";
                        number = "";
                        return tempValue;
                    }
                case ConsoleKey.T:
                    if ((inputKey.Modifiers & ConsoleModifiers.Control) != 0)
                    {
                        FormatCall();
                        Double.TryParse(number, out double newNumber);
                        Console.Write($"{output}tanh({newNumber})");
                        string tempValue = "(" + PowerCalculator.Tanh(newNumber, angleStatus).ToString() + ")";
                        number = "";
                        return tempValue;
                    }
                    else if ((inputKey.Modifiers & ConsoleModifiers.Alt) != 0)
                    {
                        FormatCall();
                        Double.TryParse(number, out double newNumber);
                        Console.Write($"{output}tan^(-1)({newNumber})");
                        string tempValue = "(" + PowerCalculator.ArcTan(newNumber, angleStatus).ToString() + ")";
                        number = "";
                        return tempValue;
                    }
                    else
                    {
                        FormatCall();
                        Double.TryParse(number, out double newNumber);
                        Console.Write($"{output}tan({newNumber})");
                        string tempValue = "(" + PowerCalculator.Tan(newNumber, angleStatus).ToString() + ")";
                        number = "";
                        return tempValue;
                    }
                case ConsoleKey.O:
                    if ((inputKey.Modifiers & ConsoleModifiers.Control) != 0)
                    {
                        FormatCall();
                        Double.TryParse(number, out double newNumber);
                        Console.Write($"{output}Coth({newNumber})");
                        string tempValue = "(" + PowerCalculator.Coth(newNumber, angleStatus).ToString() + ")";
                        number = "";
                        return tempValue;
                    }

                    else if ((inputKey.Modifiers & ConsoleModifiers.Alt) != 0)
                    {
                        FormatCall();
                        Double.TryParse(number, out double newNumber);
                        Console.Write($"{output}Cot^(-1)({newNumber})");
                        string tempValue = "(" + PowerCalculator.ArcCot(newNumber, angleStatus).ToString() + ")";
                        number = "";
                        return tempValue;
                    }
                    else
                    {
                        FormatCall();
                        Double.TryParse(number, out double newNumber);
                        Console.Write($"{output}Cot({newNumber})");
                        string tempValue = "(" + PowerCalculator.Cot(newNumber, angleStatus).ToString() + ")";
                        number = "";
                        return tempValue;
                    }
                case ConsoleKey.N:
                    if ((inputKey.Modifiers & ConsoleModifiers.Control) != 0)
                    {
                        FormatCall();
                        Double.TryParse(number, out double newNumber);
                        Console.Write($"{output}Sech({number})");
                        string tempValue = "(" + PowerCalculator.Sech(newNumber, angleStatus).ToString() + ")";
                        number = "";
                        return tempValue;
                    }
                    else if ((inputKey.Modifiers & ConsoleModifiers.Alt) != 0)
                    {
                        FormatCall();
                        Double.TryParse(number, out double newNumber);
                        Console.Write($"{output}Sec^(-1)({newNumber})");
                        string tempValue = "(" + PowerCalculator.ArcSec(newNumber, angleStatus).ToString() + ")";
                        number = "";
                        return tempValue;
                    }
                    else
                    {
                        FormatCall();
                        Double.TryParse(number, out double newNumber);
                        Console.Write($"{output}Sec({newNumber})");
                        string tempValue = "(" + PowerCalculator.Sec(newNumber, angleStatus).ToString() + ")";
                        number = "";
                        return tempValue;
                    }
                case ConsoleKey.D0:
                    if ((inputKey.Modifiers & ConsoleModifiers.Shift) != 0)
                    {
                        return ")";
                    }
                    else
                    {
                        return "0";
                    }
                case ConsoleKey.D1: return "1";
                case ConsoleKey.D2: return "2";
                case ConsoleKey.D3: return "3";
                case ConsoleKey.D4: return "4";
                case ConsoleKey.D5: return "5";
                case ConsoleKey.D6:
                    if ((inputKey.Modifiers & ConsoleModifiers.Shift) != 0)
                    {
                        return "^";
                    }
                    else
                    {
                        return "6";
                    }
                case ConsoleKey.D7: return "7";
                case ConsoleKey.D8:
                    if ((inputKey.Modifiers & ConsoleModifiers.Shift) != 0)
                    {
                        return "*";
                    }
                    else
                    {
                        return "8";
                    }
                case ConsoleKey.D9:
                    if ((inputKey.Modifiers & ConsoleModifiers.Shift) != 0)
                    {
                        return "(";
                    }
                    else
                    {
                        return "9";
                    }
                case ConsoleKey.NumPad0: return "0";
                case ConsoleKey.NumPad1: return "1";
                case ConsoleKey.NumPad2: return "2";
                case ConsoleKey.NumPad3: return "3";
                case ConsoleKey.NumPad4: return "4";
                case ConsoleKey.NumPad5: return "5";
                case ConsoleKey.NumPad6: return "6";
                case ConsoleKey.NumPad7: return "7";
                case ConsoleKey.NumPad8: return "8";
                case ConsoleKey.NumPad9: return "9";
                case ConsoleKey.L:
                    if ((inputKey.Modifiers & ConsoleModifiers.Shift) != 0)
                    {
                        FormatCall();
                        Console.Write($"{output}log({number})");
                        Double.TryParse(number, out double newNumber);
                        string ans = PowerCalculator.Log10(newNumber).ToString();
                        return ans;
                    }
                    else
                    {
                        FormatCall();
                        Console.Write($"{output}ln({number})");
                        Double.TryParse(number, out double newNumber);
                        string ans = PowerCalculator.Ln(newNumber).ToString();
                        return ans;
                    }
                case ConsoleKey.P:
                    if ((inputKey.Modifiers & ConsoleModifiers.Alt) != 0)
                    {
                        string tempValue = Math.PI.ToString();
                        return tempValue;
                    }
                    else if ((inputKey.Modifiers & ConsoleModifiers.Shift) != 0)               //2^(x)
                    {
                        FormatCall();
                        Double.TryParse(number, out double newNumber);
                        Console.Write($"{output}2^({newNumber})");
                        string ans = PowerCalculator.Exponentiation(2, newNumber).ToString();
                        return ans;
                    }
                    else if ((inputKey.Modifiers & ConsoleModifiers.Control) != 0)                  //10^(x)
                    {
                        FormatCall();
                        Double.TryParse(number, out double newNumber);
                        Console.Write($"{output}10^({newNumber})");
                        string ans = PowerCalculator.Exponentiation(10, newNumber).ToString();
                        return ans;
                    }
                    else                                       //power
                    {
                        return "^";
                    }
                case ConsoleKey.V:
                    outputCountTap++;
                    if (outputCountTap == 0)
                    {
                        outputStatus = "F-E";
                        ScientificNotation = false;
                    }
                    else if (outputCountTap == 1)
                    {
                        outputStatus = "E-F";
                        ScientificNotation = true;
                    }
                    else if (outputCountTap == 2)
                    {
                        outputCountTap = 0;
                        ScientificNotation = false;
                        outputStatus = "F-E";
                    }
                    return "";
                case ConsoleKey.J:
                    if ((inputKey.Modifiers & ConsoleModifiers.Alt) != 0)
                    {
                        FormatCall();
                        Double.TryParse(number, out double newNumber);
                        Console.Write($"{output}√({newNumber})");
                        string ans = PowerCalculator.SquareRoot(newNumber).ToString();
                        return ans;
                    }
                    else if ((inputKey.Modifiers & ConsoleModifiers.Shift) != 0)
                    {
                        FormatCall();
                        Double.TryParse(number, out double newNumber);
                        Console.Write($"{output}√({newNumber})");
                        string ans = PowerCalculator.CubeRoot(newNumber).ToString();
                        return ans;
                    }
                    else
                    {
                        return "";
                    }

                case ConsoleKey.G: 
                    if ((inputKey.Modifiers & ConsoleModifiers.Alt) != 0)                    //cube
                    {
                        FormatCall();
                        Console.Write($"{output}cube({number})");
                        Double.TryParse(number, out double newNumber);
                        string ans = PowerCalculator.Exponentiation(newNumber, 3).ToString();
                        return ans;
                    }
                    else if ((inputKey.Modifiers & ConsoleModifiers.Shift) != 0)              //squre
                    {
                        FormatCall();
                        Console.Write($"{output}cube({number})");
                        Double.TryParse(number, out double newNumber);
                        string ans = PowerCalculator.Exponentiation(newNumber, 2).ToString();
                        return ans;
                    }
                    else
                    {
                        return "";
                    }
                case ConsoleKey.R:  //Random  
                    {
                        FormatCall();
                        double random = PowerCalculator.Random();
                        Console.Write($"{random}");
                        return random.ToString();
                    }
                case ConsoleKey.Oem4:
                    {
                        FormatCall();
                        Double.TryParse(number, out double newNumber);
                        Console.Write($"{output}Floring({newNumber})");
                        string ans = PowerCalculator.Floor(newNumber).ToString();
                        return ans;
                    }
                case ConsoleKey.Oem6:
                    {
                        FormatCall();
                        Double.TryParse(number, out double newNumber);
                        Console.Write($"{output}Ceiling({newNumber})");
                        string ans = PowerCalculator.Ceiling(newNumber).ToString();
                        return ans;
                    }
                case ConsoleKey.F:
                    {
                        FormatCall();
                        Double.TryParse(number, out double newNumber);
                        Console.Write($"{output}fact({newNumber})");
                        string ans = PowerCalculator.Factorial(newNumber).ToString();
                        return ans;
                    }

                case ConsoleKey.Backspace: return "";
                case ConsoleKey.Enter: return "";
                case ConsoleKey.Add: return "+";
                case ConsoleKey.Subtract: return "-";
                case ConsoleKey.Multiply: return "*";
                case ConsoleKey.Divide: return "/";
                case ConsoleKey.Oem2: return "/";
                case ConsoleKey.OemPeriod: return ".";
                case ConsoleKey.Z:
                    angleCountTap++;
                    if (angleCountTap == 0)
                    {
                        angleStatus = "DEG";
                    }
                    else if (angleCountTap == 1)
                    {
                        angleStatus = "RAD";
                    }
                    else if (angleCountTap == 2)
                    {
                        angleStatus = "GRAD";
                    }
                    else if (angleCountTap == 3)
                    {
                        angleCountTap = 0;
                        angleStatus = "DEG";
                    }
                    return "";
                case ConsoleKey.A:
                    {
                        FormatCall();
                        Double.TryParse(number, out double newNumber);
                        Console.Write($"{output}abs({newNumber})");
                        string ans = PowerCalculator.Absolute(newNumber).ToString();
                        return ans;
                    }
                case ConsoleKey.E:
                    if ((inputKey.Modifiers & ConsoleModifiers.Shift) != 0)            //e value
                    {
                        FormatCall();
                        Console.Write($"{output}e^({number})");
                        return Math.E.ToString();
                    }
                    else                                                            //e^x
                    {
                        FormatCall();
                        Double.TryParse(number, out double newNumber);
                        Console.Write($"{output}e^({newNumber})");
                        string ans = PowerCalculator.Exp(Convert.ToDouble(newNumber)).ToString();
                        return ans;
                    }

                default: return "";
            }
            void FormatCall()
            {
                Isfunction = true;
                Console.Clear();
                output.Remove(output.Length - number.Length, number.Length);
            }
        }

        static bool IsOperator(string x)
        {
            return x == "+" || x == "-" || x == "*" || x == "/" || x == "^";
        }
        static bool IsOperand(string x)
        {
            return x == "0" || x == "1" || x == "2" || x == "3" || x == "4" || x == "5" || x == "6" || x == "7" || x == "8" || x == "9" || x == ".";
        }
        static string CusrorPosition()
        {
            int currentLeft = Console.CursorLeft;
            int currentTop = Console.CursorTop;

            StringBuilder capturedContent = new StringBuilder();

            // Capture the content before the cursor position until the start of the line or an operator is found
            for (int left = currentLeft - 1; left >= 0; left--)
            {
                char currentChar = Console.ReadKey().KeyChar;

                // Stop capturing if an operator is found or if we reached the start of the line
                if (!(currentChar >= '0' && currentChar <= '9') || left == 0)
                    break;

                capturedContent.Insert(0, currentChar);

                // Move the cursor one position to the left
                Console.SetCursorPosition(left - 1, currentTop);
            }

            // Move the cursor back to its original position
            Console.SetCursorPosition(currentLeft, currentTop);

            return capturedContent.ToString();
        }


    }
}
