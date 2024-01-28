using System;
using System.Collections.Generic;

namespace ExcelAnalyzer.Arm
{
    public class Region
    {
        public Region(int code, string caption, Period begin, Period end)
        {
            Code = code;
            Caption = caption;
            Begin = begin;
            End = end;
        }

        public Region(int code, string caption) : this(code: code, caption: caption, begin: Period.MinValue, end: Period.MaxValue) { }

        public Region(int code) : this(code: code, caption: string.Empty) { }
        
        public int Code { get; }
        public string Caption { get; }
        public string Description { get; set; }
        public object Tag { get; set; }
        public Period Begin { get; }
        public Period End { get; }
        
        public override string ToString()
        {
            return Code.ToString("0000");
        }

        public static implicit operator Region(int code)
        {
            return new Region(code: code);
        }

        public static explicit operator int(Region region)
        {
            return region.Code;
        }

        public static explicit operator string(Region region)
        {
            return region.Caption;
        }
                
        public override bool Equals(object obj)
        {
            if ((obj == null) || !GetType().Equals(obj.GetType()))
            {
                return false;
            }
            else
            {
                Region p = (Region)obj;
                return (Code == p.Code);
            }
        }

        public override int GetHashCode()
        {
            return this.Code.GetHashCode();
        }

        //public static Region[] operator +(Region a, Region b)
        //{
        //    decimal sum = a.Year * 12 + a.Month + b.Year * 12 + b.Month;
        //    decimal year = Math.Truncate(sum / 12);
        //    decimal month = sum - (year * 12);
        //    return new Period(year: (int)year, month: (int)month);
        //}
                
        //public static Period operator +(Period t, int m)
        //{
        //    decimal sum = t.Year * 12 + t.Month + m;
        //    decimal year = Math.Truncate(sum / 12);
        //    decimal month = sum - (year * 12);
        //    return new Period(year: (int)year, month: (int)month);
        //}
        
        public static bool operator == (Region x, Region y)
        {
            return Compare(x, y) == 0;
        }

        public static bool operator != (Region x, Region y)
        {
            return Compare(x, y) != 0;
        }

        public static bool operator > (Region x, Region y)
        {
            return Compare(x, y) > 0;
        }
        public static bool operator < (Region x, Region y)
        {
            return Compare(x, y) < 0;
        }

        public static bool operator >= (Region x, Region y)
        {
            return Compare(x, y) >= 0;
        }

        public static bool operator <= (Region x, Region y)
        {
            return Compare(x, y) <= 0;
        }

        public static bool operator == (Region x, int y)
        {
            return Compare(x, y) == 0;
        }

        public static bool operator != (Region x, int y)
        {
            return Compare(x, y) != 0;
        }

        public static bool operator > (Region x, int y)
        {
            return Compare(x, y) > 0;
        }

        public static bool operator < (Region x, int y)
        {
            return Compare(x, y) < 0;
        }

        public static bool operator >= (Region x, int y)
        {
            return Compare(x, y) >= 0;
        }

        public static bool operator <= (Region x, int y)
        {
            return Compare(x, y) <= 0;
        }

        public int CompareTo(Region value)
        {
            return Compare(this, value);
        }

        public int CompareTo(int value)
        {
            return Compare(this, value);
        }

        public static int Compare(Region x, Region y)
        {
            if (!Equals(x, null) & !Equals(y, null))
            {
                try
                {
                    int iCompare = decimal.Compare(x.Code, y.Code);
                    if (iCompare == 0) { iCompare = Period.Compare(x.Begin, y.Begin); }                    
                    if (iCompare == 0) { iCompare = Period.Compare(x.End, y.End); }
                    if (iCompare == 0) { string.Compare(x.Caption, y.Caption); }
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

        public static int Compare(Region x, int y)
        {
            if (!Equals(x, null) & !Equals(y, null))
            {
                return decimal.Compare(x.Code, y);               
            }
            else if (!Equals(x, null) & Equals(y, null))
            { return 1; }
            else if (Equals(x, null) & !Equals(y, null))
            { return -1; }
            else { return 0; }
        }

        public class PeriodComparer : IComparer<Region>
        {
            public int Compare(Region x, Region y)
            {
                return Region.Compare(x, y);
            }
        }
    }

    public class RegionEventArgs : EventArgs
    {
        public RegionEventArgs(Region args)
        {
            Region = args;
        }
        public Region Region { get; }
    }
}
