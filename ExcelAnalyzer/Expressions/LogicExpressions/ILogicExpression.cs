using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcelAnalyzer.Expressions.LogicExpressions
{
    interface ILogicExpression
    {
        /// <summary>
        /// Признак содержания ошибки в выражении.
        /// </summary>
        bool IsError { get; }
        /// <summary>
        /// Строковое представление выражения.
        /// </summary>
        string Formula();
        /// <summary>
        /// Значение логического выражения.
        /// </summary>
        bool Value { get; }
        /// <summary>
        /// Короткое строковое представление логического выражения.
        /// </summary>
        /// <param name="format">Формат отображения результата алгебраического выражения.</param>
        string ToString(string format);
        /// <summary>
        /// Короткое строковое представление логического выражения.
        /// </summary>
        string ToString();
    }
}
