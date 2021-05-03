using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcelAnalyzer.Arm
{
    public class FormCollection : CollectionBase, IEnumerable<Form>
    {
        public FormCollection() : base() { }

        private FormCollection(FormCollection collection, Period period) : base()
        {
            IEnumerable<Form> array = from Form F in collection where F.Start <= period && F.End >= period select F;
            foreach (Form F in array)
            {
                base.List.Add(F);
            }
        }

        public FormCollection Clone(Period period)
        {
            return new FormCollection(collection: this, period: period);
        }

        public Form this[int index]
        {
            get { return (Form)base.List[index]; }
        }
        
        public IEnumerable<Form> Forms(int code)
        {
            IEnumerable<Form> array = from Form F in this.List where F.Code == code select F;
            return array;
        }

        public IEnumerable<Form> Forms(Period period)
        {
            IEnumerable<Form> array = from Form F in this.List where F.Start <= period && F.End >= period select F;
            return array;
        }

        public IEnumerable<Form> Forms(int code, Period period)
        {
            IEnumerable<Form> array = from Form F in this.List where F.Code == code && F.Start <= period && F.End >= period select F;
            return array;
        }

        public int Add(Form item)
        {
            return base.List.Add(item);
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1062:ValidateArgumentsOfPublicMethods")]
        public void AddRange(FormCollection items)
        {
            foreach (Form item in items)
            {
                this.Add(item);
            }
        }

        public int IndexOf(Form item)
        {
            return base.List.IndexOf(item);
        }

        public void Insert(int index, Form value)
        {
            base.List.Insert(index, value);
        }

        public void Remove(Form value)
        {
            base.List.Remove(value);
        }

        public bool Contains(Form value)
        {
            return base.List.Contains(value);
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
