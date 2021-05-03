using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace ExcelAnalyzer.Expressions
{
    /// <summary>
    /// Коллекция элементов алгебраического действия.
    /// </summary>
    class UnitCollection : IEnumerable<UnitCollection.BaseUnit>
    {
        List<BaseUnit> List;

        public UnitCollection()
        {
            this.List = new List<BaseUnit>();
        }

        public static UnitCollection Create(BaseUnit unit)
        {
            UnitCollection result = new UnitCollection();
            result.List.Add(BaseUnit.Create(result, unit));
            return result;
        }

        public static UnitCollection Create(UnitCollection array)
        {
            UnitCollection result = new UnitCollection();
            foreach (BaseUnit u in array)
            {
                result.List.Add(BaseUnit.Create(result, u));
            }
            return result;
        }

        public static UnitCollection Create(UnitCollection array, int start)
        {
            return Create(array, start, array.List.Count - start);
        }

        public static UnitCollection Create(UnitCollection array, int start, int lenght)
        {
            UnitCollection result = new UnitCollection();
            for (int i = 0; i < lenght; i++)
            {
                result.List.Add(BaseUnit.Create(result, array.List[start + i]));
            }
            return result;
        }

        public static UnitCollection Create(MatchCollection array)
        {
            UnitCollection result = new UnitCollection();
            foreach (Match m in array)
            {
                result.List.Add(BaseUnit.Create(result, m));
            }
            return result;
        }

        public BaseUnit First
        {
            get { return this.List[0]; }
        }

        public BaseUnit Last
        {
            get { return this.List[this.List.Count - 1]; }
        }

        public BaseUnit this[int index]
        {
            get { return this.List[index]; }
        }

        /// <summary>
        /// Выражение целиком заключено в скобки (X+Y).
        /// </summary>
        public bool IsAssociation
        {
            get { return OpenIndex() == 0; }
        }

        /// <summary>
        /// Орицательное выражение заключенное в скобки -(X+Y)
        /// </summary>
        public bool IsNegativeAssociation
        {
            get { return OpenIndex() == 1 && First.UnitType == MatchType.Subtracting; }
        }

        /// <summary>
        /// Положительное выражение заключенное в скобки +(X+Y)
        /// </summary>
        public bool IsPositiveAssociation
        {
            get { return OpenIndex() == 1 && First.UnitType == MatchType.Addition; }
        }

        public int Count
        {
            get { return this.List.Count; }
        }

        private int OpenIndex()
        {
            if (this.Last.UnitType == MatchType.Close)
            {
                int A = 0;
                for (int i = this.List.Count - 1; i >= 0; i--)
                {
                    if (this.List[i].UnitType == MatchType.Close) { A--; }
                    if (this.List[i].UnitType == MatchType.Open) { A++; }
                    if (A == 0) { return i; }
                }
                return -1;
            }
            else { return -1; }
        }

        public int GetLastIndex()
        {
            for (int i = 0; i <= 16; i++)
            {
                int F = GetLastIndex(i);
                if (F >= 0) { return F; }
            }
            return -1;
        }

        public int GetLastIndex(int action)
        {
            int A = 0;
            for (int i = this.Count - 1; i >= 0; i--)
            {
                if (this.List[i].UnitType == MatchType.Close) { A--; }
                if (this.List[i].UnitType == MatchType.Open) { A++; }
                if (A == 0 && this.List[i].Action == action)
                {
                    return i;
                }
            }
            return -1;
        }

        IEnumerator<BaseUnit> IEnumerable<UnitCollection.BaseUnit>.GetEnumerator()
        {
            return this.List.GetEnumerator();
        }

        public IEnumerator GetEnumerator()
        {
            return this.List.GetEnumerator();
        }

        /// <summary>
        /// Базовый элемент алгебраического действия.
        /// </summary>
        public abstract class BaseUnit
        {
            private UnitCollection parent;

            /// <summary>
            /// Тип элемента.
            /// </summary>
            public abstract MatchType UnitType { get; }
            /// <summary>
            /// Приоритет математического действия.
            /// </summary>
            public abstract int Action { get; }

            /// <summary>
            /// Строковое значение элемента.
            /// </summary>
            public string Value { get; }

            /// <summary>
            /// Индекс элемента в родительской коллекции.
            /// </summary>
            public int Index
            {
                get { return this.parent.List.IndexOf(this); }
            }

            protected BaseUnit(UnitCollection parent, string value)
            {
                this.parent = parent;
                this.Value = value;
            }

            public static BaseUnit Create(UnitCollection parent, BaseUnit unit)
            {
                BaseUnit result;
                switch (unit.UnitType)
                {
                    case MatchType.Addition:
                        result = new AdditionUnit(parent: parent, value: unit.Value);
                        break;
                    case MatchType.And:
                        result = new AndUnit(parent: parent, value: unit.Value);
                        break;
                    case MatchType.Cell:
                        result = new CellUnit(parent: parent, value: unit.Value);
                        break;
                    case MatchType.Close:
                        result = new CloseUnit(parent: parent, value: unit.Value);
                        break;
                    case MatchType.Decimal:
                        result = new DecimalUnit(parent: parent, value: unit.Value);
                        break;
                    case MatchType.Division:
                        result = new DivisionUnit(parent: parent, value: unit.Value);
                        break;
                    case MatchType.Equal:
                        result = new EqualUnit(parent: parent, value: unit.Value);
                        break;
                    case MatchType.Fix:
                        result = new FixUnit(parent: parent, value: unit.Value);
                        break;
                    case MatchType.Less:
                        result = new LessUnit(parent: parent, value: unit.Value);
                        break;
                    case MatchType.LessOrEqual:
                        result = new LessOrEqualUnit(parent: parent, value: unit.Value);
                        break;
                    case MatchType.Mod:
                        result = new ModUnit(parent: parent, value: unit.Value);
                        break;
                    case MatchType.More:
                        result = new MoreUnit(parent: parent, value: unit.Value);
                        break;
                    case MatchType.MoreOrEqual:
                        result = new MoreOrEqualUnit(parent: parent, value: unit.Value);
                        break;
                    case MatchType.Multiplication:
                        result = new MultiplicationUnit(parent: parent, value: unit.Value);
                        break;
                    case MatchType.Negative:
                        result = new NegativeUnit(parent: parent, value: unit.Value);
                        break;
                    case MatchType.Not:
                        result = new NotUnit(parent: parent, value: unit.Value);
                        break;
                    case MatchType.NotEqual:
                        result = new NotEqualUnit(parent: parent, value: unit.Value);
                        break;
                    case MatchType.Open:
                        result = new OpenUnit(parent: parent, value: unit.Value);
                        break;
                    case MatchType.Or:
                        result = new OrUnit(parent: parent, value: unit.Value);
                        break;
                    case MatchType.Power:
                        result = new PowerUnit(parent: parent, value: unit.Value);
                        break;
                    case MatchType.Sqrt:
                        result = new SqrtUnit(parent: parent, value: unit.Value);
                        break;
                    case MatchType.Subtracting:
                        result = new SubtractingUnit(parent: parent, value: unit.Value);
                        break;
                    case MatchType.Xor:
                        result = new XorUnit(parent: parent, value: unit.Value);
                        break;
                    default:
                        result = new DecimalUnit(parent: parent, value: unit.Value);
                        break;
                }
                return result;
            }

            public static BaseUnit Create(UnitCollection parent, Match match)
            {
                MatchType t = GetMatchType(match);
                BaseUnit result;
                switch (t)
                {
                    case MatchType.Addition:
                        result = new AdditionUnit(parent: parent, value: match.Value);
                        break;
                    case MatchType.And:
                        result = new AndUnit(parent: parent, value: match.Value);
                        break;
                    case MatchType.Cell:
                        result = new CellUnit(parent: parent, value: match.Value);
                        break;
                    case MatchType.Close:
                        result = new CloseUnit(parent: parent, value: match.Value);
                        break;
                    case MatchType.Decimal:
                        result = new DecimalUnit(parent: parent, value: match.Value);
                        break;
                    case MatchType.Division:
                        result = new DivisionUnit(parent: parent, value: match.Value);
                        break;
                    case MatchType.Equal:
                        result = new EqualUnit(parent: parent, value: match.Value);
                        break;
                    case MatchType.Fix:
                        result = new FixUnit(parent: parent, value: match.Value);
                        break;
                    case MatchType.Less:
                        result = new LessUnit(parent: parent, value: match.Value);
                        break;
                    case MatchType.LessOrEqual:
                        result = new LessOrEqualUnit(parent: parent, value: match.Value);
                        break;
                    case MatchType.Mod:
                        result = new ModUnit(parent: parent, value: match.Value);
                        break;
                    case MatchType.More:
                        result = new MoreUnit(parent: parent, value: match.Value);
                        break;
                    case MatchType.MoreOrEqual:
                        result = new MoreOrEqualUnit(parent: parent, value: match.Value);
                        break;
                    case MatchType.Multiplication:
                        result = new MultiplicationUnit(parent: parent, value: match.Value);
                        break;
                    case MatchType.Negative:
                        result = new NegativeUnit(parent: parent, value: match.Value);
                        break;
                    case MatchType.Not:
                        result = new NotUnit(parent: parent, value: match.Value);
                        break;
                    case MatchType.NotEqual:
                        result = new NotEqualUnit(parent: parent, value: match.Value);
                        break;
                    case MatchType.Open:
                        result = new OpenUnit(parent: parent, value: match.Value);
                        break;
                    case MatchType.Or:
                        result = new OrUnit(parent: parent, value: match.Value);
                        break;
                    case MatchType.Power:
                        result = new PowerUnit(parent: parent, value: match.Value);
                        break;
                    case MatchType.Sqrt:
                        result = new SqrtUnit(parent: parent, value: match.Value);
                        break;
                    case MatchType.Subtracting:
                        result = new SubtractingUnit(parent: parent, value: match.Value);
                        break;
                    case MatchType.Xor:
                        result = new XorUnit(parent: parent, value: match.Value);
                        break;
                    default:
                        result = new DecimalUnit(parent: parent, value: match.Value);
                        break;
                }
                return result;
            }
        }

        /// <summary>
        /// Ссылка на ячейку.
        /// </summary>
        class CellUnit : BaseUnit
        {
            /// <summary>
            /// Тип элемента.
            /// </summary>
            public override MatchType UnitType
            {
                get { return MatchType.Cell; }
            }
            /// <summary>
            /// Приоритет математического действия.
            /// </summary>
            public override int Action
            {
                get { return 0; }
            }

            public CellUnit(UnitCollection parent, string value) : base(parent: parent, value: value) { }
        }
        /// <summary>
        /// Числовой показатель.
        /// </summary>
        class DecimalUnit : BaseUnit
        {
            /// <summary>
            /// Тип элемента.
            /// </summary>
            public override MatchType UnitType
            {
                get { return MatchType.Decimal; }
            }
            /// <summary>
            /// Приоритет математического действия.
            /// </summary>
            public override int Action
            {
                get { return 0; }
            }

            public DecimalUnit(UnitCollection parent, string value) : base(parent: parent, value: value) { }
        }
        /// <summary>
        /// Закрывающаяся скобка.
        /// </summary>
        class CloseUnit : BaseUnit
        {
            /// <summary>
            /// Тип элемента.
            /// </summary>
            public override MatchType UnitType
            {
                get { return MatchType.Close; }
            }
            /// <summary>
            /// Приоритет математического действия.
            /// </summary>
            public override int Action
            {
                get { return 0; }
            }

            public CloseUnit(UnitCollection parent, string value) : base(parent: parent, value: value) { }
        }
        /// <summary>
        /// Открывающаяся скобка.
        /// </summary>
        class OpenUnit : BaseUnit
        {
            /// <summary>
            /// Тип элемента.
            /// </summary>
            public override MatchType UnitType
            {
                get { return MatchType.Open; }
            }
            /// <summary>
            /// Приоритет математического действия.
            /// </summary>
            public override int Action
            {
                get { return 0; }
            }
            public OpenUnit(UnitCollection parent, string value) : base(parent: parent, value: value) { }
        }
        /// <summary>
        /// Знак степени числа.
        /// </summary>
        class PowerUnit : BaseUnit
        {
            /// <summary>
            /// Тип элемента.
            /// </summary>
            public override MatchType UnitType
            {
                get { return MatchType.Power; }
            }
            /// <summary>
            /// Приоритет математического действия.
            /// </summary>
            public override int Action
            {
                get { return 1; }
            }
            public PowerUnit(UnitCollection parent, string value) : base(parent: parent, value: value) { }
        }
        /// <summary>
        /// Знак корня числа.
        /// </summary>
        class SqrtUnit : BaseUnit
        {
            /// <summary>
            /// Тип элемента.
            /// </summary>
            public override MatchType UnitType
            {
                get { return MatchType.Sqrt; }
            }
            /// <summary>
            /// Приоритет математического действия.
            /// </summary>
            public override int Action
            {
                get { return 1; }
            }
            public SqrtUnit(UnitCollection parent, string value) : base(parent: parent, value: value) { }
        }
        /// <summary>
        /// Знак отрицательного числа.
        /// </summary>
        class NegativeUnit : BaseUnit
        {
            /// <summary>
            /// Тип элемента.
            /// </summary>
            public override MatchType UnitType
            {
                get { return MatchType.Negative; }
            }
            /// <summary>
            /// Приоритет математического действия.
            /// </summary>
            public override int Action
            {
                get { return 2; }
            }
            public NegativeUnit(UnitCollection parent, string value) : base(parent: parent, value: value) { }
        }
        /// <summary>
        /// Знак умножения.
        /// </summary>
        class MultiplicationUnit : BaseUnit
        {
            /// <summary>
            /// Тип элемента.
            /// </summary>
            public override MatchType UnitType
            {
                get { return MatchType.Multiplication; }
            }
            /// <summary>
            /// Приоритет математического действия.
            /// </summary>
            public override int Action
            {
                get { return 3; }
            }
            public MultiplicationUnit(UnitCollection parent, string value) : base(parent: parent, value: value) { }
        }
        /// <summary>
        /// Знак деления.
        /// </summary>
        class DivisionUnit : BaseUnit
        {
            /// <summary>
            /// Тип элемента.
            /// </summary>
            public override MatchType UnitType
            {
                get { return MatchType.Division; }
            }
            /// <summary>
            /// Приоритет математического действия.
            /// </summary>
            public override int Action
            {
                get { return 3; }
            }
            public DivisionUnit(UnitCollection parent, string value) : base(parent: parent, value: value) { }
        }
        /// <summary>
        /// Вычисление целой части от деления.
        /// </summary>
        class FixUnit : BaseUnit
        {
            /// <summary>
            /// Тип элемента.
            /// </summary>
            public override MatchType UnitType
            {
                get { return MatchType.Fix; }
            }
            /// <summary>
            /// Приоритет математического действия.
            /// </summary>
            public override int Action
            {
                get { return 4; }
            }
            public FixUnit(UnitCollection parent, string value) : base(parent: parent, value: value) { }
        }
        /// <summary>
        /// Вычисление остатка от деления.
        /// </summary>
        class ModUnit : BaseUnit
        {
            /// <summary>
            /// Тип элемента.
            /// </summary>
            public override MatchType UnitType
            {
                get { return MatchType.Mod; }
            }
            /// <summary>
            /// Приоритет математического действия.
            /// </summary>
            public override int Action
            {
                get { return 5; }
            }
            public ModUnit(UnitCollection parent, string value) : base(parent: parent, value: value) { }
        }
        /// <summary>
        /// Знак сложения.
        /// </summary>
        class AdditionUnit : BaseUnit
        {
            /// <summary>
            /// Тип элемента.
            /// </summary>
            public override MatchType UnitType
            {
                get { return MatchType.Addition; }
            }
            /// <summary>
            /// Приоритет математического действия.
            /// </summary>
            public override int Action
            {
                get { return 6; }
            }
            public AdditionUnit(UnitCollection parent, string value) : base(parent: parent, value: value) { }
        }
        /// <summary>
        /// Знак вычитания.
        /// </summary>
        class SubtractingUnit : BaseUnit
        {
            /// <summary>
            /// Тип элемента.
            /// </summary>
            public override MatchType UnitType
            {
                get { return MatchType.Subtracting; }
            }
            /// <summary>
            /// Приоритет математического действия.
            /// </summary>
            public override int Action
            {
                get { return 6; }
            }
            public SubtractingUnit(UnitCollection parent, string value) : base(parent: parent, value: value) { }
        }
        /// <summary>
        /// Знак равно.
        /// </summary>
        class EqualUnit : BaseUnit
        {
            /// <summary>
            /// Тип элемента.
            /// </summary>
            public override MatchType UnitType
            {
                get { return MatchType.Equal; }
            }
            /// <summary>
            /// Приоритет математического действия.
            /// </summary>
            public override int Action
            {
                get { return 7; }
            }
            public EqualUnit(UnitCollection parent, string value) : base(parent: parent, value: value) { }
        }
        /// <summary>
        /// Знак не равно (!=).
        /// </summary>
        class NotEqualUnit : BaseUnit
        {
            /// <summary>
            /// Тип элемента.
            /// </summary>
            public override MatchType UnitType
            {
                get { return MatchType.NotEqual; }
            }
            /// <summary>
            /// Приоритет математического действия.
            /// </summary>
            public override int Action
            {
                get { return 8; }
            }
            public NotEqualUnit(UnitCollection parent, string value) : base(parent: parent, value: value) { }
        }
        /// <summary>
        /// Знак меньше (&lt;).
        /// </summary>
        class LessUnit : BaseUnit
        {
            /// <summary>
            /// Тип элемента.
            /// </summary>
            public override MatchType UnitType
            {
                get { return MatchType.Less; }
            }
            /// <summary>
            /// Приоритет математического действия.
            /// </summary>
            public override int Action
            {
                get { return 9; }
            }
            public LessUnit(UnitCollection parent, string value) : base(parent: parent, value: value) { }
        }
        /// <summary>
        /// Знак больше (>).
        /// </summary>
        class MoreUnit : BaseUnit
        {
            /// <summary>
            /// Тип элемента.
            /// </summary>
            public override MatchType UnitType
            {
                get { return MatchType.More; }
            }
            /// <summary>
            /// Приоритет математического действия.
            /// </summary>
            public override int Action
            {
                get { return 10; }
            }
            public MoreUnit(UnitCollection parent, string value) : base(parent: parent, value: value) { }
        }
        /// <summary>
        /// Знак меньше или равно (&lt;=).
        /// </summary>
        class LessOrEqualUnit : BaseUnit
        {
            /// <summary>
            /// Тип элемента.
            /// </summary>
            public override MatchType UnitType
            {
                get { return MatchType.LessOrEqual; }
            }
            /// <summary>
            /// Приоритет математического действия.
            /// </summary>
            public override int Action
            {
                get { return 11; }
            }
            public LessOrEqualUnit(UnitCollection parent, string value) : base(parent: parent, value: value) { }
        }
        /// <summary>
        /// Знак больше или равно (>=).
        /// </summary>
        class MoreOrEqualUnit : BaseUnit
        {
            /// <summary>
            /// Тип элемента.
            /// </summary>
            public override MatchType UnitType
            {
                get { return MatchType.MoreOrEqual; }
            }
            /// <summary>
            /// Приоритет математического действия.
            /// </summary>
            public override int Action
            {
                get { return 12; }
            }
            public MoreOrEqualUnit(UnitCollection parent, string value) : base(parent: parent, value: value) { }
        }
        /// <summary>
        /// Знак логического отрицания (NOT).
        /// </summary>
        class NotUnit : BaseUnit
        {
            /// <summary>
            /// Тип элемента.
            /// </summary>
            public override MatchType UnitType
            {
                get { return MatchType.Not; }
            }
            /// <summary>
            /// Приоритет математического действия.
            /// </summary>
            public override int Action
            {
                get { return 13; }
            }
            public NotUnit(UnitCollection parent, string value) : base(parent: parent, value: value) { }
        }
        /// <summary>
        /// Знак логического сложения (AND).
        /// </summary>
        class AndUnit : BaseUnit
        {
            /// <summary>
            /// Тип элемента.
            /// </summary>
            public override MatchType UnitType
            {
                get { return MatchType.And; }
            }
            /// <summary>
            /// Приоритет математического действия.
            /// </summary>
            public override int Action
            {
                get { return 14; }
            }
            public AndUnit(UnitCollection parent, string value) : base(parent: parent, value: value) { }
        }
        /// <summary>
        /// Знак логического ИЛИ (OR).
        /// </summary>
        class OrUnit : BaseUnit
        {
            /// <summary>
            /// Тип элемента.
            /// </summary>
            public override MatchType UnitType
            {
                get { return MatchType.Or; }
            }
            /// <summary>
            /// Приоритет математического действия.
            /// </summary>
            public override int Action
            {
                get { return 15; }
            }
            public OrUnit(UnitCollection parent, string value) : base(parent: parent, value: value) { }
        }
        /// <summary>
        /// Знак исключающегося ИЛИ (XOR).
        /// </summary>
        class XorUnit : BaseUnit
        {
            /// <summary>
            /// Тип элемента.
            /// </summary>
            public override MatchType UnitType
            {
                get { return MatchType.Xor; }
            }
            /// <summary>
            /// Приоритет математического действия.
            /// </summary>
            public override int Action
            {
                get { return 16; }
            }
            public XorUnit(UnitCollection parent, string value) : base(parent: parent, value: value) { }
        }

        /// <summary>
        /// Определить тип элемента.
        /// </summary>
        /// <param name="match">Класс совпадения регулярного выражения.</param>
        private static MatchType GetMatchType(Match match)
        {
            if (ArithmeticExpression.regexCell != null && ArithmeticExpression.regexCell.IsMatch(match.Value))
            {
                return MatchType.Cell;
            }
            else if (ArithmeticExpression.regexDecimal.IsMatch(match.Value))
            {
                return MatchType.Decimal;
            }
            else if (ArithmeticExpression.regexAddition.IsMatch(match.Value))
            {
                return MatchType.Addition;
            }
            else if (ArithmeticExpression.regexSubtracting.IsMatch(match.Value))
            {
                return MatchType.Subtracting;
            }
            else if (ArithmeticExpression.regexMultiplication.IsMatch(match.Value))
            {
                return MatchType.Multiplication;
            }
            else if (ArithmeticExpression.regexDivision.IsMatch(match.Value))
            {
                return MatchType.Division;
            }
            else if (ArithmeticExpression.regexFix.IsMatch(match.Value))
            {
                return MatchType.Fix;
            }
            else if (ArithmeticExpression.regexMod.IsMatch(match.Value))
            {
                return MatchType.Mod;
            }
            else if (ArithmeticExpression.regexOpen.IsMatch(match.Value))
            {
                return MatchType.Open;
            }
            else if (ArithmeticExpression.regexClose.IsMatch(match.Value))
            {
                return MatchType.Close;
            }
            else if (ArithmeticExpression.regexPower.IsMatch(match.Value))
            {
                return MatchType.Power;
            }
            else if (ArithmeticExpression.regexSqrt.IsMatch(match.Value))
            {
                return MatchType.Sqrt;
            }
            //else if (LogicExpression.regexAnd.IsMatch(match.Value))
            //{
            //    return MatchType.And;
            //}
            //else if (LogicExpression.regexEqual.IsMatch(match.Value))
            //{
            //    return MatchType.Equal;
            //}
            //else if (LogicExpression.regexLess.IsMatch(match.Value))
            //{
            //    return MatchType.Less;
            //}
            //else if (LogicExpression.regexLessOrEqual.IsMatch(match.Value))
            //{
            //    return MatchType.LessOrEqual;
            //}
            //else if (LogicExpression.regexMore.IsMatch(match.Value))
            //{
            //    return MatchType.More;
            //}
            //else if (LogicExpression.regexMoreOrEqual.IsMatch(match.Value))
            //{
            //    return MatchType.MoreOrEqual;
            //}
            //else if (LogicExpression.regexNot.IsMatch(match.Value))
            //{
            //    return MatchType.Not;
            //}
            //else if (LogicExpression.regexNotEqual.IsMatch(match.Value))
            //{
            //    return MatchType.NotEqual;
            //}
            //else if (LogicExpression.regexOr.IsMatch(match.Value))
            //{
            //    return MatchType.Or;
            //}
            //else if (LogicExpression.regexXor.IsMatch(match.Value))
            //{
            //    return MatchType.Xor;
            //}
            else
            {
                return MatchType.Decimal;
            }
        }

        /// <summary>
        /// Тип элемента.
        /// </summary>
        public enum MatchType : int
        {
            /// <summary>
            /// Ссылка на ячейку.
            /// </summary>
            Cell = 0,
            /// <summary>
            /// Числовой показатель.
            /// </summary>
            Decimal = 1,
            /// <summary>
            /// Открывающаяся скобка [(].
            /// </summary>
            Open = 2,
            /// <summary>
            /// Закрывающаяся скобка [)].
            /// </summary>
            Close = 3,
            /// <summary>
            /// Степень числа [^].
            /// </summary>
            Power = 4,
            /// <summary>
            /// Корень [sqrt].
            /// </summary>
            Sqrt = 5,
            /// <summary>
            /// Отрицательное число [-].
            /// </summary>
            Negative = 6,
            /// <summary>
            /// Знак умножения [*].
            /// </summary>
            Multiplication = 7,
            /// <summary>
            /// Знак деления [/].
            /// </summary>
            Division = 8,
            /// <summary>
            /// Знак операции получения целой части от деления [\].
            /// </summary>
            Fix = 9,
            /// <summary>
            /// Знак операции получения остатка от деления [%].
            /// </summary>
            Mod = 10,
            /// <summary>
            /// Знак сложения [+].
            /// </summary>
            Addition = 11,
            /// <summary>
            /// Знак вычитания [-].
            /// </summary>
            Subtracting = 12,
            /// <summary>
            /// Равно [=].
            /// </summary>
            Equal = 13,
            /// <summary>
            /// Не равно [&lt;>].
            /// </summary>
            NotEqual = 14,
            /// <summary>
            /// Меньше [&lt;].
            /// </summary>
            Less = 15,
            /// <summary>
            /// Больше [>].
            /// </summary>
            More = 16,
            /// <summary>
            /// Меньше или равно [&lt;=].
            /// </summary>
            LessOrEqual = 17,
            /// <summary>
            /// Больше или равно [>=].
            /// </summary>
            MoreOrEqual = 18,
            /// <summary>
            /// Логическое отрицание [not].
            /// </summary>
            Not = 19,
            /// <summary>
            /// Логическое сложение [and].
            /// </summary>
            And = 20,
            /// <summary>
            /// Логическое ИЛИ [or].
            /// </summary>
            Or = 21,
            /// <summary>
            /// Исключающее ИЛИ [xor].
            /// </summary>
            Xor = 22
        }
    }
}