using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ExcelAnalyzer.Expressions
{
    /// <summary>
    /// Алгебраическое выражение.
    /// </summary>
    public class ArithmeticExpression: ArithmeticExpressions.ExpressionBase
    {
        #region РЕГУЛЯРНЫЕ ВЫРАЖЕНИЯ

        /// <summary>
        /// Цифры.
        /// </summary>
        internal const string csDecimal = @"((\d{1,}[.]\d{1,})|(\d{1,}[,]\d{1,})|(\d{1,}))";
        /// <summary>
        /// Возведение в степень [pow],[^].
        /// </summary>
        internal const string csPower = @"((\x5e)|(pow))"; // "pow" / "^"
        /// <summary>
        /// Корень [sqrt].
        /// </summary>
        internal const string csSqrt = @"sqrt"; // "sqrt"
        /// <summary>
        /// Умножение [*].
        /// </summary>
        internal const string csMultiplication = @"\x2a"; // "*"
        /// <summary>
        /// Деление [/].
        /// </summary>
        internal const string csDivision = @"\x2f"; // "/"
        /// <summary>
        /// Целочисленное деление [fix],[\].
        /// </summary>
        internal const string csFix = @"((\x5c)|(fix))";// "fix" / "\"
        /// <summary>
        /// Остаток от деления [mod],[%].
        /// </summary>
        internal const string csMod = @"((\x25)|(mod))"; // "mod" / "%"
        /// <summary>
        /// Сложение [+].
        /// </summary>
        internal const string csAddition = @"\x2b"; // "+"
        /// <summary>
        /// Вычитание [-].
        /// </summary>
        internal const string csSubtracting = @"\x2d"; // "-"
        /// <summary>
        /// Открывающаяся скобка [(].
        /// </summary>
        internal const string csOpen = @"\x28"; // "("
        /// <summary>
        /// Закрывающаяся скобка [)].
        /// </summary>
        internal const string csClose = @"\x29"; // ")"

        /// <summary>
        /// Коллекция арифметических знаков.
        /// </summary>
        internal const string csArithmetic = csDecimal + @"|" + csAddition + @"|" + csDivision + @"|" + csFix + @"|" + csMod + @"|" + csMultiplication + @"|" + csPower + @"|" + csSqrt + @"|" + csSubtracting;

        internal const RegexOptions options = RegexOptions.IgnoreCase | RegexOptions.Compiled;

        /// <summary>
        /// Регулярное выражение для поиска всех компонентов, включая ячейки.
        /// </summary>
        internal static Regex regexAll;
        /// <summary>
        /// Регулярное выражение для поиска ячеек.
        /// </summary>
        internal static Regex regexCell;
        /// <summary>
        /// Регулярное выражение для поиска цифр.
        /// </summary>
        internal static Regex regexDecimal = new Regex(csDecimal, options);
        /// <summary>
        /// Регулярное выражение для поиска знака pow (возведение в степень).
        /// </summary>
        internal static Regex regexPower = new Regex(csPower, options); // "pow" / "^"
        /// <summary>
        /// Регулярное выражение для поиска знака sqrt (корень).
        /// </summary>
        internal static Regex regexSqrt = new Regex(csSqrt, options); // "sqrt"
        /// <summary>
        /// Регулярное выражение для поиска знака умножения [*].
        /// </summary>
        internal static Regex regexMultiplication = new Regex(csMultiplication, options); // "*"
        /// <summary>
        /// Регулярное выражение для поиска знака деления [/].
        /// </summary>
        internal static Regex regexDivision = new Regex(csDivision, options); // "/"
        /// <summary>
        /// Регулярное выражение для поиска знака fix (целое от деления).
        /// </summary>
        internal static Regex regexFix = new Regex(csFix, options);// "fix" / "\"
        /// <summary>
        /// Регулярное выражение для поиска знака mod (остаток от деления).
        /// </summary>
        internal static Regex regexMod = new Regex(csMod, options); // "mod" / "%"
        /// <summary>
        /// Регулярное выражение для поиска знака сложения [+].
        /// </summary>
        internal static Regex regexAddition = new Regex(csAddition, options); // "+"
        /// <summary>
        /// Регулярное выражение для поиска знака вычитания [-].
        /// </summary>
        internal static Regex regexSubtracting = new Regex(csSubtracting, options); // "-"
        /// <summary>
        /// Регулярное выражение для поиска знака открывающейся скобки [(].
        /// </summary>
        internal static Regex regexOpen = new Regex(csOpen, options); // "("
        /// <summary>
        /// Регулярное выражение для поиска знака закрывающейся скобки [)].
        /// </summary>
        internal static Regex regexClose = new Regex(csClose, options); // ")"
        #endregion

        private ArithmeticExpressions.ExpressionBase _expression;
        private Dictionary<string, ArithmeticExpressions.ICell> _collection;

        /// <summary>
        /// Значение алгебраического выражения.
        /// </summary>
        public override decimal Value
        {
            get { return this._expression.Value; }
        }

        /// <summary>
        /// Признак содержания ошибки в выражении.
        /// </summary>
        public override bool IsError
        {
            get { return this._expression.IsError; }
        }

        /// <summary>
        /// Строковое представление алгебраического выражения.
        /// </summary>
        public override string Formula()
        {
            return this._expression.Formula();
        }

        private ArithmeticExpression(ref Dictionary<string, ArithmeticExpressions.ICell> cells, UnitCollection array)
        {
            this._collection = cells;
            this._expression = ArithmeticExpressions.Expression.Create(ref this._collection, array);
        }

        private ArithmeticExpression(UnitCollection array)
        {
            this._collection = new Dictionary<string, ArithmeticExpressions.ICell>();
            this._expression = ArithmeticExpressions.Expression.Create(ref this._collection, array);
        }

        public static ArithmeticExpression Create(string text)
        {
            string context = text.Replace(" ", "");
            regexAll = new Regex(@"(" + csArithmetic + @"|" + csOpen + @"|" + csClose + @")", options);
            UnitCollection collection = UnitCollection.Create(regexAll.Matches(text));
            return new ArithmeticExpression(collection);
        }

        public static ArithmeticExpression Create(string text, string cellpattern)
        {
            string context = text.Replace(" ", "");
            regexAll = new Regex(@"((" + cellpattern + @")|" + csArithmetic + @"|" + csOpen + @"|" + csClose + @")", options);
            regexCell = new Regex(@"(" + cellpattern + @")", options);
            UnitCollection collection = UnitCollection.Create(regexAll.Matches(text));
            return new ArithmeticExpression(collection);
        }
    }
}
