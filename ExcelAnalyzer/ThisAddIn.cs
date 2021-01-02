using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using Excel = Microsoft.Office.Interop.Excel;
using Office = Microsoft.Office.Core;
using Microsoft.Office.Tools.Excel;
using ExcelAnalyzer.Panes;

namespace ExcelAnalyzer
{
    public partial class ThisAddIn
    {

        public Microsoft.Office.Tools.CustomTaskPane ExcelAnalyzerPane;
        public Microsoft.Office.Core.CommandBarButton AddButton;
        public Microsoft.Office.Core.CommandBarButton SortButton;
        
        private void ThisAddIn_Startup(object sender, System.EventArgs e)
        {
            Globals.Ribbons.ExcelAnalyzerRibbon.ExcelAnalyzerPane_ToggleButton.Checked = false;

            this.ExcelAnalyzerPane = CustomTaskPanes.Add(new ExcelAnalyzerPane(Globals.ThisAddIn.Application), ExcelAnalyzerConstants.AddInCaption);
            this.ExcelAnalyzerPane.DockPosition = Office.MsoCTPDockPosition.msoCTPDockPositionFloating;
            this.ExcelAnalyzerPane.Height = 500;
            this.ExcelAnalyzerPane.DockPosition = Office.MsoCTPDockPosition.msoCTPDockPositionRight;
            this.ExcelAnalyzerPane.Width = 400;
            this.ExcelAnalyzerPane.Visible = Globals.Ribbons.ExcelAnalyzerRibbon.ExcelAnalyzerPane_ToggleButton.Checked;

            this.ExcelAnalyzerPane.VisibleChanged += new System.EventHandler(StatTaskPane_VisibleChanged);
            
            Globals.ThisAddIn.Application.CommandBars["Ply"].Reset();
            Globals.ThisAddIn.Application.CommandBars["Ply"].Protection = Microsoft.Office.Core.MsoBarProtection.msoBarNoProtection;

            this.AddButton =(Microsoft.Office.Core.CommandBarButton) Globals.ThisAddIn.Application.CommandBars["Ply"].Controls.Add(Type: Office.MsoControlType.msoControlButton, Before:5);
            this.AddButton.FaceId = ExcelAnalyzerConstants.AddSheet_Button_FaceId;
            this.AddButton.Caption = ExcelAnalyzer.Properties.Resources.AddSheet_Button_Label;
            this.AddButton.BeginGroup = true;
            //   this.AddButton.Enabled = StatAddIn.ConnectArm;
            this.AddButton.Click += new Office._CommandBarButtonEvents_ClickEventHandler(AddButton_Click);
            
            this.SortButton = (Microsoft.Office.Core.CommandBarButton)Globals.ThisAddIn.Application.CommandBars["Ply"].Controls.Add(Type:Office.MsoControlType.msoControlButton, Before:6);
            this.SortButton.FaceId =ExcelAnalyzerConstants.SortDialog_Button_FaceId;
            this.SortButton.Caption =ExcelAnalyzer.Properties.Resources.SortDialog_Button_Label;
            this.SortButton.Click += new Office._CommandBarButtonEvents_ClickEventHandler(SortButton_Click);

            int index = GetCommandBarButtonIndex(this.SortButton);

            Globals.ThisAddIn.Application.CommandBars["Ply"].Controls[index].BeginGroup = true;
            Globals.ThisAddIn.Application.CommandBars["Ply"].Protection = Microsoft.Office.Core.MsoBarProtection.msoBarNoCustomize;

        }

        int GetCommandBarButtonIndex(Microsoft.Office.Core.CommandBarButton button)
        {
            for (int i = 1; i <= Globals.ThisAddIn.Application.CommandBars["Ply"].Controls.Count; i++)
            {
                if (Globals.ThisAddIn.Application.CommandBars["Ply"].Controls[i].Id==button.Id)
                {
                    return i;
                }
            }
            return -1;
        }

        void StatTaskPane_VisibleChanged(object sender, System.EventArgs e)
        {
            Microsoft.Office.Tools.CustomTaskPane pane;
            pane = (Microsoft.Office.Tools.CustomTaskPane)sender;
            Globals.Ribbons.ExcelAnalyzerRibbon.ExcelAnalyzerPane_ToggleButton.Checked = pane.Visible;
        }

        void AddButton_Click(Microsoft.Office.Core.CommandBarButton Ctrl, ref bool CancelDefault)
        {
            //StatAddIn.CreateWorksheetsCollection()
        }
        
        void SortButton_Click(Microsoft.Office.Core.CommandBarButton Ctrl, ref bool CancelDefault)
        {
            //StatAddIn.SortWorksheets();
        }
        
        private void ThisAddIn_Shutdown(object sender, System.EventArgs e)
        {
        }

        #region Код, автоматически созданный VSTO

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InternalStartup()
        {
            this.Startup += new System.EventHandler(ThisAddIn_Startup);
            this.Shutdown += new System.EventHandler(ThisAddIn_Shutdown);
        }
        
        #endregion
    }
}
