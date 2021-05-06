﻿using System.Collections.Generic;

namespace ExcelAnalyzer.Expressions.BooleanExpressions
{
    /// <summary>
    /// Отрицательное логическое выражение.
    /// </summary>
    class FalseExpression : ExpressionBase
    {
        public static FalseExpression Create()
        {
            return new FalseExpression();
        }

        private FalseExpression()
        {
            this.IsError = false;
            this.Value = false;
        }

        /// <summary>
        /// Признак содержания ошибки в выражении.
        /// </summary>
        public override bool IsError { get; }

        /// <summary>
        /// Положительное значение логического выражения.
        /// </summary>
        public override bool Value { get; }

        /// <summary>
        /// Строковое представление логического выражения.
        /// </summary>
        public override string Formula()
        {
            return BooleanExpression.SymbolFalse;
        }
        /// <summary>
        /// Короткое строковое представление логического выражения.
        /// </summary>
        /// <param name="format">Формат отображения результата алгебраического выражения.</param>
        public override string ToString(string format)
        {
            return Formula();
        }
    }
}