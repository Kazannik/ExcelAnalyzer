using System;
using System.Collections.Generic;
using System.Globalization;

namespace ExcelAnalyzer.Arm
{
    public class Period : IComparable<Period>, IComparable<DateTime>
    {
        private static DateTimeFormatInfo FormatInfo = CultureInfo.CurrentCulture.DateTimeFormat;

        private Period(int year, int month)
        {
            this.Month = month;
            this.Year = year;
        }
        
        public static Period Create(int year, int month)
        {
            if (month > 12)
            { month = 12; }
            else if (month < 0)
            { month = 0; }
            return new Period (year: year, month: month);
        }

        public static Period Create(DateTime date)
        {
            return Period.Create(year: date.Year, month: date.Month);            
        }

        public static Period Create(int year)
        {
            return Period.Create(year: year, month: 0);
        }

        public static Period Today()
        {
            return Period.Create(DateTime.Today);
        }

        public static Period Now()
        {
            return Period.Create(DateTime.Now);
        }

        public static Period MaxValue
        {
            get { return Period.Create(year:2199, month:12); }
        }
        public static Period MinValue
        {
            get { return Period.Create(year:1900, month:0); }
        }
        
        public int Month { get; }

        public int Year { get; }
        
        public Period ZeroMonth
        {
            get { return new Period (year: this.Year, month:0); }
        }

        public Period FirstMonth
        {
            get { return new Period(year: this.Year, month: 1); }
        }

        public Period LastMonth
        {
            get { return new Period(year: this.Year, month: 12); }
        }

        public Period PreviouseMonth
        {
            get
            {
                if (this.Month <= 1)
                { return new Period(year: this.Year - 1, month: 12); }
                else
                { return new Period(year: this.Year, month: this.Month - 1); }
            }
        }
        public Period NextMonth
        {
            get
            {
                if (this.Month == 12)
                { return new Period(year: this.Year + 1, month: 1); }
                else
                { return new Period(year: this.Year, month: this.Month + 1); }
            }
        }

        public Period PreviouseYear
        {
            get {  return new Period(year: this.Year-1, month: this.Month); }
        }

        public Period NextYear
        {
            get { return new Period(year: this.Year + 1, month: this.Month); }
        }
        
        public string ToShortDateString()
        {
            string monthName = FormatInfo.GetMonthName(this.Month).ToString();
            if (this.Month > 0)
            { return monthName + " " + this.Year.ToString("0000"); }
            else { return this.Year.ToString("0000"); }
        }

        public DateTime ToDate()
        {
            if (this.Month > 0)
            { return new DateTime(year: this.Year, month: this.Month, day: 1); }
            else
            { return new DateTime(year: this.Year, month: 1, day: 1); }
        }
        
        public override string ToString()
        {
            return this.Year.ToString("0000") + this.Month.ToString("00");
        }
        
        public static implicit operator Period(int year)
        {
            return new Period (year: year, month: 0);
        }

        public static explicit operator int(Period period)
        {
            return period.Year;
        }

        public static implicit operator Period(DateTime date)
        {
            return new Period (year: date.Year, month: date.Month);
        }

        public static explicit operator DateTime(Period period)
        {
            return period.ToDate();
        }
        
        public override bool Equals(Object obj)
        {
            if ((obj == null) || !this.GetType().Equals(obj.GetType()))
            { return false; }
            else
            {
                Period p = (Period)obj;
                return (this.Year == p.Year) && (this.Month == p.Month);
            }
        }

        public override int GetHashCode()
        {
            int sum = this.Year * 12 + this.Month;
            return sum.GetHashCode();
        }

        public static Period operator +(Period a, Period b)
        {
            decimal sum  = a.Year * 12 + a.Month + b.Year * 12 + b.Month;
            decimal year = Math.Truncate(sum / 12);
            decimal month = sum - (year * 12);
            return new Period( year: (int) year, month: (int) month);            
        }

        public static Period operator -(Period a, Period b)
        {
            decimal sum = a.Year * 12 + a.Month - b.Year * 12 - b.Month;
            decimal year = Math.Truncate(sum / 12);
            decimal month = sum - (year * 12);
            return new Period (year: (int)year, month: (int)month);
        }

        public static Period operator +(Period t, int m)
        {
            decimal sum = t.Year * 12 + t.Month + m;
            decimal year = Math.Truncate(sum / 12);
            decimal month = sum - (year * 12);
            return new Period (year:(int)year, month:(int)month);
        }

        public static Period operator -(Period t, int m)
        {
            decimal sum = t.Year * 12 + t.Month - m;
            decimal year = Math.Truncate(sum / 12);
            decimal month = sum - (year * 12);
            return new Period (year: (int)year, month: (int)month);
        }
        
        public static bool operator ==(Period x, Period y)
        {
            return Compare(x,y) == 0;                        
        }

        public static bool operator !=(Period x, Period y)
        {
            return Compare(x, y) != 0;
        }

        public static bool operator >(Period x, Period y)
        {
            return Compare(x, y) > 0;
        }
        public static bool operator <(Period x, Period y)
        {
            return Compare(x, y) < 0;
        }

        public static bool operator >=(Period x, Period y)
        {
            return Compare(x, y) >= 0;
        }
        public static bool operator <=(Period x, Period y)
        {
            return Compare(x, y) <= 0;
        }
        
        public static bool operator ==(Period x, DateTime y)
        {
            return Compare(x, y) == 0;
        }

        public static bool operator !=(Period x, DateTime y)
        {
            return Compare(x, y) != 0;
        }

        public static bool operator >(Period x, DateTime y)
        {
            return Compare(x, y) > 0;
        }
        public static bool operator <(Period x, DateTime y)
        {
            return Compare(x, y) < 0;
        }

        public static bool operator >=(Period x, DateTime y)
        {
            return Compare(x, y) >= 0;
        }
        public static bool operator <=(Period x, DateTime y)
        {
            return Compare(x, y) <= 0;
        }
        
        public int CompareTo(Period value)
        {
            return Compare(this, value);            
        }

        public int CompareTo(DateTime value)
        {
            return Compare(this, value);
        }

        public static int Compare(Period x, Period y)
        {
            if (!Equals(x,null) & !Equals(y,null))
            {
                try
                {
                    int iCompare = Decimal.Compare(x.Year, y.Year);
                    if (iCompare == 0) { iCompare = Decimal.Compare(x.Month, y.Month); }
                    return iCompare; 
                }
                catch (Exception)
                { return 0; }
            }
            else if (!Equals(x,null) & Equals(y,null))
            { return 1; }
            else if (Equals(x,null) & !Equals(y,null))
            { return -1; }
            else { return 0; }
        }

        public static int Compare(Period x, DateTime y)
        {
            if (!Equals(x,null) & !Equals(y,null))
            {
                try
                {
                    int iCompare = Decimal.Compare(x.Year, y.Year);
                    if (iCompare == 0) { iCompare = Decimal.Compare(x.Month, y.Month); }
                    return iCompare;
                }
                catch (Exception)
                { return 0; }
            }
            else if (!Equals(x,null) & Equals(y,null))
            { return 1; }
            else if (Equals(x,null) & !Equals(y,null))
            { return -1; }
            else { return 0; }
        }

        public class PeriodComparer : IComparer<Period>
        {
            public int Compare(Period x, Period y)
            {
                return Period.Compare(x, y);
            }
        }
    }

    public class PeriodEventArgs : EventArgs
    {
        public PeriodEventArgs(Period args)
        {
            Period = args;
        }
        public Period Period { get; }        
    }
}
