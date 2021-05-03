using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace StatLibrary.Controls
{
    public partial class StatAdapter : Component
    {
        public StatAdapter()
        {
            InitializeComponent();
        }

        public StatAdapter(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }
    }
}
