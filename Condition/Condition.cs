using System;
using System.Linq;

namespace Condition
{
    public interface ICondition
    {
        bool CheckCondition(object operand);
    }
    public class Divisor : ICondition
    {
        private long _divisor;
        public Divisor(int divisor)
        {
            _divisor = divisor;
        }
        public bool CheckCondition(object firstOperand)
        {
            bool returnValue = false;
            try
            {
                CheckOperandValidity(firstOperand);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return returnValue = (Convert.ToInt64(firstOperand) % _divisor == 0);
        }
        private bool CheckOperandValidity(object firstOperand)
        {
            long longInput;
            try
            {
                longInput = Convert.ToInt64(firstOperand);
            }
            catch
            {
                throw new Exception("Invalid input, please make sure to enter a natural number");
            }
            if (longInput < 0)
                throw new Exception("Invalid input, the input cannot be negative");

            return true;
        }
    }
    public class UpperCase : ICondition
    {
        public bool CheckCondition(object operand)
        {
            bool returnValue = false;
            try
            {
                CheckOperandValidity(operand);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return returnValue = ((string)operand).All(c => char.IsUpper(c));
        }
        private bool CheckOperandValidity(object firstOperand)
        {
            return true;
        }
    }
}
