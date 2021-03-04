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
        //what we would use to manually define to ef core how we want our db to be built out
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //THIS WILL LET US HAVE A SELF INCREMENTING PRIMARY KEY WHEN OUR DB IS BUILT
            modelBuilder.Entity<Hero>()
                .Property(hero => hero.Id)
                .ValueGeneratedOnAdd();
            modelBuilder.Entity<Hero>()
                .HasOne(hero => hero.SuperPower)
                .WithOne()
                //on delete, kill the stuff that references it - cascade delete
                //have to manually let efcore know that hero has one superpower, and the superpower refers to the hero. 
                //when the hero gets deleted, i want superpower to be deleted as well
                .OnDelete(DeleteBehavior.Cascade);

            //you can add seed data here, but it's probably easier to add it db side rather than in modelbuild
        }

    }
}
