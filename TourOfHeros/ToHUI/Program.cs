using System;
using ToHModels;
//dotnet add reference ../ToHModels

namespace ToHUI
{
    class Program
    {
        static void Main(string[] args)
        {
            // create hero method/logic
            Hero newHero = new Hero();
            Console.WriteLine("Enter hero name: ");
            newHero.HeroName = Console.ReadLine();

            Console.WriteLine("Enter an HP value: ");
            newHero.Hp = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter SuperPower details: ");

            newHero.SuperPower = new SuperPower();

            Console.WriteLine("Enter SuperPower name: ");
            newHero.SuperPower.Name = Console.ReadLine();
            Console.WriteLine("Enter SuperPower Description: ");
            newHero.SuperPower.Description = Console.ReadLine();
            Console.WriteLine("Enter SuperPower damage");
            newHero.SuperPower.Damage = int.Parse(Console.ReadLine());

            Console.WriteLine("Set the element type of the hero: ");
            newHero.ElementType = Enum.Parse<Element>(Console.ReadLine());

            Console.WriteLine($"Hero Created with details: \n\tname = {newHero.HeroName} \n\tsuperPower: {newHero.SuperPower.Name} \n\ttype: {newHero.ElementType}");
        }
    }
}
