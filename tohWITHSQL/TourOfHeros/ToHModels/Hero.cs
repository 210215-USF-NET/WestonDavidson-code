using System;

/*
in java:
    fields, constructors, methods, getters and setters
in c#:
you have fields, properties, methods, constructors
    fields - characteristics of your object
    methods - define behavior of object
    constructors - special method that defines the instantiation of an object
    - if there exists no constructor, there's a default constructor
    - overriding the default constructor replaces it entirely
    Properties - "smart fields"
        - in java you need to have a field for a getter and setter to exist
        - in c#, a property is sort of a getter and setter for a private backing field (characteristic/thing in an object)

    -properties follow capital case/pascal case. every word has a capital

// https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/properties


POCO - plain ol c# object
    - class that holds data
*/
//could you reference other fields inside a 
namespace ToHModels
{
    /// <summary>
    /// Data structure used for modeling a Hero.
    /// </summary>
    public class Hero
    {

        private String heroName;

        private int hP;


        public String HeroName
        {
            get
            {
                return heroName;
            }
            set
            {
                if (value == null || value.Equals(""))
                {
                    throw new ArgumentNullException("Hero name can't be empty or null");
                }

                heroName = value;
            }
        }

        public Element ElementType { get; set; }

        public int HP { get; set; }

        public SuperPower SuperPower { get; set; }

        public override string ToString() => $"Hero Details: \n\t name: {this.HeroName} \n\t hp: {this.HP} \n\t element: {this.ElementType} \n\t superpower: {this.SuperPower.ToString()}";

    }
}
