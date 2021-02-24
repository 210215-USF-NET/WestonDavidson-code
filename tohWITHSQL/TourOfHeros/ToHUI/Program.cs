using System;
using ToHModels;
using ToHBL;
using ToHDL;
//dotnet add reference ../ToHModels
//when would you choose to create a new project vs a new namespace?
namespace ToHUI
{
    class Program
    {

        static void Main(string[] args)
        {
            IMenu menu = new HeroMenu(new HeroBL(new HeroRepoFile()));
            menu.Start();


        }
    }
}
