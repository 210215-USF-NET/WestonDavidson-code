using System;
using Serilog;

namespace serilog
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            Log.Logger = new LoggerConfiguration()
            .WriteTo.Console()
            .CreateLogger();

            Log.Information("Hi there");
        }
    }
}
