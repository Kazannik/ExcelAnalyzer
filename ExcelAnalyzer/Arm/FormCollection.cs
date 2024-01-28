using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace ExcelAnalyzer.Arm
{
    public class FormCollection : CollectionBase, IEnumerable<Form>
    {
        public FormCollection() : base() { }

        private FormCollection(FormCollection collection, Period period) : base()
        {
            IEnumerable<Form> array = from Form F in collection
                                      where F.Begin <= period && F.End >= period
                                      select F;
            foreach (Form F in array)
            {
                List.Add(F);
            }
        }

        public FormCollection Clone(Period period)
        {
            return new FormCollection(collection: this, period: period);
        }

        public Form this[int index]
        {
            get { return (Form)List[index]; }
        }
        
        public IEnumerable<Form> Forms(int code)
        {
            IEnumerable<Form> array = from Form F in List
                                      where F.Code == code
                                      select F;
            return array;
        }

        public IEnumerable<Form> Forms(Period period)
        {
            IEnumerable<Form> array = from Form F in List
                                      where F.Begin <= period && F.End >= period
                                      select F;
            return array;
        }

        public IEnumerable<Form> Forms(int code, Period period)
        {
            IEnumerable<Form> array = from Form F in List
                                      where F.Code == code && F.Begin <= period && F.End >= period
                                      select F;
            return array;
        }

        public int Add(Form item)
        {
            return List.Add(item);
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1062:ValidateArgumentsOfPublicMethods")]
        public void AddRange(FormCollection items)
        {
            foreach (Form item in items)
            {
                Add(item);
            }
        }

        public int IndexOf(Form item)
        {
            return List.IndexOf(item);
        }

        public void Insert(int index, Form value)
        {
            List.Insert(index, value);
        }

        public void Remove(Form value)
        {
            List.Remove(value);
        }

        public bool Contains(Form value)
        {
            return List.Contains(value);
        }

        protected override void OnValidate(object value)
        {
            if (!typeof(Form).IsAssignableFrom(value.GetType()))
            {
                throw new ArgumentException("value не является типом Form.", "value");
            }
        }

        IEnumerator<Form> IEnumerable<Form>.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
