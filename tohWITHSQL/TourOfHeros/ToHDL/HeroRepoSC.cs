using ToHModels;
using System.Collections.Generic;


namespace ToHDL
{
    public class HeroRepoSC 
    {
        public List<Hero> GetHeroes(){
            return Storage.AllHeroes;

        }

        public Hero AddHero(Hero newHero)
        {
        Storage.AllHeroes.Add(newHero);
        return newHero;

        }

        
    }
}