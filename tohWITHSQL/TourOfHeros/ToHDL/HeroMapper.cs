using Model = ToHModels;
using Entity = ToHDL.Entities;
using ToHModels;
using ToHDL.Entities;
using System.Linq;
using System.Collections.Generic;

namespace ToHDL
{
    public class HeroMapper : IMapper
    {
        public Model.Hero ParseHero(Entity.Hero hero)
        {
            return new Model.Hero
            {
                HeroName = hero.HeroName,

                HP = hero.Hp,
                ElementType = (Model.Element)hero.ElementType,
                SuperPower = ParseSuperPower(hero.Superpowers.First())
            };



        }

        // DOUBLE CHECK THIS PORTION OF CODE

        public Entity.Hero ParseHero(Model.Hero hero)
        {
            return new Entity.Hero
            {
                HeroName = hero.HeroName,
                Hp = hero.HP,
                ElementType = (int)hero.ElementType,
                Superpowers = new List<Entity.Superpower> { ParseSuperPower(hero.SuperPower) }

            };

        }

        public SuperPower ParseSuperPower(Superpower superpower)
        {
            return new SuperPower
            {

                Name = superpower.Name,

                Description = superpower.Description,

                Damage = superpower.Damage

            };

        }

        public Superpower ParseSuperPower(SuperPower superpower)
        {
            return new Superpower
            {
                Name = superpower.Name,
                Description = superpower.Description,
                Damage = superpower.Damage
            };
        }


    }
}