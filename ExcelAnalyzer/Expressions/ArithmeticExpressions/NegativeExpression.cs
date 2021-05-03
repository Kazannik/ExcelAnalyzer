using System.Collections.Generic;

namespace ExcelAnalyzer.Expressions.ArithmeticExpressions
{
    /// <summary>
    /// Элемент отрицательного алгебраического выражения.
    /// </summary>
    class NegativeExpression : ExpressionBase
    {
        private ExpressionBase _expression;

        private NegativeExpression(ref Dictionary<string, ICell> cells, UnitCollection array)
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
        /// Отрицательное значение алгебраического выражения.
        /// </summary>
        public override decimal Value
        {
            get { return (this._expression.Value * -1); }
        }

        /// <summary>
        /// Строковое представление алгебраического выражения.
        /// </summary>
        public override string Formula()
        {
            return @"-" + this._expression.Formula();
        }

        public static NegativeExpression Create(ref Dictionary<string, ICell> cells, UnitCollection array)
        {
            return new NegativeExpression(ref cells, UnitCollection.Create(array));
        }
    }
}
