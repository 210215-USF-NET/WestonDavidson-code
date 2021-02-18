using System;
using ToHModels;

using Xunit;
//note that models aren't really supposed to be unit tested because they mainly hold data and don't have much logic associated
// you should focus on unit testing logic like business logic or data layer logic.
// also, don't unit test your UI lol
namespace ToHTests
{
    public class HeroModelTest
    {

        Hero testHero = new Hero();


        //this is sort of like an attribute (fact) - tests data that doesn't need method arguments. 
        //Facts are tests which are always true - stuff that doesn't take in parameters
        [Fact]
        public void HeroNameShouldBeSet()
        {
            string testName = "the tick";
            //Act
            testHero.HeroName = testName;

            //assert
            //there are a bunch of different assertions, look up a list of methods for Xunit assert!
            //https://xunit.net/docs/comparisons
            //dotnet test to run a test
            Assert.Equal(testName, testHero.HeroName);

        }
        //Attribute for things that include data manipulation
        //one dataset that's passing, one that's failing, you can check when it SHOULD and shouldn't work
        [Theory]
        [InlineData("")]
        //[InlineData()]
        public void HeroNameShouldNotBeEmpty(string testName){

            //Act and assert at the same time
            //how do i check if an exception is being thrown in my code? how do i unit test that?
            //takes in a lambda expression - an anonymous function
            Assert.Throws<ArgumentNullException>(() => testHero.HeroName = testName);
        }

    }
}
