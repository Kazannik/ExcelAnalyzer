namespace ExcelAnalyzer.Expressions.ArithmeticExpressions
{
    /// <summary>
    /// Базовый класс алгебраического выражений.
    /// </summary>
    public abstract class ExpressionBase: Expressions.ExpressionBase
    {
        /// <summary>
        /// Значение алгебраического выражения.
        /// </summary>
        public abstract decimal Value { get; }

        public override string ToString(string format)
        {
            if (IsFormat(format: format))
            {
                return this.Value.ToString(format: format);
            }
            else { return this.Value.ToString(); }
        }
    }
}
