using System;
using System.Collections.Generic;
using System.Linq;
using Problem;
using System.Collections.ObjectModel;
using Condition;
namespace ProblemFactory
{
    public static class FactoryProblem
    {
        private static Dictionary<int, IProblem> _problems = new Dictionary<int, IProblem>();
        private static Dictionary<int, string> _problemStatements = new Dictionary<int, string>();

        static FactoryProblem()
        {
            #region Create the dictionary of problems available for runner

            #region Add "sum of multiples" to the to the dictionary of available problems (that requires specifying the divisors for class SumOfMultiple)

            #region create conditions for multiples of 3 and 5
            Collection<Condition.Divisor> customDivisors = new Collection<Divisor>();
            customDivisors.Add(new Divisor(3));
            customDivisors.Add(new Divisor(5));
            #endregion
            
            _problems.Add(1, new SumOfMultiple.SumOfMultiple(
                "Sum Of Multiple: Sums all natural numbers that are a multiple of 3 or 5 below a limit provided as input", customDivisors));
            #endregion

            #region  Add "sequence analysis" to the dictionary of available problems
            _problems.Add(2, new SequenceAnalysis.SequenceAnalysis());
            #endregion
           
            #endregion

            #region Create the dictionary of problem statements corresponding to the set of available problems
            foreach (KeyValuePair<int, IProblem> pair in _problems)
            {
                _problemStatements.Add(pair.Key, pair.Value.GetProblemStatement());
            }
            #endregion

        }

        public static IProblem Create(int SelectedProblem)
        {
            if (_problems.Keys.Contains(SelectedProblem))
                return _problems[SelectedProblem];
            else
                throw new Exception("Problem does not belong to the pool of problems");
        }

        public static Dictionary<int, string> GetProblems()
        {
            return _problemStatements;
        }
    }
}
