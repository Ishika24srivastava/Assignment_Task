using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("Enter the size of the array: ");
        if (int.TryParse(Console.ReadLine(), out int size) && size > 0)
        {
            object[] array = new object[size];

            Type firstInputType = InputValues(array, "Enter values for the array");
            OutputArray(array, "Array: ");
        }
        else
        {
            Console.WriteLine("Invalid input..");
        }
    }

    static Type InputValues(object[] array, string outputLabel)
    {
        Console.WriteLine(outputLabel);
        Type firstInputType = null;

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
                    array[i] = Convert.ChangeType(input, firstInputType);
                }
            }
            else
            {
                if (IsCompatibleType(input, firstInputType))
                {
                    array[i] = Convert.ChangeType(input, firstInputType);
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

    static Type GetInputType(string input)
    {
        if (int.TryParse(input, out _))
            return typeof(int);
        else if (float.TryParse(input, out _))
            return typeof(float);
        else if (double.TryParse(input, out _))
            return typeof(double);
        else
            return typeof(string);
    }

    static bool IsCompatibleType(string input, Type expectedType)
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
