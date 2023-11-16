using System;

namespace Template_Solution
{
    internal class Template_Program
    {
        public static void Templateclass()
        {
            Console.Write("Enter the size of the array: ");

            if (int.TryParse(Console.ReadLine(), out int size))
            {
                object[] array = new object[size];
                string firstInputType = null;

                Console.WriteLine("Enter values for the array");

                for (int i = 0; i < size; i++)
                {
                    Console.Write($"Enter value {i + 1}: ");
                    string input = Console.ReadLine();

                    string inputType = GetInputType(input);

                    if (i == 0)
                    {
                        if (inputType == null)
                        {
                            Console.WriteLine("Invalid input.");
                            i--;
                        }
                        else
                        {
                            firstInputType = inputType;
                            array[i] = Convert.ChangeType(input, Type.GetType(firstInputType));
                        }
                    }
                    else
                    {
                        if (inputType != null && inputType == firstInputType)
                        {
                            array[i] = Convert.ChangeType(input, Type.GetType(firstInputType));
                        }
                        else
                        {
                            Console.WriteLine("Invalid input.");
                            i--;
                        }
                    }
                }

                OutputArray(array, "Array: ");
            }
            else
            {
                Console.WriteLine("Invalid input..");
            }
        }
        ~Template_Program()
        {
            GC.Collect();
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

        static void OutputArray(object[] array, string label)
        {
            Console.WriteLine(label);
            foreach (var item in array)
            {
                Console.WriteLine(item);
            }
        }
    }
}
