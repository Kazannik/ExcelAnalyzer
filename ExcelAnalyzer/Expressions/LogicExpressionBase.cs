using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcelAnalyzer.Expressions
{
    /// <summary>
    /// Базовый элемент любого логического выражения.
    /// </summary>
    public abstract class LogicExpressionBase : ExpressionBase
    {
        public abstract bool Value { get; }
 
    }
}
