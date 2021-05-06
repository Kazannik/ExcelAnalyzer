using System.Collections.Generic;

namespace ExcelAnalyzer.Expressions.LogicExpressions
{
    /// <summary>
    /// Составное логическое выражение (Например, равенство, сравнение и т.д.)
    /// </summary>
    abstract class CompoundExpression : ExpressionBase
    {
        private ArithmeticExpressions.ExpressionBase _leftExpression;
        private ArithmeticExpressions.ExpressionBase _rightExpression;

        protected CompoundExpression(ref Dictionary<string, ArithmeticExpressions.ICell> cells, UnitCollection left, UnitCollection right)
        {
            this._leftExpression = ArithmeticExpressions.Expression.Create(ref cells, left);
            this._rightExpression = ArithmeticExpressions.Expression.Create(ref cells, right);
        }
        
        protected string GetLeftFormula()
        {
            if (this.LeftExpression.IsError)
            {
                return this.LeftExpression.ToString();
            }
            else { return this.LeftExpression.Value.ToString(); }
        }

        protected string GetLeftFormula(string format)
        {
            if (this.LeftExpression.IsError)
            {
                return this.LeftExpression.ToString(format:format);
            }
            else { return this.LeftExpression.Value.ToString(format: format); }
        }

        protected string GetRightFormula(string format)
        {
            if (this.RightExpression.IsError)
            {
                return this.RightExpression.Formula();
            }
            else { return this.RightExpression.Value.ToString(format: format); }
        }

        protected string GetRightFormula()
        {
            if (this.RightExpression.IsError)
            {
                return this.RightExpression.Formula();
            }
            else { return this.RightExpression.Value.ToString(); }
        }

        /// <summary>
        /// Признак содержания ошибки в выражении.
        /// </summary>
        public override bool IsError
        {
            get { return this._leftExpression.IsError || this._rightExpression.IsError; }
        }

        /// <summary>
        /// Левая часть алгебраического выражения.
        /// </summary>
        public ArithmeticExpressions.ExpressionBase LeftExpression
        {
            get { return this._leftExpression; }
        }

        /// <summary>
        /// Правая часть алгебраического выражения.
        /// </summary>
        public ArithmeticExpressions.ExpressionBase RightExpression
        {
            get { return this._rightExpression; }
        }
        public static ExpressionBase Create(ref Dictionary<string, ArithmeticExpressions.ICell> cells, UnitCollection array)
        {
            int i = array.GetLastIndex();
            if (i > 0)
            {
                switch (array[i].UnitType)
                {
                    case UnitCollection.MatchType.Equal:
                        return EqualExpression.Create(ref cells, UnitCollection.Create(array, 0, i), UnitCollection.Create(array, i + 1));
                    case UnitCollection.MatchType.Less:
                        return LessExpression.Create(ref cells, UnitCollection.Create(array, 0, i), UnitCollection.Create(array, i + 1));
                    case UnitCollection.MatchType.LessOrEqual:
                        return LessOrEqualExpression.Create(ref cells, UnitCollection.Create(array, 0, i), UnitCollection.Create(array, i + 1));
                    case UnitCollection.MatchType.More:
                        return MoreExpression.Create(ref cells, UnitCollection.Create(array, 0, i), UnitCollection.Create(array, i + 1));
                    case UnitCollection.MatchType.MoreOrEqual:
                        return MoreOrEqualExpression.Create(ref cells, UnitCollection.Create(array, 0, i), UnitCollection.Create(array, i + 1));
                    case UnitCollection.MatchType.NotEqual:
                        return NotEqualExpression.Create(ref cells, UnitCollection.Create(array, 0, i), UnitCollection.Create(array, i + 1));
                    default:
                        return ErrorExpression.Create(array);
                }
            }
            else if (i == -2) { return ErrorExpression.Create(array); }
            else { return Expression.Create(ref cells, array); }
        }
    }
}
