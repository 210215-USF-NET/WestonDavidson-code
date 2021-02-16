using System;
using ToHDL;
using System.Collections.Generic;
using ToHModels;

namespace ToHBL
{
    public class HeroBL : IHeroBL
    {

        private IHeroRepository repo = new HeroRepoSC();
        public void AddHero(HeroBL newHero){
            //TODO add BL
            repo.AddHero(newHero);
        }

        public List<Hero> GetHeroes(){
            //TODO add BL
            return repo.GetHeroes();
        }

        
    }
}
