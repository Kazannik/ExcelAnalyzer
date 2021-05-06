namespace ExcelAnalyzer.Expressions.BooleanExpressions
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
            this.Value = false;
            this._formula = BooleanExpression.SymbolStartError;
            foreach (UnitCollection.BaseUnit u in array)
            {
                if (this._formula.Length > 0) { this._formula += " "; }
                this._formula += u.Value;
            }
            this._formula += BooleanExpression.SymbolEndError;
        }

        /// <summary>
        /// Признак содержания ошибки в выражении.
        /// </summary>
        public override bool IsError { get; }

        /// <summary>
        /// Значение логического выражения.
        /// </summary>
        public override bool Value { get; }

        /// <summary>
        /// Строковое представление логического выражения.
        /// </summary>
        public override string Formula()
        {
            return this._formula;
        }

        /// <summary>
        /// Короткое строковое представление логического выражения.
        /// </summary>
        /// <param name="format">Формат отображения результата алгебраического выражения.</param>
        public override string ToString(string format)
        {
            return this.Formula();
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
