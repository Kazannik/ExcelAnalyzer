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
    public partial class ExcelAnalyzerPane : UserControl
    {
        Microsoft.Office.Interop.Excel.Application application;

        public ExcelAnalyzerPane(Microsoft.Office.Interop.Excel.Application app)
        {
            this.application = app;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
