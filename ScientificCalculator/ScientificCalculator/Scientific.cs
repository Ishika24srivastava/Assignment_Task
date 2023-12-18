using System;
using ArithmeticOperations;
using PowerOperations;
using System.Text;

namespace ScientificCalculator
{
    internal class Scientific
    {
        static bool nexttime = false;
        static string ToggleStatus1 = "DEG";
        static string ToggleStatus2 = "F-E";
        static int keyPressedCount = 0;
        static int formatChange = 0;
        static StringBuilder output = new StringBuilder();
        static string number = "";
        static double memory = 0;
        static bool inMemory = false;
        static bool isToggleStatus2=false ;
        static bool Isfunction = false;
        static string currenttrignoFunction = "";
        
        static void Main()
        {
            Console.WriteLine("===============================SCIENTIFIC CALCULATOR=====================================");
            ConsoleKeyInfo input;
            Console.CursorVisible = false;
            bool sequentialOperatorCame = false;
            double result = 0;
            PrintKeys();
            Console.WriteLine($"{ToggleStatus1}  |  {ToggleStatus2}  |  {(inMemory ? "M" : "")} ");
            Console.TreatControlCAsInput = true;

            while (true)
            {
                do
                {
                    input = Console.ReadKey(true);
                    sequentialOperatorCame = false;
                    Isfunction = false;
                    string currentstring = Value(input);
                    if (IsOperator(currentstring) && output.Length != 0 && IsOperator(output[output.Length - 1].ToString()))
                    {
                        sequentialOperatorCame = true;
                        output.Remove(output.Length - 1, 1);
                        output.Append(currentstring);
                        Console.Clear();
                        PrintKeys();
                        Console.WriteLine($"{ToggleStatus1}  |  {ToggleStatus2}  |  {(inMemory ? "M" : "")} ");
                        Console.Write(output.ToString());
                    }
                    else if (IsOperator(currentstring) && output.Length == 0)
                    {
                        sequentialOperatorCame = true;
                        output.Append("0");
                        output.Append(currentstring);
                        Console.Clear();
                        PrintKeys();
                        Console.WriteLine($"{ToggleStatus1}  |  {ToggleStatus2}  |  {(inMemory ? "M" : "")} ");
                        Console.Write(output.ToString());
                    }
                    else
                    {
                        if (currentstring == "" && input.Key != ConsoleKey.Backspace)
                        {
                            continue;
                        }
                        string temp = currentstring;
                        output.Append(temp);
                        if (temp == "(NaN)")
                        {
                            Console.Clear();
                            output.Clear();
                            PrintKeys();
                            Console.WriteLine($"{ToggleStatus1}  |  {ToggleStatus2}  |  {(inMemory ? "M" : "")} ");
                            Console.WriteLine("Invalid Input");
                        }
                        if (IsOperand(temp) && nexttime == false)
                        {
                            number += temp;
                        }
                        else if (IsOperator(temp))
                        {
                            number = "";
                            currenttrignoFunction = "";
                        }
                        else 
                        {
                            
                        }
                    }

                    if (nexttime == true)
                    {
                        if (output[output.Length - 1] >= '0' && output[output.Length - 1] <= '9' && Isfunction == false)
                        {
                            Console.Clear();
                            PrintKeys();
                            output.Clear();
                            Console.WriteLine($"{ToggleStatus1}   |   {ToggleStatus2}  |  {(inMemory ? "M" : "")} ");
                            output.Append(currentstring);
                            number = currentstring;
                        }
                        nexttime = false;
                    }

                    if (output.Length > 0 && sequentialOperatorCame == false && Isfunction == false)
                    {
                       
                        Console.Write(currentstring);

                    }

                    if (input.Key == ConsoleKey.Backspace)
                    {
                        if (output.Length > 0)
                        {
                            output.Remove(output.Length - 1, 1);
                        }
                        Console.Clear();
                        PrintKeys();
                        Console.WriteLine($"{ToggleStatus1}   |   {ToggleStatus2}  |  {(inMemory ? "M" : "")} ");
                        Console.Write(output.ToString());
                    }
                } while ((input.Key != ConsoleKey.Enter) && (input.Key != ConsoleKey.OemPlus));

                Console.Clear();
                PrintKeys();
                if (output.Length > 0)
                {
                    try
                    { 
                        result = Arithmetic.Evaluate(output.ToString());
                        Console.WriteLine($"{ToggleStatus1}  |  {ToggleStatus2}  |  {(inMemory ? "M" : "")} ");
                        Console.WriteLine(output.ToString() + "=");
                        if (isToggleStatus2)
                        {
                            Console.Write(Power.ConvertToScientificNotation(Convert.ToDouble(result)));
                        }
                        else
                        {
                            Console.Write(result);
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
                nexttime = true;
            }
        }

        static string Value(ConsoleKeyInfo input)
        {
            switch (input.Key)
            {
                case ConsoleKey.M:
                    if ((input.Modifiers & ConsoleModifiers.Shift) != 0)    //M+
                    {
                        if (number == "")
                        {
                            number = "0";
                        }
                        inMemory = true;
                        Double.TryParse(number, out double newNumber);
                        memory += newNumber;
                        Console.Clear();
                        PrintKeys();
                        Console.WriteLine($"{ToggleStatus1}   |   {ToggleStatus2}  |  {(inMemory ? "M" : "")} ");
                        Console.Write(output.ToString());
                        return "";
                    }
                    else if ((input.Modifiers & ConsoleModifiers.Alt) != 0)   //M- left side
                    {
                        if (number == "")
                        {
                            number = "0";
                        }
                        inMemory = true;
                        Double.TryParse(number, out double newNumber);
                        memory -= newNumber;
                        if (memory == 0)
                        {
                            Console.Clear();
                            PrintKeys();
                            Console.WriteLine($"{ToggleStatus1}   |   {ToggleStatus2}  |  {(inMemory ? "M" : "")} ");
                            Console.Write(output.ToString());
                        }
                        return "";
                    }
                    else                                            //MS 
                    {
                        inMemory = true;
                        Double.TryParse(number, out double newNumber);
                        memory = newNumber;
                        Console.Clear();
                        PrintKeys();
                        Console.WriteLine($"{ToggleStatus1}   |   {ToggleStatus2}  |  {(inMemory ? "M" : "")} ");
                        Console.Write(output.ToString());
                        return "";
                    }

                case ConsoleKey.B:
                    if ((input.Modifiers & ConsoleModifiers.Shift) != 0) //MR
                    {
                        return memory.ToString();
                    }
                    else
                    {                                                //MC
                        inMemory = false;
                        memory = 0;
                        Console.Clear();
                        PrintKeys();
                        Console.WriteLine($"{ToggleStatus1}   |   {ToggleStatus2}  |  {(inMemory ? "M" : "")} ");
                        Console.Write(output.ToString());
                        return "";
                    }

                case ConsoleKey.S:
                    {

                        if ((input.Modifiers & ConsoleModifiers.Shift) != 0)
                        {
                            formatView();
                            Double.TryParse(number, out double newNumber);

                            if (currenttrignoFunction != "")
                            {

                                if (output.Length >= 2)
                                {
                                    output.Remove(output.Length - 2, 2);
                                }

                                Console.Write($"{output}sinh({currenttrignoFunction})");
                            }
                            else
                            {
                                Console.Write($"{output}sinh({number})");
                            }
                            string ans = Power.SineHyp(newNumber).ToString();
                            number = ans;
                            currenttrignoFunction = $"sin({number})";
                            return "(" + ans + ")";

                        }
                        else if ((input.Modifiers & ConsoleModifiers.Alt) != 0)
                        {
                            formatView();
                            Double.TryParse(number, out double newNumber);

                            if (currenttrignoFunction != "")
                            {
                                output.Remove(output.Length - 2, 2);
                                Console.Write($"{output}sin^(-1)({currenttrignoFunction})");
                            }
                            else
                            {
                                Console.Write($"{output}sin^(-1)({number})");
                            }
                            string ans = Power.SineInverse(newNumber).ToString();
                            number = ans;
                            currenttrignoFunction = $"sin({number})";
                            return "(" + ans + ")";
                        }
                        else
                        {
                            formatView();
                            Double.TryParse(number, out double newNumber);

                            if (currenttrignoFunction != "")
                            {
                                if (output.Length >= 2)
                                {
                                    output.Remove(output.Length - 2, 2);
                                }

                                Console.Write($"{output}sin({currenttrignoFunction})");
                            }

                            else
                            {
                                Console.Write($"{output}sin({number})");
                            }
                            string ans = Power.Sine(newNumber, ToggleStatus1).ToString();
                            number = ans;
                            currenttrignoFunction = $"sin({number})";
                            return "(" + ans + ")";
                        }
                    }
                case ConsoleKey.Q:
                    {

                        if ((input.Modifiers & ConsoleModifiers.Shift) != 0)
                        {
                            formatView();
                            Double.TryParse(number, out double newNumber);
                            if (currenttrignoFunction != "")
                            {
                                if (output.Length >= 2)
                                {
                                    output.Remove(output.Length - 2, 2);
                                }

                                Console.Write($"{output}Csch({currenttrignoFunction})");
                            }
                            else
                            {
                                Console.Write($"{output}Csch({number})");
                            }
                            string ans = Power.CosecHyp(newNumber).ToString();
                            number = ans;
                            currenttrignoFunction = $"Csch({number})";
                            return "(" + ans + ")";

                        }
                        else if ((input.Modifiers & ConsoleModifiers.Alt) != 0)
                        {
                            formatView();
                            Double.TryParse(number, out double newNumber);
                            if (currenttrignoFunction != "")
                            {
                                if (output.Length >= 2)
                                {
                                    output.Remove(output.Length - 2, 2);
                                }

                                Console.Write($"{output}Csc^(-1)({currenttrignoFunction})");
                            }
                            else
                            {
                                Console.Write($"{output}Csc^(-1)({number})");
                            }
                            string ans = Power.CosecInverse(newNumber).ToString();
                            number = ans;
                            currenttrignoFunction = $"Csch({number})";
                            return "(" + ans + ")";

                        }
                        else
                        {
                            formatView();
                            Double.TryParse(number, out double newNumber);
                            if (currenttrignoFunction != "")
                            {
                                if (output.Length >= 2)
                                {
                                    output.Remove(output.Length - 2, 2);
                                }

                                Console.Write($"{output}Csc({currenttrignoFunction})");
                            }
                            else
                            {
                                Console.Write($"{output}Csc({number})");
                            }
                            string ans = Power.Cosec(newNumber, ToggleStatus1).ToString();
                            number = ans;
                            currenttrignoFunction = $"Csch({number})";
                            return "(" + ans + ")";

                        }
                    }
                case ConsoleKey.C:
                    {

                        if ((input.Modifiers & ConsoleModifiers.Shift) != 0)
                        {
                            formatView();
                            Double.TryParse(number, out double newNumber);
                            if (currenttrignoFunction != "")
                            {
                                if (output.Length >= 2)
                                {
                                    output.Remove(output.Length - 2, 2);
                                }

                                Console.Write($"{output}Cosh({currenttrignoFunction})");
                            }
                            else
                            {
                                Console.Write($"{output}Cosh({number})");
                            }
                            string ans = Power.CosineHyp(newNumber).ToString();
                            number = ans;
                            currenttrignoFunction = $"Cosh({number})";
                            return "(" + ans + ")";

                        }

                        else if ((input.Modifiers & ConsoleModifiers.Alt) != 0)
                        {
                            formatView();
                            Double.TryParse(number, out double newNumber);

                            if (currenttrignoFunction != "")
                            {
                                if (output.Length >= 2)
                                {
                                    output.Remove(output.Length - 2, 2);
                                }

                                Console.Write($"{output}Cos^(-1)({currenttrignoFunction})");
                            }
                            else
                            {
                                Console.Write($"{output}Cos^(-1)({number})");
                            }
                            string ans = Power.CosineInverse(newNumber).ToString();
                            number = ans;
                            currenttrignoFunction = $"Csch({number})";
                            return "(" + ans + ")";

                        }



                        else
                        {
                            formatView();
                            Double.TryParse(number, out double newNumber);
                            if (currenttrignoFunction != "")
                            {
                                if (output.Length >= 2)
                                {
                                    output.Remove(output.Length - 2, 2);
                                }

                                Console.Write($"{output}Cos({currenttrignoFunction})");
                            }
                            else
                            {
                                Console.Write($"{output}Cos({number})");
                            }
                            string ans = Power.Cosine(newNumber, ToggleStatus1).ToString();
                            number = ans;
                            currenttrignoFunction = $"Cos({number})";
                            return "(" + ans + ")";


                        }
                    }


                case ConsoleKey.T:
                    {

                        if ((input.Modifiers & ConsoleModifiers.Shift) != 0)
                        {
                            formatView();
                            Double.TryParse(number, out double newNumber);
                            if (currenttrignoFunction != "")
                            {
                                if (output.Length >= 2)
                                {
                                    output.Remove(output.Length - 2, 2);
                                }

                                Console.Write($"{output}tanh({currenttrignoFunction})");
                            }
                            else
                            {
                                Console.Write($"{output}tanh({number})");
                            }
                            string ans = Power.TangentHyp(newNumber).ToString();
                            number = ans;
                            currenttrignoFunction = $"tanh({number})";
                            return "(" + ans + ")";


                        }
                        else if ((input.Modifiers & ConsoleModifiers.Alt) != 0)
                        {
                            formatView();
                            Double.TryParse(number, out double newNumber);
                            if (currenttrignoFunction != "")
                            {
                                if (output.Length >= 2)
                                {
                                    output.Remove(output.Length - 2, 2);
                                }

                                Console.Write($"{output}tan^(-1)({currenttrignoFunction})");
                            }
                            else
                            {
                                Console.Write($"{output}tan^(-1)({number})");
                            }
                            string ans = Power.TangentInverse(newNumber, ToggleStatus1).ToString();
                            number = ans;
                            currenttrignoFunction = $"tan^(-1)({number})";
                            return "(" + ans + ")";

                        }
                        else
                        {
                            formatView();
                            Double.TryParse(number, out double newNumber);
                            if (currenttrignoFunction != "")
                            {
                                if (output.Length >= 2)
                                {
                                    output.Remove(output.Length - 2, 2);
                                }

                                Console.Write($"{output}tan({currenttrignoFunction})");
                            }
                            else
                            {
                                Console.Write($"{output}tan({number})");
                            }
                            string ans = Power.Tangent(newNumber, ToggleStatus1).ToString();
                            number = ans;
                            currenttrignoFunction = $"tan^(-1)({number})";
                            return "(" + ans + ")";


                        }
                    }
                case ConsoleKey.O:
                    {

                        if ((input.Modifiers & ConsoleModifiers.Shift) != 0)
                        {
                            formatView();
                            Double.TryParse(number, out double newNumber);
                            if (currenttrignoFunction != "")
                            {
                                if (output.Length >= 2)
                                {
                                    output.Remove(output.Length - 2, 2);
                                }

                                Console.Write($"{output}Coth({currenttrignoFunction})");
                            }
                            else
                            {
                                Console.Write($"{output}Coth({number})");
                            }
                            string ans = Power.CotHyp(newNumber).ToString();
                            number = ans;
                            currenttrignoFunction = $"Coth({number})";
                            return "(" + ans + ")";


                        }
                        else if ((input.Modifiers & ConsoleModifiers.Alt) != 0)
                        {
                            formatView();
                            Double.TryParse(number, out double newNumber);
                            if (currenttrignoFunction != "")
                            {
                                if (output.Length >= 2)
                                {
                                    output.Remove(output.Length - 2, 2);
                                }

                                Console.Write($"{output}Cot^(-1)({currenttrignoFunction})");
                            }
                            else
                            {
                                Console.Write($"{output}Cot^(-1)({number})");
                            }
                            string ans = Power.CotInverse(newNumber,ToggleStatus1).ToString();
                            number = ans;
                            currenttrignoFunction = $"Coth({number})";
                            return "(" + ans + ")";

                        }
                        else
                        {
                            formatView();
                            Double.TryParse(number, out double newNumber);
                            if (currenttrignoFunction != "")
                            {
                                if (output.Length >= 2)
                                {
                                    output.Remove(output.Length - 2, 2);
                                }

                                Console.Write($"{output}Cot({currenttrignoFunction})");
                            }
                            else
                            {
                                Console.Write($"{output}Cot({number})");
                            }
                            string ans = Power.Cot(newNumber, ToggleStatus1).ToString();
                            number = ans;
                            currenttrignoFunction = $"Coth({number})";
                            return "(" + ans + ")";


                        }
                    }
                case ConsoleKey.N:
                    {

                        if ((input.Modifiers & ConsoleModifiers.Shift) != 0)
                        {
                            formatView();
                            Double.TryParse(number, out double newNumber);
                            if (currenttrignoFunction != "")
                            {
                                if (output.Length >= 2)
                                {
                                    output.Remove(output.Length - 2, 2);
                                }

                                Console.Write($"{output}Sech({currenttrignoFunction})");
                            }
                            else
                            {
                                Console.Write($"{output}Sech({number})");
                            }
                            string ans = Power.SecHyp(newNumber).ToString();
                            number = ans;
                            currenttrignoFunction = $"Sech({number})";
                            return "(" + ans + ")";


                        }
                        else if ((input.Modifiers & ConsoleModifiers.Alt) != 0)
                        {
                            formatView();
                            Double.TryParse(number, out double newNumber);
                            if (currenttrignoFunction != "")
                            {
                                if (output.Length >= 2)
                                {
                                    output.Remove(output.Length - 2, 2);
                                }

                                Console.Write($"{output}Sec^(-1)({currenttrignoFunction})");
                            }
                            else
                            {
                                Console.Write($"{output}Sec^(-1)({number})");
                            }
                            string ans = Power.SecInverse(newNumber).ToString();
                            number = ans;
                            currenttrignoFunction = $"Sec^(-1)({number})";
                            return "(" + ans + ")";

                        }
                        else
                        {
                            formatView();
                            Double.TryParse(number, out double newNumber);
                            if (currenttrignoFunction != "")
                            {
                                if (output.Length >= 2)
                                {
                                    output.Remove(output.Length - 2, 2);
                                }

                                Console.Write($"{output}Sec({currenttrignoFunction})");
                            }
                            else
                            {
                                Console.Write($"{output}Sec({number})");
                            }
                            string ans = Power.Sec(newNumber, ToggleStatus1).ToString();
                            number = ans;
                            currenttrignoFunction = $"Sec({number})";
                            return "(" + ans + ")";

                        }
                    }
                case ConsoleKey.D0:
                    if ((input.Modifiers & ConsoleModifiers.Shift) != 0)
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
                case ConsoleKey.D5:
                    //if ((input.Modifiers & ConsoleModifiers.Shift) != 0)
                    //{
                    //    return "%";
                    //}
                    //else
                    {
                        return "5";
                    }
                case ConsoleKey.D6:
                    if ((input.Modifiers & ConsoleModifiers.Shift) != 0)
                    {
                        return "^";
                    }
                    else
                    {
                        return "6";
                    }
                case ConsoleKey.D7: return "7";
                case ConsoleKey.D8:
                    if ((input.Modifiers & ConsoleModifiers.Shift) != 0)
                    {
                        return "*";
                    }
                    else
                    {
                        return "8";
                    }
                case ConsoleKey.D9:
                    if ((input.Modifiers & ConsoleModifiers.Shift) != 0)
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
                    if ((input.Modifiers & ConsoleModifiers.Shift) != 0)
                    {
                        formatView();
                        Console.Write($"{number}log({number})");
                        Double.TryParse(number, out double newNumber);
                        string ans = Power.Log10(newNumber).ToString();
                        return ans;
                    }
                    else
                    {
                        formatView();
                        Console.Write($"{number}ln({number})");
                        Double.TryParse(number, out double newNumber);
                        string ans = Power.Ln(newNumber).ToString();
                        return ans;
                    }
                case ConsoleKey.D:
                    if ((input.Modifiers & ConsoleModifiers.Alt) != 0)
                    {
                        formatView();
                        Double.TryParse(number, out double newNumber);
                        Console.Write($"{output}dms({number})");
                        string ans = Power.ConvertToDMS(newNumber).ToString();
                        return ans;
                    }
                    else
                    {
                        formatView();
                        Double.TryParse(number, out double newNumber);
                        Console.Write($"{output}degrees({number})");
                        string ans = Power.DMSToDegree(newNumber).ToString();
                        return ans;
                    }
                case ConsoleKey.A:
                    if ((input.Modifiers & ConsoleModifiers.Alt) != 0)
                    {
                        formatView();
                        Double.TryParse(number, out double newNumber);
                        Console.Write($"{output}abs({number})");
                        string ans = Power.AbsoluteFunction(newNumber).ToString();
                        return ans;
                    }
                    else
                    {
                        Isfunction = true;
                        Console.Clear();
                        PrintKeys();
                        Console.WriteLine($"{ToggleStatus1}  |  {ToggleStatus2}  |  {(inMemory ? "M" : "")} ");
                        double random = Power.RandomFunction();
                        Console.Write($"{random}");
                        return random.ToString();
                    }

                case ConsoleKey.P:
                    if ((input.Modifiers & ConsoleModifiers.Alt) != 0)
                    {
                        return Math.PI.ToString();
                    }
                    else if ((input.Modifiers & ConsoleModifiers.Shift) != 0)
                    {
                        formatView();
                        Double.TryParse(number, out double newNumber);
                        Console.Write($"{output}2^({number})");
                        string ans = Power.Exponentiation(2, newNumber).ToString();
                        return ans;
                    }
                    else if ((input.Modifiers & ConsoleModifiers.Control) != 0)
                    {
                        formatView();
                        Double.TryParse(number, out double newNumber);
                        Console.Write($"{output}10^({number})");
                        string ans = Power.Exponentiation(10, newNumber).ToString();
                        return ans;
                    }
                    else
                    {
                        return "^";
                    }
                case ConsoleKey.E:
                    if ((input.Modifiers & ConsoleModifiers.Shift) != 0)
                    {
                        return Math.E.ToString();
                    }
                    else if ((input.Modifiers & ConsoleModifiers.Alt) != 0)
                    {
                        formatView();
                        Double.TryParse(number, out double newNumber);
                        Console.Write($"{output}{Power.ConvertToScientificNotation(newNumber)}");
                        output.Append(number);
                        return "";
                    }
                    else
                    {
                        formatView();
                        Double.TryParse(number, out double newNumber);
                        Console.Write($"{output}e^({number})");
                        string ans = Power.ePowerx(newNumber).ToString();
                        return ans;
                    }
                case ConsoleKey.V:
                    formatChange++;
                    if (formatChange == 0)
                    {
                        isToggleStatus2 = false;    // check toggle status is F_E
                        ToggleStatus2 = "F-E";
                    }
                    else if (formatChange == 1)
                    {
                        isToggleStatus2 = true;
                        ToggleStatus2 = "F-E";
                    }
                    else if (formatChange == 2)
                    {
                        isToggleStatus2 = false;
                        formatChange = 0;
                        ToggleStatus2 = "F-E";
                    }
                    Console.Clear();
                    PrintKeys();
                    Console.WriteLine($"{ToggleStatus1}  |  {ToggleStatus2}  |  {(inMemory ? "M" : "")} ");
                    Console.Write(output.ToString());
                    return "";
                case ConsoleKey.X:
                    keyPressedCount++;
                    if (keyPressedCount == 0)
                    {
                        ToggleStatus1 = "DEG";
                    }
                    else if (keyPressedCount == 1)
                    {
                        ToggleStatus1 = "RAD";
                    }
                    else if (keyPressedCount == 2)
                    {
                        ToggleStatus1 = "GRAD";
                    }
                    else if (keyPressedCount == 3)
                    {
                        keyPressedCount = 0;
                        ToggleStatus1 = "DEG";
                    }
                    Console.Clear();
                    PrintKeys();
                    Console.WriteLine($"{ToggleStatus1}  |  {ToggleStatus2}  |  {(inMemory ? "M" : "")} ");
                    Console.Write(output.ToString());
                    return "";

                case ConsoleKey.U:
                    {
                        formatView();
                        Double.TryParse(number, out double newNumber);

                        if ((input.Modifiers & ConsoleModifiers.Alt) != 0)
                        {
                            Console.Write($"{output}cube({newNumber})");
                            string ans = Power.Exponentiation(newNumber, 3).ToString();
                            return ans;
                        }
                        else
                        {
                            Console.Write($"{output}sqr({newNumber})");
                            string ans = Power.Exponentiation(newNumber, 2).ToString();
                            return ans;
                        }
                    }

                case ConsoleKey.R:
                    { 
                     formatView();
                     Double.TryParse(number, out double newNumber);

                    if ((input.Modifiers & ConsoleModifiers.Alt) != 0)
                    {
                        Console.Write($"{output}√({newNumber})");
                        string ans = Power.CubeRoot(newNumber).ToString();
                        return ans;
                    }
                    else if ((input.Modifiers & ConsoleModifiers.Shift) != 0)
                    {
                        if (newNumber < 0)
                        {
                            Console.WriteLine("Invalid Input");
                            return double.NaN.ToString();
                        }

                        Console.Write($"{output}√({newNumber})");
                        string ans = Power.SquareRoot(newNumber).ToString();
                        return ans;
                    }
                    else
                    {
                        return "";
                    }
                }


                case ConsoleKey.Oem4:
                    {
                        formatView();
                        Double.TryParse(number, out double newNumber);
                        Console.Write($"{output}floor({number})");
                        string ans = Power.FloorFunction(newNumber).ToString();
                        return ans;
                    }
                case ConsoleKey.Oem6:
                    {
                        formatView();
                        Double.TryParse(number, out double newNumber);
                        Console.Write($"{output}Ceiling({number})");
                        string ans = Power.CeilingFunction(newNumber).ToString();
                        return ans;
                    }
                case ConsoleKey.F:
                    {
                        formatView();
                        Double.TryParse(number, out double newNumber);
                        Console.Write($"{output}fact({number})");
                        string ans = Power.Factorial(newNumber).ToString();
                        return ans;
                    }
                case ConsoleKey.W:
                    {
                        formatView();                        
                        Double.TryParse(number, out double newNumber);
                        Console.Write($"{output}(-{number})");
                        string ans = (-newNumber).ToString();
                      //  number = ans;
                        return ans;
                    }
                case ConsoleKey.Z:
                    {
                        formatView();
                        Double.TryParse(number, out double newNumber);
                        Console.Write($"{output}abs({newNumber})");
                        string ans = Power.Absolute(newNumber).ToString();
                        return ans;
                    }
                case ConsoleKey.Delete:
                    {
                        Console.Clear();
                        output.Clear();
                        PrintKeys();
                        Console.WriteLine($"{ToggleStatus1}  |  {ToggleStatus1}  |  {(inMemory ? "M" : "")} ");
                        return "";
                    }
                case ConsoleKey.Escape:
                    Environment.Exit(-1);
                        return "";
                case ConsoleKey.Backspace: return "";
                case ConsoleKey.Add: return "+";
                case ConsoleKey.Subtract: return "-";
                case ConsoleKey.Multiply: return "*";
                case ConsoleKey.Divide: return "/";
                case ConsoleKey.Oem2: return "/";
                case ConsoleKey.OemPeriod: return ".";
                default: return "";
            }
        }
        
        //static double Modulus(double dividend, double divisor)
        //{
        //    // Calculate the remainder using the % operator
        //    double remainder = dividend % divisor;
        //    return remainder;
        //}
        static void formatView()
        {
            Isfunction = true;
            Console.Clear();
            PrintKeys();
            Console.WriteLine($"{ToggleStatus1}  |  {ToggleStatus2}  |  {(inMemory ? "M" : "")} ");
            int startIndex = Math.Max(output.Length - number.Length, 0);
            output = output.Remove(startIndex, number.Length);
        }

        static void KeyInfo()
        {
            Console.WriteLine("---------The keys selected for the operations performed are listed below:----------------------------");
            Console.WriteLine("Numbers (0-9) Range.\n" +
                "Functions:" + "                              " + "Operators:\n" +
                "sin: S" + "                                  " + "+: + \n" +
                "cos: C" + "                                  " + "-: - \n" +
                "tan: T" + "                                  " + "*: * or Shift + 8\n" +
                "sinh: Shift + S" + "                         " + "/: / \n" +
                "cosh: Shift + C" + "                         " + " ^: P orShift + 6\n" +
                "tanh: Shift + T" + "                         " + "\n" +
                "acos: Alt + C" + "                           " + ". :  .\n" +
                "asin: Alt + S" + "                           " + "\n" +
                "atan: Alt + T" + "                           " + "--Memory Operations:--\n" +
                "cot: O" + "                                  " + "MC: B\n" +
                "cosine: Q" + "                               " + "MS: M\n" +
                "sec: N" + "                                  " + "M+: Shift + M\n" +
                "csch: Shift + Q" + "                         " + "M -: Alt + M\n" +
                "sech: Shift + N" + "                         " + "MR: Shift + B\n" +
                "coth: Shift + 0" + "                         \n" +
                "acsc: Alt + Q" + "                           \n" +
                "asec: Alt + N" + "                           \n" +
                "acot: Alt + O" + "                          \n " +

    
                "squareroot: Shift+ R" + "                   \n" +
                "cuberoot: Alt+ R" + "                      \n" +
                "log: Alt + L" + "                           \n" + "--Other Operations:---\n" +
                "ln: L" + "                                   " + "Backspace: Backspace key\n" +
                "cube: Alt + U" + "                           " + "=: = or Enter key\n" +
                "+                                           "+"----Conversion------ \n"+                     
                "sqr: U" + "                                  " + "DEG/RAD/GRAD: X\n" +
                "rad: R" + "                                  " + "F-E/E-F: V\n" +
                "random: A\n" +
                "floor: [" + "                              " + "ceil: ]\n" +
                "fact: F" + "                               " + "PI: Alt + P" + "           " + "2^x:  Shift + P\n" +
                "negate: W" + "                             " + "e: Shift + E" + "          " + "10^X: Ctrl + P\n" +
                "exp: Alt+E" + "                            " + "e^x: E" + "                " + "abs: alt + A\n" +
                "toDms: Alt+ D" + "                         " + "Deg: D\n"+                 
                "Clear: Delete"+ "                          "+ "Exit : esc" 
         );
        }

        static void PrintKeys()
        {
            Console.SetCursorPosition(1, 4);
            KeyInfo();
            Console.SetCursorPosition(1, 1);
        }

        static bool IsOperator(string x)
        {
            return x == "+" || x == "-" || x == "*" || x == "/" || x == "^";
        }
        static bool IsOperand(string x)
        {
            return x == "1" || x == "2" || x == "3" || x == "4" || x == "5" || x == "6" || x == "7" || x == "8" || x == "9" || x == "0" || x == ".";
        }

    }
}
