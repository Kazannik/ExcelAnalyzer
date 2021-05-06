using System;
using System.Collections.Generic;

namespace ExcelAnalyzer.Expressions.ArithmeticExpressions.CompoundExpressions
{
    /// <summary>
    /// Корень числа.
    /// </summary>
    class SqrtExpression : CompoundExpression
    {
        private SqrtExpression(ref Dictionary<string, ICell> cells, UnitCollection left, UnitCollection right) : base(ref cells, left, right) { }

        /// <summary>
        /// Значение алгебраического выражения.
        /// </summary>
        public override decimal Value
        {
            get
            {
                decimal right = this.RightExpression.Value;
                if (right != 0)
                { return (decimal)Math.Pow((double)this.LeftExpression.Value, (double)(1 / this.RightExpression.Value)); }
                else { return 0; }
            }
        }
        /// <summary>
        /// Признак содержания ошибки в выражении.
        /// </summary>
        public override bool IsError
        {
            get { return (RightExpression.Value == 0) || LeftExpression.IsError || RightExpression.IsError; }
        }
        /// <summary>
        /// Строковое представление алгебраического выражения.
        /// </summary>
        public override string Formula()
        {
            if (RightExpression.Value == 0 && !RightExpression.IsError)
            {
                return this.LeftExpression.Formula() + " " + ArithmeticExpression.SymbolSqrt + " " + ArithmeticExpression.SymbolStartError + this.RightExpression.Formula() + ArithmeticExpression.SymbolEndError;
            }
            else
            {
                return this.LeftExpression.Formula() + " " + ArithmeticExpression.SymbolSqrt + " " + this.RightExpression.Formula();
            }
        }

        /// <summary>
        /// Короткое строковое представление выражения.
        /// </summary>
        /// <param name="format">Формат отображения результата алгебраического выражения.</param>
        public override string ToString(string format)
        {
            if (IsFormat(format: format))
            {
                return GetLeftFormula(format: format) + @" " + ArithmeticExpression.SymbolSqrt + @" " + GetRightFormula(format: format);
            }
            else
            {
                return GetLeftFormula() + @" " + ArithmeticExpression.SymbolSqrt + @" " + GetRightFormula();
            }
        }

        public static SqrtExpression Create(ref Dictionary<string, ICell> cells, UnitCollection left, UnitCollection right)
        {
            return new SqrtExpression(ref cells, left, right);
        }
    }
}
