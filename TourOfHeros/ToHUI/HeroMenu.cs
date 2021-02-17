using System;
using ToHModels;
using ToHBL;

namespace ToHUI
{
    public class HeroMenu : IMenu
    {
        private IHeroBL _heroBL;

        //constructor requiring IHeroBL implementation
        //business logic will need to be called in order for a hero to be added to the data layer (through the business layer)
        public HeroMenu(IHeroBL heroBL)
        {
            _heroBL = heroBL;

        }

        public void Start()
        {

            Boolean stay = true;

            do
            {
                //menu options part
                Console.WriteLine("Welcome to my tour of heroes app! What would you like to do?");
                Console.WriteLine("[0] Create a hero");
                Console.WriteLine("[1] Get all heroes");
                Console.WriteLine("[2] Exit");

                //get user input
                Console.WriteLine("Please enter a number to select an option: ");
                string userInput = Console.ReadLine();

                switch (userInput)
                {

                    case "0":
                        try {CreateHero();
                        }
                        catch(Exception){
                            Console.WriteLine("Invalid Input");
                            continue;
                        }
                        break;
                    case "1":
                        GetHeros();
                        break;
                    case "2":
                        stay = false;
                        ExitRemarks();
                        break;

                    default:
                        Console.WriteLine("Not a menu option! Please enter a valid option");
                        break;
                }

            } while (stay);


        }


        public void GetHeros()
        {
            foreach (var item in _heroBL.GetHeroes())
            {
                Console.WriteLine(item.ToString());
            }

            Console.WriteLine("Press enter to continue");
            Console.ReadLine();

        }

        public void CreateHero()
        {
            // create hero method/logic
            Hero newHero = new Hero();
            Console.WriteLine("Enter hero name: ");
            newHero.HeroName = Console.ReadLine();

            Console.WriteLine("Enter an HP value: ");
            newHero.HP = Convert.ToInt32(Console.ReadLine());
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

            Console.WriteLine($"Hero has been created successfully!");
            _heroBL.AddHero(newHero);

            Console.WriteLine("Press enter to continue");
            Console.ReadLine();
        }

        public void ExitRemarks()
        {
            Console.WriteLine("Goodbye friend! see ya next time :)!");
        }

    }
}