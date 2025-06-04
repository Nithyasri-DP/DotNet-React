using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VSDotnetClass.Daythree
{    
    class GenericClass<T, T1>
    {
        T a;
        T1 b;

        public GenericClass(T a, T1 b)
        {
            this.a = a;
            this.b = b;
        }

        public void Display()
        {
            Console.WriteLine("The First value: {0}", a);
            Console.WriteLine("The Second value: {0}", b);
        }
    }

    class Generic
    {
        public static void Genclass()
        {
            GenericClass<int, string> iobj = new GenericClass<int, string>(10, "Hi");
            GenericClass<string, char> sobj = new GenericClass<string, char>("Geetha", 'S');

            iobj.Display();
            sobj.Display();

            Console.ReadKey();
        }
    }

}
