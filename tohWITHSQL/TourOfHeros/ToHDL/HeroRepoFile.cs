using System.IO;
using System.Collections.Generic;
using ToHModels;
using System.Text.Json;
using System;

namespace ToHDL
{
    public class HeroRepoFile : IHeroRepository
    {

        private string jsonString;
        private string filePath = "../ToHDL/HeroRepoFile.json";
        public Hero AddHero(Hero newHero)
        {
            //consider finding a way to append to the end of a json file instead of rewriting file entirely
            //right now, we have to append an entirely new list with the new hero added at the end.

            List<Hero> heroesFromFile = new List<Hero>();
            
            heroesFromFile = GetHeroes();

            heroesFromFile.Add(newHero);
            jsonString = JsonSerializer.Serialize(heroesFromFile);
            File.WriteAllText(filePath, jsonString);
            
            return newHero;
        }

        public List<Hero> GetHeroes()
        {

            try{
            jsonString = File.ReadAllText(filePath);
            }
            catch(Exception){
                return new List<Hero>();
            }
            return JsonSerializer.Deserialize<List<Hero>>(jsonString);
            //the main point of generics is to be able to provide a universal interface for any type
            //while the type itself is enforced for that single instance, any instance with that generic would be able to call the same methods, etc.
            
        }
    }
}