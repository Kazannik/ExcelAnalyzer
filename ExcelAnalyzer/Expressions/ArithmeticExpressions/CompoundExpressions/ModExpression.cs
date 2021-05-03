using System.Collections.Generic;

namespace ExcelAnalyzer.Expressions.ArithmeticExpressions.CompoundExpressions
{
    /// <summary>
    /// Остаток от деления одного числа на другое.
    /// </summary>
    class ModExpression : ExpressionBase
    {
        private ModExpression(ref Dictionary<string, ICell> cells, UnitCollection left, UnitCollection right) : base(ref cells, left, right) { }

        /// <summary>
        /// Значение алгебраического выражения.
        /// </summary>
        public override decimal Value
        {
            get { return (this.LeftExpression.Value % this.RightExpression.Value); }
        }

        /// <summary>
        /// Строковое представление алгебраического выражения.
        /// </summary>
        public override string Formula()
        {
            return this.LeftExpression.Formula() + " mod " + this.RightExpression.Formula();
        }

        public static ModExpression Create(ref Dictionary<string, ICell> cells, UnitCollection left, UnitCollection right)
        {
            return new ModExpression(ref cells, left, right);
        }
    }
}
