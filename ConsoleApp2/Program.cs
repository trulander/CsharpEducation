using System;
using System.Collections.Generic;
using System.Linq;
namespace ConsoleApp1
{
    public static class Program
    {
        static void Main(string[] args)
        {
            int length = 15;
            for (int i = 0; i < length; i++)
            {

                for (int i2 = 0; i2 < length; i2++)
                {
                    Console.Write("[]");
                }
                Console.WriteLine("[]");
            }

            string text;
            text = "1test";
            text += "2test";
            Console.Write(text);


            //bool success;
            //do
            //{
            //    Console.WriteLine("введите число");
            //    string answer = Console.ReadLine();
            //    success = int.TryParse(answer, out int value);

            //    if (success)
            //    {
            //        Console.WriteLine(answer);
            //    }
            //} while (!success);

            string line = "whefgoewg";

            foreach (var item in line)
            {
                Console.WriteLine(item);
            }


            string[] names = new string[13];

            names[0] = "alex";
            names[1] = "alex1";
            names[2] = "alex2";

            for (int i = 0; i < names.Length; i++)
            {
                Console.WriteLine(names[i]);
            }

            foreach (var (item, index) in names.WithIndex())
            {
                Console.WriteLine(item + index);
            }

        }
        public static IEnumerable<(T item, int index)> WithIndex<T>(this IEnumerable<T> source)
        {
            return source.Select((item, index) => (item, index));
        }
    }
}
