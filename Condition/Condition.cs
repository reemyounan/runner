using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Condition
{
    public interface ICondition
    {
        bool CheckCondition(object operand );
    }
    public class Divisor : ICondition
    {
        private int _divisor;
        public Divisor(int divisor)
        {
            _divisor = divisor;
        }
        public bool CheckCondition(object firstOperand)
        {
            bool returnValue = false;
            Exception conditionException;
            if (CheckOperandValidity(firstOperand, out conditionException))
                returnValue = (Convert.ToInt32(firstOperand) % _divisor == 0);
            else
                throw conditionException;

            return returnValue;
        }
        private bool CheckOperandValidity(object firstOperand, out Exception conditionException)
        {
            conditionException = new Exception();
            
            return true;
        }
    }
    public class UpperCase : ICondition
    {
        public bool CheckCondition(object operand)
        {
            bool returnValue = false;
            Exception conditionException;
            if (CheckOperandValidity(operand, out conditionException))
                returnValue = ((string)operand).All(c => char.IsUpper(c));
            else
                throw conditionException;

            return returnValue;
        }
        private bool CheckOperandValidity(object firstOperand, out Exception conditionException)
        {
            conditionException = new Exception();

            return true;
        }
    }
}
