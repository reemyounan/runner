using System;
using Problem;
using Condition;
using System.Collections.ObjectModel;


//A library called “SumOfMultiple” containing a solution for the following problem:
//Find the sum of all natural numbers that are a multiple of specific divisors, below a limit provided as input.

namespace SumOfMultiple
{
    public class SumOfMultiple : SolvableProblem
    {
        private Collection<Divisor> _conditions = null;
        public SumOfMultiple()
        {
            _problemStatement = "Sum Of Multiple: Sums all natural numbers multiples below a limit provided as input";
        }
        public SumOfMultiple(string customProblemStatment, Collection<Divisor> conditions)
        {
            _conditions = conditions; //this step is done to allow creating sum of multiples that are different from 3 and 5 
            _problemStatement = customProblemStatment;
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
            catch
            {
                throw new Exception("Invalid input, please make sure to enter a natural number");
            }
            if (longInput < 0)
                throw new Exception("Invalid input, the input cannot be negative");

            return true;
        }
        private long getSum(long upperBound)
        {
            long sums = 0;
            if (_conditions.Count > 0)
            {
                for (long i = 1; i < upperBound; i++)
                {
                    foreach ( Divisor dv in _conditions )
                    {
                        if (dv.CheckCondition(i))
                        {
                            sums += i;
                            break;
                        }
                    }
                  
                }
            }


            return sums;
        }
    }
}
