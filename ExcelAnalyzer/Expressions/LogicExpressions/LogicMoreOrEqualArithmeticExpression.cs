using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcelAnalyzer.Expressions.LogicExpressions
{
    /// <summary>
    /// Логическое выражение (БОЛЬШЕ ИЛИ РАВНО).
    /// </summary>
    class LogicMoreOrEqualArithmeticExpression : Expression
    {
        public new static LogicMoreOrEqualArithmeticExpression Create(ref Dictionary<string, ArithmeticExpressions.ICell> cells, UnitCollection array)
        {
            return new LogicMoreOrEqualArithmeticExpression(ref cells, UnitCollection.Create(array));
        }

        private LogicMoreOrEqualArithmeticExpression(ref Dictionary<string, ArithmeticExpressions.ICell> cells, UnitCollection array)
        {
            this._expression = ExpressionBase.Create(ref cells, array);
        }

        /// <summary>
        /// Положительное значение логического выражения.
        /// </summary>
        public override bool Value
        {
            get { return (this._leftExpression.Value >= this._rightExpression.Value); }
        }

        /// <summary>
        /// Строковое представление логического выражения.
        /// </summary>
        public override string Formula()
        {
            return this._leftExpression.Formula() + @" >= " + this._rightExpression.Formula();
        }
    }
}
