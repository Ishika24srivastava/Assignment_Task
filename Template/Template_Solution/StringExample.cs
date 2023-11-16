using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Template_Solution
{
    public  class StringExample
    {
        public  static void StringExam()
        {
            string One = "  Hello,  How are  you!         ";                // string keyword
           // System.String two = "Welcome Every one";           // using System.String 
           

            //String   method 
            Console.WriteLine(One.Length);
            Console.WriteLine(One.ToUpper());
            Console.WriteLine(One.ToLower());
            Console.WriteLine(One.Trim());
            Console.WriteLine(One.IndexOf("lo"));
            Console.WriteLine(One.Replace("Hello", "HELLO"));
            Console.WriteLine(One.Substring(9, 15));
            Console.WriteLine("-------------------Split ---------------------------------------------------------");
            // Console.WriteLine(third.Split(','));
            string str = "apple,orange,banana";
            string[] fruits = str.Split(',');
            Console.WriteLine("Fruits:");

            foreach (string fruit1 in fruits)
            {
                Console.WriteLine(fruit1);
            }


            Console.WriteLine(1.0M / 3.0M * 3);
        }
       
    }
}
