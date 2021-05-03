using System.Collections.Generic;

namespace ExcelAnalyzer.Expressions.ArithmeticExpressions
{
    /// <summary>
    /// Алгебраическое выражение, заключенное в скобки.
    /// </summary>
    class AssociationExpression : ExpressionBase
    {
        private ExpressionBase _expression;

        private AssociationExpression(ref Dictionary<string, ICell> cells, UnitCollection array)
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
        /// Значение алгебраического выражения.
        /// </summary>
        public override decimal Value
        {
            get { return (this._expression.Value); }
        }

        /// <summary>
        /// Строковое представление алгебраического выражения.
        /// </summary>
        public override string Formula()
        {
            return @"(" + this._expression.Formula() + @")";
        }

        public static AssociationExpression Create(ref Dictionary<string, ICell> cells, UnitCollection array)
        {
            return new AssociationExpression(ref cells, UnitCollection.Create(array, 1, array.Count - 2));
        }
    }
}
