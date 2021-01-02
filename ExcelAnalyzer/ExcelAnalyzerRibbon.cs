using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Office.Tools.Ribbon;

namespace ExcelAnalyzer
{
    public partial class ExcelAnalyzerRibbon
    {
        private void ExcelAnalyzerRibbon_Load(object sender, RibbonUIEventArgs e)
        {
            this.Tabs[0].Label = ExcelAnalyzer.ExcelAnalyzerConstants.AddInCaption;
        }

        private void ExcelAnalyzerPane_ToggleButton_Click(object sender, RibbonControlEventArgs e)
        {
            Globals.ThisAddIn.ExcelAnalyzerPane.Visible = Globals.Ribbons.ExcelAnalyzerRibbon.ExcelAnalyzerPane_ToggleButton.Checked;
        }
    }
}
