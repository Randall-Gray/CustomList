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
            CustomList<int> list1 = new CustomList<int>();
            CustomList<int> list2 = new CustomList<int>();
            list1.Add(1);
            list1.Add(2);
            list1.Add(3);
            list2.Add(4);
            list2.Add(5);
            list2.Add(6);

            Console.WriteLine((list1+ list2+ list1+ list2).ToString());
            Console.ReadLine();
        }
    }
}
