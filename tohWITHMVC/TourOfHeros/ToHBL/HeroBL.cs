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
        private IHeroRepository _repo;



        public HeroBL(IHeroRepository repo){
            _repo = repo;
        }
        public Hero AddHero(Hero newHero){
            //TODO add BL
            return _repo.AddHero(newHero);
        }

        public List<Hero> GetHeroes(){
            //TODO add BL
            return _repo.GetHeroes();
        }

        public Hero GetHeroByName(string name){
            //maybe add validation here if the name given is not null or empty string
            return _repo.GetHeroByName(name);
        }


        public Hero UpdateHero(Hero hero2BUpdated)
        {

            return _repo.UpdateHero(hero2BUpdated);
        }




        public Hero DeleteHero(Hero hero2BDeleted){
            return _repo.DeleteHero(hero2BDeleted);
        }

        
    }
}
