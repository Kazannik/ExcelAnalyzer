using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ExcelAnalyzer.Expressions
{
    public class BooleanExpression : ExpressionBase
    {
        private ExpressionBase _expression;
        private Dictionary<string, ArithmeticExpressions.ICell> _collection;

        #region РЕГУЛЯРНЫЕ ВЫРАЖЕНИЯ

        /// <summary>
        /// Равно [=].
        /// </summary>
        private const string csEqual = @"\x3d"; // "="
        /// <summary>
        /// Не равно [&lt;>],[!=].
        /// </summary>
        private const string csNotEqual = @"((\x3c\x3e)|(\x21\x3d))"; // "<>" / "!=" 
        /// <summary>
        /// Логическое отрицание (NOT).
        /// </summary>
        private const string csNot = @"((\x21)|(not))"; // "not" / "!"
        /// <summary>
        /// Логическое сложение (AND).
        /// </summary>
        private const string csAnd = @"((\x26)|(and))"; // "and" / "&"
        /// <summary>
        /// Логическое ИЛИ (OR).
        /// </summary>
        private const string csOr = @"((\x7c)|(or))"; // "or" / "|"
        /// <summary>
        /// Исключающее ИЛИ (XOR).
        /// </summary>
        private const string csXor = @"xor"; // "xor"

        /// <summary>
        /// Коллекция логических знаков.
        /// </summary>
        private const string csLogic = csAnd + @"|" + csEqual + @"|" + csNot + @"|" + csNotEqual + @"|" + csOr + @"|" + csXor;

        /// <summary>
        /// Регулярное выражение для поиска всех компонентов, включая ячейки.
        /// </summary>
        private static Regex regexAll;

        /// <summary>
        /// Регулярное выражение для поиска знака равно [=].
        /// </summary>
        internal static Regex regexEqual = new Regex(csEqual, ArithmeticExpression.options); // "="
        /// <summary>
        /// Регулярное выражение для поиска знака не равно [&lt;>].
        /// </summary>
        internal static Regex regexNotEqual = new Regex(csNotEqual, ArithmeticExpression.options); // "<>" / "!="
        /// <summary>
        /// Регулярное выражение для поиска знака логического отрицания [NOT].
        /// </summary>
        internal static Regex regexNot = new Regex(csNot, ArithmeticExpression.options); // "not"
        /// <summary>
        /// Регулярное выражение для поиска знака логического сложения [AND].
        /// </summary>
        internal static Regex regexAnd = new Regex(csAnd, ArithmeticExpression.options); // "and"
        /// <summary>
        /// Регулярное выражение для поиска знака логического или [OR].
        /// </summary>
        internal static Regex regexOr = new Regex(csOr, ArithmeticExpression.options); // "or"
        /// <summary>
        /// Регулярное выражение для поиска знака исключающего или [XOR].
        /// </summary>
        internal static Regex regexXor = new Regex(csXor, ArithmeticExpression.options); // "xor"

        #endregion

        /// <summary>
        /// Значение логического выражения.
        /// </summary>
        public override bool Value
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
        /// Строковое представление логического выражения.
        /// </summary>
        public override string Formula()
        {
            return this._expression.Formula();
        }

        private BooleanExpression(ref Dictionary<string, ArithmeticExpressions.ICell> cells, UnitCollection array)
        {
            this._collection = cells;
            this._expression = ExpressionBase.Create(ref this._collection, array);
        }

        private BooleanExpression(UnitCollection array)
        {
            this._collection = new Dictionary<string, ArithmeticExpressions.ICell>();
            this._expression = LogicExpressions.Expression.Create(ref this._collection, array);
        }

        public static LogicExpression Create(string text)
        {
            string context = text.Replace(" ", "");
            regexAll = new Regex(@"(" + csLogic + ArithmeticExpression.csArithmetic + @"|" + ArithmeticExpression.csOpen + @"|" + ArithmeticExpression.csClose + @")", ArithmeticExpression.options);
            UnitCollection collection = UnitCollection.Create(ArithmeticExpression.regexAll.Matches(text));

            return new ArithmeticExpression(collection);
        }

        public static LogicExpression Create(string text, string cellpattern)
        {
            string context = text.Replace(" ", "");
            regexAll = new Regex(@"((" + cellpattern + @")|" + csLogic + ArithmeticExpression.csArithmetic + @"|" + ArithmeticExpression.csOpen + @"|" + ArithmeticExpression.csClose + @")", ArithmeticExpression.options);
            ArithmeticExpression.regexCell = new Regex(@"(" + cellpattern + @")", ArithmeticExpression.options);
            UnitCollection collection = UnitCollection.Create(regexAll.Matches(text));

            return new ArithmeticExpression(collection);
        }
    }
}
