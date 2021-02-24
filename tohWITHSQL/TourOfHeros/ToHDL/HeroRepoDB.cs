using System;
using System.Collections.Generic;
using Model = ToHModels;
using Entity = ToHDL.Entities;
using System.Linq;
using Microsoft.EntityFrameworkCore;



namespace ToHDL
{
    public class HeroRepoDB : IHeroRepository
    {


        private Entity.HeroDBContext _context;

        private IMapper _mapper;

        public HeroRepoDB(Entity.HeroDBContext context, IMapper mapper){
            _context = context;
            _mapper = mapper;
        }

        public Model.Hero AddHero(Model.Hero newHero){
            //_context.Heroes.Add(newHero);
            _context.Heroes.Add(_mapper.ParseHero(newHero));
            _context.SaveChanges();
            return newHero;
        }

        public List<Model.Hero> GetHeroes(){
            //for every hero you get from entity superpowers we want you to parse them and return a list
            //select projects each element in a list to a new form
            //for each x, do this thing
            //for us we want it to return a list of heroes
            return _context.Heroes.Include("Superpowers").Select(x => _mapper.ParseHero(x)).ToList();


        }
    }
}