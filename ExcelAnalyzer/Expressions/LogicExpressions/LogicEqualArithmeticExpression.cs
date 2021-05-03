using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcelAnalyzer.Expressions.LogicExpressions
{
    /// <summary>
    /// Логическое выражение (РАВНО).
    /// </summary>
    class LogicEqualArithmeticExpression : ExpressionBase
    {
        public static LogicEqualArithmeticExpression Create(ref Dictionary<string, ArithmeticExpressions.ICell> cells, UnitCollection array)
        {
            return new LogicEqualArithmeticExpression(ref cells, UnitCollection.Create(array));
        }

        private LogicEqualArithmeticExpression(ref Dictionary<string, ArithmeticExpressions.ICell> cells, UnitCollection array)
        {
            this._expression = LogicEqualArithmeticExpression.Create(ref cells, array);
        }

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
    }
}
