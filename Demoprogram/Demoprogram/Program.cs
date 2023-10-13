using System;

class Program
{
    static void Main()
    {
       

        Console.Write("Enter an integer value for operand1: ");
        int operand1 = Convert.ToInt32(Console.ReadLine());

        Console.Write("Enter an integer value for operand2: ");
        int operand2 = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("1. AND");
        Console.WriteLine("2. OR");
        Console.WriteLine("3. XOR");
        Console.WriteLine("4. NOT");
        Console.Write("Enter your choice (1/2/3/4): ");

        int choice = Convert.ToInt32(Console.ReadLine());
        int result = 0;

        switch (choice)
        {
            case 1:
                {
                    result = operand1 & operand2;
                    break;
                }

            case 2:
                {
                    result = operand1 | operand2;
                    break;
                }

            case 3:
                { 
                    result = operand1 ^ operand2;
                    break;
                }

            case 4:
                {
                    result = ~operand1;
                    break;
                }

            default:
                Console.WriteLine("Invalid choice.");
                return;
        }

        Console.WriteLine("Result : "+result);
    }
}
