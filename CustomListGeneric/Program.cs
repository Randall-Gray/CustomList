﻿using System;
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
            CustomList<int> list = new CustomList<int>();
            list.Add(1);
            list.Add(2);
            list.Add(3);
            list.Add(4);
            list.Add(5);
            list.Remove(6);
            list.Remove(5);
            list.Remove(1);

            List<bool> intlist = new List<bool>() { true, false, true, false };
            string str = intlist.ToString();
            bool answer = true;
            string str2 = answer.ToString();
            Console.WriteLine(intlist.ToString());
            Console.ReadLine();
        }
    }
}
