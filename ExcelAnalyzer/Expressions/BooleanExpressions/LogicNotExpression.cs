using System.Collections.Generic;

namespace ExcelAnalyzer.Expressions.BooleanExpressions
{
    /// <summary>
    /// Противоположное логическое выражение.
    /// </summary>
    class LogicNotExpression : LogicExpressionBase
    {
        private LogicExpressionBase _expression;

        public static LogicNotExpression Create(ref Dictionary<string, ArithmeticExpressions.ICell> cells, UnitCollection array)
        {
            return new LogicNotExpression(ref cells, UnitCollection.Create(array));
        }

        private LogicNotExpression(ref Dictionary<string, ArithmeticExpressions.ICell> cells, UnitCollection array)
        {
            this._expression = LogicExpressionBase.Create(ref cells, array);
        }

        /// <summary>
        /// Признак содержания ошибки в выражении.
        /// </summary>
        public override bool IsError
        {
            get { return this._expression.IsError; }
        }

        /// <summary>
        /// Положительное значение логического выражения.
        /// </summary>
        public override bool Value
        {
            get { return (!this._expression.Value); }
        }

        /// <summary>
        /// Строковое представление логического выражения.
        /// </summary>
        public override string Formula()
        {
            return @" not " + this._expression.Formula();
        }
    }
}
