using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Template_Solution
{
    public class NestedFunction
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="a">First</param>
        /// <param name="b">Second</param>
        /// <returns>Reminder</returns>
        public static int Add(int a, int b)
        {
          

            int result = a + b;
            return result;
          
        }

        public static void Main2()
        {
            int sum = Add(b:9,a:7);
            Console.WriteLine("This is the sum: " + sum);
            void Function1()
            {
                Console.WriteLine("Function 1 called ");
            }
            Function1();
            {
                Console.WriteLine("Function 2 called ");
            }
        }

        
    }
}
