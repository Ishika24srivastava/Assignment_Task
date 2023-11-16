using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Template_Solution
{
    /// <summary>
    /// 
    /// </summary>
    public class FunctionOverloading
    {
        /// <summary>
        ///  hyhello
        /// </summary>
        /// <param name="a">hello</param>
        /// <param name="b">hy</param>
        /// <returns>s</returns>
        public int Add( int a, int b)
        {
            return a + b;
        }
        

        public double Add(double a, double b)
        {
            return a + b;
        }
        
        public string Add(string a, string b)
        {
            return a + b;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="c"></param>
        /// <returns></returns>
        public int Add(int a,int b,int c)
        {
            return a + b + c;   
        }
       
        
        
    }

   public  class Program1  // In method overloading the return types does not matter beacuse it depends on the parameters passed in the method.
    {
        /// <summary>
        /// 
        /// </summary>
       public  static void Main1()
        {
            FunctionOverloading calculator = new FunctionOverloading();
            

            int result1 = calculator.Add(b: 5, a :3);
           
            Console.WriteLine("Adding integers: " + result1);

            double result2 = calculator.Add(2.5, 3.7);
            Console.WriteLine("Adding doubles: " + result2);

            string result3 = calculator.Add("Hello, ", "World!");
            Console.WriteLine("Concatenating strings: " + result3);

            int result4 = calculator.Add(2, 4, 5);
            Console.WriteLine("Adding integers: " + result4);
        }
    }
}
