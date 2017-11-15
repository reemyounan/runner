using System;
using Problem;
using Condition;

//A library called “SumOfMultiple” containing a solution for the following problem:
//Find the sum of all natural numbers that are a multiple of 3 or 5 below a limit provided as input.

namespace SumOfMultiple
{
    public class SumOfMultiple : SolvableProblem
    {
        public SumOfMultiple()
        {
            _problemStatement = "Sum Of Multiple: Sums all natural numbers that are a multiple of 3 or 5 below a limit provided as input";
        }
        public override string Solve(string input)
        {
            try
            {
                CheckInputValidity(input);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Convert.ToString(getSum(Convert.ToInt64(input)));  
        }
        public override bool CheckInputValidity(string input)
        {
            long longInput;
            try
            {
                longInput = Convert.ToInt64(input);
            }
            catch {
                throw new Exception("Invalid input, please make sure to enter a natural number");
            }
            if (longInput < 0)
                throw new Exception("Invalid input, the input cannot be negative");

            return true;
        }
        private long getSum(long upperBound)
        {
            long sums = 0;
            ICondition MultipleOfThree = new Divisor(3);
            ICondition MultipleOfFive = new Divisor(5);

            for (long i = 1; i < upperBound; i++)
            {
                if (MultipleOfThree.CheckCondition(i) ||
                    MultipleOfFive.CheckCondition(i))
                    sums += i;
            }
            return sums;
        }
    }
}
