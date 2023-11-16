using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Template_Solution
{
    internal class Parameter_Argument
    {
        public  static int  add(int a,int b) // Parameter
        {
            return a + b;
        }
        public void Anwser()
        {
            add(3, 5);   //Arguments
        }
    }
}
