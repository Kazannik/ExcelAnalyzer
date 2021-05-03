using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ExcelAnalyzer.Expressions.LogicExpressions
{
    /// <summary>
    /// Базовое логическое выражение, объединяющее два алгебраических выражения.
    /// </summary>
    public abstract class Expression : ExpressionBase
    {
        protected ArithmeticExpressions.ExpressionBase _leftExpression;
        protected ArithmeticExpressions.ExpressionBase _rightExpression;

        private Expression(ArithmeticExpressions.ExpressionBase left, ArithmeticExpressions.ExpressionBase right)
        {
            this._leftExpression = left;
            this._rightExpression = right;
        }

        public abstract bool Value { get; }

        /// <summary>
        /// Признак содержания ошибки в выражении.
        /// </summary>
        public override bool IsError
        {
            get { return this._leftExpression.IsError || this._rightExpression.IsError; }
        }

        //public static LogicArithmeticExpression Create(Expression left, Expression right)
        //{ 
        //   return new LogicArithmeticExpression(left, right);
        //}

        //public static LogicArithmeticExpression Create(string left, string right)
        //{
        //    return new LogicArithmeticExpression(Expression.Create(left), Expression.Create(right));  
        //}

        public static Expression Create(string text, string cellpattern)
        {
            string context = text.Replace(" ", "");
            regexAll = new Regex(@"((" + cellpattern + @")|" + ArithmeticcsArithmetic + @"|" + csOpen + @"|" + csClose + @")", options);
            regexCell = new Regex(@"(" + cellpattern + @")", options);
            UnitCollection collection = UnitCollection.Create(regexAll.Matches(text));
            return new Expression(collection);



            return new ExpressionBase(Expression.Create(text, cellpattern));
        }

        /// <summary>
        /// Определение вида алгебраического действия.
        /// </summary>
        /// <param name="value">Строковое значение.</param>
        protected static MixType GetMixType(string value)
        {
            if (LogicExpression.regexEqual.IsMatch(value))
            { return MixType.Equal; }
            else if (LogicExpression.regexLess.IsMatch(value))
            { return MixType.Equal; }
            else if (LogicExpression.regexLessOrEqual.IsMatch(value))
            { return MixType.Less; }
            else if (LogicExpression.regexMore.IsMatch(value))
            { return MixType.LessOrEqual; }
            else if (LogicExpression.regexMoreOrEqual.IsMatch(value))
            { return MixType.More; }
            else if (LogicExpression.regexNotEqual.IsMatch(value))
            { return MixType.MoreOrEqual; }
            else { return MixType.Default; }
        }

        /// <summary>
        /// Вид алгебраического действия.
        /// </summary>
        public enum MixType : int
        {
            /// <summary>
            /// Действие не определено.
            /// </summary>
            Default = -1,
            /// <summary>
            /// Равно [=].
            /// </summary>
            Equal = 1,
            /// <summary>
            /// Не равно [&lt;>].
            /// </summary>
            NotEqual = 2,
            /// <summary>
            /// Меньше [&lt;].
            /// </summary>
            Less = 3,
            /// <summary>
            /// Больше [>].
            /// </summary>
            More = 4,
            /// <summary>
            /// Меньше или равно [&lt;=].
            /// </summary>
            LessOrEqual = 5,
            /// <summary>
            /// Больше или равно [>=].
            /// </summary>
            MoreOrEqual = 6,
            /// <summary>
            /// Логическое отрицание [not].
            /// </summary>
            Not = 7,
            /// <summary>
            /// Логическое сложение [and].
            /// </summary>
            And = 8,
            /// <summary>
            /// Логическое ИЛИ [or].
            /// </summary>
            Or = 9,
            /// <summary>
            /// Исключающее ИЛИ [xor].
            /// </summary>
            Xor = 10
        }
    }
}
