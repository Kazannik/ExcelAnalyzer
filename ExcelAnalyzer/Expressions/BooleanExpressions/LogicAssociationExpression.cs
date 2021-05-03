using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcelAnalyzer.Expressions.BooleanExpressions
{
    /// <summary>
    /// Логическое выражение, заключенное в скобки.
    /// </summary>
    class LogicAssociationExpression : LogicExpressionBase
    {
        private LogicExpressionBase _expression;

        private LogicAssociationExpression(ref Dictionary<string, ArithmeticExpressions.ICell> cells, UnitCollection array)
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
        /// Значение логического выражения.
        /// </summary>
        public override bool Value
        {
            get { return (this._expression.Value); }
        }

        /// <summary>
        /// Строковое представление согического выражения.
        /// </summary>
        public override string Formula()
        {
            return @"(" + this._expression.Formula() + @")";
        }

        public static LogicAssociationExpression Create(ref Dictionary<string, ArithmeticExpressions.ICell> cells, UnitCollection array)
        {
            return new LogicAssociationExpression(ref cells, UnitCollection.Create(array, 1, array.Count - 2));
        }
    }
}
