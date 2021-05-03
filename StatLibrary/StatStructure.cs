using System;

/// <summary>
/// Отчетный период (дата).
/// </summary>
public struct StatPeriod: IComparable, IComparable<StatPeriod>
{
    private int _value;

    public StatPeriod(int month, int year)
    {
        if (month < 0) { month = 1; }
        if (month > 12) { month = 12; }
        if (year < 0) { year = 1; }
        if (year > 9999) { year = 9999; }
        this._value = year * 12 + month;
    }

    public StatPeriod(DateTime date) : this(date.Month, date.Year) { }
    
    private StatPeriod(int value)
    {
        this._value = value;
    }
    
    /// <summary>
    /// Месяц.
    /// </summary>
    public int Month
    { get { return this._value - this.Year*12; } }

    /// <summary>
    /// Год.
    /// </summary>
    public int Year
    {
        get
        {
            if (Math.IEEERemainder(this._value, 12) == 0)
            { return (int)Math.Truncate((double)(this._value / 12))-1; }
            else { return (int)Math.Truncate((double)(this._value / 12)); }
        }
    }

    public static StatPeriod Empty()
    {
        return new StatPeriod(-1);
    }

    /// <summary>
    /// Первый месяц в текущем году (январь).
    /// </summary>
    public static StatPeriod First
    {
        get { return new StatPeriod(1, DateTime.Today.Year); }
    }

    /// <summary>
    /// Последний месяц в текущем году (декабрь).
    /// </summary>
    public static StatPeriod Last
    {
        get { return new StatPeriod(12, DateTime.Today.Year); }
    }

    /// <summary>
    /// Месяц, следующий за текущей датой.
    /// </summary>
    public static StatPeriod Next
    {
        get { return new StatPeriod(DateTime.Today)+1; }
    }

    /// <summary>
    /// Месяц, предшествующий текущей дате.
    /// </summary>
    public static StatPeriod Previous
    {
        get { return new StatPeriod(DateTime.Today) - 1; }
    }

    /// <summary>
    /// Текущий период.
    /// </summary>
    public static StatPeriod Today
    {
        get { return new StatPeriod(DateTime.Today); }
    }
    
    public static StatPeriod MaxValue()
    {
        return new StatPeriod(120000);
    }

    public static StatPeriod MinValue()
    {
        return new StatPeriod(0);
    }

    public static StatPeriod operator ++(StatPeriod p)
    {
        int r = p._value + 1;
        if (r > 120000) { r = 120000; }
        return new StatPeriod(r);
    }

    public static StatPeriod operator --(StatPeriod p)
    {
        int r = p._value - 1;
        if (r < 0) { r = 0; }
        return new StatPeriod(r);
    }

    public static StatPeriod operator +(StatPeriod x, StatPeriod y)
    {
        int r = x._value + y._value;
        if (r > 120000) { r = 120000; }
        return new StatPeriod(r);
    }

    public static StatPeriod operator -(StatPeriod x, StatPeriod y)
    {
        int r = x._value - y._value;
        if (r <0) { r = 0; }
        return new StatPeriod(r);
    }
    
    public static StatPeriod operator +(StatPeriod x, DateTime y)
    {
        int r = x._value + (y.Year*12 + y.Month);
        if (r > 120000) { r = 120000; }
        return new StatPeriod(r);
    }

    public static StatPeriod operator -(StatPeriod x, DateTime y)
    {
        int r = x._value - (y.Year * 12 + y.Month);
        if (r < 0) { r = 0; }
        return new StatPeriod(r);
    }
    
    public static StatPeriod operator +(StatPeriod p, int month)
    {
        int r = p._value + month;
        if (r > 120000) { r = 120000; }
        return new StatPeriod(r);
    }

    public static StatPeriod operator -(StatPeriod p, int month)
    {
        int r = p._value - month;
        if (r < 0) { r = 0; }
        return new StatPeriod(r);
    }

    public static bool operator ==(StatPeriod x, StatPeriod y)
    {
        return x._value==y._value;
    }

    public static bool operator !=(StatPeriod x, StatPeriod y)
    {
        return x._value !=y._value;
    }

    public static bool operator <(StatPeriod x, StatPeriod y)
    {
        return x._value<y._value;
    }
    
    public static bool operator >(StatPeriod x, StatPeriod y)
    {
        return x._value > y._value;
    }

    public static bool operator <=(StatPeriod x, StatPeriod y)
    {
        return x._value <= y._value;
    }

    public static bool operator >=(StatPeriod x, StatPeriod y)
    {
        return x._value >= y._value;
    }
    
    public static implicit operator DateTime(StatPeriod p)
    {
        return new DateTime(p.Year, p.Month, 1);
    }
    
    public DateTime ToDate()
    {
        return new DateTime(this.Year, this.Month, 1);
    }

    public override string ToString()
    { return this.Year.ToString("0000") + this.Month.ToString("00"); }

    /// <summary>
    /// Сравнивает два заданных значения <paramref name="StatPeriod"/>
    /// </summary>
    /// <param name="p1">Объект типа <paramref name="StatPeriod"/>.</param>
    /// <param name="p2">Объект типа <paramref name="StatPeriod"/>.</param>
    public static int Compare(StatPeriod p1, StatPeriod p2)
    {
        return Decimal.Compare(p1._value, p2._value);
    }

    public int CompareTo(StatPeriod other)
    {
        return StatPeriod.Compare(this, other);
    }

    public int CompareTo(object obj)
    {
        if (obj is StatPeriod)
        {
            StatPeriod otherStatPeriod = (StatPeriod)obj;
            return StatPeriod.Compare(this, otherStatPeriod);
        }
        else { throw new ArgumentException("Объект не является StatPeriod (отчетным периодом)."); }       
    }

    /// <summary>
    /// Возвращает хеш-код данного экземпляра/
    /// </summary>
    public override int GetHashCode()
    {
        return this._value.GetHashCode();
    }

    /// <summary>
    /// Возвращает значение, позволяющее определить, представляют ли два заданных экземпляра <paramref name="StatPeriod"/> равные значения.
    /// </summary>
    /// <param name="p1">Объект типа <paramref name="StatPeriod"/>.</param>
    /// <param name="p2">Объект типа <paramref name="StatPeriod"/>.</param>
    public static bool Equals(StatPeriod p1, StatPeriod p2)
    {
        return p1._value.Equals(p2._value);
    }

    /// <summary>
    /// Возвращает значение, указывающее, равен ли данный экземпляр заданному значению типа <paramref name="StatPeriod"/>.
    /// </summary>
    /// <param name="obj">Значение типа <paramref name="StatPeriod"/> для сравнения с данным экземпляром.</param>
    public override bool Equals (Object obj)
    {
        if (obj is StatPeriod)
        {
            StatPeriod otherStatPeriod = (StatPeriod)obj;
            return StatPeriod.Equals(this,otherStatPeriod);
        }
        else { throw new ArgumentException("Объект не является StatPeriod (отчетным периодом)."); }
    }
}

/// <summary>
/// Интерфейс идентификатора.
/// </summary>
public interface IStatContent : IComparable, IComparable<IStatContent>
{
    /// <summary>
    /// Начало действия.
    /// </summary>
    StatPeriod Begin { get; }
    
    /// <summary>
    /// Окончание действия.
    /// </summary>
    StatPeriod Stop { get; }

    /// <summary>
    /// Отчетные периоды (месяцы) действия.
    /// </summary>
    int[] Period { get; }
        
    /// <summary>
    /// Определяет, принадлежит ли данному идентификатору отчетный период (дата) <paramref name="StatPeriod"/>.
    /// </summary>
    /// <param name="period">Отчетные период (дата) <paramref name="StatPeriod"/>.</param>
    bool Contains(StatPeriod period);
}

/// <summary>
/// Идентификатор.
/// </summary>
public struct StatContent: IStatContent
{
    private StatPeriod _begin;
    private StatPeriod _stop;
    private int[] _period;

    public StatContent(StatPeriod begin, StatPeriod stop, int[] period)
    {
        this._begin = begin;
        this._period = period;
        this._stop = stop;
    }

    public StatContent(StatPeriod begin, StatPeriod stop) : this(begin, stop, new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 }) { }

    public StatContent(StatPeriod begin) : this(begin, StatPeriod.MaxValue()) { }

    /// <summary>
    /// Начало действия.
    /// </summary>
    public StatPeriod Begin
    {
        get { return this._begin;}
    }

    /// <summary>
    /// Окончание действия.
    /// </summary>
    public StatPeriod Stop
    {
        get { return this._stop; }
    }

    /// <summary>
    /// Отчетные периоды (месяцы) действия.
    /// </summary>
    public int[] Period
    {
        get { return this._period; }
    }

    /// <summary>
    /// Определяет, принадлежит ли данному идентификатору отчетный период (дата) <paramref name="StatPeriod"/>.
    /// </summary>
    /// <param name="content">Объект типа <paramref name="IStatContent"/>.</param>
    /// <param name="period">Отчетные период (дата) <paramref name="StatPeriod"/>.</param>
    /// <returns></returns>
    public static bool Contains(IStatContent content, StatPeriod period)
    {
        return content.Begin <= period && content.Stop >= period && Array.IndexOf(content.Period, period.Month) >= 0;
    }
    
    /// <summary>
    /// Определяет, принадлежит ли данному идентификатору отчетный период (дата) <paramref name="StatPeriod"/>.
    /// </summary>
    /// <param name="period">Отчетные период (дата) <paramref name="StatPeriod"/>.</param>
    public bool Contains(StatPeriod period)
    { 
        return StatContent.Contains( this, period);
    }
    
    /// <summary>
    /// Сравнивает два заданных значения <paramref name="StatContent"/>.
    /// </summary>
    /// <param name="p1">Объект типа <paramref name="StatContent"/>.</param>
    /// <param name="p2">Объект типа <paramref name="StatContent"/>.</param>
    public static int Compare(StatContent c1, StatContent c2)
    {
        int c = c1.Begin.CompareTo(c2.Begin);
        if (c == 0) { return c1.Stop.CompareTo(c2.Stop); }
        else { return c; }
    }
    
    /// <summary>
    /// Сравнивает текущий объект с заданным значением <paramref name="StatContent"/>.
    /// </summary>
    /// <param name="obj">Объект типа <paramref name="StatContent"/>.</param>
    public int CompareTo(object obj)
    {
        if (obj is StatContent)
        {
            StatContent otherStatContent = (StatContent)obj;
            return StatContent.Compare(this, otherStatContent);
        }
        else { throw new ArgumentException("Объект не является StatContent (отчетным периодом)."); }
    }
    
    /// <summary>
    /// Сравнивает текущий объект с заданным значением <paramref name="StatContent"/>.
    /// </summary>
    /// <param name="other">Объект типа <paramref name="StatContent"/>.</param>
    public int CompareTo(IStatContent other)
    {
        return CompareTo(other);
    }
}

/// <summary>
/// Регион.
/// </summary>
public struct StatRegion : IComparable, IComparable<StatRegion>
{
    private int _code;
    private string _caption;

    public StatRegion(int code, string caption)
    {
        this._caption=caption;
        this._code=code;
    }

    public StatRegion(int code) : this(code, string.Empty) { }
        
    /// <summary>
    /// Код региона.
    /// </summary>
    public int Code
    { get { return this._code; } }
    
    /// <summary>
    /// Наименование.
    /// </summary>
    public string Caption
    { get { return this._caption; } }
    
    public static StatRegion Empty()
    {
        return new StatRegion(-1);
    }

    public static bool operator ==(StatRegion x, StatRegion y)
    {
        return x._code == y._code;
    }

    public static bool operator !=(StatRegion x, StatRegion y)
    {
        return x._code != y._code;
    }
    
    public static implicit operator int(StatRegion r)
    {
        return r._code;
    }

    public int ToInt()
    {
        return this._code;
    }

    public override string ToString()
    { return this._code.ToString(); }

    /// <summary>
    /// Сравнивает два заданных значения <paramref name="StatRegion"/> путем сопоставления наименований.
    /// </summary>
    /// <param name="r1">Объект типа <paramref name="StatRegion"/>.</param>
    /// <param name="r2">Объект типа <paramref name="StatRegion"/>.</param>
    public static int CaptionCompare(StatRegion r1, StatRegion r2)
    {
        return string.Compare(r1._caption.Trim(), r2._caption.Trim());
    }

    public int CaptionCompareTo(StatRegion other)
    {
        return StatRegion.CaptionCompare(this, other);
    }

    public int CaptionCompareTo(object obj)
    {
        if (obj is StatRegion)
        {
            StatRegion otherStatRegion = (StatRegion)obj;
            return StatRegion.CaptionCompare(this, otherStatRegion);
        }
        else { throw new ArgumentException("Объект не является StatRegion (регионом)."); }
    }

    /// <summary>
    /// Сравнивает два заданных значения <paramref name="StatRegion"/>
    /// </summary>
    /// <param name="r1">Объект типа <paramref name="StatRegion"/>.</param>
    /// <param name="r2">Объект типа <paramref name="StatRegion"/>.</param>
    public static int Compare(StatRegion r1, StatRegion r2)
    {
        return Decimal.Compare(r1._code, r2._code);
    }

    public int CompareTo(StatRegion other)
    {
        return StatRegion.Compare(this, other);
    }

    public int CompareTo(object obj)
    {
        if (obj is StatRegion)
        {
            StatRegion otherStatRegion = (StatRegion)obj;
            return StatRegion.Compare(this, otherStatRegion);
        }
        else { throw new ArgumentException("Объект не является StatRegion (регионом)."); }
    }

    /// <summary>
    /// Возвращает хеш-код данного экземпляра.
    /// </summary>
    public override int GetHashCode()
    {
        return this._code.GetHashCode();
    }

    /// <summary>
    /// Возвращает значение, позволяющее определить, представляют ли два заданных экземпляра <paramref name="StatRegion"/> равные значения.
    /// </summary>
    /// <param name="r1">Объект типа <paramref name="StatRegion"/>.</param>
    /// <param name="r2">Объект типа <paramref name="StatRegion"/>.</param>
    public static bool Equals(StatRegion r1, StatRegion r2)
    {
        return r1._code.Equals(r2._code);
    }

    /// <summary>
    /// Возвращает значение, позволяющее определить, представляют ли два заданных экземпляра <paramref name="StatRegion"/> равные значения.
    /// </summary>
    /// <param name="objA">Объект типа <paramref name="StatRegion"/>.</param>
    /// <param name="objB">Объект типа <paramref name="StatRegion"/>.</param>
    new public static bool Equals(Object objA, Object objB)
    {
        if (objA is StatRegion && objB is StatRegion)
        {
            StatRegion otherStatRegionA = (StatRegion)objA;
            StatRegion otherStatRegionB = (StatRegion)objB;
            return StatRegion.Equals(otherStatRegionA, otherStatRegionB);
        }
        else
        {
            if (objA is StatRegion)
            {
                throw new ArgumentException("Первый объект не является StatRegion (регионом).");
            }
            else { throw new ArgumentException("Второй объект не является StatRegion (регионом)."); }
        }
    }
    
    /// <summary>
    /// Возвращает значение, указывающее, равен ли данный экземпляр заданному значению типа <paramref name="StatRegion"/>.
    /// </summary>
    /// <param name="obj">Значение типа <paramref name="StatRegion"/> для сравнения с данным экземпляром.</param>
    public override bool Equals(Object obj)
    {
        if (obj is StatRegion)
        {
            StatRegion otherStatRegion = (StatRegion)obj;
            return StatRegion.Equals(this, otherStatRegion);
        }
        else { throw new ArgumentException("Объект не является StatRegion (регионом)."); }
    }
}

public interface IStatForm: System.IEquatable<IStatSection> 
{
    IStatSection this[int index] { get; }
    int Count { get; }
}

/// <summary>
/// Интерфейс раздела отчета.
/// </summary>
public interface IStatSection: IComparable, IComparable<IStatSection>
{
    int Index { get; }
    int RowCount { get; }
    int ColumnCount { get; }
}

/// <summary>
/// Раздел отчета.
/// </summary>
public struct StatSection: IStatSection
{
    private int _index;
    private int _rowCount;
    private int _columnCount;

    public StatSection(int index, int rowcount, int columncount)
    {
        this._index= index;
        this._rowCount = rowcount;
        this._columnCount = columncount;
    }

    public StatSection(int index) : this(index, 1, 1) { }

    /// <summary>
    /// Номер раздела (начиная с 0).
    /// </summary>
    public int Index
    { get { return this._index; } }

    /// <summary>
    /// Количество строк в разделе.
    /// </summary>
    public int RowCount
    { get { return this._rowCount; } }

    /// <summary>
    /// Количество граф в разделе.
    /// </summary>
    public int ColumnCount
    { get { return this._columnCount; } }
    
    public static StatSection Empty()
    {
        return new StatSection(-1,-1,-1);
    }

    public static bool operator ==(StatSection x, StatSection y)
    {
        return x._columnCount == y._columnCount && x._rowCount==y._rowCount;
    }

    public static bool operator !=(StatSection x, StatSection y)
    {
        return x._columnCount != y._columnCount || x._rowCount != y._rowCount;
    }

    public static implicit operator int(StatSection s)
    {
        return s._index;
    }

    public int ToInt()
    {
        return this._index;
    }

    public override string ToString()
    { return this._index.ToString(); }
    
    /// <summary>
    /// Сравнивает два заданных значения <paramref name="StatSection"/>
    /// </summary>
    /// <param name="s1">Объект типа <paramref name="IStatSection"/>.</param>
    /// <param name="s2">Объект типа <paramref name="IStatSection"/>.</param>
    public static int Compare(IStatSection s1, IStatSection s2)
    {
        return Decimal.Compare(s1.Index, s2.Index);
    }

    public int CompareTo(IStatSection other)
    {
        return StatSection.Compare(this, other);
    }

    public int CompareTo(object obj)
    {
        if (obj is IStatSection)
        {
            IStatSection otherStatSection = (IStatSection)obj;
            return StatSection.Compare(this, otherStatSection);
        }
        else { throw new ArgumentException("Объект не является IStatSection (разделом отчета)."); }
    }

    /// <summary>
    /// Возвращает хеш-код данного экземпляра.
    /// </summary>
    public override int GetHashCode()
    {
        return (this._index.ToString() + "-" + this._rowCount.ToString() + "-" + this._columnCount.ToString()).GetHashCode();
    }

    /// <summary>
    /// Возвращает значение, позволяющее определить, представляют ли два заданных экземпляра <paramref name="StatSection"/> равные значения.
    /// </summary>
    /// <param name="s1">Объект типа <paramref name="StatSection"/>.</param>
    /// <param name="s2">Объект типа <paramref name="StatSection"/>.</param>
    public static bool Equals(StatSection s1, StatSection s2)
    {
        return s1._index.Equals(s2._index) && s1._rowCount.Equals(s2._rowCount) && s1._columnCount.Equals(s2._columnCount);
    }

    /// <summary>
    /// Возвращает значение, позволяющее определить, представляют ли два заданных экземпляра <paramref name="StatSection"/> равные значения.
    /// </summary>
    /// <param name="objA">Объект типа <paramref name="StatSection"/>.</param>
    /// <param name="objB">Объект типа <paramref name="StatSection"/>.</param>
    new public static bool Equals(Object objA, Object objB)
    {
        if (objA is StatSection && objB is StatSection)
        {
            StatSection otherStatSectionA = (StatSection)objA;
            StatSection otherStatSectionB = (StatSection)objB;
            return StatSection.Equals(otherStatSectionA, otherStatSectionB);
        }
        else
        {
            if (objA is StatSection)
            {
                throw new ArgumentException("Первый объект не является StatSection (разделом отчета).");
            }
            else { throw new ArgumentException("Второй объект не является StatSection (разделом отчета)."); }
        }
    }

    /// <summary>
    /// Возвращает значение, указывающее, равен ли данный экземпляр заданному значению типа <paramref name="StatSection"/>.
    /// </summary>
    /// <param name="obj">Значение типа <paramref name="StatSection"/> для сравнения с данным экземпляром.</param>
    public override bool Equals(Object obj)
    {
        if (obj is StatSection)
        {
            StatSection otherStatSection = (StatSection)obj;
            return StatSection.Equals(this, otherStatSection);
        }
        else { throw new ArgumentException("Объект не является StatSection (разделом отчета)."); }
    }
}

public interface IStatData : IStatSection, IComparable<IStatSection>
{
    decimal this[int row, int column] { get; set; }
}

public struct StatData : IStatData 
{
    private int _index;
    private decimal[,] _data;
    private bool _isNull;

    public StatData(int index, decimal[,] data)
    {
        this._index = index;
        int rCount = data.Rank - 1;
        int cCount = data.GetLowerBound(0) - 1;
        this._data = new decimal[rCount, cCount];
        this._isNull = false;
        for (int r = 0; r < rCount; r++)
        {
            for (int c = 0; c < cCount; c++)
            {
                this._data[r, c] = data[r, c];
                if (this._data[r, c] != 0) { this._isNull = true; }
            }
        }
    }
    
    public StatData(int index, int rowcount, int columncount)
    {
        this._index = index;
        this._data = new decimal[rowcount - 1, columncount - 1];
        this._isNull = true;
    }

    public StatData(IStatSection section) : this(section.Index, section.RowCount, section.ColumnCount) { }

    public StatData(int index) : this(index, 1, 1) { }

    /// <summary>
    /// Копирование данных в двухмерный массив.
    /// </summary>
    /// <param name="data">Источник данных.</param>
    /// <param name="IsNull">Показатель нулевых данных.</param>
    private void Copy(decimal[,] source)
    {
        int rCount = source.Rank - 1;
        int cCount = source.GetLowerBound(0) - 1;
        this._data = new decimal[rCount, cCount];
        this._isNull = false;
        for (int r = 0; r < rCount; r++)
        {
            for (int c = 0; c < cCount; c++)
            {
                this._data[r, c] = source[r, c];
                if (this._data[r, c] != 0) { this._isNull = true; }
            }
        }
    }
    
    /// <summary>
    /// Номер раздела (начиная с 0).
    /// </summary>
    public int Index
    { get { return this._index; } }

    /// <summary>
    /// Количество строк в разделе.
    /// </summary>
    public int RowCount
    { get { return this._data.Rank - 1; } }

    /// <summary>
    /// Количество граф в разделе.
    /// </summary>
    public int ColumnCount
    { get { return this._data.GetLowerBound(0) - 1; } }

    public decimal this[int row, int column]
    {
        get
        {
            return this._data[row, column];
        }
        set
        {
            this._data[row, column] = value;
        }
    }

    public static StatData Empty()
    {
        return new StatData(-1);
    }

    public static bool operator ==(StatData x, StatData y)
    {
        if (x.ColumnCount == y.ColumnCount && x.RowCount == y.RowCount)
        {
            for (int r = 0; r < x.RowCount; r++)
            {
                for (int c = 0; c < x.ColumnCount; c++)
                {
                    if (x[r, c] != y[r, c]) { return false; }
                }
            }
            return true;
        }
        else { return false; }
    }

    public static bool operator !=(StatData x, StatData y)
    {
        if (x.ColumnCount != y.ColumnCount || x.RowCount != y.RowCount)
        {
            for (int r = 0; r < x.RowCount; r++)
            {
                for (int c = 0; c < x.ColumnCount; c++)
                {
                    if (x[r, c] == y[r, c]) { return false; }
                }
            }
            return true;
         }
        else { return true;}
    }

    public static StatData operator +(StatData x, StatData y)
    {
        if (x.ColumnCount == y.ColumnCount && x.RowCount == y.RowCount)
        {
            StatData result = new StatData();
            result._index = x._index;
            result._data = new decimal[x.RowCount, x.ColumnCount];
            result._isNull = false;

            for (int r = 0; r < x.RowCount; r++)
            {
                for (int c = 0; c < x.ColumnCount; c++)
                {
                   result[r,c]=  x[r, c] + y[r, c];
                   if (result[r, c] != 0) { result._isNull = true; }
                }
            }
            return result;
        }
        else { throw new ArgumentException("Количество граф или строк суммируемых объектов StatData не равны."); ; }
    }

    public static StatData operator -(StatData x, StatData y)
    {
        if (x.ColumnCount == y.ColumnCount && x.RowCount == y.RowCount)
        {
            StatData result = new StatData();
            result._index = x._index;
            result._data = new decimal[x.RowCount, x.ColumnCount];
            result._isNull = false;

            for (int r = 0; r < x.RowCount; r++)
            {
                for (int c = 0; c < x.ColumnCount; c++)
                {
                    result[r, c] = x[r, c] - y[r, c];
                    if (result[r, c] != 0) { result._isNull = true; }
                }
            }
            return result;
        }
        else { throw new ArgumentException("Количество граф или строк суммируемых объектов StatData не равны."); ; }
    }

    public static StatData operator *(StatData data, int value)
    {
        StatData result = new StatData();
        result._index = data._index;
        result._data = new decimal[data.RowCount, data.ColumnCount];
        result._isNull = false;
        for (int r = 0; r < data.RowCount; r++)
        {
            for (int c = 0; c < data.ColumnCount; c++)
            {
                result[r, c] = data[r, c] * value;
                if (result[r, c] != 0) { result._isNull = true; }
            }
        }
        return result;
    }

    public static StatData operator /(StatData data, int value)
    {
        StatData result = new StatData();
        result._index = data._index;
        result._data = new decimal[data.RowCount, data.ColumnCount];
        result._isNull = false;
        for (int r = 0; r < data.RowCount; r++)
        {
            for (int c = 0; c < data.ColumnCount; c++)
            {
                result[r, c] = data[r, c] / value;
                if (result[r, c] != 0) { result._isNull = true; }
            }
        }
        return result;
    }

    public static implicit operator int(StatData s)
    {
        return s.Index;
    }

    public int ToInt()
    {
        return this.Index;
    }

    public override string ToString()
    { return this.Index.ToString(); }

    /// <summary>
    /// Сравнивает два заданных значения <paramref name="StatSection"/>
    /// </summary>
    /// <param name="s1">Объект типа <paramref name="StatSection"/>.</param>
    /// <param name="s2">Объект типа <paramref name="StatSection"/>.</param>
    /// <returns></returns>
    public static int Compare(IStatSection s1, IStatSection s2)
    {
        return StatSection.Compare(s1, s2);
    }

    public int CompareTo(IStatSection other)
    {
        return StatData.Compare(this, other);
    }

    public int CompareTo(object obj)
    {
        if (obj is StatData)
        {
            StatData otherStatData = (StatData)obj;
            return StatData.Compare(this, otherStatData);
        }
        else { throw new ArgumentException("Объект не является StatData (разделом отчета)."); }
    }

    /// <summary>
    /// Возвращает хеш-код данного экземпляра.
    /// </summary>
    public override int GetHashCode()
    {
        return (this.Index.ToString() + "-" + this.RowCount.ToString() + "-" + this.ColumnCount.ToString()).GetHashCode();
    }

    /// <summary>
    /// Возвращает значение, позволяющее определить, представляют ли два заданных экземпляра <paramref name="StatData"/> равные значения.
    /// </summary>
    /// <param name="d1">Объект типа <paramref name="StatData"/>.</param>
    /// <param name="d2">Объект типа <paramref name="StatData"/>.</param>
    public static bool Equals(StatData d1, StatData d2)
    {
        return d1==d2;
    }

    /// <summary>
    /// Возвращает значение, позволяющее определить, представляют ли два заданных экземпляра <paramref name="StatData"/> равные значения.
    /// </summary>
    /// <param name="objA">Объект типа <paramref name="StatData"/>.</param>
    /// <param name="objB">Объект типа <paramref name="StatData"/>.</param>
    new public static bool Equals(Object objA, Object objB)
    {
        if (objA is StatData && objB is StatData)
        {
            StatData otherStatDataA = (StatData)objA;
            StatData otherStatDataB = (StatData)objB;
            return StatData.Equals(otherStatDataA, otherStatDataB);
        }
        else
        {
            if (objA is StatData)
            {
                throw new ArgumentException("Первый объект не является StatData (разделом отчета).");
            }
            else { throw new ArgumentException("Второй объект не является StatData (разделом отчета)."); }
        }
    }

    /// <summary>
    /// Возвращает значение, указывающее, равен ли данный экземпляр заданному значению типа <paramref name="StatData"/>.
    /// </summary>
    /// <param name="obj">Значение типа <paramref name="StatData"/> для сравнения с данным экземпляром.</param>
    public override bool Equals(Object obj)
    {
        if (obj is StatData)
        {
            StatData otherStatData = (StatData)obj;
            return StatData.Equals(this, otherStatData);
        }
        else { throw new ArgumentException("Объект не является StatData (разделом отчета)."); }
    }
}
