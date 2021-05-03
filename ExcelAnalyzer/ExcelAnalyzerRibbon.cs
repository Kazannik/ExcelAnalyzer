using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Office.Tools.Ribbon;
using System.Windows.Forms;

namespace ExcelAnalyzer
{
    public partial class ExcelAnalyzerRibbon
    {
        private void ExcelAnalyzerRibbon_Load(object sender, RibbonUIEventArgs e)
        {
            this.Tabs[0].Label = ExcelAnalyzerConstants.AddInCaption;

            Globals.Ribbons.ExcelAnalyzerRibbon.WorkbookTools_Group.Label = ExcelAnalyzerConstants.WorkbookTools;
            
            #region ExcelAnalyzerPane           

            Globals.Ribbons.ExcelAnalyzerRibbon.ExcelAnalyzerPane_Group.Label = ExcelAnalyzerConstants.AddInCaption;

            Globals.Ribbons.ExcelAnalyzerRibbon.ExcelAnalyzerPane_ToggleButton.Description = Properties.Resources.ExcelAnalyzerPane_Button_Description;
            Globals.Ribbons.ExcelAnalyzerRibbon.ExcelAnalyzerPane_ToggleButton.Label = Properties.Resources.ExcelAnalyzerPane_Button_Label;
            Globals.Ribbons.ExcelAnalyzerRibbon.ExcelAnalyzerPane_ToggleButton.ScreenTip = Properties.Resources.ExcelAnalyzerPane_Button_ScreenTip;
            Globals.Ribbons.ExcelAnalyzerRibbon.ExcelAnalyzerPane_ToggleButton.SuperTip = Properties.Resources.ExcelAnalyzerPane_Button_SuperTip;
            Globals.Ribbons.ExcelAnalyzerRibbon.ExcelAnalyzerPane_ToggleButton.OfficeImageId = ExcelAnalyzerConstants.ExcelAnalyzer_Button_OfficeImageId;

            Globals.Ribbons.ExcelAnalyzerRibbon.Help_Button.Description = Properties.Resources.Help_Button_Description;
            Globals.Ribbons.ExcelAnalyzerRibbon.Help_Button.Label = Properties.Resources.Help_Button_Label;
            Globals.Ribbons.ExcelAnalyzerRibbon.Help_Button.ScreenTip = Properties.Resources.Help_Button_ScreenTip;
            Globals.Ribbons.ExcelAnalyzerRibbon.Help_Button.SuperTip = Properties.Resources.Help_Button_SuperTip;
            Globals.Ribbons.ExcelAnalyzerRibbon.Help_Button.OfficeImageId = ExcelAnalyzerConstants.Help_Button_OfficeImageId;

            Globals.Ribbons.ExcelAnalyzerRibbon.About_Button.Description = Properties.Resources.About_Button_Description;
            Globals.Ribbons.ExcelAnalyzerRibbon.About_Button.Label = Properties.Resources.About_Button_Label;
            Globals.Ribbons.ExcelAnalyzerRibbon.About_Button.ScreenTip = Properties.Resources.About_Button_ScreenTip;
            Globals.Ribbons.ExcelAnalyzerRibbon.About_Button.SuperTip = Properties.Resources.About_Button_SuperTip;
            Globals.Ribbons.ExcelAnalyzerRibbon.About_Button.OfficeImageId = ExcelAnalyzerConstants.About_Button_OfficeImageId;

            #endregion

            #region ArmDataAnalyzerPane           

            Globals.Ribbons.ExcelAnalyzerRibbon.ArmDataAnalyzerPane_Group.Label = ExcelAnalyzerConstants.ArmApplication;

            Globals.Ribbons.ExcelAnalyzerRibbon.ArmDataAnalyzerPane_ToggleButton.Description = Properties.Resources.ArmDataAnalyzerPane_Button_Description;
            Globals.Ribbons.ExcelAnalyzerRibbon.ArmDataAnalyzerPane_ToggleButton.Label = Properties.Resources.ArmDataAnalyzerPane_Button_Label;
            Globals.Ribbons.ExcelAnalyzerRibbon.ArmDataAnalyzerPane_ToggleButton.ScreenTip = Properties.Resources.ArmDataAnalyzerPane_Button_ScreenTip;
            Globals.Ribbons.ExcelAnalyzerRibbon.ArmDataAnalyzerPane_ToggleButton.SuperTip = Properties.Resources.ArmDataAnalyzerPane_Button_SuperTip;
            //Globals.Ribbons.ExcelAnalyzerRibbon.ArmDataAnalyzerPane_ToggleButton.OfficeImageId = ExcelAnalyzerConstants.ExcelAnalyzer_Button_OfficeImageId;

            Globals.Ribbons.ExcelAnalyzerRibbon.ArmDataRefresh_Button.Description = Properties.Resources.ArmDataRefresh_Button_Description;
            Globals.Ribbons.ExcelAnalyzerRibbon.ArmDataRefresh_Button.Label = Properties.Resources.ArmDataRefresh_Button_Label;
            Globals.Ribbons.ExcelAnalyzerRibbon.ArmDataRefresh_Button.ScreenTip = Properties.Resources.ArmDataRefresh_Button_ScreenTip;
            Globals.Ribbons.ExcelAnalyzerRibbon.ArmDataRefresh_Button.SuperTip = Properties.Resources.ArmDataRefresh_Button_SuperTip;
            Globals.Ribbons.ExcelAnalyzerRibbon.ArmDataRefresh_Button.OfficeImageId = ExcelAnalyzerConstants.ArmDataRefresh_Button_OfficeImageId;

            #endregion

        }

        private void AnalyzerPane_ToggleButton_Click(object sender, RibbonControlEventArgs e)
        {
            RibbonToggleButton button = (RibbonToggleButton)sender;
            if (button.Id == Globals.Ribbons.ExcelAnalyzerRibbon.ExcelAnalyzerPane_ToggleButton.Id)
            {
                Globals.ThisAddIn.ExcelAnalyzerPane.Visible = Globals.Ribbons.ExcelAnalyzerRibbon.ExcelAnalyzerPane_ToggleButton.Checked;
            }
            else if (button.Id == Globals.Ribbons.ExcelAnalyzerRibbon.ArmDataAnalyzerPane_ToggleButton.Id)
            {
                Globals.ThisAddIn.ArmDataAnalyzerPane.Visible = Globals.Ribbons.ExcelAnalyzerRibbon.ArmDataAnalyzerPane_ToggleButton.Checked;
                Globals.Ribbons.ExcelAnalyzerRibbon.ArmDataRefresh_Button.Enabled = Globals.Ribbons.ExcelAnalyzerRibbon.ArmDataAnalyzerPane_ToggleButton.Checked;
                Globals.Ribbons.ExcelAnalyzerRibbon.WorkbookToolsSum_Button.Enabled = !Globals.Ribbons.ExcelAnalyzerRibbon.ArmDataAnalyzerPane_ToggleButton.Checked;
                Globals.Ribbons.ExcelAnalyzerRibbon.WorkbookToolsInsertSheet_Button.Enabled = !Globals.Ribbons.ExcelAnalyzerRibbon.ArmDataAnalyzerPane_ToggleButton.Checked;
                Globals.Ribbons.ExcelAnalyzerRibbon.WorkbookToolsInsertFormula_Button.Enabled = !Globals.Ribbons.ExcelAnalyzerRibbon.ArmDataAnalyzerPane_ToggleButton.Checked;
                Globals.Ribbons.ExcelAnalyzerRibbon.WorkbookToolsInsertText_Button.Enabled = !Globals.Ribbons.ExcelAnalyzerRibbon.ArmDataAnalyzerPane_ToggleButton.Checked;
                Globals.Ribbons.ExcelAnalyzerRibbon.WorkbookToolsCopyAndPaste_Button.Enabled = !Globals.Ribbons.ExcelAnalyzerRibbon.ArmDataAnalyzerPane_ToggleButton.Checked;
                Globals.Ribbons.ExcelAnalyzerRibbon.button6.Enabled = !Globals.Ribbons.ExcelAnalyzerRibbon.ArmDataAnalyzerPane_ToggleButton.Checked;
                Globals.Ribbons.ExcelAnalyzerRibbon.button7.Enabled = !Globals.Ribbons.ExcelAnalyzerRibbon.ArmDataAnalyzerPane_ToggleButton.Checked;
            }
        }

        private void ArmDataAnalyzerPane_ToggleButton_Click(object sender, RibbonControlEventArgs e)
        {

            if (Globals.Ribbons.ExcelAnalyzerRibbon.ArmDataAnalyzerPane_ToggleButton.Checked)
            {
                ExcelAnalyzer.Globals.ThisAddIn.Application.Workbooks.Close();
                ExcelAnalyzer.Globals.ThisAddIn.Application.Caption = ExcelAnalyzerConstants.ArmApplicationCaption;
            }

        }

        private void Help_Button_Click(System.Object sender, Microsoft.Office.Tools.Ribbon.RibbonControlEventArgs e)
        {
            if (System.IO.File.Exists(ExcelAnalyzerConstants.HelpFile))
            {
                Help.ShowHelp(null, ExcelAnalyzerConstants.HelpFile);
            }
            else
            {
                MessageBox.Show(@"Проверьте наличие файла справки: " + System.Environment.NewLine + ExcelAnalyzerConstants.HelpFile, "Справка " + Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void About_Button_Click(System.Object sender, Microsoft.Office.Tools.Ribbon.RibbonControlEventArgs e)
        {
            Dialogs.AboutDialog dialog;
            dialog = new Dialogs.AboutDialog();
            ThisAddIn.ShowDialog(dialog);
        }      
    }
}
