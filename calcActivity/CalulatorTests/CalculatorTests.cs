using System;
using Xunit;
using CalulatorUnitTesting;
namespace CalulatorTests
{
    public class CalculatorTests
    {

        Calculator testCalculator = new Calculator();

        //this is sort of like an attribute (fact) - tests data that doesn't need method arguments. 
        //Facts are tests which are always true - stuff that doesn't take in parameters
        [Theory]
        [InlineData(1, 2, 3)]
        [InlineData(-4, -6, -10)]
        [InlineData(-2, 2, 0)]
        [InlineData(int.MinValue, -1, int.MaxValue)]
        public void AddShouldAddNumber(int value1, int value2, int expected)
        {

            int result = testCalculator.Add(value1, value2);


            Assert.Equal(expected, result);
        }

         //Attribute for things that include data manipulation
        //one dataset that's passing, one that's failing, you can check when it SHOULD and shouldn't work
        /*
        [Theory]
        [InlineData("", 0)]
        [InlineData(0, "")]
        [InlineData("", "")]
        [InlineData(null, "")]
        [InlineData("", null)]
        [InlineData(null, null)]
        public void AddShouldNotBeEmpty(var value1, var value2){

            //var will become a type depending on inputs
            var result = value1 + value2;
            //Act and assert at the same time
            //how do i check if an exception is being thrown in my code? how do i unit test that?
            //takes in a lambda expression - an anonymous function
            Assert.Throws<ArgumentNullException>(() => result == value1);
        }
        */







    }
}
