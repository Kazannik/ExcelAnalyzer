using System;
using System.Collections.Generic;
using System.Globalization;

namespace ExcelAnalyzer.Arm
{
    public class Content : IComparable<Content>, IComparable<DateTime>
    {
        private List<int> collection;
        
        private Content(Period begin, Period end, int[] months)
        {
            this.Begin = begin;
            this.End = end;
            this.collection = new List<int>();
            foreach (int i in months)
            {
                this.collection.Add(i);
            }
            this.collection.Sort();
        }

        public Content() : this(Period.MinValue, Period.MaxValue, new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 }) { }

        public static Content Create(Period begin, Period end, int[] months)
        {           
            return new Content(begin: begin, end: end, months: months);
        }

        public static Content Create(Period begin, Period end)
        {
            return new Content(begin: begin, end: end, months: new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 });
        }
        public static Content Create(Period period)
        {
            return new Content(begin: period, end: period, months: new int[] { period.Month });
        }

        public static Content Create(DateTime date)
        {
            return new Content(begin: date, end: date, months: new int[] { date.Month });
        }

        public static Content Create(int month)
        {
            Period period = Period.Create(year: DateTime.Today.Year, month: month);
            return new Content(begin: period, end: period, months: new int[] { month });
        }

        public static Content Today()
        {
            return Content.Create(DateTime.Today);
        }

        public static Content Now()
        {
            return Content.Create(DateTime.Today);
        }
          

        /// <summary>
        /// Начало действия.
        /// </summary>
        public Period Begin { get; }

        /// <summary>
        /// Окончание действия.
        /// </summary>
        public Period End { get; }

        /// <summary>
        /// Отчетные периоды (месяцы) действия.
        /// </summary>
        public int[] Months
        {
            get { return this.collection.ToArray(); }
        }

 
        //public string ToShortDateString()
        //{
        //    string monthName = FormatInfo.GetMonthName(this._month).ToString();
        //    if (this._month > 0)
        //    { return monthName + " " + this._year.ToString("0000"); }
        //    else { return this._year.ToString("0000"); }
        //}

        //public DateTime ToDate()
        //{
        //    if (this._month > 0)
        //    { return new DateTime(year: this._year, month: this._month, day: 1); }
        //    else
        //    { return new DateTime(year: this._year, month: 1, day: 1); }
        //}

        //public override string ToString()
        //{
        //    return this._year.ToString("0000") + this._month.ToString("00");
        //}

        //public static implicit operator Content(int month)
        //{
        //    return new Period(year: year, month: 0);
        //}

        //public static explicit operator int(Content content)
        //{
        //    return period._year;
        //}

        //public static implicit operator Content(DateTime date)
        //{
        //    return new Period(year: date.Year, month: date.Month);
        //}

        //public static explicit operator DateTime(Content content)
        //{
        //    return period.ToDate();
        //}

        public override bool Equals(Object obj)
        {
            if ((obj == null) || !this.GetType().Equals(obj.GetType()))
            { return false; }
            else
            {
                Content c = (Content)obj;
                return (this == c);
            }
        }

        //public override int GetHashCode()
        //{
        //    int sum = this._year * 12 + this._month;
        //    return sum.GetHashCode();
        //}

    

        public static bool operator ==(Content x, Content y)
        {
            return Compare(x, y) == 0;
        }

        public static bool operator !=(Content x, Content y)
        {
            return Compare(x, y) != 0;
        }

        public static bool operator >(Content x, Content y)
        {
            return Compare(x, y) > 0;
        }
        public static bool operator <(Content x, Content y)
        {
            return Compare(x, y) < 0;
        }

        public static bool operator >=(Content x, Content y)
        {
            return Compare(x, y) >= 0;
        }
        public static bool operator <=(Content x, Content y)
        {
            return Compare(x, y) <= 0;
        }

        public static bool operator ==(Content x, DateTime y)
        {
            return Compare(x, y) == 0;
        }

        public static bool operator !=(Content x, DateTime y)
        {
            return Compare(x, y) != 0;
        }

        public static bool operator >(Content x, DateTime y)
        {
            return Compare(x, y) > 0;
        }
        public static bool operator <(Content x, DateTime y)
        {
            return Compare(x, y) < 0;
        }

        public static bool operator >=(Content x, DateTime y)
        {
            return Compare(x, y) >= 0;
        }
        public static bool operator <=(Content x, DateTime y)
        {
            return Compare(x, y) <= 0;
        }

        public int CompareTo(Content value)
        {
            return Compare(this, value);
        }

        public int CompareTo(DateTime value)
        {
            return Compare(this, value);
        }

        public static int Compare(Content x, Content y)
        {
            if (!Equals(x, null) & !Equals(y, null))
            {
                try
                {
                    int iCompare = Period.Compare(x.Begin, y.Begin);
                    if (iCompare == 0) { iCompare = Period.Compare(x.End, y.End); }
                    return iCompare; 
                }
                catch (Exception)
                { return 0; }
            }
            else if (!Equals(x, null) & Equals(y, null))
            { return 1; }
            else if (Equals(x, null) & !Equals(y, null))
            { return -1; }
            else { return 0; }
        }

        public static int Compare(Content x, DateTime y)
        {
            if (!Equals(x, null) & !Equals(y, null))
            {
                try
                {
                    int iCompare = Period.Compare(x.Begin, y);
                    if (iCompare == 0) { iCompare = Period.Compare(x.End, y); }
                    return iCompare;
                }
                catch (Exception)
                { return 0; }
            }
            else if (!Equals(x, null) & Equals(y, null))
            { return 1; }
            else if (Equals(x, null) & !Equals(y, null))
            { return -1; }
            else { return 0; }
        }

        public class ContentComparer : IComparer<Content>
        {
            public int Compare(Content x, Content y)
            {
                return Content.Compare(x, y);
            }
        }
    }

    public class ContentEventArgs : EventArgs
    {
        public ContentEventArgs(Content args)
        {
            Content = args;
        }
        public Content Content { get; }
    }
}
