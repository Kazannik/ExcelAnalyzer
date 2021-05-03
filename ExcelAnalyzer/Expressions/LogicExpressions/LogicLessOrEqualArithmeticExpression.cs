﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcelAnalyzer.Expressions.LogicExpressions
{
    /// <summary>
    /// Логическое выражение (МЕНЬШЕ ИЛИ РАВНО).
    /// </summary>
    class LogicLessOrEqualArithmeticExpression : ExpressionBase
    {
        public new static LogicLessOrEqualArithmeticExpression Create(ref Dictionary<string, ArithmeticExpressions.ICell> cells, UnitCollection array)
        {
            return new LogicLessOrEqualArithmeticExpression(ref cells, UnitCollection.Create(array));
        }

        private LogicLessOrEqualArithmeticExpression(ref Dictionary<string, ArithmeticExpressions.ICell> cells, UnitCollection array)
        {
            this._expression = LogicExpressionBase.Create(ref cells, array);
        }

        /// <summary>
        /// Положительное значение логического выражения.
        /// </summary>
        public override bool Value
        {
            get { return (this._leftExpression.Value <= this._rightExpression.Value); }
        }

        /// <summary>
        /// Строковое представление логического выражения.
        /// </summary>
        public override string Formula()
        {
            return this._leftExpression.Formula() + @" <= " + this._rightExpression.Formula();
        }
    }
}
