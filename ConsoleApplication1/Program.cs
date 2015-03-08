using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task1;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            Polynomial a = new Polynomial(0);
            Polynomial b = new Polynomial(1.5, 2, 3);
            Console.WriteLine(a.ToString());
            Console.WriteLine(b.ToString());
            Console.WriteLine((a * b).ToString());
            Console.WriteLine((new Polynomial(2, 3, 4, 5) * new Polynomial(1, 0, 3)).ToString());
        }
    }
}
