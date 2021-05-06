﻿namespace ExcelAnalyzer.Expressions.ArithmeticExpressions
{
    /// <summary>
    /// Ошибочное выражение.
    /// </summary>
    class ErrorExpression : ExpressionBase
    {
        private string _formula;

        private ErrorExpression(UnitCollection array)
        {
            this.IsError = true;
            this.Value = 0;
            this._formula = ArithmeticExpression.SymbolStartError;
            foreach (UnitCollection.BaseUnit u in array)
            {
                if (this._formula.Length > 0) { this._formula += " "; }
                this._formula += u.Value;
            }
            this._formula += ArithmeticExpression.SymbolEndError;
        }

        /// <summary>
        /// Признак содержания ошибки в выражении.
        /// </summary>
        public override bool IsError { get; }

        /// <summary>
        /// Значение алгебраического выражения.
        /// </summary>
        public override decimal Value { get; }

        /// <summary>
        /// Строковое представление алгебраического выражения.
        /// </summary>
        public override string Formula()
        {
            return this._formula;
        }

        public static ErrorExpression Create(UnitCollection.BaseUnit unit)
        {
            return new ErrorExpression(UnitCollection.Create(unit));
        }

        public static ErrorExpression Create(UnitCollection array)
        {
            return new ErrorExpression(array);
        }
    }
}
