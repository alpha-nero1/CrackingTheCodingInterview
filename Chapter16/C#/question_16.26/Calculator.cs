using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Linq;

namespace question_16._26
{
    /// <summary>
    /// Gorgeous calculator class that exposes a `Calc` function.
    /// the Calc function recursively reduces the expression untill a final
    /// result is returned. Amazing!
    /// </summary>
    public class Calculator
    {
        private static Dictionary<string, Func<decimal, decimal, decimal>> _funcs = new Dictionary<string, Func<decimal, decimal, decimal>>
        {
            { "*", (a, b) => a * b },
            { "+", (a, b) => a + b },
            { "/", (a, b) => a / b },
            { "-", (a, b) => a - b },
        };

        private static List<string> _opsInOrder = new List<string>
        {
            "*",
            "/",
            "+",
            "-"
        };

        public Calculator() {

        }

        public string Calc(string expression, int opIndex = 0)
        {
            // Get the operation that is to be done.
            var op = GetOp(opIndex);
            // If there are no expressions left to process, calculation is complete.
            if (op == null) return expression;
            var split = expression.Split(op);
            // Regex in order to get the digits out of the first and second splits.
            var firstArgRegex = new Regex("\\d+$");
            var secondArgRegex = new Regex("^\\d+");
            if (split.Length > 1)
            {
                // If we have enough in the split, get the first and second arg.
                decimal first = Decimal.Parse(firstArgRegex.Matches(split[0]).FirstOrDefault()?.Value);
                decimal second = Decimal.Parse(secondArgRegex.Matches(split[1]).FirstOrDefault()?.Value);
                // Calculate the result of this part of the expression.
                var result = _funcs[op](first, second);
                // Replace the result back into the expression string.
                var expr = $"{firstArgRegex.Replace(split[0], "")}{result}{secondArgRegex.Replace(split[1], "")}";
                expression = $"{expr}{String.Join("", split.Skip(2))}";
            }


            // If we split and there was more than the one multiplication case
            // recurse but do not increase the operation.
            if (split.Length > 2) return Calc(expression, opIndex);
            // Recurse to next operation!
            return Calc(expression, opIndex + 1);
        }

        private static string GetOp(int opIndex = 0)
        {
            if (opIndex >= _opsInOrder.Count) return null;
            return _opsInOrder[opIndex];
        }
    }
}