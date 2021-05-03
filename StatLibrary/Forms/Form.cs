using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StatLibrary.Forms
{
    public interface IForm: IEnumerable<ISection>
    {
        int Code { get; }
        string Caption { get; }
        StatContent Period { get; }
        ISection this[int index] { get; }
        int Count { get; }
    }

    public interface ISection: IStatSection, IRowCollection 
    {
        IRowCollection Rows { get; }
        IColumnCollection Columns { get; }
        ICell this[int row, int column] { get; }
    }

    public interface IRowCollection: IEnumerable <IRow> 
    {
        IRow this[int index] { get; }
        int Count { get; }
    }

    public interface IRow: ICellCollection
    {
    
    }

    public interface IColumnCollection: IEnumerable <IColumn>
    {
        IColumn this[int index] { get; }
        int Count { get; }
    }

    public interface IColumn: ICellCollection
    { 
    }

    public interface ICellCollection: IEnumerable<ICell>
    {
        ICell this[int index] { get; }
        int Count { get; }
    }

    public interface ICell
    { 
    }
    
    public class Form: IForm
    {
        public int Code
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        public string Caption
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        public StatContent Period
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        public ISection this[int index]
        {
            get
            {
                throw new System.NotImplementedException();
            }           
        }

        public int Count
        {
            get
            {
                throw new System.NotImplementedException();
            }
        }
        
        public IEnumerator<ISection> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
