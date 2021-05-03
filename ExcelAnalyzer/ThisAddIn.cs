using System;
using System.Windows.Forms;
using System.Diagnostics;
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
        public Microsoft.Office.Tools.CustomTaskPane ArmDataAnalyzerPane;

        public Microsoft.Office.Core.CommandBarButton AddSheetButton;
        public Microsoft.Office.Core.CommandBarButton SortSheetButton;

        private void ThisAddIn_Startup(object sender, System.EventArgs e)
        {
            #region ExcelAnalyzerPane

            Globals.Ribbons.ExcelAnalyzerRibbon.ExcelAnalyzerPane_ToggleButton.Checked = false;

            this.ExcelAnalyzerPane = CustomTaskPanes.Add(new ExcelAnalyzerPane(), ExcelAnalyzerConstants.AddInCaption);
            this.ExcelAnalyzerPane.DockPosition = Office.MsoCTPDockPosition.msoCTPDockPositionRight;
            this.ExcelAnalyzerPane.Width = 400;
            this.ExcelAnalyzerPane.Visible = Globals.Ribbons.ExcelAnalyzerRibbon.ExcelAnalyzerPane_ToggleButton.Checked;
            this.ExcelAnalyzerPane.VisibleChanged += new System.EventHandler(TaskPane_VisibleChanged);

            #endregion

            #region ArmDataAnalyzerPane

            Globals.Ribbons.ExcelAnalyzerRibbon.ArmDataAnalyzerPane_ToggleButton.Checked = false;
            Globals.Ribbons.ExcelAnalyzerRibbon.ArmDataRefresh_Button.Enabled = false;
            
            this.ArmDataAnalyzerPane = CustomTaskPanes.Add(new ArmDataAnalyzerPane(), ExcelAnalyzerConstants.ArmApplication);
            this.ArmDataAnalyzerPane.DockPosition = Office.MsoCTPDockPosition.msoCTPDockPositionBottom;
            this.ArmDataAnalyzerPane.Height = 160;
            this.ArmDataAnalyzerPane.Visible = Globals.Ribbons.ExcelAnalyzerRibbon.ExcelAnalyzerPane_ToggleButton.Checked;
            this.ArmDataAnalyzerPane.VisibleChanged += new System.EventHandler(TaskPane_VisibleChanged);

            #endregion
            

            Globals.ThisAddIn.Application.CommandBars["Ply"].Reset();
            Globals.ThisAddIn.Application.CommandBars["Ply"].Protection = Microsoft.Office.Core.MsoBarProtection.msoBarNoProtection;

            this.AddSheetButton = (Microsoft.Office.Core.CommandBarButton)Globals.ThisAddIn.Application.CommandBars["Ply"].Controls.Add(Type: Office.MsoControlType.msoControlButton, Before: 5);
            this.AddSheetButton.FaceId = ExcelAnalyzerConstants.AddSheet_Button_FaceId;
            this.AddSheetButton.Caption = ExcelAnalyzer.Properties.Resources.AddSheet_Button_Label;
            this.AddSheetButton.BeginGroup = true;
            //   this.AddButton.Enabled = StatAddIn.ConnectArm;
            this.AddSheetButton.Click += new Office._CommandBarButtonEvents_ClickEventHandler(AddButton_Click);

            this.SortSheetButton = (Microsoft.Office.Core.CommandBarButton)Globals.ThisAddIn.Application.CommandBars["Ply"].Controls.Add(Type: Office.MsoControlType.msoControlButton, Before: 6);
            this.SortSheetButton.FaceId = ExcelAnalyzerConstants.SortDialog_Button_FaceId;
            this.SortSheetButton.Caption = ExcelAnalyzer.Properties.Resources.SortDialog_Button_Label;
            this.SortSheetButton.Click += new Office._CommandBarButtonEvents_ClickEventHandler(SortButton_Click);

            int index = GetCommandBarButtonIndex(this.SortSheetButton);

            Globals.ThisAddIn.Application.CommandBars["Ply"].Controls[index].BeginGroup = true;
            Globals.ThisAddIn.Application.CommandBars["Ply"].Protection = Microsoft.Office.Core.MsoBarProtection.msoBarNoCustomize;

        }

        int GetCommandBarButtonIndex(Microsoft.Office.Core.CommandBarButton button)
        {
            for (int i = 1; i <= Globals.ThisAddIn.Application.CommandBars["Ply"].Controls.Count; i++)
            {
                if (Globals.ThisAddIn.Application.CommandBars["Ply"].Controls[i].Id == button.Id)
                {
                    return i;
                }
            }
            return -1;
        }

        void TaskPane_VisibleChanged(object sender, System.EventArgs e)
        {
            Microsoft.Office.Tools.CustomTaskPane pane;
            pane = (Microsoft.Office.Tools.CustomTaskPane)sender;
            if (pane.Title == ExcelAnalyzerConstants.AddInCaption)
            {
                Globals.Ribbons.ExcelAnalyzerRibbon.ExcelAnalyzerPane_ToggleButton.Checked = pane.Visible;
            }
            else if (pane.Title == ExcelAnalyzerConstants.ArmApplication)
            {
                Globals.Ribbons.ExcelAnalyzerRibbon.ArmDataAnalyzerPane_ToggleButton.Checked = pane.Visible;
                Globals.Ribbons.ExcelAnalyzerRibbon.ArmDataRefresh_Button.Enabled = pane.Visible;
                Globals.Ribbons.ExcelAnalyzerRibbon.WorkbookToolsSum_Button.Enabled = !pane.Visible;
                Globals.Ribbons.ExcelAnalyzerRibbon.WorkbookToolsInsertSheet_Button.Enabled = !pane.Visible;
                Globals.Ribbons.ExcelAnalyzerRibbon.WorkbookToolsInsertFormula_Button.Enabled = !pane.Visible;
                Globals.Ribbons.ExcelAnalyzerRibbon.WorkbookToolsInsertText_Button.Enabled = !pane.Visible;
                Globals.Ribbons.ExcelAnalyzerRibbon.WorkbookToolsCopyAndPaste_Button.Enabled = !pane.Visible;
                Globals.Ribbons.ExcelAnalyzerRibbon.button6.Enabled = !pane.Visible;
                Globals.Ribbons.ExcelAnalyzerRibbon.button7.Enabled = !pane.Visible;

            }
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


        public static void Show(object dialog)
        {
            Form form = (Form)dialog;
            NativeWindow mainWindow = new NativeWindow();
            mainWindow.AssignHandle(Process.GetCurrentProcess().MainWindowHandle);
            form.Show(mainWindow);
            mainWindow.ReleaseHandle();
        }
        
        public static DialogResult ShowDialog(object dialog)
        {
            Form form = (Form)dialog;
            NativeWindow mainWindow = new NativeWindow();
            mainWindow.AssignHandle(Process.GetCurrentProcess().MainWindowHandle);

            DialogResult DialogResult = form.ShowDialog(mainWindow);
            mainWindow.ReleaseHandle();
            return DialogResult;
        }
    

   // Public Shared Function ShowDialog(dialog As CheckedFileDialog, path As String) As System.Windows.Forms.DialogResult
   //     Dim mainWindow As NativeWindow = New NativeWindow()
     ///   mainWindow.AssignHandle(Process.GetCurrentProcess().MainWindowHandle)
      //  Dim DialogResult As System.Windows.Forms.DialogResult = dialog.ShowDialog(mainWindow, path)
       // mainWindow.ReleaseHandle()
       // Return DialogResult
    //End Function

    //Public Shared Function ShowDialog(dialog As SelectSheetDialog, ByVal ThisWorksheet As Boolean) As System.Windows.Forms.DialogResult
      //  Dim mainWindow As NativeWindow = New NativeWindow()
       // mainWindow.AssignHandle(Process.GetCurrentProcess().MainWindowHandle)
       // Dim DialogResult As System.Windows.Forms.DialogResult = dialog.ShowDialog(mainWindow, ThisWorksheet)
       // mainWindow.ReleaseHandle()
       // Return DialogResult
    //End Function

    //Public Shared Function ShowDialog(dialog As ValueEditDialog, ByVal value As String, ByVal sheetname As String, ByVal cellindex As String) As System.Windows.Forms.DialogResult
      //  Dim mainWindow As NativeWindow = New NativeWindow()
      //  mainWindow.AssignHandle(Process.GetCurrentProcess().MainWindowHandle)
      //  Dim DialogResult As System.Windows.Forms.DialogResult = dialog.ShowDialog(mainWindow, value, sheetname, cellindex)
      //  mainWindow.ReleaseHandle()
     //   Return DialogResult
    //End Function

    //Public Shared Function ShowDialog(dialog As ListFileDialog, ByVal promt As String, ByVal title As String, ByVal image As Drawing.Image, ByVal caption1 As String, ByVal array1() As Object, ByVal caption2 As String, ByVal array2() As Object) As System.Windows.Forms.DialogResult
    //    Dim mainWindow As NativeWindow = New NativeWindow()
    //    mainWindow.AssignHandle(Process.GetCurrentProcess().MainWindowHandle)
    //    Dim DialogResult As System.Windows.Forms.DialogResult = dialog.ShowDialog(owner:=mainWindow, promt:=promt, title:=title, image:=image, caption1:=caption1, array1:=array1, caption2:=caption2, array2:=array2)
    //    mainWindow.ReleaseHandle()
    //    Return DialogResult
    //End Function

    //Public Shared Function ShowDialog(dialog As ListFileDialog, ByVal promt As String, ByVal title As String, ByVal caption1 As String, ByVal array1() As Object, ByVal caption2 As String, ByVal array2() As Object) As System.Windows.Forms.DialogResult
    //    Dim mainWindow As NativeWindow = New NativeWindow()
    ///    mainWindow.AssignHandle(Process.GetCurrentProcess().MainWindowHandle)
     //   Dim DialogResult As System.Windows.Forms.DialogResult = dialog.ShowDialog(owner:=mainWindow, promt:=promt, title:=title, caption1:=caption1, array1:=array1, caption2:=caption2, array2:=array2)
     //   mainWindow.ReleaseHandle()
     //   Return DialogResult
    //End Function

    


    }
}
