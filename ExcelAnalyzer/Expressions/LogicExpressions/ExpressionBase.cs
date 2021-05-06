namespace ExcelAnalyzer.Expressions.LogicExpressions
{
    /// <summary>
    /// Базовый класс логического выражений.
    /// </summary>
    public abstract class ExpressionBase: Expressions.ExpressionBase, ILogicExpression
    {
        /// <summary>
        /// Значение логического выражения.
        /// </summary>
        public abstract bool Value { get; }       
    }
}
