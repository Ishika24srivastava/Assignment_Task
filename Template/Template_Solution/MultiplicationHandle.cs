using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Template_Solution
{
    public  class MultiplicationHandle
    {

            public static void MainEntry()
            {
                for (int i = 1; i <= 10; i++)
                {
                    Divide(i);
                }
            }

            static void Divide(int number)
            {
                float result = 0.0f;

                for (float i = 0.001f, multiplication = 0.0f; multiplication < 1.0f; i += 0.001f)
                {
                    multiplication = i * number;
                    result = i;
                }

                Console.WriteLine($"1/{number} = {result}");
            }
        }
    }






    