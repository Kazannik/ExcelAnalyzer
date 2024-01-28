using System;
using System.Collections.Generic;

namespace ExcelAnalyzer.Arm
{
    public class Form
    {
        public Form(int code, string caption, Period begin, Period end)
        {
            Code = code;
            Caption = caption;
            Begin = begin;
            End = end;
        }

        public Form(int code, string caption) : this(code: code, caption: caption, begin: Period.MinValue, end: Period.MaxValue) { }

        public Form(int code) : this(code: code, caption: string.Empty) { }

        public int Code { get; }
        public string Caption { get; }
        public string Description { get; set; }
        public object Tag { get; set; }
        public Period Begin { get; }
        public Period End { get; }

        public override string ToString()
        {
            return this.Code.ToString("0000");
        }

        public static implicit operator Form(string code)
        {
            int iCode = -1;
            int.TryParse(code, out iCode);
            if (iCode >=0) { return new Form(code: iCode); }
            else { return null; }            
        }

        public static implicit operator Form(int code)
        {
            return new Form(code: code);
        }

        public static explicit operator int(Form region)
        {
            return region.Code;
        }

        public static explicit operator string(Form region)
        {
            return region.Code.ToString("0000");
        }

        public override bool Equals(object obj)
        {
            if ((obj == null) || !GetType().Equals(obj.GetType()))
            { return false; }
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
               
        public static bool operator ==(Form x, Form y)
        {
            return Compare(x, y) == 0;
        }

        public static bool operator !=(Form x, Form y)
        {
            return Compare(x, y) != 0;
        }

        public static bool operator >(Form x, Form y)
        {
            return Compare(x, y) > 0;
        }
        public static bool operator <(Form x, Form y)
        {
            return Compare(x, y) < 0;
        }

        public static bool operator >=(Form x, Form y)
        {
            return Compare(x, y) >= 0;
        }
        public static bool operator <=(Form x, Form y)
        {
            return Compare(x, y) <= 0;
        }

        public static bool operator ==(Form x, int y)
        {
            return Compare(x, y) == 0;
        }

        public static bool operator !=(Form x, int y)
        {
            return Compare(x, y) != 0;
        }

        public static bool operator >(Form x, int y)
        {
            return Compare(x, y) > 0;
        }
        public static bool operator <(Form x, int y)
        {
            return Compare(x, y) < 0;
        }

        public static bool operator >=(Form x, int y)
        {
            return Compare(x, y) >= 0;
        }
        public static bool operator <=(Form x, int y)
        {
            return Compare(x, y) <= 0;
        }

        public int CompareTo(Form value)
        {
            return Compare(this, value);
        }

        public int CompareTo(int value)
        {
            return Compare(this, value);
        }

        private static int Compare(Form x, Form y)
        {
            if (!Equals(x, null) & !Equals(y, null))
            {
                try
                {
                    int iCompare = decimal.Compare(x.Code, y.Code);
                    if (iCompare != 0) { return iCompare; }
                    iCompare = Period.Compare(x.Begin, y.Begin);
                    if (iCompare != 0) { return iCompare; }
                    iCompare = Period.Compare(x.End, y.End);
                    if (iCompare != 0) { return iCompare; }
                    return string.Compare(x.Caption, y.Caption); 
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

        private static int Compare(Form x, int y)
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

        public class FormComparer : IComparer<Form>
        {
            public int Compare(Form x, Form y)
            {
                return Form.Compare(x, y);
            }
        }
    }

    public class FormEventArgs : EventArgs
    {
        public FormEventArgs(Form args)
        {
            Form = args;
        }
        public Form Form { get; }
    }
}