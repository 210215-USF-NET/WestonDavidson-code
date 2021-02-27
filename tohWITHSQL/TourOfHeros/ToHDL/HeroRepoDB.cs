using System;
using System.Collections.Generic;
using Model = ToHModels;
using Entity = ToHDL.Entities;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using ToHModels;

namespace ToHDL
{
    public class HeroRepoDB : IHeroRepository
    {


        private Entity.HeroDBContext _context;

        private IMapper _mapper;

        public HeroRepoDB(Entity.HeroDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public Model.Hero AddHero(Model.Hero newHero)
        {
            //_context.Heroes.Add(newHero);
            _context.Heroes.Add(_mapper.ParseHero(newHero));
            _context.SaveChanges();
            return newHero;
        }

        public Hero DeleteHero(Hero hero2BDeleted)
        {
            _context.Heroes.Remove(_mapper.ParseHero(hero2BDeleted));
            _context.SaveChanges();
            return hero2BDeleted;
        }

        public Model.Hero GetHeroByName(string name)
        {
            return _context.Heroes.Include("Superpowers").AsNoTracking().Select(x => _mapper.ParseHero(x)).ToList().FirstOrDefault(x => x.HeroName == name);
        }
        public List<Model.Hero> GetHeroes()
        {
            //for every hero you get from entity superpowers we want you to parse them and return a list
            //select projects each element in a list to a new form
            //for each x, do this thing
            //for us we want it to return a list of heroes
            return _context.Heroes.Include("Superpowers").AsNoTracking().Select(x => _mapper.ParseHero(x)).ToList();


        }

        public void UpdateHero(Hero hero2BUpdated)
        {
            //efcore has a tracker that tracks changes to entities, so we can take advantage of that to update our hero!
            //efcore doesn't update tables related to it
            Entity.Hero oldHero = _context.Heroes.Find(hero2BUpdated.Id);

            //this one was only updating the hero table, not the superpower table
            _context.Entry(oldHero).CurrentValues.SetValues(_mapper.ParseHero(hero2BUpdated));

            Entity.Superpower oldSuperPower = _context.Superpowers.Find(hero2BUpdated.SuperPower.Id);
            oldSuperPower.Damage = hero2BUpdated.SuperPower.Damage;
            oldSuperPower.Description = hero2BUpdated.SuperPower.Description;
            oldSuperPower.Name = hero2BUpdated.SuperPower.Name;
            //save changes to db
            _context.SaveChanges();
            //clear changes that have been made
            _context.ChangeTracker.Clear();
        }
    }
}