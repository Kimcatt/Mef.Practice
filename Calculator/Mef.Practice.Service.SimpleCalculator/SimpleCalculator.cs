using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.Composition;
using Mef.Practice.Service.Calculator;

namespace Mef.Practice.Service.SimpleCalculator
{
    [Export(typeof(ICalculator))]
    public class SimpleCalculator : Practice.Service.Calculator.ICalculator
    {
        [ImportMany]
        IEnumerable<Lazy<IOperation, IOperationMetadata>> operations;

        public String Calculate(String input)
        {
            int left;
            int right;
            Char operation;
            int fn = FindFirstNonDigit(input); //finds the operator
            if (fn < 0) return "Could not parse expression.";

            try
            {
                //separate out the operands
                left = int.Parse(input.Substring(0, fn).Trim());
                right = int.Parse(input.Substring(fn + 1).Trim());
            }
            catch
            {
                return "Could not parse expression.";
            }

            operation = input[fn];

            foreach (Lazy<IOperation, IOperationMetadata> i in operations)
            {
                if (i.Metadata.Symbol.Equals(operation)) return i.Value.Operate(left, right).ToString();
            }
            return "Operation Not Found!";
        }

        private int FindFirstNonDigit(String s)
        {

            for (int i = 0; i < s.Length; i++)
            {
                //if (!(Char.IsDigit(s[i]))) return i;
                if (!char.IsNumber(s[i]) && !char.IsWhiteSpace(s[i])) return i;
            }
            return -1;
        }
    }
}
