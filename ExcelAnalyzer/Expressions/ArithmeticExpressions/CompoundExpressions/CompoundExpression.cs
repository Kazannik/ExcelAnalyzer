using System.Collections.Generic;

namespace ExcelAnalyzer.Expressions.ArithmeticExpressions.CompoundExpressions
{
    /// <summary>
    /// Составное алгебраическое выражение (Например, сложение, вычитание, умножение и т.д.)
    /// </summary>
    abstract class CompoundExpression : ExpressionBase
    {
        private ExpressionBase _leftExpression;
        private ExpressionBase _rightExpression;

        protected CompoundExpression(ref Dictionary<string, ICell> cells, UnitCollection left, UnitCollection right)
        {
            this._leftExpression = Expression.Create(ref cells, left);
            this._rightExpression = Expression.Create(ref cells, right);
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
                return this.LeftExpression.ToString(format: format);
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
        public ExpressionBase LeftExpression
        {
            get { return this._leftExpression; }
        }

        /// <summary>
        /// Правая часть алгебраического выражения.
        /// </summary>
        public ExpressionBase RightExpression
        {
            get { return this._rightExpression; }
        }

        public static ExpressionBase Create(ref Dictionary<string, ICell> cells, UnitCollection array)
        {
            int i = array.GetLastIndex();
            if (i > 0)
            {
                switch (array[i].UnitType)
                {
                    case UnitCollection.MatchType.Addition:
                        return AdditionExpression.Create(ref cells, UnitCollection.Create(array, 0, i), UnitCollection.Create(array, i + 1));
                    case UnitCollection.MatchType.Division:
                        return DivisionExpression.Create(ref cells, UnitCollection.Create(array, 0, i), UnitCollection.Create(array, i + 1));
                    case UnitCollection.MatchType.Fix:
                        return FixExpression.Create(ref cells, UnitCollection.Create(array, 0, i), UnitCollection.Create(array, i + 1));
                    case UnitCollection.MatchType.Mod:
                        return ModExpression.Create(ref cells, UnitCollection.Create(array, 0, i), UnitCollection.Create(array, i + 1));
                    case UnitCollection.MatchType.Multiplication:
                        return MultiplicationExpression.Create(ref cells, UnitCollection.Create(array, 0, i), UnitCollection.Create(array, i + 1));
                    case UnitCollection.MatchType.Subtracting:
                        return SubtractingExpression.Create(ref cells, UnitCollection.Create(array, 0, i), UnitCollection.Create(array, i + 1));
                    case UnitCollection.MatchType.Power:
                        return PowerExpression.Create(ref cells, UnitCollection.Create(array, 0, i), UnitCollection.Create(array, i + 1));
                    case UnitCollection.MatchType.Sqrt:
                        return SqrtExpression.Create(ref cells, UnitCollection.Create(array, 0, i), UnitCollection.Create(array, i + 1));
                    default:
                        return ErrorExpression.Create(array);
                }
            }
            else if (i == 0)
            {
                if (array.Count > 1)
                {
                    switch (array.First.UnitType)
                    {
                        case UnitCollection.MatchType.Addition:
                            return PositiveExpression.Create(ref cells, UnitCollection.Create(array, 1));
                        case UnitCollection.MatchType.Subtracting:
                            return NegativeExpression.Create(ref cells, UnitCollection.Create(array, 1));
                        default:
                            return ErrorExpression.Create(array);
                    }
                }
                else { return ErrorExpression.Create(array); }
            }
            else if (i < 0)
            {
                return ErrorExpression.Create(array);
            }
            else { return Expression.Create(ref cells, array); }
        }
    }
}
