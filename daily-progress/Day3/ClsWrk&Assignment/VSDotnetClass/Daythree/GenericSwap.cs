using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VSDotnetClass.Daythree
{
    class GenericSwap
    {
        // Declare the user-defined generic method
        public static void Swap<T>(ref T x, ref T y)
        {
            T temp = x;
            x = y;
            y = temp;
        }

        public static void Genericrun()
        {
            int A = 10, B = 20;
            string A1 = "Hello", B1 = "World";

            // Calling the generic Swap method for integers
            Swap<int>(ref A, ref B);
            Console.WriteLine("After Swap A = {0} \t B = {1}", A, B);

            // Calling the generic Swap method for strings
            Swap<string>(ref A1, ref B1);
            Console.WriteLine("After Swap A1 = {0} \t B1 = {1}", A1, B1);

            // Another swap using type inference (no need to specify <string>)
            A1 = "hi";
            B1 = "Hello";
            Swap(ref A1, ref B1); // type <string> inferred automatically
            Console.WriteLine("After Swap A1 = {0} \t B1 = {1}", A1, B1);

            Console.ReadKey();
        }
    }
}
