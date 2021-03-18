using System;
using ToHDL;
using System.Collections.Generic;
using ToHModels;
using System.Threading.Tasks;

namespace ToHBL
{
    //implements interface IHeroBL
    public class HeroBL : IHeroBL
    {

        //instantiate hero repository from ToHDL Data Layer project
        private IHeroRepository _repo;



        public HeroBL(IHeroRepository repo)
        {
            _repo = repo;
        }
        public async Task<Hero> AddHeroAsync(Hero newHero)
        {
            //TODO add BL
            return await _repo.AddHeroAsync(newHero);
        }

        public async Task<List<Hero>> GetHeroesAsync()
        {
            //TODO add BL
            return await _repo.GetHeroesAsync();
        }

        public async Task<Hero> GetHeroByNameAsync(string name)
        {
            //maybe add validation here if the name given is not null or empty string
            return await _repo.GetHeroByNameAsync(name);
        }


        public async Task<Hero> UpdateHeroAsync(Hero hero2BUpdated)
        {

            return await _repo.UpdateHeroAsync(hero2BUpdated);
        }




        public async Task<Hero> DeleteHeroAsync(Hero hero2BDeleted)
        {
            return await _repo.DeleteHeroAsync(hero2BDeleted);
        }


    }
}
