﻿using System;

namespace HelloWorld
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            String name = Console.ReadLine();
            String adjective = "epic";
            Console.WriteLine($"Hello {name}! You are {adjective}");
        }
    }
}
