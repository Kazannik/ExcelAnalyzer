using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcelAnalyzer.Expressions.BooleanExpressions.CompoundExpressions
{
    /// <summary>
    /// Исключающее ИЛИ (XOR).
    /// </summary>
    class LogicXorExpression : ExpressionBase
    {
        private LogicXorExpression(ref Dictionary<string, ArithmeticExpressions.ICell> cells, UnitCollection left, UnitCollection right) : base(ref cells, left, right) { }

        /// <summary>
        /// Положительное значение логического выражения.
        /// </summary>
        public override bool Value
        {
            get
            {
                if (this._leftExpression.Value || this._rightExpression.Value)
                { return true; }
                else if (this._leftExpression.Value == this._rightExpression.Value)
                { return false; }
                else { return true; }
            }
        }

        /// <summary>
        /// Строковое представление логического выражения.
        /// </summary>
        public override string Formula()
        {
            return this._leftExpression.Formula() + @" xor " + this._rightExpression.Formula();
        }

        public static LogicXorExpression Create(ref Dictionary<string, ArithmeticExpressions.ICell> cells, UnitCollection left, UnitCollection right)
        {
            return new LogicXorExpression(ref cells, left, right);
        }
    }
}
