﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcelAnalyzer.Expressions.BooleanExpressions.CompoundExpressions
{
    /// <summary>
    /// Исключающее ИЛИ (XOR).
    /// </summary>
    class XorExpression : CompoundExpression
    {
        private XorExpression(ref Dictionary<string, ArithmeticExpressions.ICell> cells, UnitCollection left, UnitCollection right) : base(ref cells, left, right) { }

        /// <summary>
        /// Положительное значение логического выражения.
        /// </summary>
        public override bool Value
        {
            get
            {
                if (this.LeftExpression.Value || this.RightExpression.Value)
                { return true; }
                else if (this.LeftExpression.Value == this.RightExpression.Value)
                { return false; }
                else { return true; }
            }
        }

        /// <summary>
        /// Строковое представление логического выражения.
        /// </summary>
        public override string Formula()
        {
            return this.LeftExpression.Formula() + @" " + BooleanExpression.SymbolXor + @" " + this.RightExpression.Formula();
        }

        /// <summary>
        /// Короткое строковое представление логического выражения.
        /// </summary>
        /// <param name="format">Формат отображения результата алгебраического выражения.</param>
        public override string ToString(string format)
        {
            if (IsFormat(format: format))
            {
                return GetLeftFormula(format: format) + @" " + BooleanExpression.SymbolXor + @" " + GetRightFormula(format: format);
            }
            else
            {
                return GetLeftFormula() + @" " + BooleanExpression.SymbolXor + @" " + GetRightFormula();
            }
        }

        public static XorExpression Create(ref Dictionary<string, ArithmeticExpressions.ICell> cells, UnitCollection left, UnitCollection right)
        {
            return new XorExpression(ref cells, left, right);
        }
    }
}