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
                //SuperPower = ParseSuperPower(hero.Superpower);
        };



    }

    // DOUBLE CHECK THIS PORTION OF CODE

    public Entity.Hero ParseHero(Model.Hero hero)
    {


        if (hero.Id == null)
        {
            return new Entity.Hero
            {
                //for when you add a new hero, ID isn't set yet

                HeroName = hero.HeroName,
                Hp = hero.HP,
                ElementType = (int)hero.ElementType,
                Superpower = new List<Entity.Superpower> { ParseSuperPower(hero.SuperPower) }




            };
        }

        return new Entity.Hero
        {
            HeroName = hero.HeroName,
            Hp = hero.HP,
            ElementType = (int)hero.ElementType,
            Superpowers = new ParseSuperPower(Entity.Superpower);

        }

    }

    public SuperPower ParseSuperPower(Superpower superpower)
    {
        //for adding new superpower
        if (superpower.Id == null)
        {
            this.superpower = superpower;

            return new SuperPower
            {

                Name = superpower.Name,

                Description = superpower.Description,

                Damage = superpower.Damage

            };

        }
        //FOR UPDATING
        return new SuperPower
        {

            Name = superpower.Name,

            Description = superpower.Description,

            Damage = superpower.Damage,
            Id = (int)superpower.Id

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