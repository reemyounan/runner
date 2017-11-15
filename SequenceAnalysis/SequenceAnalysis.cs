using System;
using System.Linq;
using Problem;
using Condition;

//A library called “SequenceAnalysis” containing a solution for the following problem:
//Finds the uppercase words in a string, provided as input, and order all characters in these words alphabetically.

namespace SequenceAnalysis
{
    public class SequenceAnalysis : SolvableProblem
    {
        public SequenceAnalysis()
        {
            _problemStatement = "Sequence Analysis: Finds the uppercase words in a string and orders their characters alphabetically.";
        }

        public override string Solve(string input)
        {
            if (CheckInputValidity(input))
            {
                return SortLetters(GetCapitalWords(input));
            }
            return "";
        }

        public override bool CheckInputValidity(string input)
        {
            if (input.Length == 0)
                throw new Exception("String cannot be empty");
            return true;
        }

        private string GetCapitalWords(string input)
        {
            string[] words = input.Split(' ');
            string capitalWords = "";

            ICondition isUpperCase = new UpperCase();

            foreach (string word in words)
            {
                if (isUpperCase.CheckCondition(word))
                    capitalWords += word;
            }
            return capitalWords;
        }

        private string SortLetters(string input)
        {
            return string.Concat(input.OrderBy(c => c));
        }
    }
}

