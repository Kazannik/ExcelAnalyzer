using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExcelAnalyzer.Panes
{
    public partial class ArmDataAnalyzerPane : UserControl
    {

        public ArmDataAnalyzerPane()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.regionComboBox1.Add(1, "Первая запись");
            this.regionComboBox1.Add(2, "Вторая запись");
            this.regionComboBox1.Add(3, "Третья запись");
        }

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {

        }
    }
}
