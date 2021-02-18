using System;

namespace EventsTest
{
    class Primary
    {
        static void Main(string[] args)
        {
            MathStuff logic = new MathStuff();


            logic.NotifyEvent += logic_NotifyComplete;
            

            
            Console.WriteLine("enter in two values to add!");

            int a = Convert.ToInt32(Console.ReadLine());
            int b = Convert.ToInt32(Console.ReadLine());


            logic.MathEquation(a, b);
        }

        public static void logic_NotifyComplete(object sender, int result){
            Console.WriteLine($"The output value is {result}");
        }
    }
}
