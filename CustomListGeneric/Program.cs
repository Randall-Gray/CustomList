using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomListGeneric
{
    class Program
    {
        static void Main(string[] args)
        {
            CustomList<string> list1 = new CustomList<string>();
            list1.Add("e");
            list1.Add("E");
            list1.Add("e");
            list1.Add("E");
            list1.Sort();
            Console.WriteLine(list1.ToString());
            Console.ReadLine();
        }
    }
}
