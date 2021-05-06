﻿using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace ExcelAnalyzer.Expressions
{
    /// <summary>
    /// Логическое выражение.
    /// </summary>
    public class LogicExpression : LogicExpressions.ExpressionBase
    {
        private LogicExpressions.ExpressionBase _expression;
        private Dictionary<string, ArithmeticExpressions.ICell> _collection;

        #region РЕГУЛЯРНЫЕ ВЫРАЖЕНИЯ
                
        /// <summary>
        /// Равно [=].
        /// </summary>
        internal const string csEqual = @"\x3d"; // "="
        /// <summary>
        /// Не равно [&lt;>],[!=].
        /// </summary>
        internal const string csNotEqual = @"((\x3c\x3e)|(\x21\x3d))"; // "<>" / "!="
        /// <summary>
        /// Меньше [&lt;].
        /// </summary>
        internal const string csLess = @"\x3c"; // "<"
        /// <summary>
        /// Больше (>).
        /// </summary>
        internal const string csMore = @"\x3e"; // ">"
        /// <summary>
        /// Меньше или равно(&lt;=).
        /// </summary>
        internal const string csLessOrEqual = @"\x3c\x3d"; // "<="
        /// <summary>
        /// Больше или равно (>=).
        /// </summary>
        internal const string csMoreOrEqual = @"\x3e\x3d"; // ">="

        /// <summary>
        /// Коллекция логических знаков.
        /// </summary>
        internal const string csLogic = csLessOrEqual + @"|" + csMoreOrEqual + @"|" + csNotEqual + @"|" + csEqual + @"|" + csLess  + @"|" + csMore ;

        /// <summary>
        /// Регулярное выражение для поиска всех компонентов, включая ячейки.
        /// </summary>
        internal static Regex regexAll;
         
        /// <summary>
        /// Регулярное выражение для поиска знака равно [=].
        /// </summary>
        internal static Regex regexEqual = new Regex(csEqual, ArithmeticExpression.options); // "="
        /// <summary>
        /// Регулярное выражение для поиска знака не равно [&lt;>].
        /// </summary>
        internal static Regex regexNotEqual = new Regex(csNotEqual, ArithmeticExpression.options); // "<>" / "!="
        /// <summary>
        /// Регулярное выражение для поиска знака меньше [&lt;].
        /// </summary>
        internal static Regex regexLess = new Regex(csLess, ArithmeticExpression.options); // "<"
        /// <summary>
        /// Регулярное выражение для поиска знака больше [>].
        /// </summary>
        internal static Regex regexMore = new Regex(csMore, ArithmeticExpression.options); // ">"
        /// <summary>
        /// Регулярное выражение для поиска знака меньше или равно [&lt;=].
        /// </summary>
        internal static Regex regexLessOrEqual = new Regex(csLessOrEqual, ArithmeticExpression.options); // "<="
        /// <summary>
        /// Регулярное выражение для поиска знака больше или равно [>=].
        /// </summary>
        internal static Regex regexMoreOrEqual = new Regex(csMoreOrEqual, ArithmeticExpression.options); // ">="

        #endregion

        /// <summary>
        /// Начало сообщение об ошибке "[Error:".
        /// </summary>
        public static string SymbolStartError { get; set; }
        /// <summary>
        /// Окончание сообщения об ошибке "]".
        /// </summary>
        public static string SymbolEndError { get; set; }
        /// <summary>
        /// Равно.
        /// </summary>
        public static string SymbolEqual { get; set; }
        /// <summary>
        /// Не равно.
        /// </summary>
        public static string SymbolNotEqual { get; set; }
        /// <summary>
        /// Меньше.
        /// </summary>
        public static string SymbolLess { get; set; }
        /// <summary>
        /// Больше.
        /// </summary>
        public static string SymbolMore { get; set; }
        /// <summary>
        /// Меньше или равно.
        /// </summary>
        public static string SymbolLessOrEqual { get; set; }
        /// <summary>
        /// Больше или равно.
        /// </summary>
        public static string SymbolMoreOrEqual { get; set; }

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

        /// <summary>
        /// Короткое строковое представление логического выражения.
        /// </summary>
        /// <param name="format">Формат отображения результата алгебраического выражения.</param>
        public override string ToString(string format)
        {
            return this._expression.ToString(format: format);
        }

        public bool Contains(string key)
        {
            return this._collection.ContainsKey(key);
        }

        public string[] Keys
        {
            get { return this._collection.Keys.ToArray(); }
        }

        public ArithmeticExpressions.ICell this[string key]
        {
            get { return this._collection[key]; }
        }

        public int Count
        {
            get { return this._collection.Count; }
        }

        private LogicExpression(ref Dictionary<string, ArithmeticExpressions.ICell> cells, UnitCollection array)
        {
            InitializeSymbols();
            this._collection = cells;
            this._expression = LogicExpressions.Expression.Create(ref this._collection, array);
        }

        private LogicExpression(UnitCollection array)
        {
            InitializeSymbols();
            this._collection = new Dictionary<string, ArithmeticExpressions.ICell>();
            this._expression = LogicExpressions.Expression.Create(ref this._collection, array);
        }

        internal static void InitializeSymbols()
        {
            ArithmeticExpression.InitializeSymbols();

            SymbolStartError = ArithmeticExpression.SymbolStartError;
            SymbolEndError = ArithmeticExpression.SymbolEndError;

            SymbolEqual = @"=";
            SymbolNotEqual = @"<>";
            SymbolLess = @"<";
            SymbolMore = @">";
            SymbolLessOrEqual = "<=";
            SymbolMoreOrEqual = @">=";
        }

        public static LogicExpression Create(string text)
        {
            string context = text.Replace(" ", "");
            regexAll = new Regex(csLogic + @"|" + ArithmeticExpression.csArithmetic + @"|" +  ArithmeticExpression.csOpen + @"|" + ArithmeticExpression.csClose, ArithmeticExpression.options);
            UnitCollection collection = UnitCollection.Create(ArithmeticExpression.regexAll.Matches(text));
            return new LogicExpression(collection);
        }

        public static LogicExpression Create(string text, string cellpattern)
        {
            string context = text.Replace(" ", "");
            regexAll = new Regex(@"(" + cellpattern + @")|" + csLogic + @"|" + ArithmeticExpression.csArithmetic + @"|"  + ArithmeticExpression.csOpen + @"|" + ArithmeticExpression.csClose, ArithmeticExpression.options);
            ArithmeticExpression.regexCell = new Regex(@"(" + cellpattern + @")", ArithmeticExpression.options);
            UnitCollection collection = UnitCollection.Create(regexAll.Matches(text));
            return new LogicExpression(collection);
        }
    }
}
