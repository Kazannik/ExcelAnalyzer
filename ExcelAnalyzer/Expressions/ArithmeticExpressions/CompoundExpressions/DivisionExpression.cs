using System.Collections.Generic;

namespace ExcelAnalyzer.Expressions.ArithmeticExpressions.CompoundExpressions
{
    /// <summary>
    /// Алгебраическое выражение деления.
    /// </summary>
    class DivisionExpression : ExpressionBase
    {
        private DivisionExpression(ref Dictionary<string, ICell> cells, UnitCollection left, UnitCollection right) : base(ref cells, left, right) { }

        /// <summary>
        /// Значение алгебраического выражения.
        /// </summary>
        public override decimal Value
        {
            get { return this.LeftExpression.Value / this.RightExpression.Value; }
        }

        /// <summary>
        /// Строковое представление алгебраического выражения.
        /// </summary>
        public override string Formula()
        {
            return this.LeftExpression.Formula() + " / " + this.RightExpression.Formula();
        }

        public static DivisionExpression Create(ref Dictionary<string, ICell> cells, UnitCollection left, UnitCollection right)
        {
            return new DivisionExpression(ref cells, left, right);
        }
    }
}
