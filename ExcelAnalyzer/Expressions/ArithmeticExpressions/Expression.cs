using System.Collections.Generic;

namespace ExcelAnalyzer.Expressions.ArithmeticExpressions
{
    /// <summary>
    /// Базовый элемент алгебраического выражения.
    /// </summary>
    abstract class Expression
    {
        public static ExpressionBase Create(ref Dictionary<string, ICell> cells, UnitCollection array)
        {
            if (array.Count == 0)
            { // Элементы отсуствуют.
                return ErrorExpression.Create(array);
            }
            else if (array.Count == 1 && array.First.UnitType == UnitCollection.MatchType.Decimal)
            { // Если обычное число (количество знаков составляет один, а его тип равен Decimal).
                return ValueExpression.Create(array[0].Value);
            }
            else if (array.Count == 1 && array.First.UnitType == UnitCollection.MatchType.Cell)
            { // Если ссылка на ячейку (количество знаков составляет один, а его тип равен Cell).
                string key = array[0].Value;
                if (cells.ContainsKey(key))
                {
                    return (ExpressionBase)cells[key];
                }
                else
                {
                    ExpressionBase cell = CellExpression.Create(key);
                    cells.Add(key, (ICell)cell);
                    return cell;
                }
            }
            else if (array.Count == 1)
            { // Количество знаков составляет один, но это не число.
                return ErrorExpression.Create(array);
            }
            else if (array.Count == 2 && array.Last.UnitType == UnitCollection.MatchType.Decimal)
            { // Проверяем, что коллекция состоит из двух знаков, второй из которых число.
                if (array.First.UnitType == UnitCollection.MatchType.Addition)
                { // Если первый знак является плюсом.
                    return PositiveExpression.Create(ref cells, UnitCollection.Create(array, 1));
                }
                else if (array.First.UnitType == UnitCollection.MatchType.Subtracting)
                { // Если первый знак является минусом.
                    return NegativeExpression.Create(ref cells, UnitCollection.Create(array, 1));
                }
                else
                { // Если первый знак не является ни плюсом ни минусом.
                    return ErrorExpression.Create(array);
                }
            }
            else if (array.IsAssociation)
            { // Если выражение заключено в скобки.
                return AssociationExpression.Create(ref cells, UnitCollection.Create(array));
            }
            else if (array.IsPositiveAssociation)
            { // Положительное выражение, заключенное в скобки.
                return PositiveExpression.Create(ref cells, UnitCollection.Create(array, 1));
            }
            else if (array.IsNegativeAssociation)
            { // Отрицательное выражение, заключенное в скобки.
                return NegativeExpression.Create(ref cells, UnitCollection.Create(array, 1));
            }
            else
            { // Составное выражение.
                return CompoundExpressions.ExpressionBase.Create(ref cells, array);
            }
        }

        /// <summary>
        /// Определение вида алгебраического действия.
        /// </summary>
        /// <param name="value">Строковое значение.</param>
        protected static MixType GetMixType(string value)
        {
            if (ArithmeticExpression.regexAddition.IsMatch(value))
            { return MixType.Addition; }
            else if (ArithmeticExpression.regexDivision.IsMatch(value))
            { return MixType.Division; }
            else if (ArithmeticExpression.regexMultiplication.IsMatch(value))
            { return MixType.Multiplication; }
            else if (ArithmeticExpression.regexSubtracting.IsMatch(value))
            { return MixType.Subtracting; }
            else if (ArithmeticExpression.regexFix.IsMatch(value))
            { return MixType.Fix; }
            else if (ArithmeticExpression.regexMod.IsMatch(value))
            { return MixType.Mod; }
            else { return MixType.Default; }
        }

        /// <summary>
        /// Вид алгебраического действия.
        /// </summary>
        public enum MixType : int
        {
            /// <summary>
            /// Действие не определено.
            /// </summary>
            Default = -1,
            /// <summary>
            /// Сложение.
            /// </summary>
            Addition = 2,
            /// <summary>
            /// Вычитание.
            /// </summary>
            Subtracting = 3,
            /// <summary>
            /// Умножение.
            /// </summary>
            Multiplication = 4,
            /// <summary>
            /// Деление.
            /// </summary>    
            Division = 5,
            /// <summary>
            /// Целая часть в результате деления.
            /// </summary>    
            Fix = 6,
            /// <summary>
            /// Остаток от деления.
            /// </summary>    
            Mod = 7,
            /// <summary>
            /// Возведение в степень.
            /// </summary>    
            Power = 8,
            /// <summary>
            /// Извлечение корня.
            /// </summary>    
            Sqrt = 9
        }
    }
}
