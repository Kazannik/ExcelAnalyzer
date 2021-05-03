using System.Collections.Generic;

namespace ExcelAnalyzer.Expressions.ArithmeticExpressions.CompoundExpressions
{
    /// <summary>
    /// Составное алгебраическое выражение (Например, сложение, вычитание, умножение и т.д.)
    /// </summary>
    abstract class ExpressionBase : ArithmeticExpressions.ExpressionBase
    {
        private ArithmeticExpressions.ExpressionBase _leftExpression;
        private ArithmeticExpressions.ExpressionBase _rightExpression;

        protected ExpressionBase(ref Dictionary<string, ICell> cells, UnitCollection left, UnitCollection right)
        {
            this._leftExpression = ArithmeticExpressions.Expression.Create(ref cells, left);
            this._rightExpression = ArithmeticExpressions.Expression.Create(ref cells, right);
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

        public static new ArithmeticExpressions.ExpressionBase Create(ref Dictionary<string, ICell> cells, UnitCollection array)
        {
            int i = array.GetLastIndex();
            if (i > 0)
            {
                if (array[i].Action != UnitCollection.ActionType.Other)
                {
                    switch (array[i].UnitType)
                    {
                        case UnitCollection.MatchType.Addition:
                            return AdditionExpression.Create(ref cells, UnitCollection.Create(array, 0, i), UnitCollection.Create(array, i + 1));
                            break;
                        case UnitCollection.MatchType.Division:
                            return DivisionExpression.Create(ref cells, UnitCollection.Create(array, 0, i), UnitCollection.Create(array, i + 1));
                            break;
                        case UnitCollection.MatchType.Fix:
                            return FixExpression.Create(ref cells, UnitCollection.Create(array, 0, i), UnitCollection.Create(array, i + 1));
                            break;
                        case UnitCollection.MatchType.Mod:
                            return ModExpression.Create(ref cells, UnitCollection.Create(array, 0, i), UnitCollection.Create(array, i + 1));
                            break;
                        case UnitCollection.MatchType.Multiplication:
                            return MultiplicationExpression.Create(ref cells, UnitCollection.Create(array, 0, i), UnitCollection.Create(array, i + 1));
                            break;
                        case UnitCollection.MatchType.Subtracting:
                            return SubtractingExpression.Create(ref cells, UnitCollection.Create(array, 0, i), UnitCollection.Create(array, i + 1));
                            break;
                        case UnitCollection.MatchType.Power:
                            return PowerExpression.Create(ref cells, UnitCollection.Create(array, 0, i), UnitCollection.Create(array, i + 1));
                            break;
                        case UnitCollection.MatchType.Sqrt:
                            return SqrtExpression.Create(ref cells, UnitCollection.Create(array, 0, i), UnitCollection.Create(array, i + 1));
                            break;
                        default:
                            return ErrorExpression.Create(array);
                            break;
                    }
                }
                return ErrorExpression.Create(array);
            }
            else if (i == 0)
            {
                if (array.Count > 1)
                {
                    switch (array.First.UnitType)
                    {
                        case UnitCollection.MatchType.Addition:
                            return PositiveExpression.Create(ref cells, UnitCollection.Create(array, 1));
                            break;
                        case UnitCollection.MatchType.Subtracting:
                            return NegativeExpression.Create(ref cells, UnitCollection.Create(array, 1));
                            break;
                        default:
                            return ErrorExpression.Create(array);
                            break;
                    }
                }
                else { return ErrorExpression.Create(array); }
            }
            else { return ArithmeticExpressions.ExpressionBase.Create(ref (Dictionary<string, ICell>)cells, array); }
        }
    }
}
