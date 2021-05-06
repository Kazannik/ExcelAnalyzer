using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace ExcelAnalyzer.Expressions.ArithmeticExpressions
{
    /// <summary>
    /// Ячейка, используемая при расчете.
    /// </summary>
    class CellExpression : ExpressionBase, ICell
    {
        string _format;
        string _formulaformat;
        decimal _value;

        List<CellRegex> cellFormat;

        CellExpression(string key, string formula) : this(key: key, formula: formula, value: 0, format: string.Empty) { }
        CellExpression(string key) : this(key: key, formula: "[{key}:{value}]", value: 0, format: string.Empty) { }
        CellExpression(string key, string formula, decimal value, string format)
        {
            this.cellFormat= new List<CellRegex>();
            this.Key = key;
            this.IsError = false;

            this._value = value;
            this.Format = format;
            this.FormulaFormat = formula;
        }

        delegate string GetArgDelegate();
        string GetKey()
        {
            return this.Key;
        }
        string GetValue()
        {
            return GetStringValue.Invoke(this.Value);
        }
        
        delegate string GetValueDelegate(decimal value);
        GetValueDelegate GetStringValue;
        string ClearFormat(decimal value)
        {
            return value.ToString();
        }
        string DecimalFormat(decimal value)
        {
            return value.ToString(this.Format);
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
        /// Формат отображения формулы числа.
        /// </summary>
        public string Format {
            get { return this._format; }
            set
            {
                this._format = value;
                if (this._format == null || this._format.Equals(string.Empty) || this._format.Trim().Length == 0)
                { this.GetStringValue = this.ClearFormat; }
                else { this.GetStringValue = this.DecimalFormat; }                
            }
        }
        /// <summary>
        /// Формат отображения формулы ячейки.
        /// </summary>
        public string FormulaFormat
        {
            get { return this._formulaformat; }
            set
            {
                this._formulaformat = value;
                this.cellFormat.Clear();
                cellFormat.Add(new CellRegex(ArithmeticExpression.regexCellKey.Match(this._formulaformat), GetKey));
                cellFormat.Add(new CellRegex(ArithmeticExpression.regexCellValue.Match(this._formulaformat), GetValue));
                cellFormat.Sort(delegate (CellRegex x, CellRegex y)
                {
                    return x.Match.Index.CompareTo(y.Match.Index);
                });
            }
        }

        /// <summary>
        /// Строковое представление алгебраического выражения.
        /// </summary>
        public override string Formula()
        {
            if (cellFormat.Count == 0)
                return this._formulaformat;
            else
            {
                string result=string.Empty;
                int LastLength = 0;
                for (int i = 0; i < cellFormat.Count; i++)
                {
                    result += this._formulaformat.Substring(LastLength, cellFormat[i].Match.Index - LastLength) + cellFormat[i].Value.Invoke();
                    LastLength = cellFormat[i].Match.Index + cellFormat[i].Match.Length;
                }
                result += this._formulaformat.Substring(LastLength);
                return result;
            }            
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

        struct CellRegex
        {
            public CellRegex(Match match, GetArgDelegate fun)
            {
                _match = match;
                _value = fun;
            }
            GetArgDelegate _value;
            Match _match;
            public GetArgDelegate Value { get { return _value; } }
            public Match Match { get { return _match; } }
        }
    }
}
