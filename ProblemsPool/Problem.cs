namespace Problem
{
    public interface IProblem
    {
        string GetProblemStatement();
        string Solve(string input);
    }

    public abstract class SolvableProblem: IProblem
    {
        protected string _problemStatement="";
        public string GetProblemStatement()
        {
            return _problemStatement;
        }
        public abstract string Solve(string input);
        public abstract bool CheckInputValidity(string input);
    }
}
