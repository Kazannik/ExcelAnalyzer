using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcelAnalyzer.Arm
{
    public class RegionCollection : CollectionBase
    {
        public RegionCollection():base() {}

        private RegionCollection(RegionCollection collection, Period period) : base()
        {
            IEnumerable<Region> array = from Region R in collection where R.Start <= period && R.End >= period select R;
            foreach (Region  R in array)
            {
                base.List.Add(R);
            }
        }

        public RegionCollection Clone(Period period)
        {
            return new RegionCollection(collection: this, period: period);
        }

        public Region this[int index]
        {
            get { return (Region)base.List[index]; }
        }

        public int Add(Region item)
        {
            return base.List.Add(item);
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1062:ValidateArgumentsOfPublicMethods")]
        public void AddRange(RegionCollection items)
        {
            foreach (Region item in items)
            {
                this.Add(item);
            }
        }

        public int IndexOf(Region item)
        {
            return base.List.IndexOf(item);
        }

        public void Insert(int index, Region value)
        {
            base.List.Insert(index, value);
        }

        public void Remove(Region value)
        {
            base.List.Remove(value);
        }

        public bool Contains(Region value)
        {
            return base.List.Contains(value);
        }

        
        protected override void OnValidate(object value)
        {
            if (!typeof(Region).IsAssignableFrom(value.GetType()))
            {
                throw new ArgumentException("value не является типом Region.", "value");
            }
        }
    }
}
