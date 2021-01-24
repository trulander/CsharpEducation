using System;

namespace programm_class
{
    class Program
    {
        static void Main(string[] args)
        {
            Printer.Print("test");


            Person person = new Person("alex",17);
            //person.SetName("Alex");

            //Person person2 = new Person();
           // person2.SetName("Alex2");

            person.Name = "trulander";


            Console.WriteLine(person.Name);
            //Console.WriteLine(person.GetName());
            //Console.WriteLine(person2.GetName());



            //person.PrintName();
            //person2.PrintName();


        }
    }
}
