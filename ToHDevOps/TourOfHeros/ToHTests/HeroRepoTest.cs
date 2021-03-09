using Xunit;
using Microsoft.EntityFrameworkCore;
using ToHDL;
using Model = ToHModels;
using System.Linq;
using ToHModels;

// unit testing with sqlite link: https://docs.microsoft.com/en-us/ef/core/testing/



namespace ToHTests
{
    /// <summary>
    /// test class for the data access methods in my DL
    /// </summary>

    //using dotnet add package Microsoft.EntityFrameworkCore.Sqlite for testing
    public class HeroRepoTest
    {
        private readonly DbContextOptions<HeroDBContext> options;

        public HeroRepoTest()
        {
            options = new DbContextOptionsBuilder<HeroDBContext>()
            .UseSqlite("Filename=Test.db")
            .Options;

            Seed();
        }
        //testing read operations
        //read is a fact because it's not dependent on any input data, you're returning data!
        [Fact]
        public void GetAllHeroesShouldReturnAllHeroes()
        {
            using (var context = new HeroDBContext(options))
            {
                //this isn't completely a unit since we're using heromapper from outside our test area
                //but whatever lol
                //Arrange (includes the seeding stuff earlier on)
                IHeroRepository _repo = new HeroRepoDB(context);
                //Act
                var heroes = _repo.GetHeroes();
                Assert.Equal(2, heroes.Count);
            }
        }

        [Fact]
        public void GetHeroByNameShouldReturnHero()
        {
            using (var context = new HeroDBContext(options))
            {
                IHeroRepository _repo = new HeroRepoDB(context);
                var foundHero = _repo.GetHeroByName("Aquaman");

                Assert.NotNull(foundHero);
                Assert.Equal("Aquaman", foundHero.HeroName);
            }
        }

        [Fact]
        public void AddHeroShouldAddHero()
        {
            using (var context = new HeroDBContext(options))
            {
                IHeroRepository _repo = new HeroRepoDB(context);
                _repo.AddHero
                (
                    new Model.Hero
                    {
                        HeroName = "ironman",
                        HP = 100,
                        ElementType = (Model.Element)4,
                        SuperPower = new Model.SuperPower
                        {
                            Name = "Really really rich",
                            Description = "he just makes a bunch of iron outfits with all his money",
                            Damage = 50
                        }

                    }
                );
            }
            using (var assertContext = new HeroDBContext(options))
            {
                var result = assertContext.Heroes.FirstOrDefault(hero => hero.HeroName == "ironman");
                Assert.NotNull(result);
                Assert.Equal("ironman", result.HeroName);
            }
        }

        [Fact]
        public void DeleteShouldDelete()
        {
            using (var context = new HeroDBContext(options))
            {
                IHeroRepository _repo = new HeroRepoDB(context);

                _repo.DeleteHero(
                    new Model.Hero
                    {
                        Id = 1,
                        HeroName = "Aquaman",
                        HP = 500,
                        ElementType = Model.Element.Water,
                        SuperPower = new Model.SuperPower
                        {
                            Id = 1,
                            Name = "Super swimming",
                            Description = "He can breate underwater, and swim really fast.",
                            Damage = 50
                        }
                    }
                );


            }
            using (var assertContext = new HeroDBContext(options))
            {
                var result = assertContext.Heroes.Find(1);
                Assert.Null(result);
            }

        }


        [Fact]

        public void UpdateHeroShouldUpdate()
        {

            using (var context = new HeroDBContext(options))
            {
                IHeroRepository _repo = new HeroRepoDB(context);

                _repo.UpdateHero(
                    new Model.Hero
                    {
                        Id = 1,
                        HeroName = "Aquaperson",
                        HP = 1500,
                        ElementType = Model.Element.Water,
                        SuperPower = new Model.SuperPower
                        {
                            Id = 1,
                            Name = "Super swimming",
                            Description = "He can breate underwater, and swim really fast.",
                            Damage = 150
                        }
                    }
                );


            }
            using (var assertContext = new HeroDBContext(options))
            {
                var result = assertContext.Heroes.Include("Superpower").FirstOrDefault(hero => hero.Id == 1);
                Assert.NotNull(result);
                Assert.Equal("Aquaperson", result.HeroName);
                Assert.Equal(1500, result.HP);
                Assert.Equal(150, result.SuperPower.Damage);

            }
        }

        private void Seed()
        {
            //this is an example of a using block.
            //at the end of the execution, the unmanaged resource is disposed
            using (var context = new HeroDBContext(options))
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();

                context.Heroes.AddRange
                (
                    new Hero
                    {
                        Id = 1,
                        HeroName = "Aquaman",
                        HP = 500,
                        ElementType = (Element)1,
                        SuperPower = new SuperPower
                        {
                            Id = 1,
                            Name = "Super swimming",
                            Description = "He can breate underwater, and swim really fast.",
                            Damage = 50
                        }
                    },
                    new Hero
                    {
                        Id = 1,
                        HeroName = "Batman",
                        HP = 100,
                        ElementType = (Element)2,
                        SuperPower = new SuperPower
                        {
                            Id = 2,
                            Name = "Rich",
                            Description = "He can buy you out. Also he knows the secrets of all the other justice league members",
                            Damage = 75
                        }
                    }
                );
                context.SaveChanges();
            }
        }


    }
}