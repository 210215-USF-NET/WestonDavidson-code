using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToHModels;

namespace ToHDL
{

    //By inheriting the DbContext class, we establish an is-a relationship between herodbcontext and
    //the dbcontext =>/implies that herodbcontext is a dbcontext
    public class HeroDBContext : DbContext
    {
        public HeroDBContext(DbContextOptions options) : base(options)
        {

        }
        protected HeroDBContext()
        {
        }

        //here we list the models/entities that we want to be persisted to our database
        //this plus the constructors is really all we need for ef core to scaffold a db structure for you from our db provider
        public DbSet<Hero> Heroes { get; set; }
        public DbSet<SuperPower> SuperPowers { get; set; }

        //onmodelconfiguring might be worth looking into because it will let you detail how you want efcore to build your stuff
        //this might be a fallback plan if needed, but prolly won't need it

    }
}
