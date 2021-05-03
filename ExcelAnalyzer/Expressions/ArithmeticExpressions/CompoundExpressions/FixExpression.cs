﻿using System;
using System.Collections.Generic;

namespace ExcelAnalyzer.Expressions.ArithmeticExpressions.CompoundExpressions
{
    /// <summary>
    /// Целая часть от деления одного числа на другое.
    /// </summary>
    class FixExpression : ExpressionBase
    {
        private FixExpression(ref Dictionary<string, ICell> cells, UnitCollection left, UnitCollection right) : base(ref cells, left, right) { }

        /// <summary>
        /// Значение алгебраического выражения.
        /// </summary>
        public override decimal Value
        {
            get { return Math.Truncate((decimal)(this.LeftExpression.Value / this.RightExpression.Value)); }
        }

        /// <summary>
        /// Строковое представление алгебраического выражения.
        /// </summary>
        public override string Formula()
        {
            return this.LeftExpression.Formula() + " fix " + this.RightExpression.Formula();
        }

        public static FixExpression Create(ref Dictionary<string, ICell> cells, UnitCollection left, UnitCollection right)
        {
            return new FixExpression(ref cells, left, right);
        }
    }
}