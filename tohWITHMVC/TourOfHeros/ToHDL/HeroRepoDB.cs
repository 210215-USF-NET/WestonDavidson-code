using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToHModels;

namespace ToHDL
{
    public class HeroRepoDB : IHeroRepository
    {
        private readonly HeroDBContext _context;

        public HeroRepoDB(HeroDBContext context)
        {
            _context = context;
        }

        public Hero AddHero(Hero newHero)
        {
            _context.Heroes.Add(newHero);
            _context.SaveChanges();
            return newHero;
        }

        public Hero DeleteHero(Hero hero2BDeleted)
        {
            _context.Heroes.Remove(hero2BDeleted);
            _context.SaveChanges();
            return hero2BDeleted;
        }

        public Hero GetHeroByName(string name)
        {
            return _context.Heroes
                .Include("SuperPower")
                .AsNoTracking()
                .FirstOrDefault(hero => hero.HeroName == name);
        }

        public List<Hero> GetHeroes()
        {
            return _context.Heroes
                .Include("SuperPower")
                .AsNoTracking()
                .Select(hero => hero)
                .ToList();
        }

        public Hero UpdateHero(Hero hero2BUpdated)
        {
            //TODO: to be implemented soon?

            //Hero oldHero = _context.Heroes.Include("SuperPower).Where(hero => hero.HeroName == hero2BUpdated.HeroName).First();
            Hero oldHero = GetHeroByName(hero2BUpdated.HeroName);
            _context.Entry(oldHero).CurrentValues.SetValues(hero2BUpdated);

            //NEED TO EDIT THIS STUFF!!!




            _context.SaveChanges();
            //oldHero = GetHeroByName(hero2BUpdated.HeroName);
            //_context.ChangeTracker.Clear();
            return hero2BUpdated;




               }
    }
}
