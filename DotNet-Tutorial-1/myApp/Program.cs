using System;

namespace myApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            String time = DateTime.Now.ToString();
            Console.WriteLine($"The current time is {time}");
        }
    }
}
