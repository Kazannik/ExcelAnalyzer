using System.Collections.Generic;

namespace ExcelAnalyzer.Expressions.BooleanExpressions.CompoundExpressions
{
    /// <summary>
    /// Составное логическое выражение (Например, равенство, сравнение и т.д.)
    /// </summary>
    abstract class CompoundExpression : ExpressionBase
    {
        private LogicExpressions.ILogicExpression _leftExpression;
        private LogicExpressions.ILogicExpression _rightExpression;

        protected CompoundExpression(ref Dictionary<string, ArithmeticExpressions.ICell> cells, UnitCollection left, UnitCollection right)
        {
            this._leftExpression = BooleanExpressions.Expression.Create(ref cells, left);
            this._rightExpression = BooleanExpressions.Expression.Create(ref cells, right);
        }
        
        protected string GetLeftFormula()
        {
            if (this.LeftExpression.IsError)
            {
                return this.LeftExpression.Formula();
            }
            else { return this.LeftExpression.Value.ToString(); }
        }

        protected string GetLeftFormula(string format)
        {
            if (this.LeftExpression.IsError)
            {
                return this.LeftExpression.Formula();
            }
            else { return this.LeftExpression.ToString(format: format); }
        }

        protected string GetRightFormula(string format)
        {
            if (this.RightExpression.IsError)
            {
                return this.RightExpression.Formula();
            }
            else { return this.RightExpression.ToString(format: format); }
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
        public LogicExpressions.ILogicExpression LeftExpression
        {
            get { return this._leftExpression; }
        }

        /// <summary>
        /// Правая часть алгебраического выражения.
        /// </summary>
        public LogicExpressions.ILogicExpression RightExpression
        {
            get { return this._rightExpression; }
        }

        public static LogicExpressions.ILogicExpression Create(ref Dictionary<string, ArithmeticExpressions.ICell> cells, UnitCollection array)
        {
            int i = array.GetLastIndex();
            if (i > 0)
            {
                switch (array[i].UnitType)
                {
                    case UnitCollection.MatchType.And:
                        return AndExpression.Create(ref cells, UnitCollection.Create(array, 0, i), UnitCollection.Create(array, i + 1));
                    case UnitCollection.MatchType.Or:
                        return OrExpression.Create(ref cells, UnitCollection.Create(array, 0, i), UnitCollection.Create(array, i + 1));
                    case UnitCollection.MatchType.Xor:
                        return XorExpression.Create(ref cells, UnitCollection.Create(array, 0, i), UnitCollection.Create(array, i + 1));
                    case UnitCollection.MatchType.Not:
                        return NotExpression.Create(ref cells, UnitCollection.Create(array, 1));
                    case UnitCollection.MatchType.True:
                        return TrueExpression.Create();
                    case UnitCollection.MatchType.False:
                        return FalseExpression.Create();
                    default:
                        return ErrorExpression.Create(array);
                }
            }
            else if (i == -2) { return ErrorExpression.Create(array); }
            else { return Expression.Create(ref cells, array); }
        }
    }
}
