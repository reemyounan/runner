using System;
using System.Collections.Generic;
using System.Linq;
using Problem;

namespace ProblemFactory
{
    public static class FactoryProblem
    {
        private static Dictionary<int, IProblem> _problems = new Dictionary<int, IProblem>();
        private static Dictionary<int, string> _problemStatements = new Dictionary<int, string>();
        static FactoryProblem()
        {
            #region add problems
            _problems.Add(1, new SumOfMultiple.SumOfMultiple());
            _problems.Add(2, new SequenceAnalysis.SequenceAnalysis());
            #endregion

            #region add problem statement
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
