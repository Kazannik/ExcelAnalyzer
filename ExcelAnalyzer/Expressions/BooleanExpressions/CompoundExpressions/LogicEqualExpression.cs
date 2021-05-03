using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcelAnalyzer.Expressions.BooleanExpressions.CompoundExpressions
{
    /// <summary>
    /// Логическое выражение "=" (РАВНО).
    /// </summary>
    class LogicEqualExpression : ExpressionBase
    {
        private LogicEqualExpression(ref Dictionary<string, ArithmeticExpressions.ICell> cells, UnitCollection left, UnitCollection right) : base(ref cells, left, right) { }

        /// <summary>
        /// Положительное значение логического выражения.
        /// </summary>
        public override bool Value
        {
            get { return (this._leftExpression.Value == this._rightExpression.Value); }
        }

        /// <summary>
        /// Строковое представление логического выражения.
        /// </summary>
        public override string Formula()
        {
            return this._leftExpression.Formula() + @" = " + this._rightExpression.Formula();
        }

        public static LogicEqualExpression Create(ref Dictionary<string, ArithmeticExpressions.ICell> cells, UnitCollection left, UnitCollection right)
        {
            return new LogicEqualExpression(ref cells, left, right);
        }
    }
}
