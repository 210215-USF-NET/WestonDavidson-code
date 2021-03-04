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


        public Hero UpdateHero(Hero hero2BUpdated, Hero updatedDetails)
        {
            hero2BUpdated.ElementType = updatedDetails.ElementType;
            hero2BUpdated.HeroName = updatedDetails.HeroName;
            hero2BUpdated.HP = updatedDetails.HP;
            hero2BUpdated.SuperPower.Damage = updatedDetails.SuperPower.Damage;
            hero2BUpdated.SuperPower.Description = updatedDetails.SuperPower.Description;
            hero2BUpdated.SuperPower.Name = updatedDetails.SuperPower.Name;

            return _repo.UpdateHero(hero2BUpdated);
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
