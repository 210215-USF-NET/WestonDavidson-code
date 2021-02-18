using System;

namespace CalulatorUnitTesting
{
    public class Calculator
    {


        public int Result {get; set;}

        public int Add(int one, int two) {
            
        
            Result = one + two;


            return Result;
         }

        
        public int Subtract(int one, int two)
        {
            Result = one - two;

            
            return Result;
        }


        public int Multiply(int one, int two) {
            Result = one * two;

            
            return Result;
         }

        public int Divide(int one, int two)
        {
            try{
            Result = one / two;
            return Result;
            } catch (DivideByZeroException){
                throw new DivideByZeroException("cannot divide by 0");
            }

            
            return Result;
        }
/*
        public void FibonacciCalc()
        {

        }
        */



    }
}