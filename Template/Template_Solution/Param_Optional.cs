using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Template_Solution
{
    public class Param_Optional
    {
        public static  void Param(float m=11, params int[] args)          //   Param Keyword
        {

            int sum = 0;
            for(int i=0;i<args.Length; i++) { 
            
                sum+= args[i];
            }
            Console.WriteLine(sum);
            Console.WriteLine(m);
           /* float num1 = 1.00f;
            //int num2 = 0;
            float num2 = 0.005f;
            float num3=num1 + num2;
            Console.WriteLine(num3);*/
        }
    }
}
