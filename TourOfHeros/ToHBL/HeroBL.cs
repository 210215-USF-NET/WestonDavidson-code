using System;
using ToHDL;
using System.Collections.Generic;
using ToHModels;

namespace ToHBL
{
    //implements interface IHeroBL
    public class HeroBL:IHeroBL
    {

        //instantiate hero repository from ToHDL Data Layer project
        private IHeroRepository repo = new HeroRepoSC();

        public void AddHero(Hero newHero){
            //TODO add BL
            repo.AddHero(newHero);
        }

        public List<Hero> GetHeroes(){
            //TODO add BL
            return repo.GetHeroes();
        }

        
    }
}
