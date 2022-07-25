using System;

namespace ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MyListImplementation list = new MyListImplementation();
            list.Add(1);
            list.Add(2);
            list.Add(3);


            do
            {
                Console.WriteLine(list.Current);
            }
            while (list.MoveNext());
        }
    }
}
