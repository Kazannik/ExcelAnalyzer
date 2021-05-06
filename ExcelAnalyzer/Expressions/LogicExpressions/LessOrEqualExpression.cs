using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcelAnalyzer.Expressions.LogicExpressions
{
    /// <summary>
    /// Логическое выражение (МЕНЬШЕ ИЛИ РАВНО).
    /// </summary>
    class LessOrEqualExpression : CompoundExpression
    {
        private LessOrEqualExpression(ref Dictionary<string, ArithmeticExpressions.ICell> cells, UnitCollection left, UnitCollection right) : base(ref cells, left, right) { }

        /// <summary>
        /// Положительное значение логического выражения.
        /// </summary>
        public override bool Value
        {
            get { return (this.LeftExpression.Value <= this.RightExpression.Value); }
        }

        /// <summary>
        /// Строковое представление логического выражения.
        /// </summary>
        public override string Formula()
        {
            return this.LeftExpression.Formula() + @" " + LogicExpression.SymbolLessOrEqual + @" " + this.RightExpression.Formula();
        }

        /// <summary>
        /// Короткое строковое представление логического выражения.
        /// </summary>
        /// <param name="format">Формат отображения результата алгебраического выражения.</param>
        public override string ToString(string format)
        {
            if (IsFormat(format: format))
            {
                return GetLeftFormula(format: format) + @" " + LogicExpression.SymbolLessOrEqual + @" " + GetRightFormula(format: format);
            }
            else
            {
                return GetLeftFormula() + @" " + LogicExpression.SymbolLessOrEqual + @" " + GetRightFormula();
            }
        }
        public static LessOrEqualExpression Create(ref Dictionary<string, ArithmeticExpressions.ICell> cells, UnitCollection left, UnitCollection right)
        {
            return new LessOrEqualExpression(ref cells, left, right);
        }
    }
}
