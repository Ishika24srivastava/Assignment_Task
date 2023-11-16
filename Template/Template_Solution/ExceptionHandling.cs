using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Template_Solution
{
    public class ExceptionHandling
    {
        public static  void Try()
        {
            try
            {
                //   Array Index Out of =Value Exception
                /*int[] a = { 2, 3, 4, 4, 5, 55, 6 };
                Console.WriteLine(a[11]);*/
                //Null Pointer Exception
                //// int? a= null;
                int a = 0;
                Console.WriteLine(a/0);
               /* string s = null;
                Console.WriteLine(s.Length);*/

                

            }
           /* catch                               //One way to write catch block 
            {
                Console.WriteLine("Error");
            }*/
           /* catch(NullReferenceException)
            {
                throw new Exception("Error occure"); // Whenever we throw any exception statement after the finally block never get executed.
            }*/
             catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            /* catch (NullReferenceException) // Showing error because the hierarchy of catch block is from chile to parent .
             {

             }*/
            finally
            {
                Console.WriteLine("Code Ends");
            }
            Console.WriteLine("Try Catch Block ends");  // Excuted after the completion of the try catch block when the exception handled successfully.
        }
    }
}
