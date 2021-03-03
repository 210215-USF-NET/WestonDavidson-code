using ToHModels;
using System.Collections.Generic;

namespace ToHBL
{
    public interface IHeroBL
    {
        void AddHero(Hero newHero);
        List<Hero> GetHeroes();

        Hero GetHeroByName(string name);

        void DeleteHero(Hero hero2BDeleted);

        void UpdateHero(Hero hero2BUpdated, Hero updatedDetails);
    }
}