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
            if (CheckInputValidity(input))
            {
                return Convert.ToString(getSum(Convert.ToInt32(input)));
            }
            return "";
        }
        public override bool CheckInputValidity(string input)
        {
            return true;
        }
        private int getSum(int upperBound)
        {
            int sums = 0;
            ICondition MultipleOfThree = new Divisor(3);
            ICondition MultipleOfFive = new Divisor(5);

            for (int i = 1; i < upperBound; i++)
            {
                if (MultipleOfThree.CheckCondition(i) ||
                    MultipleOfFive.CheckCondition(i))
                    sums += i;
            }
            return sums;
        }
    }
}
