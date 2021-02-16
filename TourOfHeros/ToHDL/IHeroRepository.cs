using ToHModels;
using System.Collections.Generic;
namespace ToHDL
{
    public class IHeroRepository
    {
        
        List<Hero> GetHeroes();

        Hero AddHero(Hero newHero);
    }
}