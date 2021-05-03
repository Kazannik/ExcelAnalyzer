namespace ExcelAnalyzer.Expressions.ArithmeticExpressions
{
    /// <summary>
    /// Ячейка, используемая при расчете.
    /// </summary>
    class CellExpression : ExpressionBase, ICell
    {
        private decimal _value;

        private CellExpression(string key)
        {
            this.Key = key;
            this.IsError = false;
            this._value = 0;
        }

        /// <summary>
        /// Признак содержания ошибки в выражении.
        /// </summary>
        public override bool IsError { get; }

        /// <summary>
        /// Ключ для доступа к ячеке расчетов.
        /// </summary>
        public string Key { get; }

        /// <summary>
        /// Значение алгебраического выражения.
        /// </summary>
        public override decimal Value { get { return this._value; } }

        /// <summary>
        /// Строковое представление алгебраического выражения.
        /// </summary>
        public override string Formula()
        {
            return @"[" + this.Key + @":" + this.Value + @"]";
        }

        /// <summary>
        /// Присвоить значение ячейке.
        /// </summary>
        /// <param name="value">Значение ячейки.</param>
        public void SetValue(decimal value)
        {
            this._value = value;
        }
               
        public static CellExpression Create(string key)
        {
            return new CellExpression(key);
        }
    }
}
