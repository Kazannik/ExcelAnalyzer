using System;
using System.Collections.Generic;

namespace ExcelAnalyzer.Expressions.ArithmeticExpressions
{
    /// <summary>
    /// Элемент положительного алгебраического выражения.
    /// </summary>
    class PositiveExpression : ExpressionBase
    {
        private ExpressionBase _expression;

        public static PositiveExpression Create(ref Dictionary<string, ICell> cells, UnitCollection array)
        {
            return new PositiveExpression(ref cells, UnitCollection.Create(array));
        }

        private PositiveExpression(ref Dictionary<string, ICell> cells, UnitCollection array)
        {
            this._expression = Expression.Create(ref cells, array);
        }

        /// <summary>
        /// Признак содержания ошибки в выражении.
        /// </summary>
        public override bool IsError
        {
            get { return this._expression.IsError; }
        }

        /// <summary>
        /// Положительное значение алгебраического выражения.
        /// </summary>
        public override Decimal Value
        {
            get { return (+1 * this._expression.Value); }
        }

        /// <summary>
        /// Строковое представление алгебраического выражения.
        /// </summary>
        public override string Formula()
        {
            return @"+" + this._expression.Formula();
        }
    }
}
