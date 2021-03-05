using ToHModels;
using System.Collections.Generic;

namespace ToHBL
{
    public interface IHeroBL
    {
        Hero AddHero(Hero newHero);
        List<Hero> GetHeroes();

        Hero GetHeroByName(string name);

        Hero DeleteHero(Hero hero2BDeleted);
        Hero UpdateHero(Hero hero2BUpdated);
    }
}