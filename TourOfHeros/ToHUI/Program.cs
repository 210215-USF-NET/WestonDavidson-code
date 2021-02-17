using System;
using ToHModels;
using ToHBL;
//dotnet add reference ../ToHModels
//when would you choose to create a new project vs a new namespace?
namespace ToHUI
{
    class Program
    {

        private static IHeroBL heroBL = new HeroBL();
        static void Main(string[] args)
        {
            IMenu menu = new HeroMenu(new HeroBL());
            menu.Start();


        }
    }
}
