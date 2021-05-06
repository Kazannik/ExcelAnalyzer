using System;
using System.Collections.Generic;

namespace ExcelAnalyzer.Expressions.ArithmeticExpressions.CompoundExpressions
{
    /// <summary>
    /// Число, возведенное в степень.
    /// </summary>
    class PowerExpression : CompoundExpression
    {
        private PowerExpression(ref Dictionary<string, ICell> cells, UnitCollection left, UnitCollection right) : base(ref cells, left, right) { }

        /// <summary>
        /// Значение алгебраического выражения.
        /// </summary>
        public override decimal Value
        {
            get { return (decimal)Math.Pow((double)this.LeftExpression.Value, (double)this.RightExpression.Value); }
        }

        /// <summary>
        /// Строковое представление алгебраического выражения.
        /// </summary>
        public override string Formula()
        {
            return this.LeftExpression.Formula() + " " + ArithmeticExpression.SymbolPower + " " + this.RightExpression.Formula();
        }

        /// <summary>
        /// Короткое строковое представление выражения.
        /// </summary>
        /// <param name="format">Формат отображения результата алгебраического выражения.</param>
        public override string ToString(string format)
        {
            if (IsFormat(format: format))
            {
                return GetLeftFormula(format: format) + @" " + ArithmeticExpression.SymbolPower + @" " + GetRightFormula(format: format);
            }
            else
            {
                return GetLeftFormula() + @" " + ArithmeticExpression.SymbolPower + @" " + GetRightFormula();
            }
        }

        public static PowerExpression Create(ref Dictionary<string, ICell> cells, UnitCollection left, UnitCollection right)
        {
            return new PowerExpression(ref cells, left, right);
        }
    }
}
