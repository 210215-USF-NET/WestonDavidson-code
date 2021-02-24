using ToHModels;
using System.Collections.Generic;

namespace ToHBL
{
    public interface IHeroBL
    {
        void AddHero(Hero newHero);
        List<Hero> GetHeroes();

        Hero GetHeroByName(string name);
    }
}