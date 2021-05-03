using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcelAnalyzer.Expressions.BooleanExpressions.CompoundExpressions
{
    /// <summary>
    /// Логическое "И" (AND).
    /// </summary>
    class LogicAndExpression : ExpressionBase
    {
        private LogicAndExpression(ref Dictionary<string, ArithmeticExpressions.ICell> cells, UnitCollection left, UnitCollection right) : base(ref cells, left, right) { }

        /// <summary>
        /// Положительное значение логического выражения.
        /// </summary>
        public override bool Value
        {
            get { return (this._leftExpression.Value & this._rightExpression.Value); }
        }

        /// <summary>
        /// Строковое представление логического выражения.
        /// </summary>
        public override string Formula()
        {
            return this._leftExpression.Formula() + @" and " + this._rightExpression.Formula();
        }

        public static LogicAndExpression Create(ref Dictionary<string, ArithmeticExpressions.ICell> cells, UnitCollection left, UnitCollection right)
        {
            return new LogicAndExpression(ref cells, left, right);
        }
    }
}
