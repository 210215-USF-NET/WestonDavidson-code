using System;
using ToHModels;
using ToHBL;
//dotnet add reference ../ToHModels
//when would you choose to create a new project vs a new namespace?
namespace ToHUI
{
    class Program
    {

        private IHeroBL heroBL = new HeroBL();
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

            heroBL.addHero(newHero);
            foreach(var item in HeroBL.GetHeroes()){
                Console.WriteLine($"Hero Details: \n\tname = {item.HeroName} \n\tsuperPower: {item.SuperPower.Name} \n\ttype: {item.ElementType}");
        
            }

 }
    }
}
