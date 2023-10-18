using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("Enter the size of the array: ");
        if (int.TryParse(Console.ReadLine(), out int size) && size > 0)
        {
            object[] array = new object[size];

            string firstInputType = InputValues(array, "Enter values for the array");
            OutputArray(array, "Array: ");
        }
        else
        {
            Console.WriteLine("Invalid input..");
        }
    }

    static string InputValues(object[] array, string outputLabel)
    {
        Console.WriteLine(outputLabel);
        string firstInputType = null;

        for (int i = 0; i < array.Length; i++)
        {
            Console.Write($"Enter value {i + 1}: ");
            string input = Console.ReadLine();

            if (i == 0)
            {
                firstInputType = GetInputType(input);
                if (firstInputType == null)
                {
                    Console.WriteLine("Invalid input.");
                    i--;
                }
                else
                {
                    array[i] = Convert.ChangeType(input, Type.GetType(firstInputType));
                }
            }
            else
            {
                if (IsCompatibleType(input, firstInputType))
                {
                    array[i] = Convert.ChangeType(input, Type.GetType(firstInputType));
                }
                else
                {
                    Console.WriteLine($"Invalid input.");
                    i--;
                }
            }
        }

        return firstInputType;
    }

    static string GetInputType(string input)
    {
        if (int.TryParse(input, out _))
            return "System.Int32";
        else if (float.TryParse(input, out _))
            return "System.Single";
        else if (double.TryParse(input, out _))
            return "System.Double";
        else
            return "System.String";
    }

    static bool IsCompatibleType(string input, string expectedType)
    {
        return expectedType != null && GetInputType(input) == expectedType;
    }

    static void OutputArray(object[] array, string label)
    {
        Console.WriteLine(label);
        foreach (var item in array)
        {
            Console.WriteLine(item);
        }
    }
}
