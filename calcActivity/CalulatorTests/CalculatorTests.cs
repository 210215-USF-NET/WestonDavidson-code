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

            testCalculator.Result = testCalculator.Add(value1, value2);


            Assert.Equal(expected, testCalculator.Result);
        }



        [Theory]
        [InlineData(1, 2, -1)]
        [InlineData(4, 6, -2)]
        [InlineData(2, 2, 0)]
        [InlineData(int.MaxValue, 1, int.MaxValue-1)]
        public void SubtractShouldSubtractNumber(int value1, int value2, int expected)
        {

            testCalculator.Result = testCalculator.Subtract(value1, value2);


            Assert.Equal(expected, testCalculator.Result);
        }

        [Theory]
        [InlineData(2, 2, 4)]
        [InlineData(4, -6, -24)]
        [InlineData(0, 2, 0)]
        [InlineData(int.MaxValue, 0, 0)]
        public void MultiplyShouldMultiplyValue(int value1, int value2, int expected)
        {

            testCalculator.Result = testCalculator.Multiply(value1, value2);


            Assert.Equal(expected, testCalculator.Result);
        }

        [Theory]
        [InlineData(2, 2, 1)]
        [InlineData(4, -4, -1)]
        [InlineData(int.MaxValue, 1, int.MaxValue)]
        public void DivedShouldDivideValues(int value1, int value2, int expected)
        {

            testCalculator.Result = testCalculator.Divide(value1, value2);


            Assert.Equal(expected, testCalculator.Result);
        }

        [Theory]
        [InlineData(3, 0)]
        public void DivideWillThrowZeroError(int value1, int value2){
            //Act and assert at the same time
            //how do i check if an exception is being thrown in my code? how do i unit test that?
            //takes in a lambda expression - an anonymous function
            Assert.Throws<DivideByZeroException>(() => testCalculator.Divide(value1, value2) );
        }
        







    }
}
