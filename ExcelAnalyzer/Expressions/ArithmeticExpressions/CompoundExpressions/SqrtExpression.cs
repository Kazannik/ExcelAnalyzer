using System;
using System.Collections.Generic;

namespace ExcelAnalyzer.Expressions.ArithmeticExpressions.CompoundExpressions
{
    /// <summary>
    /// Корень числа.
    /// </summary>
    class SqrtExpression : ExpressionBase
    {
        private SqrtExpression(ref Dictionary<string, ICell> cells, UnitCollection left, UnitCollection right) : base(ref cells, left, right) { }

        /// <summary>
        /// Значение алгебраического выражения.
        /// </summary>
        public override decimal Value
        {
            get { return (decimal)Math.Pow((double)this.LeftExpression.Value, (double)(1 / this.RightExpression.Value)); }
        }

        /// <summary>
        /// Строковое представление алгебраического выражения.
        /// </summary>
        public override string Formula()
        {
            return this.LeftExpression.Formula() + " sqrt " + this.RightExpression.Formula();
        }

        public static SqrtExpression Create(ref Dictionary<string, ICell> cells, UnitCollection left, UnitCollection right)
        {
            return new SqrtExpression(ref cells, left, right);
        }
    }
}
