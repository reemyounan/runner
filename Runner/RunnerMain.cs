using System;
using System.Collections.Generic;
using Problem;
using ProblemFactory;

namespace Runner
{
    class RunnerMain
    {
        static void Main()
        {
            IProblem currentProblemToSolve;
            Dictionary<int, string> problemStatements = FactoryProblem.GetProblems();

            do
            {
                currentProblemToSolve = null;

                #region Prompt the user with the available problems
                Console.WriteLine("\r\n--------------------------------------");
                Console.WriteLine("Choose the problem you wish to solve:");
                Console.WriteLine("--------------------------------------");

                foreach (KeyValuePair<int, string> pair in problemStatements)
                {
                    Console.WriteLine(string.Format("\r\n\t{0}. {1}", Convert.ToString(pair.Key), pair.Value));
                }

                Console.WriteLine("\r\n(Type the problem number then press ENTER or type 'Q' to exit.)");
                string ProblemToSolve = Console.ReadLine();
                #endregion


                if (ProblemToSolve.ToLower() == "q")
                    break;
                else
                {
                    try
                    {
                        #region create instance of the requested problem using the problem factory and proceed with solving the probelm
                        currentProblemToSolve = FactoryProblem.Create(Int32.Parse(ProblemToSolve));
                        Console.WriteLine("\r\nPlease input your data and press ENTER.");
                        string UserInput = Console.ReadLine();
                        Console.WriteLine("\r\nSolution: " + currentProblemToSolve.Solve(UserInput));
                        #endregion
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("\r\n" + ex.Message + "\r\n");
                        continue;
                    }
                }
            } while (true);
        }
    }
}