using System;
using ToHModels;
//dotnet add reference ../ToHModels

namespace ToHUI
{
    class Program
    {
        static void Main(string[] args)
        {
            Hero newHero = new Hero();
            newHero.HeroName = "Spiderman";
            Console.WriteLine(newHero.HeroName);
        }
    }
}
