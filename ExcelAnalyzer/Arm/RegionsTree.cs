using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcelAnalyzer.Arm
{
    public class RegionsTree : CollectionBase
    {
        RegionCollection owner;

        public RegionsTree(RegionCollection owner) : base()
        {
            this.owner = owner;
        }

        public RegionsTreeItem this[int index]
        {
            get { return (RegionsTreeItem)base.List[index]; }
        }
                 
        public int Add(RegionsTreeItem item)
        {
            item.owner = this;
            return base.List.Add(item);
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1062:ValidateArgumentsOfPublicMethods")]
        public void AddRange(RegionCollection items)
        {
            foreach (RegionsTreeItem item in items)
            {
                item.owner = this;
                this.Add(item);
            }
        }

        public int IndexOf(RegionsTreeItem item)
        {
            return base.List.IndexOf(item);
        }

        public void Insert(int index, RegionsTreeItem value)
        {
            value.owner = this;
            base.List.Insert(index, value);
        }

        public void Remove(RegionsTreeItem value)
        {
            base.List.Remove(value);
        }

        public bool Contains(RegionsTreeItem value)
        {
            return base.List.Contains(value);
        }

        protected override void OnValidate(object value)
        {
            if (!typeof(RegionsTreeItem).IsAssignableFrom(value.GetType()))
            {
                throw new ArgumentException("value не является типом RegionsTreeItem.", "value");
            }
        }


        public class RegionsTreeItem: Region
        {
            internal RegionsTree owner;

            public RegionsTreeItem(RegionsTreeItem parent, Region region) : base(code: region.Code, caption: region.Caption)
            {
                this.Parent = parent;
            }

            public RegionsTreeItem(Region parent, Region region) : base(code: region.Code, caption: region.Caption)
            {
                foreach (RegionsTreeItem r in owner.List)
                {
                    if (r == parent)
                    {
                        this.Parent = r;
                    }
                }
            }

            public RegionsTreeItem(Region region):base(code: region.Code, caption: region.Caption)
            {
                this.Parent = null;
            }

            public RegionsTreeItem Parent { get; }

            public IEnumerable<RegionsTreeItem> Child
            {
                get
                {
                    return from RegionsTreeItem r in owner where r.Parent == this select r;
                }
            }
        }
    }
}
