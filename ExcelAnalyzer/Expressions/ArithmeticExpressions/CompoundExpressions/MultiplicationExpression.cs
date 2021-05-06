using System.Collections.Generic;

namespace ExcelAnalyzer.Expressions.ArithmeticExpressions.CompoundExpressions
{
    /// <summary>
    /// Алгебраическое выражение умножения.
    /// </summary>
    class MultiplicationExpression : CompoundExpression
    {
        private MultiplicationExpression(ref Dictionary<string, ICell> cells, UnitCollection left, UnitCollection right) : base(ref cells, left, right) { }

        /// <summary>
        /// Значение алгебраического выражения.
        /// </summary>
        public override decimal Value
        {
            get { return this.LeftExpression.Value * this.RightExpression.Value; }
        }

        /// <summary>
        /// Строковое представление алгебраического выражения.
        /// </summary>
        public override string Formula()
        {
            return this.LeftExpression.Formula() + " " + ArithmeticExpression.SymbolMultiplication + " " + this.RightExpression.Formula();
        }

        /// <summary>
        /// Короткое строковое представление выражения.
        /// </summary>
        /// <param name="format">Формат отображения результата алгебраического выражения.</param>
        public override string ToString(string format)
        {
            if (IsFormat(format: format))
            {
                return GetLeftFormula(format: format) + @" " + ArithmeticExpression.SymbolMultiplication + @" " + GetRightFormula(format: format);
            }
            else
            {
                return GetLeftFormula() + @" " + ArithmeticExpression.SymbolMultiplication + @" " + GetRightFormula();
            }
        }

        public static MultiplicationExpression Create(ref Dictionary<string, ICell> cells, UnitCollection left, UnitCollection right)
        {
            return new MultiplicationExpression(ref cells, left, right);
        }
    }
}
