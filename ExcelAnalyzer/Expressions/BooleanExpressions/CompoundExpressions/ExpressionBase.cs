using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ExcelAnalyzer.Expressions.BooleanExpressions.CompoundExpressions
{
    /// <summary>
    /// Составное логическое выражение.
    /// </summary>
    abstract class ExpressionBase : Expressions.ExpressionBase
    {
        protected Expressions.ExpressionBase _leftExpression;
        protected Expressions.ExpressionBase _rightExpression;


        protected ExpressionBase(ref Dictionary<string, ArithmeticExpressions.ICell> cells, Expressions.ExpressionBase left, Expressions.ExpressionBase right)
        {
            this._leftExpression = BooleanExpressions.LogicExpressionBase.Create(ref cells, left);
            this._rightExpression = Expressions.ExpressionBase.Create(ref cells, right);
        }

        /// <summary>
        /// Признак содержания ошибки в выражении.
        /// </summary>
        public override bool IsError
        {
            get { return this._leftExpression.IsError || this._rightExpression.IsError; }
        }

        //public static LogicCompoundExpression Create(Expression left, Expression right)
        //{ 
        //   return new LogicCompoundExpression(left, right);
        //}

        //public static LogicCompoundExpression Create(string left, string right)
        //{
        //    return new LogicCompoundExpression(Expression.Create(left), Expression.Create(right));  
        //}

        public static ExpressionBase Create(string text, string cellpattern)
        {
            string context = text.Replace(" ", "");
            regexAll = new Regex(@"((" + cellpattern + @")|" + csArithmetic + @"|" + csOpen + @"|" + csClose + @")", options);
            regexCell = new Regex(@"(" + cellpattern + @")", options);
            UnitCollection collection = UnitCollection.Create(regexAll.Matches(text));
            return new Expression(collection);

            return new LogicArithmeticExpression(Expression.Create(text, cellpattern));
        }
    }
}
