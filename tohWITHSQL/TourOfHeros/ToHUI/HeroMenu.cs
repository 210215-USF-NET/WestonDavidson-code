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
                Console.WriteLine("[2] Search hero by name");
                Console.WriteLine("[3] Delete a hero");
                Console.WriteLine("[4] Update a Hero");
                Console.WriteLine("[5] Exit");

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
                        SearchHero();
                        break;
                    case "3":
                        DeleteHero();
                        break;
                    case"4":
                        UpdateHero();
                        break;
                    case "5":
                        stay = false;
                        ExitRemarks();
                        break;

                    default:
                        Console.WriteLine("Not a menu option! Please enter a valid option");
                        break;
                }

            } while (stay);


        }





        public void UpdateHero()
        {
            Console.WriteLine("Enter the name of the hero you want to update: ");
            Hero hero2BUpdated = _heroBL.GetHeroByName(Console.ReadLine());
            if(hero2BUpdated == null)
            {
                Console.WriteLine("Well darn, can't find that hero. Maybe you'd want to create them instead?");
            }   else
            {
                //ask the end user for the details they want to change.
                _heroBL.UpdateHero"(hero2BUpdated, GetHeroDetails());
                Console.WriteLine("Hero Successfully Updated!!!");

            }

        }

        private Hero GetHeroDetails()
        {
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

            return newHero;
        }

        public void DeleteHero(){
            Console.WriteLine("Enter the hero that you wish to be removed from the roster: ");
            Hero hero2BDeleted = _heroBL.GetHeroByName(Console.ReadLine());

            if(hero2BDeleted == null){
                Console.WriteLine("We can't find the hero, they may have already been deleted, \nor there was a misspelling." +
                "This application is case sensitive");
            } else
            {
                _heroBL.DeleteHero(hero2BDeleted);
                Console.WriteLine($"Success!!!! {hero2BDeleted.HeroName} has been deleted from your hero collection");
            }





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

        public void SearchHero(){
        
            Console.WriteLine("Enter hero name: ");
            Hero foundHero = _heroBL.GetHeroByName(Console.ReadLine());
            if(foundHero == null)
            {
                Console.WriteLine("no such hero found :(");

            } else{
                Console.WriteLine(foundHero.ToString());
            }

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